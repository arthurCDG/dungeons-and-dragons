using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace dnd_infra.Items.Configurations;

internal class ArtifactEffectDalConfiguration : IEntityTypeConfiguration<ArtifactEffectDal>
{
    public void Configure(EntityTypeBuilder<ArtifactEffectDal> builder)
    {
        builder.ToTable("ArtifactEffects", ProjectSchema.Items);

        builder.HasKey(artifactEffect => artifactEffect.Id);

        builder.Property(artifactEffect => artifactEffect.Effect).HasConversion(new EnumToStringConverter<ArtifactEffectType>());

        builder.HasOne<ArtifactDal>()
            .WithMany(a => a.Effects)
            .HasForeignKey(artifactEffect => artifactEffect.ArtifactId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
