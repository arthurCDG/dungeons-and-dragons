using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Campaigns.Rooms;
internal sealed class RoomDalConfiguration : IEntityTypeConfiguration<RoomDal>
{
    public void Configure(EntityTypeBuilder<RoomDal> builder)
    {
        builder.ToTable("Rooms", ProjectSchema.Campaigns);

        builder.HasKey(room => room.Id);

        builder.HasMany(room => room.Squares)
            .WithOne()
            .HasForeignKey(square => square.RoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
