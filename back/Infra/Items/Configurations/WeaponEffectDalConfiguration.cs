using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal class WeaponEffectDalConfiguration : IEntityTypeConfiguration<WeaponEffectDal>
{
    public void Configure(EntityTypeBuilder<WeaponEffectDal> builder)
    {
        builder.ToTable("WeaponEffects", "Items");

        builder.HasKey(weaponEffect => weaponEffect.Id);

        builder.Property(weaponEffect => weaponEffect.Effect).HasConversion(new EnumToStringConverter<WeaponEffectType>());
    }
}