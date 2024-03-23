namespace DotNote.Web.ViewModels.Note
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidations.Note;

    public class NoteFormModel
    {
        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(MaxSubtitleLength)]
        public string? Subtitle { get; set; }
        [Required]
        [StringLength(MaxTextLength)]
        public string? Text { get; set; } = null!;
    }
}
