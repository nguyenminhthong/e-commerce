using Microsoft.EntityFrameworkCore.Storage;
using Net.Core;
using Net.Data.Repository;

namespace Net.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;
       

        private AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task BeginAsync()
        {
            _transaction = await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _appDbContext.SaveChangesAsync();

                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                if (_transaction != null)
                {
                    await RollbackAsync();
                }
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }


        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }


        public ICRUDableRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            return new CRUDableRepository<TEntity>(_appDbContext);
        }
    }
}
