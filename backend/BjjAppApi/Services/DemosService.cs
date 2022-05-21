using BjjAppApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BjjAppApi.Services;

public class DemosService
{
    private readonly IMongoCollection<Demo> _demosCollection;

    public DemosService(
        IOptions<BjjAppDatabaseSettings> bjjAppDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bjjAppDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bjjAppDatabaseSettings.Value.DatabaseName);

        _demosCollection = mongoDatabase.GetCollection<Demo>(
            bjjAppDatabaseSettings.Value.DemosCollectionName);
    }

    public async Task<List<Demo>> GetAsync() =>
        await _demosCollection.Find(_ => true).ToListAsync();

    public async Task<Demo?> GetAsync(string id) =>
        await _demosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Demo newDemo) =>
        await _demosCollection.InsertOneAsync(newDemo);

    public async Task UpdateAsync(string id, Demo updatedDemo) =>
        await _demosCollection.ReplaceOneAsync(x => x.Id == id, updatedDemo);

    public async Task RemoveAsync(string id) =>
        await _demosCollection.DeleteOneAsync(x => x.Id == id);
}