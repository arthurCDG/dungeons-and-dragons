using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal class ArtefactDalConfiguration : IEntityTypeConfiguration<ArtefactDal>
{
    public void Configure(EntityTypeBuilder<ArtefactDal> builder)
    {
        builder.ToTable("Artefacts", "Items");

        builder.HasKey(a => a.Id);
    }
}
