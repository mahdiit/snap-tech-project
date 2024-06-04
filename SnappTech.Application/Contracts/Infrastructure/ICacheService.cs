using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Contracts.Infrastructure
{
    public interface ICacheService
    {
        Task<T?> GetData<T>(string cacheKey, Func<Task<T?>>? fallbackFunction = null, TimeSpan? expireTime = null) where T : class;
        Task SetData<T>(string cacheKey, T inputData, TimeSpan expireTime) where T : class;
        Task Remove(string key);
    }
}
