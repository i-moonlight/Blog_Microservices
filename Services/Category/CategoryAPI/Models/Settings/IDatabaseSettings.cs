namespace CategoryAPI.Models.Settings;

public interface IDatabaseSettings
{
    public string CategoryCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
