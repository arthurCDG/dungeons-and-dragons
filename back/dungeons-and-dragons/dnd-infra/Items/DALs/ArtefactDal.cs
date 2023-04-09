using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class ArtefactDal : BaseItemDal
{
    public bool? DiscardAfterUsage { get; set; }
    public bool? CastDieToDiscardAfterUsage { get; set; }

    public List<ArtefactEffectDal> Effects { get; set; } = new();
}