namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class User_History
    {
        public int User_History_ID { get; set; }
        public int User_ID { get; set; }
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string User_Type_ID { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }

    }
}