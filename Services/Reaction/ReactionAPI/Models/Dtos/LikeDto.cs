namespace ReactionAPI.Models.Dtos;

public class LikeDto
{
    public string Id { get; set; }
    public User User { get; set; }
    public string ContentId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
