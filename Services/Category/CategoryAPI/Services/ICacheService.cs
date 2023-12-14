using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryAPI.Models.Dtos;

namespace CategoryAPI.Services
{
    public interface ICacheService
    {
        public Task<string> Get(string key);
        public void Add(CacheDto cacheDto);
    }
}