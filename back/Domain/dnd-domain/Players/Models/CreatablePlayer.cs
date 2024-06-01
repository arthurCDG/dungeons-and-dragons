using dnd_domain.Players.Enums;
using System.Collections.Generic;

namespace dnd_domain.Players.Models;

public class CreatablePlayer
{
    public required List<CreatableSpecies> AssociatedSpecies { get; set; }
    public required Class Class { get; set; }
    public required string Description { get; set; }
    public required string LokalisedClassName { get; set; }
    public required PlayerMaxAttributes MaxAttributes { get; set; }
}
