using dnd_domain.Players.Enums;
using dnd_infra.Players.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Players.Configurations;

internal sealed class HeroDalConfiguration : IEntityTypeConfiguration<HeroDal>
{
    public void Configure(EntityTypeBuilder<HeroDal> builder)
    {
        builder.ToTable("Heroes", "Players");

        builder.HasKey(hero => hero.Id);

        builder.Property(hero => hero.Class).HasConversion(new EnumToStringConverter<HeroClass>());
        builder.Property(hero => hero.Race).HasConversion(new EnumToStringConverter<HeroRace>());

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(hero => hero.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
