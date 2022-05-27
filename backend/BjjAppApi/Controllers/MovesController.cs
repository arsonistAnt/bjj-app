using BjjAppApi.Models;
using BjjAppApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BjjAppApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovesController : ControllerBase
{
    private readonly IMovesRepository _movesRepository;

    public MovesController(IMovesRepository movesRepository) =>
        _movesRepository = movesRepository;

    [HttpGet]
    public async Task<List<Move>> Get() =>
        await _movesRepository.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Move>> Get(string id)
    {
        var move = await _movesRepository.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        return move;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Move newMove)
    {
        await _movesRepository.CreateAsync(newMove);

        return CreatedAtAction(nameof(Get), new { id = newMove.Id }, newMove);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Move updatedMove)
    {
        var move = await _movesRepository.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        updatedMove.Id = move.Id;

        await _movesRepository.UpdateAsync(id, updatedMove);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var move = await _movesRepository.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        await _movesRepository.RemoveAsync(id);

        return NoContent();
    }
}