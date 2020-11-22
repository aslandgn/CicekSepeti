using CicekSepeti.Entity.Entities.SchemaShopping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Entity.Entities.SchemaUser
{
    [Table("Users",Schema ="USER")]
    public class Users: BaseEntity<int>
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string Password { get; set; }

        public virtual IEnumerable<ShoppingCarts> ShoppingCarts { get; set; }

    }
}
