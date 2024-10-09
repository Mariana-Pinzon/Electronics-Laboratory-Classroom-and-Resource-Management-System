namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Status_Equipment_History
    {
        public int Status_Equipment_History_ID { get; set; }
        public int StatusE_ID { get; set; }
        public required string Status { get; set; }

        public required DateTime Date { get; set; }
        public required DateTime ModifiedDate { get; set; }
        public required int ModifiedBy { get; set; }
    }
}
