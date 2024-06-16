using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL051807
{
    public class SalesTransactionBL051807FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
