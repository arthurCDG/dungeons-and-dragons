using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class EffectDal
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int WeaponSuperAttackId { get; set; }
    public int Probability { get; set; } = 100;
    public required EffectType Type { get; set; }

    public int? Amount { get; set; }

    public Effect ToDomain()
        => new()
        {
            Id = Id,
            ItemId = ItemId,
            Type = Type,
            Amount = Amount,
            Probability = Probability
        };
}
