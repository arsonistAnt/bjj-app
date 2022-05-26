using BjjAppApi.Models;

namespace BjjAppApi.Interfaces;

public interface IMovesRepository
{
    Task<List<Move>> GetAsync();

    Task<Move?> GetAsync(string id);

    Task CreateAsync(Move newMove);

    Task UpdateAsync(string id, Move updatedMove);

    Task RemoveAsync(string id);
}