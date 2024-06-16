using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO
{
    public class LeadDto
    {
        public int RecId { get; set; }
        public int LeadStatusId { get; set; }
        public string LeadStatusCode { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string Owner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EMail { get; set; }
        public string Job { get; set; }
        public string Company { get; set; }
        public string Topic { get; set; }
        public string BusinessLine { get; set; }
        public int LeadSourceId { get; set; }
        public string LeadSourceCode { get; set; }
        public int LeadSaleId { get; set; }
        public string LeadSaleCode { get; set; }
        public string SummaryFeedback { get; set; }
        public DateTime NextActionDate { get; set; }

        public bool IsActive { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
