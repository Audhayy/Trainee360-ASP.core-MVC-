namespace Trainee360App.Models
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string? InsertedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}