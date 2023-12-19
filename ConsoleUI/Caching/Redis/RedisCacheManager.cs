using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Caching.Redis
{
    public class RedisCacheManager : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _options;
        private IDatabase _db;
        private ConnectionMultiplexer _redis;

        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(10)   // TTL süresi commander'da yazıyor saniye cinsinden             
            };
            Connect();
            _db = GetDb(0);

            //_db.StringSet("name", "deniz");
            //_db.StringSet("status", true);

            //_db.StringSet("ziyaretci", 100);

            //_db.StringIncrement("ziyaretci");

            //Console.WriteLine(_db.StringGet("name"));
            //Console.WriteLine(_db.StringGet("status"));
            //Console.WriteLine(_db.StringGet("ziyaretci"));

            //string listKey = "fruits";

            // _db.ListRightPush(listKey, "apple");
            // _db.ListRightPush(listKey, "orange");
            // _db.ListRightPush(listKey, "banana");

            // _db.ListRemove(listKey,"orange",1);

            //_db.ListLeftPush(listKey, "grapes");

            //if (_db.KeyExists(listKey))
            //{
            //    foreach (var item in _db.ListRange("fruits", 0, -1))
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            // HashSet<string> deger = new();

            //_db.SetAdd("isimler", "item*11"); // set aynı değer eklenemez, random sıra ile eklenir. // c#'daki HashSet ile aynı

            //_db.SetMembers("isimler").ToList().ForEach((item) =>
            //{
            //    Console.WriteLine(item);
            //});

            // _db.SetRemove("isimler", "item*1");
            // 

            // sorted set: skoru yüksek olan en başta olacak şekilde sıralanır. aynı elemanlar skorları farklı olsa da eklenmez

            //_db.SortedSetAdd("meyve", "elma", 29); 
            //_db.SortedSetAdd("meyve", "elma", 28);
            //_db.SortedSetAdd("meyve", "armut2", 11);
            //_db.SortedSetAdd("meyve", "portakal", 30);

            //// _db.KeyExpire("meyve",DateTime.Now.AddSeconds(10)); var olan  key'e bitim süresi verme yeni oluşturulurken verirse görmez


            ////_db.KeyExpire("test", DateTime.Now.AddDays(1));
            ////_db.SortedSetAdd("test", "değer", 10);

            //_db.SortedSetScan("meyve").ToList().ForEach(x =>
            //{
            //    //Console.WriteLine(x);
            //    Console.WriteLine(x.ToString());
            //});

            // redis hash: c# dictionary karşılık geliyor
            // aynı key'e aynı ekleyince değişmiyor

            Dictionary<string, string> dictList = new Dictionary<string, string>();

            _db.HashSet("dictList", "key-3", "value-22");
            _db.HashSet("dictList", "key-2", "value-33");

            //_db.HashDelete("dictList", "key-1");

            if (_db.KeyExists("dictList"))
            {
                _db.HashGetAll("dictList").ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Name + " -- " + x.Value);
                });
            }

            Console.WriteLine(_db.HashGet("dictList","key-2"));    

        }

        public void Connect()
        {
            var configString = $"localhost:6380";            
            _redis = ConnectionMultiplexer.Connect(configString);
        }

        public IDatabase GetDb(int db)
        {            
            return _redis.GetDatabase(db); // default sıfırıncı db
        }

        public void Add(object key, object value)
        { 
            var val = Encoding.UTF8.GetBytes(value.ToString());
            
            _distributedCache.Set(key.ToString(), val,_options);

            //_distributedCache.SetString(key.ToString(), value.ToString(), _options); // hash olarak kaydediyor
        }

        public object Get(object key)
        {
            return Encoding.UTF8.GetString(_distributedCache.Get(key.ToString()));
            //return _distributedCache.GetString(key.ToString());
        }

        public bool IsExist(object key, out object cacheValue)
        {
            throw new Exception();
        }

        public void Remove(object key)
        {
            _distributedCache.Remove(key.ToString());
        }
    }
}
