using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211DetailsPricesFindWithSalesTrxDetailsIdReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionDetailsId { get; set; }
    }
}
