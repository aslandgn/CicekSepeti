using CicekSepeti.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Services
{
    public interface IServiceBase<T> where T : class, IEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        void Delete(T entity);

        /// <summary>
        /// sistem üzerinde hard delete yapmamak istenmemesi durumunda soft delete
        /// yapmak için üretildi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateDelete(T entity);
    }
}
