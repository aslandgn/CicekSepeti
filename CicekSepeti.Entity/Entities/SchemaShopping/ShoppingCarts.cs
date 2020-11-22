using CicekSepeti.Entity.Entities.SchemaUser;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Entity.Entities.SchemaShopping
{
    [Table("ShoppingCarts",Schema ="SHOPPING")]
    public class ShoppingCarts: BaseEntity<long>
    {
        public int User_Id { get; set; }

        public virtual Users User { get; set; }

        public virtual IEnumerable<ShoppingCartItems> ShoppingCartItems { get; set; }
    }
}
