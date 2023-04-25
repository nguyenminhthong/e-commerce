using Net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Data.Repository
{
    public interface ICRUDableRepository<TEntity> where TEntity : BaseEntity
    {
        public Task CreateAsync(TEntity entity, bool publishEvent = true);

        public Task UpdateAsync(TEntity entity, bool publishEvent = true);

        public Task DeleteAsync(TEntity entity, bool publishEvent = true);

    }
}
