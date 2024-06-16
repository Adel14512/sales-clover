using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL291908
{
    public class SalesTransactionBL291908FindCQWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
