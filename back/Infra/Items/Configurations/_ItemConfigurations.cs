using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Items.Configurations;

internal static class ItemConfigurations
{
    public static void ApplyItemConfigurations(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StoredItemDalConfiguration());

        modelBuilder.ApplyConfiguration(new ArtifactDalConfiguration());
        modelBuilder.ApplyConfiguration(new ArtifactEffectDalConfiguration());

        modelBuilder.ApplyConfiguration(new ChestTrapDalConfiguration());
        modelBuilder.ApplyConfiguration(new ChestTrapEffectDalConfiguration());

        modelBuilder.ApplyConfiguration(new PotionDalConfiguration());
        modelBuilder.ApplyConfiguration(new PotionEffectDalConfiguration());

        modelBuilder.ApplyConfiguration(new SpellDalConfiguration());
        modelBuilder.ApplyConfiguration(new SpellEffectDalConfiguration());

        modelBuilder.ApplyConfiguration(new WeaponDalConfiguration());
        modelBuilder.ApplyConfiguration(new WeaponEffectDalConfiguration());
        modelBuilder.ApplyConfiguration(new WeaponSuperAttackDalConfiguration());
    }
}
