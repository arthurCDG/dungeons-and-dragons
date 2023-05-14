using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class ArtefactEffectDal
{
    public int Id { get; set; }
    public int ArtefactId { get; set; }
    public ArtefactEffectType Effect { get; set; }

    public ArtefactEffect ToDomain()
        => new()
        {
            Id = Id,
            ArtefactId = ArtefactId,
            Effect = Effect
        };
}
