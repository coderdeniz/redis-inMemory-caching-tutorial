using ConsoleUI.Caching;
using ConsoleUI.DependencyResolvers;
using ConsoleUI.Entity;
using ConsoleUI.Extensions;
using ConsoleUI.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Drawing;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection();
            
            ICacheService cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();

           

            
            // resim okuma sıkıntılı
        }

        private static void ServiceCollection()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });
        }


        private static string ConvertImageToAscii(string imagePath, int width, int height)
        {
            // Resmi yükleyin
            Bitmap image = new Bitmap(imagePath);

            // Resmi küçültün
            image = new Bitmap(image, width, height);

            // ASCII sanatını oluştur
            string asciiArt = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    System.Drawing.Color pixelColor = image.GetPixel(x, y);
                    int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    char asciiChar = GetAsciiChar(grayValue);
                    asciiArt += asciiChar;
                }
                asciiArt += Environment.NewLine;
            }

            return asciiArt;
        }
        private static char GetAsciiChar(int grayValue)
        {
            char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };
            int index = grayValue * (asciiChars.Length - 1) / 255;
            return asciiChars[asciiChars.Length - index - 1];
        }
        private static void Test()
        {

            //C:\Users\belbi\OneDrive\Masaüstü\repo\coderdeniz\redis-inMemory\Redis_InMemory_Tutorial\ConsoleUI\images\download.png


            //string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images","download.png");

            //string imagePath = "C:\\Users\\belbi\\OneDrive\\Masaüstü\\repo\\coderdeniz\\redis-inMemory\\Redis_InMemory_Tutorial\\ConsoleUI\\images\\download.png";

            //Console.WriteLine(imagePath);

            ////byte[] imageByte = File.ReadAllBytes(imagePath);

            ////cacheService.Add("resim2", imageByte);

            //var resimByte = cacheService.Get("resim2");


            //// Resmin tam yolunu al
            ////string resimYolu = imagePath; // Resminizin gerçek yolunu buraya ekleyin

            //// Resmi ASCII sanatına dönüştür ve ekrana yazdır
            //string asciiArt = ConvertImageToAscii(resimByte.ToString(), 100, 40); // Genişlik ve yüksekliği uygun değerlere değiştirin
            //Console.WriteLine(asciiArt);


            //Console.WriteLine();

            //Console.WriteLine(cacheService.Get("name"));       

            // cacheService.Add("name", "duman");
            // var name = cacheService.Get("name");
            // Console.WriteLine(name);

            //Product p = new Product()
            //{
            //    Id = 1,
            //    Name = "Kalem",
            //    Price = 200
            //};

            //string jsonProduct = JsonConvert.SerializeObject(p);

            //cacheService.Add(p.Id, jsonProduct);

            //var pFromRedis = cacheService.Get(p.Id).ToString();

            //var product = JsonConvert.DeserializeObject<Product>(pFromRedis);

            //Console.WriteLine(product.Name);

            //cacheService.Add(p.Id, p);

            ////Thread.Sleep(3000);

            //cacheService.Remove(p.Id);

            //Thread.Sleep(10);

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
    }
}