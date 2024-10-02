namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class User_History
    {
        public int User_History_ID { get; set; }
        public virtual required User User { get; set; }
        public required string Password { get; set; }
        public virtual required User_Type User_Type { get; set; }
        public required DateTime Date { get; set; }
        public required DateTime ModifiedDate { get; set; }
        public required int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
