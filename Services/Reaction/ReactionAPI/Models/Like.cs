using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReactionAPI.Models;

public class Like
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string UserId { get; set; }
    public string CommentId { get; set; }
    
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
