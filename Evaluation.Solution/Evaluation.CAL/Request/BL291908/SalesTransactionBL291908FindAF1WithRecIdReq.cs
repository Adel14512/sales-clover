using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL291908
{
    public class SalesTransactionBL291908FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
