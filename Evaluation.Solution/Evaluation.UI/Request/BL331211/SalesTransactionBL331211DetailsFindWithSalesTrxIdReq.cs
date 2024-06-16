using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211DetailsFindWithSalesTrxIdReq:GenericEmptyReq
    {
       
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
