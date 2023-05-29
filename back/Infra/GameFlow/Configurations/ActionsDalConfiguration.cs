using dnd_infra.GameFlow.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.GameFlow.Configurations;

internal sealed class ActionsDalConfiguration : IEntityTypeConfiguration<ActionsDal>
{
    public void Configure(EntityTypeBuilder<ActionsDal> builder)
    {
        builder.ToTable("Actions", ProjectSchema.GameFlow);

        builder.HasKey(actions => actions.Id);

        builder.HasOne<HeroDal>()
            .WithOne(h => h.Actions)
            .HasForeignKey<ActionsDal>(actions => actions.HeroId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<MonsterDal>()
            .WithOne(m => m.Actions)
            .HasForeignKey<ActionsDal>(actions => actions.MonsterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
