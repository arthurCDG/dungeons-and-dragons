using dnd_domain.Players.Enums;
using dnd_infra.Dice;
using System.Collections.Generic;

namespace dnd_infra.Players.DALs;

internal sealed class MonsterDal : PlayerDal
{
    public MonsterType Type { get; set; } = new();
    public List<DieAssociationDal> MeleeAttackDice { get; set; } = new();
    public List<DieAssociationDal> RangeAttackDice { get; set; } = new();
}
