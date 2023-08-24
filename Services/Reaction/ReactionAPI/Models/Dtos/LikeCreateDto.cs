namespace ReactionAPI.Models.Dtos;

public class LikeCreateDto
{
    public string UserId { get; set; }
    public string CommentId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
