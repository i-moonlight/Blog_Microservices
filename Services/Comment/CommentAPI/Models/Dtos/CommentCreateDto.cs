namespace CommentAPI.Models.Dtos;

public class CommentCreateDto
{
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
