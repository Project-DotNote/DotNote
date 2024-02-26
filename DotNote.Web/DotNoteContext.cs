using DotNote.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNote.Web
{
    public class DotNoteContext : DbContext
    {
        public DotNoteContext(DbContextOptions<DotNoteContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Update> Updates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Note>().HasKey(n => n.Id);
            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Update>().HasKey(u => u.Id);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Group>()
                .HasOne(g => g.User)
                .WithMany(u => u.Groups)
                .HasForeignKey(g => g.UserId);

            modelBuilder.Entity<Note>()
                .Property(n => n.Status)
                .HasConversion<string>();

        }
    }
}
