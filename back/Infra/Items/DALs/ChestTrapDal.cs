using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class ChestTrapDal : ItemDal
{
    public List<ChestTrapEffectDal> Effects { get; set; } = new();
}
