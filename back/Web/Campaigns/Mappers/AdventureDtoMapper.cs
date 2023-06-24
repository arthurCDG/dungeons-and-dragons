using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace dungeons_and_dragons.Campaigns.Mappers;

public static class AdventureDtoMapper
{
    public static AdventureDto ToDto(Adventure adventure, List<Player> players)
        => new()
        {
            Id = adventure.Id,
            Name = adventure.Name,
            Type = adventure.Type,
            Squares = adventure.Rooms
                .SelectMany(r => r.Squares)
                .Select(s => SquareDtoMapper.ToDto(s, players))
                .ToList()
        };
}
