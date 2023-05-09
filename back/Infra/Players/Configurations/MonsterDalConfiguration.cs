using dnd_infra.Players.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Players.Configurations;

internal sealed class MonsterDalConfiguration : IEntityTypeConfiguration<MonsterDal>
{
    public void Configure(EntityTypeBuilder<MonsterDal> builder)
    {
        builder.ToTable("Monsters", "Players");

        builder.HasKey(monster => monster.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(monster => monster.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
