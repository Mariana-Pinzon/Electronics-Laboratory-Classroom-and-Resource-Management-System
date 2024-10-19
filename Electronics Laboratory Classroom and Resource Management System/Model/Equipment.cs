using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Equipment
    {
        public int Equipment_ID { get; set; }
        public required string Equipment_Name { get; set; }
        public required string Description { get; set; }
        public virtual required Status_Equipment Status_Equipment { get; set; }

        [FutureDate(ErrorMessage = "La fecha de adquisición no puede ser una fecha futura.")]
        public DateOnly Acquisition_date { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly dateOnly)
            {
                if (dateOnly > DateOnly.FromDateTime(DateTime.Now))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
