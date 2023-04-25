using Net.Core;
using Net.Event.Events;

namespace Net.Data.Repository
{
    internal class CRUDRepository<TEntity> : BaseRepository<TEntity>, ICRUDRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields
        private readonly IEventPublisher? _eventPublisher;
        #endregion

        #region Ctor
        public CRUDRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
        #endregion

        #region Method
        
        /// <summary>
        /// Insert the entityentry
        /// </summary>
        /// <param name="entity">POJO</param>
        /// <param name="publishEvent">Flag publish</param>
        /// <returns></returns>
        public async Task CreateAsync(TEntity entity, bool publishEvent = false)
        {
            await Entities.AddAsync(entity);

            if (publishEvent )
            {
                await Task.CompletedTask;
            }
        }

        /// <summary>
        /// Remove Entity entry
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="publishEvent"></param>
        /// <returns></returns>
        public async Task DeleteAsync(TEntity entity, bool publishEvent = false)
        {
            Entities.Remove(entity);

            if (publishEvent)
            {
                await Task.CompletedTask;
            }
        }

        /// <summary>
        /// Merge the Entity Entry
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="publishEvent"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity, bool publishEvent = false)
        {
            Entities.Update(entity);

            if (publishEvent)
            {
                await Task.CompletedTask;
            }
        } 
        #endregion
    }
}
