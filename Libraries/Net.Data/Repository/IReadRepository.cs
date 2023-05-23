using Net.Core;
using Net.Core.Caching;

namespace Net.Data.Repository
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        #endregion

        #region Method

        Task<TEntity> GetByIdAsync(int? id, Func<IStaticCacheManager, CacheKey>? getCacheKey = null, bool includeDeleted = true);

        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func, bool includeDeleted = false);

        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func, int pageNumber, int pageSize, bool includeDelted = false);
        #endregion
    }
}
