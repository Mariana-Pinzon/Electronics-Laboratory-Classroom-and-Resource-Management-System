namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Status_Reservation_History
    {
        public int Status_Reservation_History_ID { get; set; }
        public int StatusR_ID { get; set; }
        public required string StatusR { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
