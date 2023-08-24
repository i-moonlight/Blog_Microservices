namespace ReactionAPI.Models.Dtos;

public class LikeDto
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string CommentId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
