using dnd_infra.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Campaigns;

internal sealed class CampaignDalConfiguration : IEntityTypeConfiguration<CampaignDal>
{
    public void Configure(EntityTypeBuilder<CampaignDal> builder)
    {
        builder.ToTable("Campaigns", ProjectSchema.Campaigns);

        builder.HasKey(campaign => campaign.Id);

        builder.Property(campaign => campaign.StartsAt)
            .HasColumnType("datetime2(2)");

        builder.Property(campaign => campaign.EndsAt)
             .HasColumnType("datetime2(2)");

        builder.HasMany<UserCampaignAssociationDal>()
            .WithOne()
            .HasForeignKey(uca => uca.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(campaign => campaign.Adventures)
            .WithOne()
            .HasForeignKey(adventure => adventure.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
