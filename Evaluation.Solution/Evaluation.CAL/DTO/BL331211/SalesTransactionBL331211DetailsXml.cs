using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.DTO.BL331211
{
    public class SalesTransactionBL331211DetailsXml
    {
        public int RecId { get; set; }
        public int SalesTrxId { get; set; }
        public string Insurer_Code { get; set; }
        public string ThirdPartyAdmin_Code { get; set; }
        public int ContactId { get; set; }
        public string AF1BL331211 { get; set; }
        public string Slip2BL331211 { get; set; }
        public string Slip3BL331211 { get; set; }
        public string Slip4BL331211 { get; set; }
        public decimal CommisinOnGPPer { get; set; }
        public decimal AdminFeesAmount { get; set; }
        public decimal CostOfPolicyPer { get; set; }
        public decimal CostOfPolicyAmount { get; set; }
        public decimal FixedTaxesAmount { get; set; }
        public decimal FixedTaxesPer { get; set; }
        public decimal VATPer { get; set; }
        public string Reserved1 { get; set; }
        public string Reserved2 { get; set; }
    }
}
