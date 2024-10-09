using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class User
    {   
        public int User_ID { get; set; }
        public required string First_Name { get; set; }
        public required string Last_Name { get; set;}

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public required string Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        public required string Password { get; set; }
        public virtual required User_Type User_Type { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
