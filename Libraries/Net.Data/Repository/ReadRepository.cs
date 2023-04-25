using Microsoft.EntityFrameworkCore;
using Net.Core;
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

        public IQueryable<TEntity> Table => Entities.AsNoTracking();
        #endregion
    }
}
