namespace ContentAPI.Models.Dtos;

public class ContentDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public List<Comment> Comments { get; set; }
    public List<Like> Likes { get; set; }
    public User User { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    
}
