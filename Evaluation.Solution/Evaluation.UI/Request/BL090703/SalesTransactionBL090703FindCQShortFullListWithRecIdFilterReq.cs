using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL090703
{
    public class SalesTransactionBL090703FindCQShortFullListWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
