using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Items.Configurations;

internal class ArtefactEffectDalConfiguration : IEntityTypeConfiguration<ArtefactEffectDal>
{
    public void Configure(EntityTypeBuilder<ArtefactEffectDal> builder)
    {
        builder.ToTable("ArtefactEffects", "Items");
        builder.HasKey(a => a.Id);

        builder.HasOne<ArtefactDal>()
            .WithMany(artefact => artefact.Effects)
            .HasForeignKey(effect => effect.ArtefactId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
