using BjjAppApi.Models;

namespace BjjAppApi.Interfaces;

public interface IDemosRepository
{
    Task<List<Demo>> GetAsync();

    Task<Demo?> GetAsync(string id);

    Task CreateAsync(Demo newDemo);

    Task UpdateAsync(string id, Demo updatedDemo);

    Task RemoveAsync(string id);
}