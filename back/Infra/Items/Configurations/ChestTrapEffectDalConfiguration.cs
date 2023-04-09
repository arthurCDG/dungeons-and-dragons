using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ChestTrapEffectDalConfiguration : IEntityTypeConfiguration<ChestTrapEffectDal>
{
    public void Configure(EntityTypeBuilder<ChestTrapEffectDal> builder)
    {
        builder.ToTable("ChestTrapEffects", "Items");

        builder.HasKey(a => a.Id);

        builder.HasOne<ChestTrapDal>()
            .WithMany(chestTrap => chestTrap.Effects)
            .HasForeignKey(effect => effect.ChestTrapId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
