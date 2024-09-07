using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation
    {
        public int Reservation_ID { get; set; }
        public virtual required User User { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public DateTime Reservation_date { get; set; }
        public TimeOnly Start_time { get; set; }
        public TimeOnly End_time { get; set; }
    }
}
