using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContentAPI.Models;

public class Like
{
    public string Id { get; set; }
    public string ContentId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public User User { get; set; }
}
