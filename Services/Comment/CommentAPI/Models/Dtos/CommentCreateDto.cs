namespace CommentAPI.Models.Dtos;

public class CommentCreateDto
{
    public string ContentId { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
}
