using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation_Equipment
    {
        public int ReservationE_ID { get; set; }
        public virtual required Reservation Reservation { get; set; }
        public virtual required Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
