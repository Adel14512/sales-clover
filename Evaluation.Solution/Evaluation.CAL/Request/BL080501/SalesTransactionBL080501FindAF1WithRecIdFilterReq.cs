using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL080501
{
    public class SalesTransactionBL080501FindAF1WithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
