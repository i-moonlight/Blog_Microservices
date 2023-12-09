namespace ContentAPI.Models.Dtos;

public class ContentCreateDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string CategoryId { get; set; }
    public User User { get; set; }
}
