using dnd_domain.Dice;
using System.Collections.Generic;

namespace dnd_infra.Dice;

internal sealed class DieDal
{
    public int Id { get; set; }
    public DieType Type { get; set; } = new();
    public List<int> Values { get; set; } = new();
}
