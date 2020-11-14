namespace CicekSepeti.Dto.WebUiDtos.DtoProduct
{
    public class CategoryDto
    {
        public long id { get; set; }
        public string categoryName { get; set; }
        public long? rootCategoryId { get; set; }
        public string rootCategoryName { get; set; }
        public bool status { get; set; }
    }
}
