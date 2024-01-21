using dnd_domain.Campaigns.Adventures;
using System;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class AdventureDto
{
    public int Id { get; set; }
    public required int CampaignId { get; set; }
    public required string Name { get; set; }
    public required AdventureType Type { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset? EndsAt { get; set; }

    public List<SquareDto> Squares { get; set; } = new();

    public AdventureDto FromDomain(List<SquareDto> squares)
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Name = Name,
            Type = Type,
            StartsAt = StartsAt,
            EndsAt = EndsAt,
            Squares = squares
        };
}
