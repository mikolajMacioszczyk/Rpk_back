using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Rpk_back.Application.Interfaces;

namespace Rpk_back.Application.MemoryStore
{
    public class ApplicationMemoryStore : IApplicationMemoryStore
    {
        private IMemoryCache _cache;

        public ApplicationMemoryStore(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public void Set<T>(string itemKey, T itemValue, DateTime expirationDate)
        {
            _cache.Set(itemKey, itemValue, expirationDate);
        }

        public bool Contains(string key)
        {
            object result = null;
            _cache.TryGetValue(key, out result );
            return result != null;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}