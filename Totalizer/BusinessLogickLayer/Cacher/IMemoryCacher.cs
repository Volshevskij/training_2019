using System;

namespace BusinessLogickLayer.Cacher
{
    public interface IMemoryCacher
    {
        object Get(string key);
        bool Add(string key, object value, DateTimeOffset absExpiration);
        void Delete(string key);
        object CheckCache(string key, object value, DateTimeOffset absExpiration);
    }
}
