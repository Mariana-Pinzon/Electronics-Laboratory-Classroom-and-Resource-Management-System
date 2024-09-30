using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation_History
    {
        public int History_ID { get; set; }
        public virtual required Reservation Reservation { get; set; }
        public virtual required Status_Reservation Status_Reservation { get; set; }
        public DateTime Modification_date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
