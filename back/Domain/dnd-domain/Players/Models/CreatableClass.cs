using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public sealed class CreatableClass
{
    public required Class Type { get; set; }
    public required string LokalisedClassName { get; set; }
}
