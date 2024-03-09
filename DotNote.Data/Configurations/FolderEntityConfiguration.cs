using System.Text.RegularExpressions;
using DotNote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNote.Data.Configurations
{
    public class FolderEntityConfiguration : IEntityTypeConfiguration<Folder>
    {
        public void Configure(EntityTypeBuilder<Folder> builder)
        {
            builder
                .HasOne(g => g.User)
                .WithMany(u => u.Folders)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
