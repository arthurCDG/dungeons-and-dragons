using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class SpellEffectDalConfiguration : IEntityTypeConfiguration<SpellEffectDal>
{
    public void Configure(EntityTypeBuilder<SpellEffectDal> builder)
    {
        builder.ToTable("SpellEffects", "Items");

        builder.HasKey(a => a.Id);

        builder.HasOne<SpellDal>()
            .WithMany(spell => spell.Effects)
            .HasForeignKey(effect => effect.SpellId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}