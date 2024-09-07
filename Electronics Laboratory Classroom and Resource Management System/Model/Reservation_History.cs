using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation_History
    {
        [Key]
        int History_ID { get; set; }
        int Reservation_ID { get; set; }
        int StatusR_ID { get; set; }
        DateTime Modification_date { get; set; }
    }
}
