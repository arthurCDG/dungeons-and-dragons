using dnd_domain.Boards.Enums;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.Configurations;
internal sealed class SquareTrapDalConfiguration : IEntityTypeConfiguration<SquareTrapDal>
{
    public void Configure(EntityTypeBuilder<SquareTrapDal> builder)
    {
        builder.ToTable("SquareTraps", ProjectSchema.Campaigns);

        builder.HasKey(squareTrap => squareTrap.Id);

        builder.Property(squareTrap => squareTrap.Type).HasConversion(new EnumToStringConverter<SquareTrapType>());
    }
}
