using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL291908
{
    public class SalesTransactionBL291908FindCQWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
