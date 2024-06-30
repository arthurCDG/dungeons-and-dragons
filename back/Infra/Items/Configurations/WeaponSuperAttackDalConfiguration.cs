using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class WeaponSuperAttackDalConfiguration : IEntityTypeConfiguration<WeaponSuperAttackDal>
{
    public void Configure(EntityTypeBuilder<WeaponSuperAttackDal> builder)
    {
        builder.ToTable("WeaponSuperAttacks", ProjectSchema.Items);

        builder.HasKey(weaponSuperAttack => weaponSuperAttack.Id);

        builder.HasMany(wsa => wsa.Effects)
               .WithOne()
               .HasForeignKey(e => e.WeaponSuperAttackId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
