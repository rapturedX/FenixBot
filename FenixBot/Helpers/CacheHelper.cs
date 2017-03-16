using System;
using System.Runtime.Caching;

namespace FenixBot.Helpers
{
    public static class CacheHelper
    {
        public static T GetCache<T>(string key, string region)
        {
            var obj = (T)MemoryCache.Default.Get(key);

            return obj;
        }

        public static void Cache(string key, string region, object obj, TimeSpan? expireTimespan = null)
        {
            var expireTime = DateTime.Now.AddMinutes(expireTimespan.GetValueOrDefault(new TimeSpan(0, 15, 0)).TotalMinutes);

            MemoryCache.Default.Add(key, obj, expireTime);
        }

        public static void Bust(string key, string region)
        {
            MemoryCache.Default.Remove(key);
        }
    }
}
