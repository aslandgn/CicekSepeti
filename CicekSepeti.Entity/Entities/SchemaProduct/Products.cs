using CicekSepeti.Entity.Entities.SchemaShopping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Entity.Entities.SchemaProduct
{
    [Table("Products", Schema = "PRODUCT")]
    public class Products : BaseEntity<long>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public string Product_Code { get; set; }

        public decimal Price { get; set; }

        public int InStock { get; set; }

        public long Category_Id { get; set; }

        public Categories Category { get; set; }
        public IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}
