using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class TeamChatConfiguration : IEntityTypeConfiguration<TeamChat>
    {
        public void Configure(EntityTypeBuilder<TeamChat> builder)
        {
            builder.ToTable("Teams");

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.TeamName)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.CoverImageUrl)
                .HasColumnType("nvarchar(MAX)");

            //constraints
            builder.HasKey(t => t.Id)
                .HasName("PK_Teams");

            //foreign key
            builder.HasOne(t => t.Creator)
                .WithMany(u => u.MyTeamChats)
                .HasForeignKey("Id_Creator")
                .HasConstraintName("FK_Teams_Users")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
