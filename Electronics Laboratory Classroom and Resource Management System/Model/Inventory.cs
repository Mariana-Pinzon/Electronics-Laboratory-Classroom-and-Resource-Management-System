using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Inventory
    {
        public int Inventory_ID { get; set; }
        public virtual required Equipment Equipment { get; set; }

        public required int Available_quantity { get; set; }

        public virtual required Laboratory Laboratory { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
