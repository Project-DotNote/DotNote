using DotNote.Data.Configurations;
using DotNote.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNote.Data
{
    public class DotNoteDbContext : IdentityDbContext
    {
        public DotNoteDbContext(DbContextOptions<DotNoteDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<Update> Updates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new FolderEntityConfiguration());
            builder
            .ApplyConfiguration(new NoteEntityConfiguration());
            builder
                .ApplyConfiguration(new UpdateEntityConfiguration());
            builder
            .ApplyConfiguration(new UserEntityConfiguration());

            base.OnModelCreating(builder);
        }
    }
}

