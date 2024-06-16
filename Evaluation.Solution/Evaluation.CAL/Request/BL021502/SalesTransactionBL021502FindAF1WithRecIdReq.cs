using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL021502
{
    public class SalesTransactionBL021502FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
