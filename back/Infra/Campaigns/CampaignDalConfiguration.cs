using dnd_infra.Sessions;
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

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(campaign => campaign.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(campaign => campaign.Rooms)
            .WithOne()
            .HasForeignKey(board => board.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(campaign => campaign.Heroes)
            .WithOne()
            .HasForeignKey(hero => hero.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(campaign => campaign.Monsters)
            .WithOne()
            .HasForeignKey(monster => monster.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
