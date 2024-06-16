using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class ContactNewDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        //[DataType(DataType.Date, ErrorMessage = "")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(\d{4})(-/|-)(\d{1,2})(-/|-)(\d{1,2})$", ErrorMessage = "DOB must be in format yyyy-mm-dd")]
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "DOB must be in format dd-mm-yyyy")]
        //[Required]
        //[MinLength(4), MaxLength(4, ErrorMessage = "The RegistrationNo Length should be EQ to 4")]
        //[RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the RegistrationNo field")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year in the YOB field")]
        //[Range(1970, 2023, ErrorMessage = "Please enter a valid Number in the YOB field")]

        public int YOB { get; set; }
        //[Required]
        public string RegistrationNo { get; set; }
        public string GenderCode { get; set; }
        //public string LocalCode { get; set; }
        public string RegionCode { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
        public List<ContactChannelNewDto> ContactChannel { get; set; }

        //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        //{
        //    var valueString = value != null ? value.ToString() : null;

        //    // Convert to date time.
        //    if (!DateTime.TryParse(valueString, out DateTime dob))
        //    {
        //        // Not a valid date, so return error.
        //        return new ValidationResult("Unable to convert the date of birth to a valid date");
        //    }
        //    return ValidationResult.Success;
        //}

    }
}
