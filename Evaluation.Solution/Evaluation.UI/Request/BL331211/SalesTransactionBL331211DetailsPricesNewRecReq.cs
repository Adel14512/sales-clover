
using Evaluation.UI.DTO.BL331211;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211DetailsPricesNewRecReq : GenericEmptyReq
    {
        public decimal CommisinOnGPPer { get; set; }
        public decimal AdminFeesAmount { get; set; }
        public decimal CostOfPolicyPer { get; set; }
        public decimal CostOfPolicyAmount { get; set; }
        public decimal FixedTaxesAmount { get; set; }
        public decimal FixedTaxesPer { get; set; }
        public decimal VATPer { get; set; }
        public List<SalesTransactionBL331211DetailsPricesNewDto> salesTransactionBL331211DetailsPrices { get; set; }
    }
}
