using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Status_Equipment
    {
        public int StatusE_ID { get; set; }
        public required string Status { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
