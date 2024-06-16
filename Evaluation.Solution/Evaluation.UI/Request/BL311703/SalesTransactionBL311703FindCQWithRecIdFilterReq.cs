using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL311703
{
    public class SalesTransactionBL311703FindCQWithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
