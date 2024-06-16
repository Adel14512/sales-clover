

using Evaluation.UI.DTO.BL321110;


namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110DetailsPricesNewRecReq : GenericEmptyReq
    {

        public decimal CommisinOnGPPer { get; set; }
        public decimal AdminFeesAmount { get; set; }
        public decimal CostOfPolicyPer { get; set; }
        public decimal CostOfPolicyAmount { get; set; }
        public decimal FixedTaxesAmount { get; set; }
        public decimal FixedTaxesPer { get; set; }
        public decimal VATPer { get; set; }
        public bool AgeCalculationYear { get; set; }
        public bool AgeCalculationFullDate { get; set; }
        public DateTime AgeCalculationStartDate { get; set; }
        public List<SalesTransactionDetailsPricesNewDto> salesTransactionDetailsPrices { get; set; }

    }
}
