namespace Trainee360App.Models
{
    public class Messages
    {
        public int Id { get; set; } 

        public int FromId { get; set; } 
        public string? Message { get; set; } 
        public bool IsActive { get; set; } 
        public string InsertedBy { get; set; } 
        public DateTime InsertedOn { get; set; } 
        public string UpdatedBy { get; set; } 
        public DateTime? UpdatedOn { get; set; } 
    }

}