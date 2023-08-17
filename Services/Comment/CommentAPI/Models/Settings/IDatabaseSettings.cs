namespace CommentAPI.Models.Settings;

public interface IDatabaseSettings
{
public string UserName { get; set; }
    public string Password { get; set; }
    public string DatabaseName { get; set; }
}
