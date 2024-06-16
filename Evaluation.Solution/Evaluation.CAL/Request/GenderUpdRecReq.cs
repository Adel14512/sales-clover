using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class GenderUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public GenderUpdDto Gender { get; set; }
    }
}
