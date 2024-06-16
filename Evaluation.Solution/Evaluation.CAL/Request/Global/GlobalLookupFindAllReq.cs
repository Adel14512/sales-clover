using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Global
{
    public class GlobalLookupFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
