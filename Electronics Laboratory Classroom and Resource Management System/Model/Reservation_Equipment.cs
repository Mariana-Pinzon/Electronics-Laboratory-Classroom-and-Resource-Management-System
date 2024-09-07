using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation_Equipment
    {
        int Reservation_ID { get; set; }
        int Equipment_ID { get; set; }
        int Quantity { get; set; }
    }
}
