using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Reservation
    {
        public int Reservation_ID { get; set; }
        public virtual required User User { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public virtual required Reservation_Equipment Reservation_Equipment { get; set; }

        [NotPastDate(ErrorMessage = "La fecha elegida no es válida, se encuentra en el pasado.")]
        public required DateOnly Reservation_date { get; set; }
        public required TimeOnly Start_time { get; set; }
        public required TimeOnly End_time { get; set; }
        public virtual required Status_Reservation Status_Reservation { get; set; }

        public ICollection<Reservation_Equipment> Reservation_Equipments { get; set; } = new List<Reservation_Equipment>();
        public bool IsDeleted { get; set; } = false;

        public bool IsValidTime()
        {
            return Start_time < End_time; 
        }
    }
    public class NotPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly dateOnly && dateOnly < DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
