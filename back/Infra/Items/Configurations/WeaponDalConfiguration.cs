﻿using dnd_infra.Items.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class WeaponDalConfiguration : IEntityTypeConfiguration<WeaponDal>
{
    public void Configure(EntityTypeBuilder<WeaponDal> builder)
    {
        builder.ToTable("Weapons", "Items");

        builder.HasKey(weapon => weapon.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(weapon => weapon.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StoredItemDal>()
            .WithOne(storedItem => storedItem.Weapon)
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.WeaponId)
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