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
        public async Task<CategoryDto> Get(long id)
        {
            try
            {
                return await _categoryHelper.GetOne(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/Category
        [HttpPost]
        public async Task<CategoryDto> Post(CategoryDto categoryDto)
        {
            try
            {
                return await _categoryHelper.Add(categoryDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<CategoryDto> Put(long id,[FromBody]CategoryDto categoryDto)
        {
            try
            {
                return await _categoryHelper.Update(categoryDto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(long id)
        {
            try
            {
                await _categoryHelper.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
