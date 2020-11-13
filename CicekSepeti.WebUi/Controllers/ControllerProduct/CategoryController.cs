using CicekSepeti.Business.Abstract.Helpers.HelperProduct;
using CicekSepeti.Dto.WebUiDtos.DtoProduct;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.WebUi.Controllers.ControllerProduct
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region services 
        private readonly ICategoryHelper _categoryHelper;
        #endregion
        public CategoryController(ICategoryHelper categoryHelper)
        {
            _categoryHelper = categoryHelper;

        }
        // GET: api/Category
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            try
            {
                return await _categoryHelper.GetActives();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
