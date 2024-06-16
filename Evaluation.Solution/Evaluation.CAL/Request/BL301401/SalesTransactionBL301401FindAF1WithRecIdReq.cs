using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL301401
{
    public class SalesTransactionBL301401FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
