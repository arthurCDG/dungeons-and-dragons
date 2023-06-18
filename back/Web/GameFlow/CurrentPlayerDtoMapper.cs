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
            HeroId = currentPlayer.Hero?.Id,
            MonsterId = currentPlayer.Monster?.Id
        };

        if (currentPlayer.Hero?.Id is not null)
            dto.Hero = await _heroesService.GetByIdAsync(currentPlayer.Hero.Id);

        else if (currentPlayer.Monster?.Id is not null)
            dto.Monster = await _monstersService.GetByIdAsync(currentPlayer.Monster.Id);

        return dto;
    }
}
