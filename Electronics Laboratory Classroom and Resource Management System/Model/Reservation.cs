using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation
    {
        public int Reservation_ID { get; set; }
        public virtual required User User { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public required DateTime Reservation_date { get; set; }
        public required TimeOnly Start_time { get; set; }
        public required TimeOnly End_time { get; set; }
        public virtual required Status_Reservation Status_Reservation { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool IsValidTime()
        {
            return Start_time < End_time; 
        }
    }
}
