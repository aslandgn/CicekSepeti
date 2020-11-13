using CicekSepeti.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CicekSepeti.Core.Abstract
{
    public interface IRepositoryBase<T> where T: class,IEntity
    {
        /// <summary>
        /// yeni bir nesne ekleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// varolan bir nesneyi güncelleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// varolan bir nesneyi silme
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// bir nesneyi getirme
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// bir nesne listesi getirme
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IEnumerable<T> GetList(Expression<Func<T,bool>> filter = null);
    }
}
