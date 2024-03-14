using System.ComponentModel.DataAnnotations;
using static DotNote.Common.EntityValidations.Note;

namespace DotNote.Data.Models
{
    public class Note
    {
        public Note()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxSubtitleLength, MinimumLength = MinSubtitleLength)]
        public string Subtitle { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        //Must be implemented logic
        //public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
