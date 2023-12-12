using ConsoleUI.Caching;
using ConsoleUI.DependencyResolvers;
using ConsoleUI.Extensions;
using ConsoleUI.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection();
            
            ICacheService cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();

            var date = DateTime.Now;

            Console.WriteLine(date);

            cacheService.Add("tarih", date);

            date = (DateTime)cacheService.Get("tarih");

            Console.WriteLine(date);

            cacheService.Remove("tarih");

            cacheService.Add("tarih", DateTime.Now.AddSeconds(10));

            date = (DateTime)cacheService.Get("tarih");

            Console.WriteLine(date);

        }

        private static void ServiceCollection()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });
        }
    }
}