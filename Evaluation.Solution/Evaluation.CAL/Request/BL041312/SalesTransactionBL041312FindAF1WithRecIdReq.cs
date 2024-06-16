using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL041312
{
    public class SalesTransactionBL041312FindAF1WithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
