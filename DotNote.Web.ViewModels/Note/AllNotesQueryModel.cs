namespace DotNote.Web.ViewModels.Note
{
    using System.ComponentModel.DataAnnotations;

    using ViewModels.Enums;
    using static Common.GeneralApplicationConstants;
    public class AllNotesQueryModel
    {
        public AllNotesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.NotesPerPage = EntitiesPerPage;

            this.Notes = new HashSet<NoteAllViewModel>();
        }
        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Notes By")]
        public NoteSorting NoteSorting { get; set; }

        [Display(Name = "Show Notes On Page")]
        public int NotesPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalNotes { get; set; }

        public IEnumerable<NoteAllViewModel> Notes { get; set; }
    }
}
