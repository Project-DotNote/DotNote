namespace DotNote.Web.ViewModels.Note
{
    using System.ComponentModel.DataAnnotations;

    public class NoteAllViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Subtitle { get; set; } = null!;
        public string Text { get; set; } = null!;

        [Display(Name = "Created At")]
        public string CreatedAt { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
