using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAPI.Models.Dtos
{
    public class CommentCreatedEvent
    {
        public string Id { get; set; }
        public string ContentId { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
    }
}