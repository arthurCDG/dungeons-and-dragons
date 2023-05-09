using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ChestTrapEffectDalConfiguration : IEntityTypeConfiguration<ChestTrapEffectDal>
{
    public void Configure(EntityTypeBuilder<ChestTrapEffectDal> builder)
    {
        builder.ToTable("ChestTrapEffects", "Items");

        builder.HasKey(chestTrapEffect => chestTrapEffect.Id);

        builder.HasOne<ChestTrapDal>()
            .WithMany()
            .HasForeignKey(chestTrapEffect => chestTrapEffect.ChestTrapId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
