using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.ProductBenefits
{
    public class ProductBenefitsTemplateDto
    {
        public int RecId { get; set; }
        public int BranchId { get; set; }
        public string ClassCode { get; set; }
        public int BenefitNumber { get; set; }
        public string BenefitName { get; set; }
        public string BenefitAnswer { get; set; }
        public string LifeTime { get; set; }
        public string Excess { get; set; }
        //public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        //[JsonPropertyName("Type")]
        public string Reserved2 { get; set; }
    }
}
