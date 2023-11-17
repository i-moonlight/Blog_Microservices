using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogAPI.Models
{
    public class LogCreatedEvent
    {
      public string Message { get; set; } 
      public string LogType { get; set; }
      public DateTime CreatedDate { get; set; }
      
    }
}