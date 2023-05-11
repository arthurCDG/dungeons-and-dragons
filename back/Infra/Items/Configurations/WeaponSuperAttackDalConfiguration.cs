using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class WeaponSuperAttackDalConfiguration : IEntityTypeConfiguration<WeaponSuperAttackDal>
{
    public void Configure(EntityTypeBuilder<WeaponSuperAttackDal> builder)
    {
        builder.ToTable("WeaponSuperAttacks", "Items");

        builder.HasKey(weaponSuperAttack => weaponSuperAttack.Id);

        builder.HasOne<WeaponSuperAttackDal>()
            .WithOne()
            .HasForeignKey<WeaponSuperAttackDal>(weaponSuperAttack => weaponSuperAttack.WeaponId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
