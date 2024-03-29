﻿using dnd_infra.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Campaigns;

internal sealed class CampaignDalConfiguration : IEntityTypeConfiguration<CampaignDal>
{
    public void Configure(EntityTypeBuilder<CampaignDal> builder)
    {
        builder.ToTable("Campaigns", ProjectSchema.Campaigns);

        builder.HasKey(campaign => campaign.Id);

        builder.Property(campaign => campaign.Name).HasMaxLength(255);

        builder.HasMany(c => c.Players)
            .WithOne()
            .HasForeignKey(p => p.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(campaign => campaign.Adventures)
            .WithOne()
            .HasForeignKey(adventure => adventure.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<UserDal>()
            .WithMany()
            .HasForeignKey(campaign => campaign.DungeonMasterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
