using System.Text.RegularExpressions;

namespace DotNote.Web.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
