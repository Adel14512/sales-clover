using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110DetailsFindWithSalesTrxIdReq:GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
