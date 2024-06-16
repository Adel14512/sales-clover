using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110FindCQShortFullListWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
