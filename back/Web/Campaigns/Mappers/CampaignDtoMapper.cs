using dnd_domain.Campaigns.Models;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Linq;

namespace dungeons_and_dragons.Campaigns.Mappers;

public static class CampaignDtoMapper
{
    public static CampaignDto ToDto(Campaign campaign)
        => new()
        {
            Id = campaign.Id,
            StartsAt = campaign.StartsAt,
            EndsAt = campaign.EndsAt,
            Adventures = campaign.Adventures.Select(AdventureDtoMapper.ToDto).ToList()
        };
}
