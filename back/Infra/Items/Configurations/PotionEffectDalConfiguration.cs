using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionEffectDalConfiguration : IEntityTypeConfiguration<PotionEffectDal>
{
    public void Configure(EntityTypeBuilder<PotionEffectDal> builder)
    {
        builder.ToTable("PotionEffects", "Items");

        builder.HasKey(a => a.Id);

        builder.HasOne<PotionDal>()
            .WithMany(potion => potion.Effects)
            .HasForeignKey(effect => effect.PotionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
