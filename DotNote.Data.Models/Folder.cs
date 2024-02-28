using System.ComponentModel.DataAnnotations;
using static DotNote.Common.EntityValidations.Folder;

namespace DotNote.Data.Models
{
    public class Folder
    {
        public Folder()
        {
            this.Id = Guid.NewGuid();

            this.Notes = new HashSet<Note>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(MaxNameLength, MinimumLength = MinNameLength)]
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Note> Notes { get; set; }

    }
}
