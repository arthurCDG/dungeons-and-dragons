using dnd_application.Campaigns;
using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Mappers;

public class AdventureDtoMapper
{
    private readonly ICampaignsService _campaignsService;
    private readonly IPlayersRepository _playersRepository;

    public AdventureDtoMapper(ICampaignsService campaignsService, IPlayersRepository playersRepository)
    {
        _campaignsService = campaignsService ?? throw new System.ArgumentNullException(nameof(campaignsService));
        _playersRepository = playersRepository ?? throw new System.ArgumentNullException(nameof(playersRepository));
    }

    public List<AdventureDto> ToDtos(Campaign campaign)
        => campaign.Adventures.Select(a =>
        {
            return new AdventureDto
            {
                Id = a.Id,
                Name = a.Name,
                Type = a.Type,
                StartsAt = a.StartsAt,
                EndsAt = a.EndsAt,
                Squares = a.Rooms.SelectMany(r => r.Squares)
                                 .Select(s => SquareDtoMapper.ToDto(s, campaign.Players))
                                 .ToList()
            };
        })
        .ToList();

    public async Task<AdventureDto> ToDtoAsync(Adventure adventure)
    {
        Campaign campaign = await _campaignsService.GetFromAdventureAsync(adventure.Id);
        List<Player> players = campaign.Players;

        return new AdventureDto
        {
            Id = adventure.Id,
            Name = adventure.Name,
            Type = adventure.Type,
            StartsAt = adventure.StartsAt,
            EndsAt = adventure.EndsAt,
            Squares = adventure.Rooms.SelectMany(r => r.Squares)
                                     .Select(s => SquareDtoMapper.ToDto(s, players))
                                     .OrderBy(s => s.Id)
                                     .ToList()
        };
    }
}
