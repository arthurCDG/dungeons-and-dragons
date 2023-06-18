using dnd_infra.Campaigns.Adventures;
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

        builder.HasOne<AdventureDal>()
            .WithMany()
            .HasForeignKey(currentPlayer => currentPlayer.AdventureId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cp => cp.Player)
            .WithOne()
            .HasForeignKey<CurrentPlayerDal>(currentPlayer => currentPlayer.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
