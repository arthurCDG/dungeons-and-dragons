using dnd_domain.Players.Enums;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Players.Configurations;

internal sealed class PlayerProfileDalConfiguration : IEntityTypeConfiguration<PlayerProfileDal>
{
    public void Configure(EntityTypeBuilder<PlayerProfileDal> builder)
    {
        builder.ToTable("PlayerProfiles", ProjectSchema.Players);

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Gender).HasConversion(new EnumToStringConverter<PlayerGender>());
        builder.Property(p => p.Class).HasConversion(new EnumToStringConverter<Class>());
        builder.Property(p => p.Race).HasConversion(new EnumToStringConverter<Race>());
        builder.Property(p => p.Role).HasConversion(new EnumToStringConverter<PlayerRole>());
    }
}
