using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using dnd_domain.Items.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionEffectDalConfiguration : IEntityTypeConfiguration<PotionEffectDal>
{
    public void Configure(EntityTypeBuilder<PotionEffectDal> builder)
    {
        builder.ToTable("PotionEffects", "Items");

        builder.HasKey(potionEffect => potionEffect.Id);

        builder.Property(potionEffect => potionEffect.Effect).HasConversion(new EnumToStringConverter<PotionEffectType>());

        builder.HasOne<PotionDal>()
            .WithMany(potion => potion.Effects)
            .HasForeignKey(potionEffect => potionEffect.PotionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
