using System.Collections.Generic;

namespace dnd_domain.Items.Models;

public class Artifact : Item
{
    public List<ArtifactEffect> Effects { get; set; } = new();
}
