using BjjAppApi.Interfaces;
using BjjAppApi.Models;
using MongoDB.Driver;

namespace BjjAppApi.Repositories;

public class MovesMongoRepository : IMovesRepository
{
    private readonly IMongoCollection<Move> _movesCollection;

    public MovesMongoRepository(IMongoCollection<Move> movesCollection)
    {
        _movesCollection = movesCollection;
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