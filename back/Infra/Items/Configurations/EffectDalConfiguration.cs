using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class EffectDalConfiguration : IEntityTypeConfiguration<EffectDal>
{
    public void Configure(EntityTypeBuilder<EffectDal> builder)
    {
        builder.ToTable("Effects", ProjectSchema.Items);

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Type).HasConversion(new EnumToStringConverter<EffectType>());

        builder.HasOne<ItemDal>()
               .WithMany(i => i.Effects)
               .HasForeignKey(e => e.ItemId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}