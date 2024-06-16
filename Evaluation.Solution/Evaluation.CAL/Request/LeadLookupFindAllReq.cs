using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class LeadLookupFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
