using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL030904
{
    public class SalesTransactionBL030904FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
