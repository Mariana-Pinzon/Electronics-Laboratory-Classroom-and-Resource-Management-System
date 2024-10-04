using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Equipment
    {
        public int Equipment_ID { get; set; }
        public required string Equipment_Name { get; set; }
        public required string Description { get; set; }
        public virtual required Status_Equipment Status_Equipment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Acquisition_date { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
