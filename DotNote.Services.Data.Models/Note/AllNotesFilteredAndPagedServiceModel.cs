namespace DotNote.Services.Data.Models.Note
{
    using Web.ViewModels.Note;
    public class AllNotesFilteredAndPagedServiceModel 
    {
        public AllNotesFilteredAndPagedServiceModel()
        {
            this.Notes = new HashSet<NoteAllViewModel>();
        }
        public int TotalNotesCount { get; set; }
        public IEnumerable<NoteAllViewModel> Notes { get; set; }
    }
}
    