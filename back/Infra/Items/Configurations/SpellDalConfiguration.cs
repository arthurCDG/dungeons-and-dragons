using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class SpellDalConfiguration : IEntityTypeConfiguration<SpellDal>
{
    public void Configure(EntityTypeBuilder<SpellDal> builder)
    {
        builder.ToTable("Spells", ProjectSchema.Items);

        builder.HasKey(spell => spell.Id);

        builder.HasMany<StoredItemDal>()
            .WithOne(storedItem => storedItem.Spell)
            .HasForeignKey(storedItem => storedItem.SpellId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
