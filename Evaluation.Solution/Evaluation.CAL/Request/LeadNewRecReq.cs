using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class LeadNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public LeadNewDto Lead { get; set; }
    }
}
