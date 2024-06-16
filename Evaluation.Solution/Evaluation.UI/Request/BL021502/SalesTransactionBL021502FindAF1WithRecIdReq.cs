using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL021502
{
    public class SalesTransactionBL021502FindAF1WithRecIdReq : GenericEmptyReq
    {
  
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
