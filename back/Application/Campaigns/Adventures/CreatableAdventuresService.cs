using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

internal sealed class CreatableAdventuresService : ICreatableAdventuresService
{
    private readonly ICampaignsRepository _campaignsRepository;

    public CreatableAdventuresService(ICampaignsRepository campaignsRepository)
    {
        _campaignsRepository = campaignsRepository ?? throw new ArgumentNullException(nameof(campaignsRepository));
    }

    public async Task<List<CreatableAdventure>> GetAsync(int campaignId)
    {
        Campaign campaign = await _campaignsRepository.GetByIdAsync(campaignId);
        List<Adventure> createdAdventures = campaign.Adventures
            .Where(a => a.Status == AdventureStatus.Finished || a.Status == AdventureStatus.Started)
            .ToList();

        List<CreatableAdventure> creatableAdventures = campaign.Type switch
        {
            CampaignType.HollbrooksLiberation => GetLevel1CreatableAdventures().Where(ca => !createdAdventures.Select(a => a.Type).Contains(ca.Type)).ToList(),
            _ => throw new InvalidOperationException($"Unknown campaign type: {campaign.Type}.")
        };

        if (!creatableAdventures.Any())
        {
            return new();
        }

        if (createdAdventures.All(ca => ca.Status == AdventureStatus.Finished))
        {
            creatableAdventures.First().CanBeStarted = true;
        }

        return creatableAdventures;
    }

    private static List<CreatableAdventure> GetLevel1CreatableAdventures()
        => new()
        {
            new CreatableAdventure
            {
                Type = AdventureType.GoblinBandits,
                Name = AdventureFactoryHelper.GetAdventureName(AdventureType.GoblinBandits),
                Description = "Un groupe de gobelins a attaqué la ville de Hollbrook. Le maire de la ville vous a demandé de l'aide."
            },
            new CreatableAdventure
            {
                Type = AdventureType.OnTheTrailOfEvil,
                Name = AdventureFactoryHelper.GetAdventureName(AdventureType.OnTheTrailOfEvil),
                Description = "Les gobelins ont été vaincus, mais le maire vous a demandé d'enquêter sur la source du mal qui a ravagé la ville."
            },
            new CreatableAdventure
            {
                Type = AdventureType.HauntedVillage,
                Name = AdventureFactoryHelper.GetAdventureName(AdventureType.HauntedVillage),
                Description = "Vous avez éradiqué la source du mal principal mais vos pérégrinations vous ont conduit jusqu'à un étrange village hanté."
            }
        };
}
