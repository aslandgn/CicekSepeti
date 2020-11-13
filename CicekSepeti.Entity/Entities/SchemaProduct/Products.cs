namespace CicekSepeti.Entity.Entities.SchemaProduct
{
    public class Products: BaseEntity<long>
    {
        public string NAME { get; set; }

        public int ORDER { get; set; }

        public string PRODUCT_CODE { get; set; }

        public decimal PRICE { get; set; }

        public long CATEGORY_ID { get; set; }

        public Categories Category { get; set; }
    }
}
