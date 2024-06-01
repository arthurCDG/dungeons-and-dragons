using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dnd_infra.Users;

internal sealed class UserDalConfiguration : IEntityTypeConfiguration<UserDal>
{
    public void Configure(EntityTypeBuilder<UserDal> builder)
    {
        builder.ToTable("Users", ProjectSchema.Users);

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .ValueGeneratedOnAdd();

        builder.Property(u => u.Name)
               .HasMaxLength(55);

        builder.Property(u => u.PasswordHash)
               .HasMaxLength(255);

        builder.Property(u => u.PasswordResetToken)
               .HasMaxLength(255);

        builder.Property(u => u.PasswordSalt)
               .HasMaxLength(255);

        builder.Property(u => u.PictureUrl)
               .HasMaxLength(255);

        builder.HasMany(u => u.Players)
               .WithOne()
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
