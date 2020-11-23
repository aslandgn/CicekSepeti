namespace CicekSepeti.Dto.WebUiDtos.DtoShopping
{
    public class ShoppingCartItemDto
    {
        public long? cartId { get; set; }
        public long productId { get; set; }
        public short quantity { get; set; }
        public string productName { get; set; }

    }
}
