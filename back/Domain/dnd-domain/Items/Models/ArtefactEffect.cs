using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class ArtefactEffect
{
    public int Id { get; set; }
    public int ArtefactId { get; set; }
    public ArtefactEffectType Effect { get; set; } = new();
}
