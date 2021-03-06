using BjjAppApi.Interfaces;
using BjjAppApi.Models;
using MongoDB.Driver;

namespace BjjAppApi.Repositories;

public class NamesMongoRepository : INamesRepository
{
    private readonly IMongoCollection<Name> _namesCollection;

    public NamesMongoRepository(IMongoCollection<Name> namesCollection)
    {
        _namesCollection = namesCollection;
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