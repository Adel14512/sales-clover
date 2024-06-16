using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class RegionFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
