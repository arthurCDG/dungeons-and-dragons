using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal sealed class SpellDalConfiguration : IEntityTypeConfiguration<SpellDal>
{
    public void Configure(EntityTypeBuilder<SpellDal> builder)
    {
        builder.ToTable("Spells", ProjectSchema.Items);

        builder.HasKey(spell => spell.Id);

        builder.Property(spell => spell.Type)
               .HasConversion(new EnumToStringConverter<SpellType>());

        builder.HasMany<StoredItemDal>()
               .WithOne(storedItem => storedItem.Spell)
               .HasForeignKey(storedItem => storedItem.SpellId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
