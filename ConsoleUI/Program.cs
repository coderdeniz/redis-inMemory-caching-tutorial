using ConsoleUI.Caching;
using ConsoleUI.DependencyResolvers;
using ConsoleUI.Entity;
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

            Product p = new Product()
            {
                Id = 1,
                Name = "Kalem",
                Price = 200
            };

            cacheService.Add(p.Id, p);

            //Thread.Sleep(3000);

            cacheService.Remove(p.Id);

            Thread.Sleep(10);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.Write(i);
            //    Thread.Sleep(500);
            //}
            
            //var product = (Product)cacheService.Get(p.Id);

            //Console.WriteLine(product.Id + " " + product.Name + " " + product.Price);


            //var err = (string)cacheService.Get(p.Id);

            //Console.WriteLine(err);

            //Thread.Sleep(2000);

            //var product = (Product)cacheService.Get(p.Id);

            //Console.WriteLine(product.Id + " " + product.Name + " " + product.Price);

            //var date = DateTime.Now;

            //Console.WriteLine(date);

            //cacheService.Add("tarih", date);

            ////Thread.Sleep(3000);

            //cacheService.Remove("tarih");

            //bool isExist = cacheService.IsExist("tarih",out object cacheValue);

            //if (isExist)
            //{
            //    Console.WriteLine(cacheValue);
            //}
            //else
            //{
            //    Console.WriteLine("cache'deki data expire olmuş");
            //}

            //cacheService.Remove("tarih");

            //cacheService.Add("tarih", DateTime.Now.AddSeconds(10));

            //date = (DateTime)cacheService.Get("tarih");

            //Console.WriteLine(date);

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