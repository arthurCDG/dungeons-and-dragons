using dnd_domain.Campaigns.Models;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Linq;

namespace dungeons_and_dragons.Campaigns.Mappers;

public static class AdventureDtoMapper
{
    public static AdventureDto ToDto(Adventure adventure)
        => new()
        {
            Id = adventure.Id,
            Name = adventure.Name,
            Type = adventure.Type,
            Players = adventure.Players,
            Squares = adventure.Rooms
                .SelectMany(r => r.Squares)
                .Select(s => SquareDtoMapper.ToDto(s, adventure.Players))
                .ToList()
        };
}
