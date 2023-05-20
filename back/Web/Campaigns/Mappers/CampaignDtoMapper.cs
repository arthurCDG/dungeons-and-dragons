using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using dnd_domain.Players.Services;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Mappers;

public class CampaignDtoMapper
{
    private readonly IHeroesService _heroesService;
    private readonly IMonstersRepository _monstersRepository;

    public CampaignDtoMapper(IHeroesService heroesService, IMonstersRepository monstersRepository)
    {
        _heroesService = heroesService ?? throw new System.ArgumentNullException(nameof(heroesService));
        _monstersRepository = monstersRepository ?? throw new System.ArgumentNullException(nameof(monstersRepository));
    }

    public async Task<CampaignDto> ToDtoAsync(Campaign campaign)
    {
        List<Hero> heroes = await _heroesService.GetAsync(campaign.Id);
        List<Monster> monsters = await _monstersRepository.GetAsync(campaign.Id);

        List<Square> squares = campaign.Rooms.SelectMany(r => r.Squares).ToList();
        List<SquareDto> squareDtos = squares
            .ConvertAll(square => FromDomain(square, heroes, monsters))
            .OrderBy(square => square.Id)
            .ToList();

        return CampaignDto.FromDomain(campaign, squareDtos);
    }

    private static SquareDto FromDomain(Square square, List<Hero> heroes, List<Monster> monsters)
        => new()
        {
            Id = square.Id,
            RoomId = square.RoomId,
            ImageUrl = square.ImageUrl,
            IsDisabled = square.IsDisabled,
            IsDoor = square.IsDoor,
            HasBottomWall = square.HasBottomWall,
            HasTopWall = square.HasTopWall,
            HasLeftWall = square.HasLeftWall,
            HasRightWall = square.HasRightWall,
            Position = square.Position,
            Trap = square.Trap,
            Hero = heroes.SingleOrDefault(h => h.SquareId == square.Id),
            Monster = monsters.SingleOrDefault(m => m.SquareId == square.Id)
        };
}
