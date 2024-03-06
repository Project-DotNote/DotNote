using DotNote.Data.Configurations;
using DotNote.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DotNote.Data
{
    public class DotNoteDbContext : DbContext
    {
        private readonly bool seedDb;
        public DotNoteDbContext(DbContextOptions<DotNoteDbContext> options)
            : base(options)
        {
            //this.seedDb = seedDb;
        }

        //public DbSet<User> Users { get; set; } = null!;
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

            //if (this.seedDb)
            //{
            builder
                    .ApplyConfiguration(new SeedNotesEntityConfiguration());
            //}

            base.OnModelCreating(builder);
        }
    }
}

