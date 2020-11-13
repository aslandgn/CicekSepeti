using CicekSepeti.Core.Entity;
using System;

namespace CicekSepeti.Entity.Entities
{
    public abstract class BaseEntity<Type>:IEntity where Type: IComparable
    {
        public Type Id { get; set; }

        public bool Status { get; set; }

        public bool Is_Deleted { get; set; }
    }
}
