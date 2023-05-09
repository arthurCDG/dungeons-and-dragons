﻿using dnd_infra.Items.DALs;
using dnd_infra.Players.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Dice;

internal sealed class DieAssociationDalConfiguration : IEntityTypeConfiguration<DieAssociationDal>
{
    public void Configure(EntityTypeBuilder<DieAssociationDal> builder)
    {
        builder.ToTable("DieAssociations", "Dice");

        builder.HasKey(dieAssociation => dieAssociation.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ArtefactDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.ArtefactId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ChestTrapDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.ChestTrapId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PotionDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.PotionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SpellDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.SpellId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<WeaponDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.WeaponId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<WeaponSuperAttackDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.WeaponSuperAttackId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<HeroDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.HeroId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MonsterDal>()
            .WithMany()
            .HasForeignKey(dieAssociation => dieAssociation.MonsterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
