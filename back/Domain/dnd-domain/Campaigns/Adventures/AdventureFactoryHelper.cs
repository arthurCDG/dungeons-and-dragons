using System;

namespace dnd_domain.Campaigns.Adventures;

public static class AdventureFactoryHelper
{
    public static string GetAdventureName(AdventureType adventure)
    => adventure switch
    {
        AdventureType.GoblinBandits => "Les bandits gobelins", // TODO lokalise name
        AdventureType.OnTheTrailOfEvil => "Sur la piste du mal", // TODO lokalise name
        AdventureType.HauntedVillage => "Le village hanté", // TODO lokalise name
        _ => throw new ArgumentException($"Unknown adventure: {adventure}")
    };
}
