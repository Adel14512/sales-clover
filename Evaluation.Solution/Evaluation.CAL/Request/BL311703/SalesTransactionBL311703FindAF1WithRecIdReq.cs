using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL311703
{
    public class SalesTransactionBL311703FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
