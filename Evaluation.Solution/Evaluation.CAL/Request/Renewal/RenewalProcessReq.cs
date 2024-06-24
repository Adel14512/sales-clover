using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Renewal
{
    public class RenewalProcessReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
