using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Inventory
    {
        [Key]
        int Inventory_ID { get; set; }
        int Equipment_ID { get; set; }
        int Available_quantity { get; set; }
        int Total_quantity { get; set; }
        DateTime Last_update { get; set; }
        int Laboratory_ID { get; set; }



    }
}
