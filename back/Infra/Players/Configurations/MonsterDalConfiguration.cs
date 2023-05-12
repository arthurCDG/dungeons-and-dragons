using dnd_domain.Players.Enums;
using dnd_infra.Players.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Players.Configurations;

internal sealed class MonsterDalConfiguration : IEntityTypeConfiguration<MonsterDal>
{
    public void Configure(EntityTypeBuilder<MonsterDal> builder)
    {
        builder.ToTable("Monsters", "Players");

        builder.HasKey(monster => monster.Id);

        builder.Property(monster => monster.Type).HasConversion(new EnumToStringConverter<MonsterType>());

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(monster => monster.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
