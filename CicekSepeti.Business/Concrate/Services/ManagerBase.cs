using CicekSepeti.Business.Abstract.Services;
using CicekSepeti.Core.Abstract;
using CicekSepeti.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Services
{
    public abstract class ManagerBase<T, Type, TDal> : IServiceBase<T> where T : BaseEntity<Type>, new() where TDal : IRepositoryBase<T> where Type : IComparable
    {
        protected internal TDal _manager;
        public async Task<T> Add(T entity)
        {
            return await _manager.Add(entity);
        }

        public void Delete(T entity)
        {
            _manager.Delete(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _manager.Get(filter);
        }

        public async Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            return await _manager.GetList(filter);
        }

        public async Task<T> Update(T entity)
        {
            return await _manager.Update(entity);
        }

        public async Task<T> UpdateDelete(T entity)
        {
            entity.Is_Deleted = true;
            return await _manager.Update(entity);
        }
    }
}
