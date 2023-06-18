using dnd_domain.Players.Models;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerMaxAttributesDal
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int MaxLifePoints { get; set; }
    public int MaxManaPoints { get; set; }
    public int MaxFootSteps { get; set; }
    public int MaxShield { get; set; }
    public int MaxAttackCount { get; set; }
    public int MaxHealCount { get; set; }
    public int MaxChestSearchCount { get; set; }
    public int MaxTrapSearchCount { get; set; }

    public PlayerMaxAttributes ToDomain()
        => new()
        {
            Id = Id,
            PlayerId = PlayerId,
            MaxLifePoints = MaxLifePoints,
            MaxManaPoints = MaxManaPoints,
            MaxFootSteps = MaxFootSteps,
            MaxShield = MaxShield,
            MaxAttackCount = MaxAttackCount,
            MaxHealCount = MaxHealCount,
            MaxChestSearchCount = MaxChestSearchCount,
            MaxTrapSearchCount = MaxTrapSearchCount,
        };
}
