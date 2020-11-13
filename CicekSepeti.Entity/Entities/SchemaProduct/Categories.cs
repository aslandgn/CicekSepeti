using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CicekSepeti.Entity.Entities.SchemaProduct
{
    [Table("Categories", Schema = "PRODUCT")]
    public class Categories : BaseEntity<long>
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public long? Root_Category_Id { get; set; }

        public virtual Categories RootCategory { get; set; }
        public virtual IEnumerable<Categories> ChildCategories { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
    }
}
