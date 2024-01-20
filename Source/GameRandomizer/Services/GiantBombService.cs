using GameRandomizer.Interfaces;
using GiantBomb.Api;
using GiantBomb.Api.Model;

namespace GameRandomizer.Services;

public class GiantBombService(IConfiguration configuration) : IGiantBombService
{
    private readonly GiantBombRestClient _client = new(configuration["GiantBombKey"]);
    
    public async Task<List<Game>> GetGames(int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var games = await _client.GetGamesAsync(page: page);
        return games.ToList();
    }
    
    public async Task<Game> GetGame(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var game = await _client.GetGameAsync(id);
        return game;
    }

    public async Task<List<Game>> GetGamesByPlatform(int platformId, int page, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var filters = new Dictionary<string, object>() {
            {"platforms", platformId}
        };
        
        var games = await _client.GetListResourceAsync<Game>("games", filterOptions: filters);
        
        return games.ToList();
    }

    public async Task<List<Platform>> GetPlatforms(int page = 1, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var platforms = await _client.GetPlatformsAsync(page: page);
        return platforms.ToList();
    }
    
    public async Task<Platform> GetPlatform(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var platform = await _client.GetPlatformAsync(id);
        return platform;
    }
}