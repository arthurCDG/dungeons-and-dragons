using dnd_infra.Campaigns;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class WeaponDalConfiguration : IEntityTypeConfiguration<WeaponDal>
{
    public void Configure(EntityTypeBuilder<WeaponDal> builder)
    {
        builder.ToTable("Weapons", ProjectSchema.Items);

        builder.HasKey(weapon => weapon.Id);

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(weapon => weapon.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<StoredItemDal>()
            .WithOne(storedItem => storedItem.Weapon)
            .HasForeignKey(storedItem => storedItem.WeaponId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<WeaponSuperAttackDal>()
            .WithOne()
            .HasForeignKey<WeaponSuperAttackDal>(weaponSuperAttack => weaponSuperAttack.WeaponId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(weapon => weapon.Effects)
            .WithOne()
            .HasForeignKey(weaponEffect => weaponEffect.WeaponId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
