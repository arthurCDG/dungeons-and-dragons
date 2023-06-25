using dnd_domain.Campaigns.Models;
using dungeons_and_dragons.Campaigns.DTOs;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.Mappers;

public class CampaignDtoMapper
{
    private readonly AdventureDtoMapper _adventureDtoMapper;

    public CampaignDtoMapper(AdventureDtoMapper adventureDtoMapper)
    {
        _adventureDtoMapper = adventureDtoMapper ?? throw new System.ArgumentNullException(nameof(adventureDtoMapper));
    }

    public List<CampaignDto> ToDtos(List<Campaign> campaigns)
        => campaigns.ConvertAll(ToDto);

    public CampaignDto ToDto(Campaign campaign)
    {
        List<AdventureDto> adventures = _adventureDtoMapper.ToDtos(campaign);

        return new()
        {
            Id = campaign.Id,
            StartsAt = campaign.StartsAt,
            EndsAt = campaign.EndsAt,
            Adventures = adventures
        };
    }
}
