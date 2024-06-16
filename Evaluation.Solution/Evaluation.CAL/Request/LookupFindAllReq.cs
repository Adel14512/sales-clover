using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class LookupFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
