using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class ContactDto //: ValidationAttribute
    {
        public int RecId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [DataType(DataType.Date, ErrorMessage = "")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(\d{4})(-/|-)(\d{1,2})(-/|-)(\d{1,2})$", ErrorMessage = "DOB must be in format yyyy-mm-dd")]
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "DOB must be in format dd-mm-yyyy")]
        public int YOB { get; set; }
        public string RegistrationNo { get; set; }
        public int GenderId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int RegionId { get; set; }
        public string LocalCode { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string RegionCode { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
        public List<ContactChannelDto> ContactChannel { get; set; }

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
