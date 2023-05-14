using dnd_domain.Players.Enums;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Players.Configurations;

internal sealed class HeroDalConfiguration : IEntityTypeConfiguration<HeroDal>
{
    public void Configure(EntityTypeBuilder<HeroDal> builder)
    {
        builder.ToTable("Heroes", ProjectSchema.Players);

        builder.HasKey(hero => hero.Id);

        builder.Property(hero => hero.Class).HasConversion(new EnumToStringConverter<HeroClass>());
        builder.Property(hero => hero.Race).HasConversion(new EnumToStringConverter<HeroRace>());

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(hero => hero.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SquareDal>()
            .WithOne()
            .HasForeignKey<HeroDal>(hero => hero.SquareId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
