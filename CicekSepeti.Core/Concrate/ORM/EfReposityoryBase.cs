using CicekSepeti.Core.Abstract;
using CicekSepeti.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CicekSepeti.Core.Concrate.ORM
{
    public class EfReposityoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
