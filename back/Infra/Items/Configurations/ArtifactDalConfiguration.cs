using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ArtifactDalConfiguration : IEntityTypeConfiguration<ArtifactDal>
{
    public void Configure(EntityTypeBuilder<ArtifactDal> builder)
    {
        builder.ToTable("Artifacts", ProjectSchema.Items);

        builder.HasKey(artifact => artifact.Id);

        builder.HasMany<StoredItemDal>()
               .WithOne(storedItem => storedItem.Artifact)
               .HasForeignKey(storedItem => storedItem.ArtifactId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
