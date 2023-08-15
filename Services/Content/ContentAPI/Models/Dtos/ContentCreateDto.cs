namespace ContentAPI.Models.Dtos;

public class ContentCreateDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string AuthorId { get; set; }
    public string ImageUrl { get; set; }
}
