using dnd_domain.Items.Enums;

namespace dnd_infra.Items.DALs;

internal sealed class ArtefactEffectDal
{
    public int Id { get; set; }
    public int ArtefactId { get; set; }
    public ArtefactEffect Effect { get; set; }
}
