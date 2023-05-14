using dnd_domain.Players.Enums;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Players.Configurations;

internal sealed class MonsterDalConfiguration : IEntityTypeConfiguration<MonsterDal>
{
    public void Configure(EntityTypeBuilder<MonsterDal> builder)
    {
        builder.ToTable("Monsters", ProjectSchema.Players);

        builder.HasKey(monster => monster.Id);

        builder.Property(monster => monster.Type).HasConversion(new EnumToStringConverter<MonsterType>());

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(monster => monster.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SquareDal>()
            .WithOne()
            .HasForeignKey<MonsterDal>(monster => monster.SquareId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
