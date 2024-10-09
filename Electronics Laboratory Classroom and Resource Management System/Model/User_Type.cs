using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class User_Type
    {
        public int User_Type_ID { get; set; }
        public required string UserType { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}