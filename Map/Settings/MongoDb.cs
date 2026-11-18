namespace StudentAPI.Settings;

public class MongoDb
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; }=string.Empty;
    public string CollectionName { get; set; }=string.Empty;

}