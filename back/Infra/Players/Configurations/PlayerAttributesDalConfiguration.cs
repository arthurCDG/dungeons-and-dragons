using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Players.Configurations;

internal sealed class PlayerAttributesDalConfiguration : IEntityTypeConfiguration<PlayerAttributesDal>
{
    public void Configure(EntityTypeBuilder<PlayerAttributesDal> builder)
    {
        builder.ToTable("PlayerAttributes", ProjectSchema.Players);
        builder.HasKey(p => p.Id);
    }
}
