using CicekSepeti.Core.Abstract;
using CicekSepeti.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public async Task<List<T>> Add(List<T> entityList)
        {
            var addEntity = dbContext.Entry(entityList);
            addEntity.State = EntityState.Added;
            await dbContext.SaveChangesAsync();
            return entityList;
        }

        public void Delete(T entity)
        {
            var addEntity = dbContext.Entry(entity);
            addEntity.State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Delete(List<T> entityList)
        {
            dbContext.Set<T>().RemoveRange(entityList);
            dbContext.SaveChanges();
        }

        public Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return dbContext.Set<T>().Where(filter).SingleOrDefaultAsync();
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? dbContext.Set<T>().ToListAsync() : dbContext.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            var updEntity = dbContext.Entry(entity);
            updEntity.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<List<T>> Update(List<T> entityList)
        {
            dbContext.Set<T>().UpdateRange(entityList);
            await dbContext.SaveChangesAsync();
            return entityList;
        }

        public async Task<List<T>> GetList(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes, Expression<Func<T, bool>> filter = null)
        {
            return await (filter == null ? includes(dbContext.Set<T>()).ToListAsync() : includes(dbContext.Set<T>()).Where(filter).ToListAsync());
        }
    }
}
