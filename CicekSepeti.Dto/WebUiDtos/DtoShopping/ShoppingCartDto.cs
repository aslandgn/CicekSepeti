using System.Collections.Generic;

namespace CicekSepeti.Dto.WebUiDtos.DtoShopping
{
    public class ShoppingCartDto
    {
        public int userId { get; set; }

        public decimal total { get; set; }

        public List<ShoppingCartItemDto> products { get; set; }
    }
}
