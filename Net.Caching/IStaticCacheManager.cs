using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Caching
{
    public interface IStaticCacheManager
    {
        Task<T> GetAsync<T>(CacheKey key, Func<Task<T>> acquire);

        Task<T> GetAsync<T>(CacheKey key, Func<T> acquire);

        Task RemoveAsync(CacheKey cacheKey, params object[] cacheKeyParameters);

        Task ClearAsync();
    }
}
