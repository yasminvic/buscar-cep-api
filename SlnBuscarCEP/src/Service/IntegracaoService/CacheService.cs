using Domain.DTO;
using Domain.Interfaces.IService;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Service.IntegracaoService
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cacheMemory;
        private readonly DistributedCacheEntryOptions _options;

        public CacheService(IDistributedCache cacheMemory)
        {
            _cacheMemory = cacheMemory;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            };
        }

        public async Task<string> Get(string key)
        {
            return await _cacheMemory.GetStringAsync(key);
        }

        public async Task Set(string key, string cep)
        {
           await _cacheMemory.SetStringAsync(key, cep, _options);
        }
    }
}
