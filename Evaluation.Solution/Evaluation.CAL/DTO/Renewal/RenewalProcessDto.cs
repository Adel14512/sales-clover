using System;
using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.Renewal
{
    public class RenewalProcessDto
    {
        public string BusinessLineCode { get; set; }
        public string PolicyId { get; set; }
        public string MasterName { get; set; }
        public int MasterId { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public string DecisionMaker { get; set; }
        public string PolicyHandler { get; set; }
        public int ContactId { get; set; }
        public string CoNSSF { get; set; }
        public string ResidenceCode { get; set; }
        public string Id { get; set; }
        public string GenderCode { get; set; }
        public DateTime DOB { get; set; }
        public string MaritalStatusCode { get; set; }
        public string RelationCode { get; set; }
        public string NationalityCode { get; set; }
        public string GatheringClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool PrescriptionMedecine { get; set; }
        public bool Ambulatory { get; set; }
        public int ClassOfCoveragCode { get; set; }
        public bool DoctorVisit { get; set; }
        public string NetworkLevelCode { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public bool NSSF { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
