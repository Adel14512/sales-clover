using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Renewal
{
    public class RenewalParameterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
