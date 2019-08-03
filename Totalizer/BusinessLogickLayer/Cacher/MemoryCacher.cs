using System;
using System.Runtime.Caching;

namespace BusinessLogickLayer.Cacher
{
    public class MemoryCacher : IMemoryCacher
    {
        private MemoryCache MemoryCache { get; set; }

        public MemoryCacher()
        {
            MemoryCache = MemoryCache.Default;
        }

        public object Get(string key)
        {
            return MemoryCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            return MemoryCache.Add(key, value, absExpiration);
        }

        public void Delete(string key)
        {
            if (MemoryCache.Contains(key))
            {
                MemoryCache.Remove(key);
            }
        }

        public object CheckCache(string key, object value, DateTimeOffset absExpiration)
        {
            if (MemoryCache.Get(key) == null)
            {
                MemoryCache.Add(key, value, DateTimeOffset.UtcNow.AddHours(1));
            }

            return MemoryCache.Get(key);
        }
    }
}
