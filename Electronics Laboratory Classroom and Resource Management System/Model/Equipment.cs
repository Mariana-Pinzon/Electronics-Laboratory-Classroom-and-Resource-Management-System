using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Equipment
    {
        [Key]
        int Equipment_Id { get; set; }
        public required string Equipment_Name { get; set; }
        public required string Description { get; set; }
        int Status_ID { get; set; }
        DateTime Acquisition_date { get; set; }
        int Laboratory_ID { get; set; }



    }
}
