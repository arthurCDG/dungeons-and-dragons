using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Items.Configurations;

internal static class ItemConfigurations
{
    public static void ApplyItemConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StoredItemDalConfiguration());
        modelBuilder.ApplyConfiguration(new EffectDalConfiguration());
        modelBuilder.ApplyConfiguration(new ArtifactDalConfiguration());
        modelBuilder.ApplyConfiguration(new ChestTrapDalConfiguration());
        modelBuilder.ApplyConfiguration(new PotionDalConfiguration());
        modelBuilder.ApplyConfiguration(new SpellDalConfiguration());
        modelBuilder.ApplyConfiguration(new WeaponDalConfiguration());
        modelBuilder.ApplyConfiguration(new WeaponSuperAttackDalConfiguration());
    }
}
