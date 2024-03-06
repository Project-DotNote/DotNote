using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNote.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNote.Data.Configurations
{
    public class SeedUsersEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(GenerateUsers());
        }
        private List<User> GenerateUsers()
        {
            var generateUsers = new List<User>();

            var user1 = new User
            {
                Id = new Guid("442f7e99-7581-42c1-9a4e-890e69ff1b9b"), // Use the provided GUID
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "Password1", // Hash the password before storing in production
                CreatedAt = DateTime.UtcNow
            };
            generateUsers.Add(user1);

            return generateUsers;
        }
    }
}
