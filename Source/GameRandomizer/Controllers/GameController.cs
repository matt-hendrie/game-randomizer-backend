using GameRandomizer.Interfaces;
using GameRandomizer.Services;
using GiantBomb.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace GameRandomizer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController(IGiantBombService giantBombService) : ControllerBase
{
    [HttpGet]
    public async Task<List<Game>> GetGames(int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await giantBombService.GetGames(page, cancellationToken);
    }
    
    [HttpGet("{id:int}")]
    public async Task<Game> GetGame(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await giantBombService.GetGame(id, cancellationToken);
    }
}