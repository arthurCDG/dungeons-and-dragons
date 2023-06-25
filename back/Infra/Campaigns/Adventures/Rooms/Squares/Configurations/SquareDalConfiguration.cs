using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.Configurations;

internal sealed class SquareDalConfiguration : IEntityTypeConfiguration<SquareDal>
{
    public void Configure(EntityTypeBuilder<SquareDal> builder)
    {
        builder.ToTable("Squares", ProjectSchema.Campaigns);

        builder.HasKey(square => square.Id);

        builder.HasOne(square => square.Position)
            .WithOne()
            .HasForeignKey<PositionDal>(square => square.SquareId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(square => square.Trap)
             .WithOne()
             .HasForeignKey<SquareTrapDal>(square => square.SquareId)
             .OnDelete(DeleteBehavior.Restrict);
    }
}
