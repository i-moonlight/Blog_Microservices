using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionAPI.Models.Dtos
{
    public class LikeCreatedEvent
    {
        public string Id { get; set; }
        public User User { get; set; }
        public string ContentId { get; set; }
    }
}