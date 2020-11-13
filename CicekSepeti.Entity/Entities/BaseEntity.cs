using CicekSepeti.Core.Entity;
using System;

namespace CicekSepeti.Entity.Entities
{
    public abstract class BaseEntity<Type>:IEntity where Type: IComparable
    {
        public Type ID { get; set; }

        public bool STATUS { get; set; }

        public bool IS_DELETED { get; set; }
    }
}
