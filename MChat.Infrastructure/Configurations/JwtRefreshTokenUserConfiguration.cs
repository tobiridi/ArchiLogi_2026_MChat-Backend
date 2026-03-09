using MChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class JwtRefreshTokenUserConfiguration : IEntityTypeConfiguration<JwtRefreshTokenUser>
    {
        public void Configure(EntityTypeBuilder<JwtRefreshTokenUser> builder)
        {
            builder.ToTable("UsersRefreshToken");

            builder.Property(t => t.RefreshToken)
                .HasColumnType("nvarchar")
                .HasMaxLength(90)
                .IsRequired();

            builder.Property(t => t.ExpiresAt)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(t => t.IsRevoked)
                .HasColumnType("bit")
                .IsRequired();

            //constraints
            builder.HasKey(t => t.RefreshToken)
                .HasName("PK_UsersRefreshToken");

            //foreign key
            builder.HasOne(t => t.User)
                .WithOne()
                .HasForeignKey(nameof(JwtRefreshTokenUser))
                .HasConstraintName("FK_UsersRefreshToken_Users")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
