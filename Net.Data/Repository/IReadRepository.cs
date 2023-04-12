using Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Net.Data.Repository
{
    internal interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        #region Properties

        public IQueryable<TEntity> Table { get; }

        public IQueryable<TEntity> TableNoTracking { get; }

        #endregion


        public Task<TEntity> GetByIdAsync<TKey>(TKey Id);

        public Task<IEnumerable<TEntity>> QueryableListAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}
