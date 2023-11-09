namespace CommentAPI.Models.Dtos;

public class CommentUpdateDto
{
    public string Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    public string UserName { get; set; }
}
