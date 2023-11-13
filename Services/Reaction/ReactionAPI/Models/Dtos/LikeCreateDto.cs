namespace ReactionAPI.Models.Dtos;

public class LikeCreateDto
{
    public User User { get; set; }
    public string ContentId { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
