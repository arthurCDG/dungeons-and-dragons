using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Players.Configurations;

internal sealed class PlayerDalConfiguration : IEntityTypeConfiguration<PlayerDal>
{
    public void Configure(EntityTypeBuilder<PlayerDal> builder)
    {
        builder.ToTable("Players", ProjectSchema.Players);

        builder.HasKey(p => p.Id);

        builder.HasOne<SquareDal>()
            .WithOne()
            .HasForeignKey<PlayerDal>(p => p.SquareId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Campaigns)
            .WithMany(c => c.Players);
    }
}
