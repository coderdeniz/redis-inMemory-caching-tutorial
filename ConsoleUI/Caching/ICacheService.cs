using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Caching
{
    public interface ICacheService
    {
        void Add(object key, object value);
        void Remove(object key);
        object Get(object key);
        bool IsExist(object key, out object cacheValue);
    }
}
