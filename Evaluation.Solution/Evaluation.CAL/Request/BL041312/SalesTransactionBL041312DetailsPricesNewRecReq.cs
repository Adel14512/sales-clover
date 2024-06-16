using Evaluation.CAL.DTO.BL041312;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL041312
{
    public class SalesTransactionBL041312DetailsPricesNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
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
