using BjjAppApi.Models;

namespace BjjAppApi.Interfaces;

public interface INamesRepository
{
    Task<List<Name>> GetAsync();

    Task<Name?> GetAsync(string id);

    Task CreateAsync(Name newName);

    Task UpdateAsync(string id, Name updatedName);

    Task RemoveAsync(string id);
}