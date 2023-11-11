namespace ContentAPI.Models.Dtos;

public class ContentDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public List<Comment> Comments { get; set; }
    
}
