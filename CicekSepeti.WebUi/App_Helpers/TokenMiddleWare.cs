using CicekSepeti.Business.Concrate.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.WebUi.App_Helpers
{
    public class TokenCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public TokenCheckMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var key = httpContext.Request.Headers.Keys.Contains("Authorization");
            var path = httpContext.Request.Path.Value.ToLower();
            if (path.StartsWith("/api/"))
            {
                if (path == "/api/user/login")
                {
                    await _next.Invoke(httpContext);
                    return;
                }
                if (!key)
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await httpContext.Response.WriteAsync("Missing token!!!");
                    return;
                }
                else
                {
                    try
                    {
                        var bearerToken = httpContext.Request.Headers["Authorization"].ToString();
                        var token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
                        var secretKey = Encoding.ASCII.GetBytes(_appSettings.Secret);


                        SecurityToken securityToken;
                        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                        TokenValidationParameters validationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            LifetimeValidator = this.LifetimeValidator
                        };
                        httpContext.User = handler.ValidateToken(token, validationParameters, out securityToken);
                    }
                    catch (Exception)
                    {
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        await httpContext.Response.WriteAsync("Invalid Token!!!");
                        return;
                    }
                }
            }
            await _next.Invoke(httpContext);
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
