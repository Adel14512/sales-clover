using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL281609
{
    public class SalesTransactionBL281609FindCQWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
