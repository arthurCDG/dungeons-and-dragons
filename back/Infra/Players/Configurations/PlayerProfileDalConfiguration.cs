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

        builder.Property(p => p.Id)
               .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
               .HasMaxLength(55);

        builder.Property(p => p.ImageUrl)
               .HasMaxLength(255);

        builder.Property(p => p.Gender)
               .HasMaxLength(55)
               .HasConversion(new EnumToStringConverter<PlayerGender>());

        builder.Property(p => p.Class)
               .HasMaxLength(55)
               .HasConversion(new EnumToStringConverter<Class>());

        builder.Property(p => p.Species)
               .HasMaxLength(55)
               .HasConversion(new EnumToStringConverter<Species>());

        builder.Property(p => p.Role)
               .HasMaxLength(55)
               .HasConversion(new EnumToStringConverter<PlayerRole>());
    }
}
