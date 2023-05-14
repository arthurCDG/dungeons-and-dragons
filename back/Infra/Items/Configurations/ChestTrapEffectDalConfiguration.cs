using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class ChestTrapEffectDalConfiguration : IEntityTypeConfiguration<ChestTrapEffectDal>
{
    public void Configure(EntityTypeBuilder<ChestTrapEffectDal> builder)
    {
        builder.ToTable("ChestTrapEffects", ProjectSchema.Items);

        builder.HasKey(chestTrapEffect => chestTrapEffect.Id);

        builder.Property(chestTrapEffect => chestTrapEffect.Effect).HasConversion(new EnumToStringConverter<ChestTrapEffectType>());

        builder.HasOne<ChestTrapDal>()
            .WithMany(chestTrap => chestTrap.Effects)
            .HasForeignKey(chestTrapEffect => chestTrapEffect.ChestTrapId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
