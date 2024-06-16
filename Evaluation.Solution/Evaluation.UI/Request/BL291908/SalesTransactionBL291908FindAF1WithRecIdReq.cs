using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL291908
{
    public class SalesTransactionBL291908FindAF1WithRecIdReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
