namespace ContentAPI.Models.Dtos;

public class ContentUpdateDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    public User User { get; set; }
}
