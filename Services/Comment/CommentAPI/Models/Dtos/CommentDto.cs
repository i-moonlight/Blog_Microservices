namespace CommentAPI.Models.Dtos;

public class CommentDto
{
    public string Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
}
