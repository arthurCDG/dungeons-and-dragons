using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class WeaponDalConfiguration : IEntityTypeConfiguration<WeaponDal>
{
    public void Configure(EntityTypeBuilder<WeaponDal> builder)
    {
        builder.ToTable("Weapons", ProjectSchema.Items);

        builder.HasKey(weapon => weapon.Id);

        builder.Property(weapon => weapon.Type)
               .HasConversion(new EnumToStringConverter<WeaponType>());

        builder.HasMany<StoredItemDal>()
               .WithOne(storedItem => storedItem.Weapon)
               .HasForeignKey(storedItem => storedItem.WeaponId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<WeaponSuperAttackDal>()
               .WithOne()
               .HasForeignKey<WeaponSuperAttackDal>(weaponSuperAttack => weaponSuperAttack.WeaponId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
