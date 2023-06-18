using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Users;

internal sealed class UserCampaignAssociationDalConfiguration : IEntityTypeConfiguration<UserCampaignAssociationDal>
{
    public void Configure(EntityTypeBuilder<UserCampaignAssociationDal> builder)
    {
        builder.ToTable("UserCampaignAssociations", ProjectSchema.Users);

        builder.HasKey(uca => uca.Id);
    }
}
