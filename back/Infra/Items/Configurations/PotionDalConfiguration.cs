using dnd_infra.Campaigns;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class PotionDalConfiguration : IEntityTypeConfiguration<PotionDal>
{
    public void Configure(EntityTypeBuilder<PotionDal> builder)
    {
        builder.ToTable("Potions", ProjectSchema.Items);

        builder.HasKey(potion => potion.Id);

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(potion => potion.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StoredItemDal>()
            .WithOne(storedItem => storedItem.Potion)
            .HasForeignKey<StoredItemDal>(storedItem => storedItem.PotionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
