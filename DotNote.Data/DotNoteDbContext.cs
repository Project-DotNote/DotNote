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
        public DotNoteDbContext(DbContextOptions<DotNoteDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; } = null!;
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<Update> Updates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(DotNoteDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}