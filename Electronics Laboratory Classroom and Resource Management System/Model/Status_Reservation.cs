using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Status_Reservation
    {
        public int StatusR_ID { get; set; }
        public required string StatusR { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
