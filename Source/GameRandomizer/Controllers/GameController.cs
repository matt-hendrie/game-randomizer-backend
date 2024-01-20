using GameRandomizer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameRandomizer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController(IGiantBombService giantBombService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetGames(int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return Ok(await giantBombService.GetGames(page, cancellationToken));
        }
        catch (OperationCanceledException e)
        {
            return StatusCode(499, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGame(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return Ok(await giantBombService.GetGame(id, cancellationToken));
        }
        catch (OperationCanceledException e)
        {
            return StatusCode(499, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet("platform")]
    public async Task<IActionResult> GetGamesByPlatform(int platformId, int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return Ok(await giantBombService.GetGamesByPlatform(platformId, page, cancellationToken));
        }
        catch (OperationCanceledException e)
        {
            return StatusCode(499, e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}