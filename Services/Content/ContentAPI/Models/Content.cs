using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContentAPI.Models;

public class Content
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedTime { get; set; }=DateTime.Now;
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }=true;
    public string CategoryId { get; set; }
    public User User { get; set; }
    public List<Comment> Comments { get; set; }
}
