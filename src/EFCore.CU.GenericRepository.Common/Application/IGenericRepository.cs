
/*
** BurakQuartz v1.0.0 ()
** Copyright © 2022 BurakQuartz. All rights reserved.
*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.CU.GenericRepository.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.CU.GenericRepository.Common.Application
{
    public interface IGenericRepository<TContext, T, TId>
        where TContext : DbContext
        where T : BaseEntity<TId>
    {

        /// <summary>
        ///   It is used to create a record in the database.
        /// </summary>
        /// <param name="entity">
        ///    A <see cref="T"/> represents the Generic Entity to be registered.
        /// </param>
        void Insert(T entity);
        /// <summary>
        ///    It is used to create a record in the database asynchronously.
        /// </summary>
        /// <param name="entity">
        ///    A <see cref="T"/> represents the Generic Entity to be registered.
        /// </param>
        Task InsertAsync(T entity);


        /// <summary>
        ///    It is used to  update a record in the database.
        /// </summary>
        /// <param name="entity">
        ///    A <see cref="T"/> represents the Generic Entity to be registered.
        /// </param>
        void Update(T entity);
        /// <summary>
        ///    It is used to asynchronously update a record in the database.
        /// </summary>
        /// <param name="entity">
        ///    A <see cref="T"/> represents the Generic Entity to be registered.
        /// </param>
        Task UpdateAsync(T entity);

        /// <summary>
        ///    It is used to update a record in the database or add a new record.
        /// </summary>
        /// <param name="predicate">
        ///    A <see cref="Func<T, bool>"/> The condition to use for filtering the array content.
        /// </param>
        /// <param name="entity">
        ///    A <see cref="T"/> represents the Generic Entity to be registered.
        /// </param>
        void UpSert(Func<T, bool> predicate, T entity);
        /// <summary>
        ///    It is used to asynchronously update a record in the database or add a new record.
        /// </summary>
        /// <param name="predicate">
        ///    A <see cref="Func<T, bool>"/> The condition to use for filtering the array content.
        /// </param>
        /// <param name="entity">
        ///    A <see cref="T"/> represents the Generic Entity to be registered.
        /// </param>
        Task UpSertAsync(Func<T, bool> predicate, T entity);

        /// <summary>
        ///    It is used to insert a collection in bulk.
        /// </summary>
        /// <param name="entity">
        ///    A <see cref="IEnumerable<T>"/> represents the Generic IEnumerable Entity to be registered.
        /// </param>

        int SaveChanges();
        /// <summary>
        ///  Saves all changes made in this context to the underlying database asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="int"/> Freezes the total affected record information.
        /// </returns>
        Task<int> SaveChangesAsync();

    }
}