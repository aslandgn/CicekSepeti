using CicekSepeti.Business.Abstract.Services;
using CicekSepeti.Core.Abstract;
using CicekSepeti.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Business.Concrate.Services
{
    public abstract class ManagerBaseWoPrimary<T, TDal> : IServiceBaseWoPrimary<T> where T : class, IEntity, new() where TDal : IRepositoryBase<T>
    {
        protected internal TDal _manager;
        public async Task<T> Add(T entity)
        {
            return await _manager.Add(entity);
        }

        public async Task<List<T>> Add(List<T> entityList)
        {
            return await _manager.Add(entityList);
        }

        public void Delete(T entity)
        {
            _manager.Delete(entity);
        }

        public void Delete(List<T> entityList)
        {
            _manager.Delete(entityList);
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

        public async Task<List<T>> Update(List<T> entityList)
        {
            return await _manager.Update(entityList);
        }
    }
}
