using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Players.Configurations;

internal sealed class PlayerMaxAttributesDalConfiguration : IEntityTypeConfiguration<PlayerMaxAttributesDal>
{
    public void Configure(EntityTypeBuilder<PlayerMaxAttributesDal> builder)
    {
        builder.ToTable("PlayerMaxAttributes", ProjectSchema.Players);
        builder.HasKey(p => p.Id);
    }
}