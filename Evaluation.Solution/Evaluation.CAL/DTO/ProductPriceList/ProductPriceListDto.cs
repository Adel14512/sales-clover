using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.ProductPriceList
{
    public class ProductPriceListDto
    {
        public int RecId { get; set; }
        public int ProductId { get; set; }
        public int TechnicalSheet { get; set; }
        public decimal FamilyCountMinRange { get; set; }
        public decimal FamilyCountMaxRange { get; set; }
        public string Period { get; set; }
        public int DaysCountMinRange { get; set; }
        public int DaysCountMaxRange { get; set; }
        public string Dependency { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string CostSharing { get; set; }
        public int AgeMinRange { get; set; }
        public int AgeMaxRange { get; set; }
        public decimal Rate { get; set; }
        public decimal Premium { get; set; }
        public decimal PaPremiium { get; set; }
        public int NbrChildFree { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
