using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation_Equipment
    {
        public int ReservationE_ID { get; set; }
        public virtual required Reservation Reservation { get; set; }
        public virtual required Equipment Equipment { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
        public required int Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
