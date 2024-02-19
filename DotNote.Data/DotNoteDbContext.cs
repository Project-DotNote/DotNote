using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNote.Web.Data
{
    public class DotNoteDbContext : IdentityDbContext
    {
        public DotNoteDbContext(DbContextOptions<DotNoteDbContext> options)
            : base(options)
        {
        }
    }
}