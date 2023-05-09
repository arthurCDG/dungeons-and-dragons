using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionEffectDalConfiguration : IEntityTypeConfiguration<PotionEffectDal>
{
    public void Configure(EntityTypeBuilder<PotionEffectDal> builder)
    {
        builder.ToTable("PotionEffects", "Items");

        builder.HasKey(potionEffect => potionEffect.Id);

        builder.HasOne<PotionDal>()
            .WithMany()
            .HasForeignKey(potionEffect => potionEffect.PotionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
