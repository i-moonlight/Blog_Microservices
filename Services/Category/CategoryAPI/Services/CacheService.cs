using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CategoryAPI.Models.Dtos;

namespace CategoryAPI.Services
{
    public class CacheService : ICacheService
    {

        private readonly HttpClient _httpClient;
        public CacheService(HttpClient httpClient, IHttpClientFactory _httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5021/api/");
        }

        public async void Add(CacheDto cacheDto)
        {
            var content = new StringContent(JsonSerializer.Serialize(cacheDto), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("cache/add", content);
        }

        public async Task<string> Get(string key)
        {
            var result = await _httpClient.GetAsync("cache/get?key=" + key);
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();
            else
                return "";
        }
    }
}