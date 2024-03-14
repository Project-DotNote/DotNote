using DotNote.Data.Configurations;
using DotNote.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace DotNote.Data
{
    public class DotNoteDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
<<<<<<< HEAD
        public DotNoteDbContext(DbContextOptions<DotNoteDbContext> options)
            : base(options)
        {
        }

=======
        private readonly bool seedDb;
        public DotNoteDbContext(DbContextOptions<DotNoteDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = this.seedDb;
        }

        public DbSet<User> Users { get; set; } = null!;
>>>>>>> 22c7db02c71f4a11438dae0a031a5ec937952809
        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<Update> Updates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
<<<<<<< HEAD
            Assembly configAssembly = Assembly.GetAssembly(typeof(DotNoteDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);
=======
            builder
                .ApplyConfiguration(new FolderEntityConfiguration());
            builder
                .ApplyConfiguration(new NoteEntityConfiguration());
            //builder
            //  .ApplyConfiguration(new UserEntityConfiguration());

            if (this.seedDb)
            {
                builder
                    .ApplyConfiguration(new SeedNotesEntityConfiguration());
            }
>>>>>>> 22c7db02c71f4a11438dae0a031a5ec937952809

            base.OnModelCreating(builder);
        }
    }
}

