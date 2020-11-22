namespace CicekSepeti.Dto.WebUiDtos.DtoShopping
{
    public class ShoppingCartItemModel
    {
        public long? cartId { get; set; }
        public long productId { get; set; }
        public int quantity { get; set; }
    }
}
