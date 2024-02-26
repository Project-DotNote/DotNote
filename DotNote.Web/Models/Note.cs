namespace DotNote.Web.Models
{
    public class Note
    {
        public Note()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Text { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public NoteStatus Status { get; set; }

        public User User { get; set; }
    }

        public enum NoteStatus
    {
        Active,
        Deleted
    }
}
