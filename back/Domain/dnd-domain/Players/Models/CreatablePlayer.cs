using System.Collections.Generic;

namespace dnd_domain.Players.Models;

public class CreatablePlayer
{
    public required List<CreatableSpecies> AssociatedSpecies { get; set; }
    public required CreatableClass Class { get; set; }
    public required string Description { get; set; }
    public required PlayerMaxAttributes MaxAttributes { get; set; }
}
