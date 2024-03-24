namespace DotNote.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DotNote.Common.EntityValidations.Note;

    public class Note
    {
        public Note()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; } = null!;

        [MaxLength(MaxSubtitleLength)]
        public string? Subtitle { get; set; }

        [MaxLength(MaxTextLength)]
        public string? Text { get; set; }

        public DateTime CreatedAt { get; set; }

        //Must be implemented logic
        //public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
