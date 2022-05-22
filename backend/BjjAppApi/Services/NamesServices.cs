using BjjAppApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BjjAppApi.Services;

public class NamesService
{
    private readonly IMongoCollection<Name> _namesCollection;

    public NamesService(
        IOptions<BjjAppDatabaseSettings> bjjAppDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bjjAppDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bjjAppDatabaseSettings.Value.DatabaseName);

        _namesCollection = mongoDatabase.GetCollection<Name>(
            bjjAppDatabaseSettings.Value.NamesCollectionName);
    }

    public async Task<List<Name>> GetAsync() =>
        await _namesCollection.Find(_ => true).ToListAsync();

    public async Task<Name?> GetAsync(string id) =>
        await _namesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Name newName) =>
        await _namesCollection.InsertOneAsync(newName);

    public async Task UpdateAsync(string id, Name updatedName) =>
        await _namesCollection.ReplaceOneAsync(x => x.Id == id, updatedName);

    public async Task RemoveAsync(string id) =>
        await _namesCollection.DeleteOneAsync(x => x.Id == id);
}