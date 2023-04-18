using Net.Core;
using Net.Data.Repository;

namespace Net.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task BeginAsync();

        public Task CommitAsync();

        public Task RollbackAsync();

        public ICRUDableRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    }
}
