using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Inventory_History
    {
        public int Inventory_History_ID { get; set; }
        public int Inventory_ID { get; set; }
        public required string Equipment_ID { get; set; }

        public required string Available_quantity { get; set; }

        public required string Laboratory_ID { get; set; }

        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
    }
}