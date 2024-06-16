using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL321110
{
    public class SalesTransactionDetailsPricesNewDto
    {
        public int SalesTrxDetailsId { get; set; }
        public string SectionName { get; set; }
        public string Category { get; set; }
        public string Dependency { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string CostSharing { get; set; }
        public int AgeMinRange { get; set; }
        public int AgeMaxRange { get; set; }
        public decimal Premium { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
