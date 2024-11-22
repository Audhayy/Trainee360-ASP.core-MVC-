namespace Trainee360App.Models
{
    public class UserAudit
    {
        public int Id { get; set; }
        public required User User { get; set; }
        public DateTime Date { get; set; }
        public DateTime SignIn { get; set; } = DateTime.Now;
        public DateTime SignOut { get; set; }
        public bool IsActive { get; set; } = true;
        public string InsertedBy { get; set; }
        public DateTime InsertedOn { get; set; }
    }
}