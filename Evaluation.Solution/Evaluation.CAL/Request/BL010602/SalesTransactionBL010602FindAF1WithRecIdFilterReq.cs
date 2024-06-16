using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL010602
{
    public class SalesTransactionBL010602FindAF1WithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
