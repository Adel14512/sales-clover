using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.DTO.BL021502
{
    public class ValueInTableAttribute : ValidationAttribute
    {
        public string ErrorMessage { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext.DisplayName == "GenderCode") 
            { 
            }
            //var dbContext = (MyDbContext)validationContext.GetService(typeof(MyDbContext));

            // Retrieve the entity from the database
            string entity = null;

            if (entity == null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}