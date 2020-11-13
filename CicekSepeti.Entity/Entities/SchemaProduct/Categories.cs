using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Entity.Entities.SchemaProduct
{
    public class Categories: BaseEntity<long>
    {
        public string NAME { get; set; }

        public int ORDER { get; set; }

        public long? ROOT_CATEGORY_ID { get; set; }

        public virtual Categories RootCategory { get; set; }
        public virtual IEnumerable<Categories> ChildCategories { get; set; }
        public virtual IEnumerable<Products> Products { get; set; }
    }
}
