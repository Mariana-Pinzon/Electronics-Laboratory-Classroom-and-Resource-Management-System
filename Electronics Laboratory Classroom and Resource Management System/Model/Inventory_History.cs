namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Inventory_History
    {
        public int Inventory_History_ID { get; set; }
        public virtual required Equipment Equipment { get; set; }
        public int Available_quantity { get; set; }
        public int Total_quantity { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public required DateTime Date { get; set; }
        public required DateTime ModifiedDate { get; set; }
        public required int ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
