using dnd_infra.Campaigns;
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

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(spell => spell.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StoredItemDal>()
            .WithOne(storedItem => storedItem.Spell)
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.SpellId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
