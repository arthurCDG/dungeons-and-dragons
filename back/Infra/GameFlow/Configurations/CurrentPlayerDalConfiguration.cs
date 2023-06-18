using dnd_infra.Campaigns;
using dnd_infra.GameFlow.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.GameFlow.Configurations;

internal sealed class CurrentPlayerDalConfiguration : IEntityTypeConfiguration<CurrentPlayerDal>
{
    public void Configure(EntityTypeBuilder<CurrentPlayerDal> builder)
    {
        builder.ToTable("CurrentPlayers", ProjectSchema.GameFlow);

        builder.HasKey(currentPlayer => currentPlayer.Id);

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(currentPlayer => currentPlayer.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cp => cp.Hero)
            .WithOne()
            .HasForeignKey<CurrentPlayerDal>(currentPlayer => currentPlayer.HeroId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cp => cp.Monster)
            .WithOne()
            .HasForeignKey<CurrentPlayerDal>(currentPlayer => currentPlayer.MonsterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
