using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation_History
    {
        public int History_ID { get; set; }
        public virtual required Reservation Reservation { get; set; }
        public virtual required Status_Reservation Status_Reservation { get; set; }
        public required DateTime Date { get; set; }
        public required DateTime ModifiedDate { get; set; }
        public required int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
