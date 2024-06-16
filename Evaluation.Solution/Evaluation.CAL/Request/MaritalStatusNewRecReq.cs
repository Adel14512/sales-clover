using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class MaritalStatusNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public MaritalStatusNewDto MaritalStatus { get; set; }
    }
}
