using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL021502
{
    public class SalesTransactionBL021502FindCQWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
