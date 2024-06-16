using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL061005
{
    public class SalesTransactionBL061005FindCQWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
