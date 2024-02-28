using DotNote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNote.Data.Configurations
{
    public class UpdateEntityConfiguration : IEntityTypeConfiguration<Update>
    {
        public void Configure(EntityTypeBuilder<Update> builder)
        {
            
        }
    }
}
