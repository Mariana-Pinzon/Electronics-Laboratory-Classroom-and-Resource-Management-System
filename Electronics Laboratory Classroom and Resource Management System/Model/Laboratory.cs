using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Laboratory
    {
        [Key]
        int Laboratory_ID { get; set; }
        int Laboratory_Num { get; set; }
        int Capacity { get; set; }
    }
}
