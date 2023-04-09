using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class ChestTrapDal : BaseItemDal
{
    public List<ChestTrapEffectDal> Effects { get; set; } = new();
}
