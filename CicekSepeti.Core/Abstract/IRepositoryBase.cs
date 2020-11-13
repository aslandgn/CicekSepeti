﻿using CicekSepeti.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CicekSepeti.Core.Abstract
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        /// <summary>
        /// yeni bir nesne ekleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Add(T entity);

        /// <summary>
        /// varolan bir nesneyi güncelleme
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Update(T entity);

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
        Task<T> Get(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// bir nesne listesi getirme
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
    }
}
