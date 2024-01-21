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
        List<Adventure> existingAdventures = campaign.Adventures;

        List<CreatableAdventure> creatableAdventures = campaign.Type switch
        {
            CampaignType.HollbrooksLiberation => GetHollbrooksLiberationCreatableAdventures(existingAdventures),
            _ => throw new InvalidOperationException($"Unknown campaign type: {campaign.Type}.")
        };

        creatableAdventures.RemoveAll(cc => existingAdventures.Any(ec => ec.Type == cc.Type));
        return creatableAdventures;
    }

    private static List<CreatableAdventure> GetHollbrooksLiberationCreatableAdventures(List<Adventure> existingAdventures)
        => new()
        {
            new CreatableAdventure
            {
                Type = AdventureType.GoblinBandits,
                Name = AdventureFactoryHelper.GetAdventureName(AdventureType.GoblinBandits),
                Description = "Un groupe de gobelins a attaqué la ville de Hollbrook. Le maire de la ville vous a demandé de l'aide.",
                CanBeStarted = CanBeStarted(AdventureType.GoblinBandits, existingAdventures)
            },
            new CreatableAdventure
            {
                Type = AdventureType.OnTheTrailOfEvil,
                Name = AdventureFactoryHelper.GetAdventureName(AdventureType.OnTheTrailOfEvil),
                Description = "Les gobelins ont été vaincus, mais le maire vous a demandé d'enquêter sur la source du mal qui a ravagé la ville.",
                CanBeStarted = CanBeStarted(AdventureType.OnTheTrailOfEvil, existingAdventures)
            },
            new CreatableAdventure
            {
                Type = AdventureType.HauntedVillage,
                Name = AdventureFactoryHelper.GetAdventureName(AdventureType.HauntedVillage),
                Description = "Vous avez éradiqué la source du mal principal mais vos pérégrinations vous ont conduit jusqu'à un étrange village hanté.",
                CanBeStarted = CanBeStarted(AdventureType.HauntedVillage, existingAdventures)
            }
        };

    private static bool CanBeStarted(AdventureType adventureType, List<Adventure> existingAdventures)
    {
        if (existingAdventures.Any(a => a.Type == adventureType))
            return false;

        if (adventureType == AdventureType.GoblinBandits)
            return true;

        if (adventureType == AdventureType.OnTheTrailOfEvil)
        {
            Adventure? previousadventure = existingAdventures.SingleOrDefault(ea => ea.Type == AdventureType.GoblinBandits && ea.EndsAt != null);
            return previousadventure is not null;
        }

        if (adventureType == AdventureType.HauntedVillage)
        {
            Adventure? previousadventure = existingAdventures.SingleOrDefault(ea => ea.Type == AdventureType.OnTheTrailOfEvil && ea.EndsAt != null);
            return previousadventure is not null;
        }

        return false;
    }
}
