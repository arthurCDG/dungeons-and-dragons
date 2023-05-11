using dnd_infra.Items.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class SpellDalConfiguration : IEntityTypeConfiguration<SpellDal>
{
    public void Configure(EntityTypeBuilder<SpellDal> builder)
    {
        builder.ToTable("Spells", "Items");

        builder.HasKey(spell => spell.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(spell => spell.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StoredItemDal>()
            .WithOne(storedItem => storedItem.Spell)
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.SpellId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
