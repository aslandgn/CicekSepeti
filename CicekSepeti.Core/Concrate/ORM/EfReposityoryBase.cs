using CicekSepeti.Core.Abstract;
using CicekSepeti.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Core.Concrate.ORM
{
    public class EfReposityoryBase<T> : IRepositoryBase<T> where T : class, IEntity, new()
    {
        public DbContext dbContext { get; set; }

        public async Task<T> Add(T entity)
        {
            var addEntity = dbContext.Entry(entity);
            addEntity.State = EntityState.Added;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async void Delete(T entity)
        {
            var addEntity = dbContext.Entry(entity);
            addEntity.State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
        }

        public Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? dbContext.Set<T>().ToListAsync() : dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            var addEntity = dbContext.Entry(entity);
            addEntity.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
