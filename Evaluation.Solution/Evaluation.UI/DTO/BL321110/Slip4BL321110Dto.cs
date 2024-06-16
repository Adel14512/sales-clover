using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL321110
{
    public class Slip4BL321110Dto
    {
        public int RecId { get; set; }
        public int BranchId { get; set; }
        public string BusinessLineCode { get; set; }
        public string Category { get; set; }
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
