using AutoMapper;
using CicekSepeti.Business.Abstract.Helpers.HelperProduct;
using CicekSepeti.Business.Abstract.Services.ServiceProduct;
using CicekSepeti.Dto.WebUiDtos.DtoProduct;
using CicekSepeti.Entity.Entities.SchemaProduct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Helpers.HelperProduct
{
    public class ProductHelper : IProductHelper
    {
        #region services
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        #endregion
        public ProductHelper(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<ProductDto> Add(ProductDto productDto)
        {
            try
            {
                var entity = _mapper.Map<ProductDto, Products>(productDto);
                var result = await _productService.Add(entity);
                if (result == null)
                {
                    throw new Exception("can not add the item.");
                }
                productDto.id = result.Id;
                return productDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductDto> Update(ProductDto productDto)
        {
            try
            {
                var entity = await _productService.Get(x => x.Id == productDto.id);
                if (entity == null)
                {
                    throw new Exception("can not find the object to update");
                }
                var changedEntity = _mapper.Map(productDto, entity);
                var result = await _productService.Update(changedEntity);
                return productDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductDto> UpdateDelete(ProductDto productDto)
        {
            try
            {
                var entity = await _productService.Get(x => x.Id == productDto.id);
                if (entity == null)
                {
                    throw new Exception("can not find the element to delete");
                }
                var result = await _productService.UpdateDelete(entity);
                return productDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(ProductDto productDto)
        {
            try
            {
                var entity = await _productService.Get(x => x.Id == productDto.id);
                if (entity == null)
                {
                    throw new Exception("can not find the element to delete");
                }
                _productService.Delete(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetActives()
        {
            try
            {
                var result = await _productService.GetList(x => x.Status && !x.Is_Deleted);
                if (result == null)
                {
                    throw new Exception("something went wrong");
                }
                return _mapper.Map<List<Products>, List<ProductDto>>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductDto> GetOne(long id)
        {
            try
            {
                var result = await _productService.Get(x => x.Id == id);
                if (result == null)
                {
                    throw new Exception("Can not found any element");
                }
                return _mapper.Map<Products, ProductDto>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
