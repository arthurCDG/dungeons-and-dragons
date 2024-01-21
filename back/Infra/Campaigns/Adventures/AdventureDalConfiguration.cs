using dnd_domain.Campaigns.Adventures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Campaigns.Adventures;

internal class AdventureDalConfiguration : IEntityTypeConfiguration<AdventureDal>
{
    public void Configure(EntityTypeBuilder<AdventureDal> builder)
    {
        builder.ToTable("Adventures", ProjectSchema.Campaigns);

        builder.HasKey(adventure => adventure.Id);

        builder.Property(p => p.Type).HasConversion(new EnumToStringConverter<AdventureType>());

        builder.HasMany(adventure => adventure.Rooms)
            .WithOne()
            .HasForeignKey(room => room.AdventureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
