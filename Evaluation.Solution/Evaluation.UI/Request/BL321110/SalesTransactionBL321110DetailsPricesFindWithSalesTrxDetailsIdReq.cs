using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL321110
{
    public class SalesTransactionBL321110DetailsPricesFindWithSalesTrxDetailsIdReq : GenericEmptyReq
    {
        [Required]
        public int SalesTransactionDetailsId { get; set; }
    }
}
