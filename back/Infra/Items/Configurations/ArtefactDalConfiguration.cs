using dnd_infra.Campaigns;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ArtefactDalConfiguration : IEntityTypeConfiguration<ArtefactDal>
{
    public void Configure(EntityTypeBuilder<ArtefactDal> builder)
    {
        builder.ToTable("Artefacts", ProjectSchema.Items);

        builder.HasKey(artefact => artefact.Id);

        builder.HasOne<CampaignDal>()
            .WithMany()
            .HasForeignKey(artefact => artefact.CampaignId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany<StoredItemDal>()
            .WithOne(storedItem => storedItem.Artefact)
            .HasForeignKey(storedItem => storedItem.ArtefactId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
