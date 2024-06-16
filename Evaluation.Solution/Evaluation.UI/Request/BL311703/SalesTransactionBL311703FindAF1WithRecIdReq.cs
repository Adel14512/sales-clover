using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL311703
{
    public class SalesTransactionBL311703FindAF1WithRecIdReq :GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
