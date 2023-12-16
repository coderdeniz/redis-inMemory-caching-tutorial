using ConsoleUI.Caching;
using ConsoleUI.Caching.Microsoft;
using ConsoleUI.Caching.Redis;
using ConsoleUI.Utilities.IoC;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); // in-memory caching için
            serviceCollection.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6380";
            });
            serviceCollection.AddSingleton<ICacheService, RedisCacheManager>();            
        }
    }
}
