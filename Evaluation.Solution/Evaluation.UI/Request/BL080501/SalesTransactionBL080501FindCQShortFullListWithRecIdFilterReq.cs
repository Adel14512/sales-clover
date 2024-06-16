using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL080501
{
    public class SalesTransactionBL080501FindCQShortFullListWithRecIdFilterReq:GenericEmptyReq
    {
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
