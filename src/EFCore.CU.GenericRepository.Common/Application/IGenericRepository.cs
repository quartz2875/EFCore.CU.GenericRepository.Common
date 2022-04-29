
using EFCore.GenericRepository.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.GenericRepository.Common.Application
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
        void BulkInsert(IEnumerable<T> entities);
        /// <summary>
        ///   Used to add a collection asynchronously.
        /// </summary>
        /// <param name="entity">
        ///    A <see cref="IEnumerable<T>"/> represents the Generic IEnumerable Entity to be registered.
        /// </param>
        Task BulkInsertAsync(IEnumerable<T> entities);

        /// <summary>
        ///  Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// A <see cref="int"/> Freezes the total affected record information.
        /// </returns>

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