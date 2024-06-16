using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703
{
    public class SalesTransactionBL090703FindAF1WithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
