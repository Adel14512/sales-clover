using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL080501
{
    public class SalesTransactionBL080501FindAF1WithRecIdFilterReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
