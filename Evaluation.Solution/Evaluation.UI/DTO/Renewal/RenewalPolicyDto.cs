using System;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Renewal
{
    public class RenewalPolicyDto
    {
        public string ClientType { get; set; }
        public string BlCode { get; set; }
        public string BlName { get; set; }
        public string PolicyId { get; set; }
        public string MasterName { get; set; }
        public string ClientName { get; set; }
        public string DecisionMaker { get; set; }
        public string PolicyHandler { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Principal { get; set; }
        public string Spouce { get; set; }
        public string Child { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
