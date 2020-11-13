using AutoMapper;
using CicekSepeti.Business.Abstract.Helpers.HelperProduct;
using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.Dto.WebUiDtos.DtoProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Helpers.HelperProduct
{
    public class CategoryHelper : ICategoryHelper
    {
        #region services
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        #endregion
        public CategoryHelper(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<CategoryDto> Add(CategoryDto categoryDto)
        {
            try
            {
                var entity = _mapper.Map<CategoryDto, Categories>(categoryDto);
                var result = await _categoryService.Add(entity);
                if (result == null)
                {
                    throw new Exception("can not add the item.");
                }
                categoryDto.id = result.Id;
                return categoryDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CategoryDto> Update(CategoryDto categoryDto)
        {
            try
            {
                var entity = await _categoryService.Get(x => x.Id == categoryDto.id);
                if (entity == null)
                {
                    throw new Exception("can not find the object to update");
                }
                var changedEntity = _mapper.Map(categoryDto, entity);
                var result = await _categoryService.Update(changedEntity);
                return categoryDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CategoryDto> UpdateDelete(CategoryDto categoryDto)
        {
            try
            {
                var entity = await _categoryService.Get(x => x.Id == categoryDto.id);
                if (entity == null)
                {
                    throw new Exception("can not find the element to delete");
                }
                var result = await _categoryService.UpdateDelete(entity);
                return categoryDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                var entity = await _categoryService.Get(x => x.Id == id);
                if (entity == null)
                {
                    throw new Exception("can not find the element to delete");
                }
                _categoryService.Delete(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetActives()
        {
            try
            {
                var result = await _categoryService.GetList(x => x.Status && !x.Is_Deleted);
                if (result == null)
                {
                    throw new Exception("something went wrong");
                }
                return _mapper.Map<List<Categories>, List<CategoryDto>>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CategoryDto> GetOne(long id)
        {
            try
            {
                var result = await _categoryService.Get(x => x.Id == id);
                if (result == null)
                {
                    throw new Exception("Can not found any element");
                }
                return _mapper.Map<Categories,CategoryDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
