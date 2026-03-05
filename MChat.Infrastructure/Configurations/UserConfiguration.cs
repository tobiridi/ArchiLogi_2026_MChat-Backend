using MChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(u => u.Password)
                .HasColumnType("nvarchar")
                .HasMaxLength(84)
                .IsRequired();

            builder.Property(u => u.Username)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.CreateAt)
                .HasColumnType("date")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.LastUpdate)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            //constraints
            builder.HasKey(u => u.Id)
                .HasName("PK_Users");

            builder.HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("UK_Users__email");

            builder.HasIndex(u => u.Username)
                .IsUnique()
                .HasDatabaseName("UK_Users__username");
        }
    }
}
