using dnd_infra.Items.DALs;
using dnd_infra.Sessions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal sealed class ArtefactDalConfiguration : IEntityTypeConfiguration<ArtefactDal>
{
    public void Configure(EntityTypeBuilder<ArtefactDal> builder)
    {
        builder.ToTable("Artefacts", "Items");

        builder.HasKey(artefact => artefact.Id);

        builder.HasOne<SessionDal>()
            .WithMany()
            .HasForeignKey(artefact => artefact.SessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
