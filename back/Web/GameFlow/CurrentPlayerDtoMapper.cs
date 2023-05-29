using dnd_domain.GameFlow.Models;
using dnd_domain.Players.Services;
using System.Threading.Tasks;

namespace dungeons_and_dragons.GameFlow;

public class CurrentPlayerDtoMapper
{
    private readonly IHeroesService _heroesService;
    private readonly IMonstersService _monstersService;

    public CurrentPlayerDtoMapper(IHeroesService heroesService, IMonstersService monstersService)
    {
        _heroesService = heroesService ?? throw new System.ArgumentNullException(nameof(heroesService));
        _monstersService = monstersService ?? throw new System.ArgumentNullException(nameof(monstersService));
    }

    public async Task<CurrentPlayerDto> MapToDtoAsync(CurrentPlayer currentPlayer)
    {
        CurrentPlayerDto dto = new()
        {
            CampaignId = currentPlayer.CampaignId,
            HeroId = currentPlayer.HeroId,
            MonsterId = currentPlayer.MonsterId
        };

        if (currentPlayer.HeroId is not null)
            dto.Hero = await _heroesService.GetByIdAsync((int)currentPlayer.HeroId);

        else if (currentPlayer.MonsterId is not null)
            dto.Monster = await _monstersService.GetByIdAsync((int)currentPlayer.MonsterId);

        return dto;
    }
}
