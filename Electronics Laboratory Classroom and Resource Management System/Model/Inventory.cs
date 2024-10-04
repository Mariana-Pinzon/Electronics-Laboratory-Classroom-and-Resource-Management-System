using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Inventory
    {
        public int Inventory_ID { get; set; }
        public virtual required Equipment Equipment { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The quantity must be a non-negative number.")]
        public required int Available_quantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The total quantity must be a non-negative number.")]
        public required int Total_quantity { get; set; }

        [DataType(DataType.DateTime)]
        public required DateTime Last_update { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
