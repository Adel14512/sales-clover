using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class ContactUpdDto
    {
        public int RecId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [DataType(DataType.Date, ErrorMessage = "")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(\d{4})(-/|-)(\d{1,2})(-/|-)(\d{1,2})$", ErrorMessage = "DOB must be in format yyyy-mm-dd")]
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "DOB must be in format dd-mm-yyyy")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year in the YOB field")]
        public int YOB { get; set; }
        //[Required]
        public string RegistrationNo { get; set; }
        public string GenderCode { get; set; }       //public string LocalCode { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
        public List<ContactChannelUpdDto> ContactChannel { get; set; }
    }
}
