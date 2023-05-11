using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class SpellEffectDalConfiguration : IEntityTypeConfiguration<SpellEffectDal>
{
    public void Configure(EntityTypeBuilder<SpellEffectDal> builder)
    {
        builder.ToTable("SpellEffects", "Items");

        builder.HasKey(spellEffect => spellEffect.Id);

        builder.Property(spellEffect => spellEffect.Effect).HasConversion(new EnumToStringConverter<SpellEffectType>());

        builder.HasOne<SpellDal>()
            .WithMany(spell => spell.Effects)
            .HasForeignKey(spellEffect => spellEffect.SpellId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}