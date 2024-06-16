
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312DetailsPricesNewRecReq : GenericEmptyReq
    {
        public decimal CommisinOnGPPer { get; set; }
        public decimal AdminFeesAmount { get; set; }
        public decimal CostOfPolicyPer { get; set; }
        public decimal CostOfPolicyAmount { get; set; }
        public decimal FixedTaxesAmount { get; set; }
        public decimal FixedTaxesPer { get; set; }
        public decimal VATPer { get; set; }
        public List<SalesTransactionBL041312DetailsPricesNewDto> salesTransactionBL041312DetailsPrices { get; set; }
    }
}
