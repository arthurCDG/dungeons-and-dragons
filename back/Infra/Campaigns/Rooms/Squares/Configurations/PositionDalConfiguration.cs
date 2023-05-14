using dnd_infra.Campaigns.Rooms.Squares.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Campaigns.Rooms.Squares.Configurations;

internal sealed class PositionDalConfiguration : IEntityTypeConfiguration<PositionDal>
{
    public void Configure(EntityTypeBuilder<PositionDal> builder)
    {
        builder.ToTable("Positions", ProjectSchema.Campaigns);

        builder.HasKey(position => position.Id);
    }
}
