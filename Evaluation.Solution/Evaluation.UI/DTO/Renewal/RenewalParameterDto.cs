using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Renewal
{
    public class RenewalParameterDto
    {
        public string ProductCategory { get; set; }
        public string ClientType { get; set; }
        public int BranchId { get; set; }
        public string BranchDescription { get; set; }
        public string ProductClass { get; set; }
        public string NbrInsured { get; set; }
        public int RenewalTriggerDays { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
