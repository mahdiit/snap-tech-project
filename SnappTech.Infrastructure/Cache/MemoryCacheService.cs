using Microsoft.Extensions.Caching.Memory;
using SnappTech.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Infrastructure.Cache
{
    public class MemoryCacheService : IMemoryCacheService
    {
        IMemoryCache MemoryCache;
        HashSet<string> CacheNames;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
            CacheNames = new HashSet<string>();
        }
        public Task Clear()
        {
            foreach (string key in CacheNames)
            {
                MemoryCache.Remove(key);
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            MemoryCache.Dispose();
        }

        public async Task<T?> GetData<T>(string cacheKey, Func<Task<T>>? fallbackFunction, TimeSpan? expireTime) where T : class
        {
            T? data;
            if (MemoryCache.TryGetValue(cacheKey, out data))
                return data;

            if (fallbackFunction == null)
                return null;

            data = await fallbackFunction();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(expireTime.GetValueOrDefault(TimeSpan.FromDays(7)))
                  .SetPriority(CacheItemPriority.Normal);

            MemoryCache.Set(cacheKey, data, cacheEntryOptions);
            return data;
        }

        public Task SetData<T>(string cacheKey, T inputData, TimeSpan expireTime) where T : class
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                  .SetAbsoluteExpiration(expireTime)
                  .SetPriority(CacheItemPriority.Normal);

            MemoryCache.Set(cacheKey, inputData, cacheEntryOptions);
            return Task.CompletedTask;
        }

        public Task Remove(string key)
        {
            CacheNames.Remove(key);
            MemoryCache.Remove(key);
            return Task.CompletedTask;
        }
    }

}
