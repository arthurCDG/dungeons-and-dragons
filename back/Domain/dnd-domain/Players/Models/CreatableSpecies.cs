using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public sealed class CreatableSpecies
{
    public required string LokalisedSpeciesName { get; set; }
    public required Species Species { get; set; }
}
