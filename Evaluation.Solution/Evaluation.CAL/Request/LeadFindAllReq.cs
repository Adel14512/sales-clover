using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class LeadFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
