namespace CommentAPI.Models.Dtos;

public class CommentCreateDto
{
    public string PostId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
