using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class MaritalStatusUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public MaritalStatusUpdDto MaritalStatus { get; set; }
    }
}
