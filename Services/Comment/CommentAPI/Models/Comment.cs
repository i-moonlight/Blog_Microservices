namespace CommentAPI.Models;

public class Comment
{
    public string Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; } = DateTime.Now;
    public string UserId { get; set; }
    public string UserName { get; set; }
}
