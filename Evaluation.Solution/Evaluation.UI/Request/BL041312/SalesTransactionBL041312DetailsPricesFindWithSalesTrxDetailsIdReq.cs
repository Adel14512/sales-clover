using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;


namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312DetailsPricesFindWithSalesTrxDetailsIdReq : GenericEmptyReq
    {
       
        [Required]
        public int SalesTransactionDetailsId { get; set; }
    }
}
