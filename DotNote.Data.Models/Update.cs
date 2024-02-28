using System.ComponentModel.DataAnnotations;
using static DotNote.Common.EntityValidations.Update;

namespace DotNote.Data.Models
{
    public class Update
    {
        public Update()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(MaxTitleLength, MinimumLength = MinTitleLength)]
        public string Title { get; set; }

        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
