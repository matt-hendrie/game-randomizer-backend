using GameRandomizer.Interfaces;
using GiantBomb.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace GameRandomizer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController(IGiantBombService giantBombService) : ControllerBase
{
    [HttpGet]
    public async Task<List<Platform>> GetPlatforms(int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await giantBombService.GetPlatforms(page, cancellationToken);
    }
    
    [HttpGet("{id:int}")]
    public async Task<Platform> GetPlatform(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await giantBombService.GetPlatform(id, cancellationToken);
    }
}