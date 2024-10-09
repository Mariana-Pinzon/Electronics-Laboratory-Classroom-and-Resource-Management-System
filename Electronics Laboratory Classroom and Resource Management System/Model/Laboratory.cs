using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Laboratory
    {
        public int Laboratory_ID { get; set; }

        [Range(100, 399, ErrorMessage = "El número de laboratorio debe estar entre 100 y 399.")]
        public required int Laboratory_Num { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La capacidad debe ser mayor que cero.")]
        public required int Capacity { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}