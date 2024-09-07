using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation
    {
        [Key]
        int Reservation_Id { get; set; }
        int User_ID { get; set; }
        int Laboratory_ID { get; set; }
        DateTime Reservation_date { get; set; }
        TimeOnly Start_time { get; set; }
        TimeOnly End_time { get; set; }
    }
}
