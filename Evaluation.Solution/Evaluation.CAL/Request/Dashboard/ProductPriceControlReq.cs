using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Dashboard
{
    public class ProductPriceControlReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
