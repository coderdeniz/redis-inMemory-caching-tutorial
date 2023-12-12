using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Caching.Microsoft
{
    public class InMemoryCacheManager : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(object key, object value)
        {
            _memoryCache.Set(key, value);
        }

        public object Get(object key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsExist(object key, out object cacheValue)
        {
            return _memoryCache.TryGetValue(key,out cacheValue);
        }

        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }
    }
}
