using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Status_Equipment
    {
        [Key]
        int Status_ID { get; set; }
        public required string Status { get; set; }
    }
}
