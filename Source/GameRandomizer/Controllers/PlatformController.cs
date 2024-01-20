using GameRandomizer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameRandomizer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController(IGiantBombService giantBombService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPlatforms(int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return Ok(await giantBombService.GetPlatforms(page, cancellationToken));
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
    public async Task<IActionResult> GetPlatform(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            return Ok(await giantBombService.GetPlatform(id, cancellationToken));
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