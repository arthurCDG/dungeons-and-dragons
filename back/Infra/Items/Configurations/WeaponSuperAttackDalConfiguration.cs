using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class WeaponSuperAttackDalConfiguration : IEntityTypeConfiguration<WeaponSuperAttackDal>
{
    public void Configure(EntityTypeBuilder<WeaponSuperAttackDal> builder)
    {
        builder.ToTable("WeaponSuperAttacks", ProjectSchema.Items);

        builder.HasKey(weaponSuperAttack => weaponSuperAttack.Id);

        builder.Property(weaponSuperAttack => weaponSuperAttack.Type).HasConversion(new EnumToStringConverter<WeaponSuperAttackType>());

    }
}
