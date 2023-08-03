using dnd_domain.Campaigns.Adventures;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class AdventureDto
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public AdventureType Type { get; set; }
    public bool IsActive { get; set; } = false;
    public bool IsCompleted { get; set; } = false;

    public List<SquareDto> Squares { get; set; } = new();

    public AdventureDto FromDomain(List<SquareDto> squares)
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Name = Name,
            Type = Type,
            IsActive = IsActive,
            IsCompleted = IsCompleted,
            Squares = squares
        };
}
