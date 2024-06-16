using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL281609
{
    public class SalesTransactionBL281609FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
