using CicekSepeti.Dto.WebUiDtos.DtoProduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Helpers.HelperProduct
{
    public interface ICategoryHelper
    {
        Task<CategoryDto> Add(CategoryDto categoryDto);

        Task<CategoryDto> Update(CategoryDto categoryDto);

        Task<CategoryDto> UpdateDelete(CategoryDto categoryDto);

        Task Delete(CategoryDto categoryDto);

        Task<IEnumerable<CategoryDto>> GetActives();

        Task<CategoryDto> GetOne(long id);
    }
}
