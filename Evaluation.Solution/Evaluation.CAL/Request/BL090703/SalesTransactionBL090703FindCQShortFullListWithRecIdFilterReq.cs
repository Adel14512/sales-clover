using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703
{
    public class SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
