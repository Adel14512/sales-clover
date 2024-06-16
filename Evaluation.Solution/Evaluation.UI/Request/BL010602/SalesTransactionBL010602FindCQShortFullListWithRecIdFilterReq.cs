using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL010602
{
    public class SalesTransactionBL010602FindCQShortFullListWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
