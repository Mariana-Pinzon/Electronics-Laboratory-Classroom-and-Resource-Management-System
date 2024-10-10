using System.ComponentModel.DataAnnotations;

namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Equipment
    {
        public int Equipment_ID { get; set; }
        public required string Equipment_Name { get; set; }
        public required string Description { get; set; }
        public virtual required Status_Equipment Status_Equipment { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "La fecha de adquisición no puede ser una fecha futura.")]
        public DateTime Acquisition_date { get; set; }
        public virtual required Laboratory Laboratory { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime > DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
