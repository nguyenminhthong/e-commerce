using Microsoft.EntityFrameworkCore;
using Net.Core;
using Net.Core.Caching;
using Net.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Data.Repository
{
    internal class ReadRepository<TEntity> : BaseRepository<TEntity>, IReadRepository<TEntity> where TEntity : BaseEntity
    {
        #region Ctor
        public ReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
        #endregion

        #region Properties
        public IQueryable<TEntity> Table => Entities.AsNoTracking();
        #endregion

        #region Method

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func, bool includeDeleted = false)
        {
            var query = IncludeDetedFilter(Table, includeDeleted);

            query = func != null ? func(query) : query;

            return await query.ToListAsync();
        }

        public async Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func, int pageNumber, int pageSize, bool includeDeleted = false)
        {
            var query = IncludeDetedFilter(Table, includeDeleted);

            query = func != null ? func(query) : query;

            return await query.ToPageListAsync(pageNumber, pageSize);
        }

        public async Task<TEntity> GetByIdAsync(int? id)
        {
            return await Table.Where(x => x.Id == id).FirstAsync();
        }
        #endregion

        #region Private

        private IQueryable<TEntity> IncludeDetedFilter(IQueryable<TEntity> query, in bool includeDeleted)
        {
            if (includeDeleted) return query;

            if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) == null)
                return query;

            return query.OfType<ISoftDeletedEntity>().Where(entry => entry.IsDeleted).OfType<TEntity>();
        }

        private async Task<IEnumerable<TEntity>> GetEntitiesAsync(Func<Task<IEnumerable<TEntity>>> fncGetAllAsync, Func<IStaticCacheManager, CacheKey> getCacheKey)
        {
            if (getCacheKey == null)
                return await fncGetAllAsync();

            return await fncGetAllAsync();
        }

        #endregion
    }
}
