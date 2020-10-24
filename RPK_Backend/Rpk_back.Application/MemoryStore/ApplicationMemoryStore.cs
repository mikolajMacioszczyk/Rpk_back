using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Rpk_back.Application.Interfaces;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.MemoryStore
{
    public class ApplicationMemoryStore : IApplicationMemoryStore
    {
        private readonly IMemoryCache _cache;
        private readonly IRegisterService _registerService;

        public ApplicationMemoryStore(IMemoryCache cache,
            IRegisterService registerService)
        {
            _cache = cache;
            _registerService = registerService;
        }

        public List<RegisterNode> GetCachedRegisteredNodes()
        {
            return _cache.GetOrCreate(nameof(GetCachedRegisteredNodes),  entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return _registerService.GetRegisterNodes();
            });
        }
    }
}