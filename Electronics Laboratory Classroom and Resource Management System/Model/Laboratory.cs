using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Laboratory
    {
        public int Laboratory_ID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The laboratory number must be a positive integer.")]
        public required int Laboratory_Num { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive number.")]
        public required int Capacity { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
