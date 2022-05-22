using BjjAppApi.Models;
using BjjAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BjjAppApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovesController : ControllerBase
{
    private readonly MovesService _movesService;

    public MovesController(MovesService movesService) =>
        _movesService = movesService;

    [HttpGet]
    public async Task<List<Move>> Get() =>
        await _movesService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Move>> Get(string id)
    {
        var move = await _movesService.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        return move;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Move newMove)
    {
        await _movesService.CreateAsync(newMove);

        return CreatedAtAction(nameof(Get), new { id = newMove.Id }, newMove);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Move updatedMove)
    {
        var move = await _movesService.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        updatedMove.Id = move.Id;

        await _movesService.UpdateAsync(id, updatedMove);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var move = await _movesService.GetAsync(id);

        if (move is null)
        {
            return NotFound();
        }

        await _movesService.RemoveAsync(id);

        return NoContent();
    }
}