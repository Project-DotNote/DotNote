using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static DotNote.Common.EntityValidations.User;

namespace DotNote.Data.Models
{ 
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.Id = Guid.NewGuid();

            this.Notes = new HashSet<Note>();
            this.Folders = new HashSet<Folder>();
        }

        //Must be implemented in future update a profile picture stored in the database
        //public string ProfilePicture { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Note> Notes { get; set; } = null!;
        public virtual ICollection<Folder> Folders { get; set; } = null!;

    }
}
