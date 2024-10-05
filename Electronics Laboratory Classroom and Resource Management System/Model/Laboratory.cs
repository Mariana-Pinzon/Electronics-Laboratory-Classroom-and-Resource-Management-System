using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Laboratory
    {
        public int Laboratory_ID { get; set; }

        public required int Laboratory_Num { get; set; }

        public required int Capacity { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
