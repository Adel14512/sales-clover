using Evaluation.UI.Response;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Models
{
    public class ContactVM
    {
        public ContactVM() {
            Channels = new List<ChannelResp>();
            Regions = new List<RegionResp>();
            Genders = new List<GenderResp>();
        }
        public int RecId { get; set; }
        [StringLength(50, ErrorMessage = "The {0} field must not exceed {1} characters.")]
        [Required]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "The {0} field must not exceed {1} characters.")]
        [Required]
        public string LastName { get; set; }
        [StringLength(50, ErrorMessage = "The {0} field must not exceed {1} characters.")]
       
        public string MiddleName { get; set; }
        public string MotherName { get; set; }
        public int? YOB { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime Dob { get; set; }
        [Required]
        public int GenderId { get; set; }
        public int RegionID { get; set; }
        public string Code { get; set; }
        [StringLength(100, ErrorMessage = "The {0} field must not exceed {1} characters.")]
        public string Job { get; set; }
        [StringLength(100, ErrorMessage = "The {0} field must not exceed {1} characters.")]
        public string Company { get; set; }
        public string Description { get; set; }
        [StringLength(13, ErrorMessage = "The {0} field must not exceed {1} characters.")]
        public string LocalCode { get; set; }
        [StringLength(13, ErrorMessage = "The {0} field must not exceed {1} characters.")]
        public string RegionCode { get; set; }
        public List<ContactChannelResp> ContactChannel { get; set; }
        public List<ChannelResp> Channels { get; set; }
        public List<RegionResp> Regions { get; set; }
        public List<GenderResp> Genders { get; set; }
    }
}
