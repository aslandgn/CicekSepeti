using CicekSepeti.Core.Entity;
using CicekSepeti.Entity.Entities.SchemaProduct;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Entity.Entities.SchemaShopping
{
    [Table("ShoppingCartItem",Schema ="SHOPPING")]
    public class ShoppingCartItems : IEntity
    {
        public long ShoppingCart_Id { get; set; }

        public long Product_Id { get; set; }

        public short Quantity { get; set; }

        public virtual ShoppingCarts ShoppingCart { get; set; }

        public virtual Products Product { get; set; }
    }
}
