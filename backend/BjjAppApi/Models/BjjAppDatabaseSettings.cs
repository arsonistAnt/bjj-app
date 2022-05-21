namespace BjjAppApi.Models;

public class BjjAppDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string MovesCollectionName { get; set; } = null!;
    public string DemosCollectionName { get; set; } = null!;
    public string NamesCollectionName { get; set; } = null!;
}