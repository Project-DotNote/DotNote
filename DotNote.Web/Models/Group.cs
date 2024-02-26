namespace DotNote.Web.Models
{
    public class Group
    {
        public Group()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
    }
}
