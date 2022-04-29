
using EFCore.GenericRepository.Common.Application;
using EFCore.GenericRepository.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.CU.GenericRepository.Common.Persistence
{
    /// <inheritdoc>
    public class GenericRepository<TContext, T, TId> : IGenericRepository<TContext, T, TId>
                                                                                            where TContext : DbContext, IDisposable
                                                                                                where T : BaseEntity<TId>
    {
        private TContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        /// <inheritdoc>
        public void BulkInsert(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc>
        public Task BulkInsertAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                new ArgumentNullException(nameof(entity));
            }
            else
            {
                _dbSet.Add(entity);
            }
        }

        /// <inheritdoc>
        public async Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                new ArgumentNullException(nameof(entity));
            }
            else
            {
                await _dbSet.AddAsync(entity);
            }
        }
        /// <inheritdoc>
        public int SaveChanges() => _context.SaveChanges();
        /// <inheritdoc>
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        /// <inheritdoc>
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        /// <inheritdoc>
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        /// <inheritdoc>
        public void UpSert(Func<T, bool> where, T entity)
        {
            var obj = _dbSet.Where(where).LastOrDefault<T>();
            //  ÖNEMLİ.
            //Burada Update Icın Gelen obj Class ından Id yı entityToUpSert Icındekı Id Alanı Ile Eslestırmek Gerekıyor.
            if (obj != null)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbSet.Add(entity);
            }
        }
        /// <inheritdoc>
        public async Task UpSertAsync(Func<T, bool> where, T entity)
        {
            var obj1 = await _dbSet.ToListAsync();

            var obj = obj1.Where(where).LastOrDefault<T>();

            //  ÖNEMLİ.
            //Burada Update Icın Gelen obj Class ından Id yı entityToUpSert Icındekı Id Alanı Ile Eslestırmek Gerekıyor.
            if (obj != null)
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                await _dbSet.AddAsync(entity);

            }
        }
        /// <inheritdoc>
        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}