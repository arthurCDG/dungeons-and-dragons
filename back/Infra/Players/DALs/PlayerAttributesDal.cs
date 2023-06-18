using dnd_domain.Players.Models;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerAttributesDal
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int LifePoints { get; set; }
    public int ManaPoints { get; set; }
    public int FootSteps { get; set; }
    public int Shield { get; set; }
    public int AttackCount { get; set; }
    public int HealCount { get; set; }
    public int ChestSearchCount { get; set; }
    public int TrapSearchCount { get; set; }

    public PlayerAttributes ToDomain()
        => new()
        {
            Id = Id,
            PlayerId = PlayerId,
            LifePoints = LifePoints,
            ManaPoints = ManaPoints,
            FootSteps = FootSteps,
            AttackCount = AttackCount,
            HealCount = HealCount,
            ChestSearchCount = ChestSearchCount,
            TrapSearchCount = TrapSearchCount,
        };
}
