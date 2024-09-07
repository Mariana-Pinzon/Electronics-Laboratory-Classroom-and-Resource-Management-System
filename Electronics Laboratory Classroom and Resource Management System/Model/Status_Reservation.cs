using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Status_Reservation
    {
        [Key]
        int StatusR_ID { get; set; }
        public required string StatusR { get; set; }

    }
}
