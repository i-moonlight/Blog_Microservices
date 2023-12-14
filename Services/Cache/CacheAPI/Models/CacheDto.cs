using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheAPI.Models
{
    public class CacheDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int ExpirySeconds { get; set; } = 3600;
    }
}