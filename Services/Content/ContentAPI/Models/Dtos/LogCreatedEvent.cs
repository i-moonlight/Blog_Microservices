using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAPI.Models.Dtos
{
    public class LogCreatedEvent
    {
      public string Message { get; set; } 
      public string LogType { get; set; }
      public DateTime CreatedDate { get; set; }
      
    }
}