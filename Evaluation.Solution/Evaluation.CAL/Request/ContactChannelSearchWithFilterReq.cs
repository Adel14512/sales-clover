using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ContactChannelSearchWithFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string LineNbr { get; set; }
        public string RegistrationNo { get; set; }
        //[DataType(DataType.Date, ErrorMessage = "DOB must be in format yyyy-mm-dd")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(\d{4})(-/|-)(\d{1,2})(-/|-)(\d{1,2})$", ErrorMessage = "DOB must be in format yyyy-mm-dd")]
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$", ErrorMessage = "DOB must be in format dd-mm-yyyy")]
        public int YOB { get; set; }
    }
}
