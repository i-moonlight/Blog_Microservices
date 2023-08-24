namespace CommentAPI.Models.Dtos;

public class CommentUpdateDto
{
    public string Id { get; set; }
    public string PostId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
}
