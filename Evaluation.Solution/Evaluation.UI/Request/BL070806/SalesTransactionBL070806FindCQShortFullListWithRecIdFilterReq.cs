using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL070806
{
    public class SalesTransactionBL070806FindCQShortFullListWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
