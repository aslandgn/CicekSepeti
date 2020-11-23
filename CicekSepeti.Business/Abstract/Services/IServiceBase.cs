using CicekSepeti.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Abstract.Services
{
    public interface IServiceBase<T> where T : class, IEntity, new()
    {
        Task<T> Add(T entity);
        Task<List<T>> Add(List<T> entityList);
        Task<T> Update(T entity);
        Task<List<T>> Update(List<T> entityList);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        void Delete(T entity);
        void Delete(List<T> entityList);

        /// <summary>
        /// sistem üzerinde hard delete yapmamak istenmemesi durumunda soft delete
        /// yapmak için üretildi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateDelete(T entity);
    }
}
