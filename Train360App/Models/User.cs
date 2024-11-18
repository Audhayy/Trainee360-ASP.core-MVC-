using System.Data;

namespace Trainee360App.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public string? Qualification { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public string? InsertedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public required Role Role { get; set; }

    }
}
