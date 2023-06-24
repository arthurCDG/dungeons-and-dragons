using System.Collections.Generic;

namespace dnd_domain.Items.Models;

public class Artefact : Item
{
    public List<ArtefactEffect> Effects { get; set; } = new();
}
