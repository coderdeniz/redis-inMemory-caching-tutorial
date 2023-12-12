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
        private readonly MemoryCacheEntryOptions _options;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _options = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(20), // 20 saniye sonunda erişilse de data expire olacak
                SlidingExpiration = TimeSpan.FromSeconds(10), // 10 saniye içinde erişilirse tekrardan bir 10 saniye daha data tutulacak
                Priority = CacheItemPriority.Normal, // memory dolduğunda cache'lerden keylerin silinmesi öncelik sırasına göre belirlenir.
            };
        }

        public void Add(object key, object value)
        {
            _memoryCache.Set(key, value, _options);
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
