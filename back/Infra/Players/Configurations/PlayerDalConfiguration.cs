using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
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

        builder.HasOne(p => p.Profile)
            .WithOne()
            .HasForeignKey<PlayerProfileDal>(pp => pp.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Attributes)
            .WithOne()
            .HasForeignKey<PlayerAttributesDal>(pp => pp.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.MaxAttributes)
            .WithOne()
            .HasForeignKey<PlayerMaxAttributesDal>(pp => pp.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<SquareDal>()
            .WithOne()
            .HasForeignKey<PlayerDal>(p => p.SquareId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Campaigns)
            .WithMany(c => c.Players);
    }
}
