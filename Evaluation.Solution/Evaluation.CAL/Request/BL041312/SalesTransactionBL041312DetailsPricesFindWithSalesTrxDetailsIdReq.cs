using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL041312
{
    public class SalesTransactionBL041312DetailsPricesFindWithSalesTrxDetailsIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionDetailsId { get; set; }
    }
}
