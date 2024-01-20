using GiantBomb.Api.Model;

namespace GameRandomizer.Interfaces;

public interface IGiantBombService
{
    Task<List<Game>> GetGames(int page, CancellationToken cancellationToken);
    Task<Game> GetGame(int id, CancellationToken cancellationToken);
    Task<List<Platform>> GetPlatforms(int page, CancellationToken cancellationToken);
    Task<Platform> GetPlatform(int id, CancellationToken cancellationToken);
}