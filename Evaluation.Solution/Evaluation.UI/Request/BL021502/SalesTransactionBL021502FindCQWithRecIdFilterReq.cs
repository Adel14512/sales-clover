using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL021502
{
    public class SalesTransactionBL021502FindCQWithRecIdFilterReq : GenericEmptyReq
    {
   
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
