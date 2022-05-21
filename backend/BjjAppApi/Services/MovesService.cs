using BjjAppApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BjjAppApi.Services;

public class MovesService
{
    private readonly IMongoCollection<Move> _movesCollection;

    public MovesService(
        IOptions<BjjAppDatabaseSettings> bjjAppDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bjjAppDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bjjAppDatabaseSettings.Value.DatabaseName);

        _movesCollection = mongoDatabase.GetCollection<Move>(
            bjjAppDatabaseSettings.Value.MovesCollectionName);
    }

    public async Task<List<Move>> GetAsync() =>
        await _movesCollection.Find(_ => true).ToListAsync();

    public async Task<Move?> GetAsync(string id) =>
        await _movesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Move newMove) =>
        await _movesCollection.InsertOneAsync(newMove);

    public async Task UpdateAsync(string id, Move updatedMove) =>
        await _movesCollection.ReplaceOneAsync(x => x.Id == id, updatedMove);

    public async Task RemoveAsync(string id) =>
        await _movesCollection.DeleteOneAsync(x => x.Id == id);
}