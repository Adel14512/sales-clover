using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL051807
{
    public class CQDetailsBL051807Dto
    {
        public int SalesTrxId { get; set; }
        public int FamilyId { get; set; }
        public string Insurred { get; set; }
        public int AF1Age { get; set; }
        public string RelationCode { get; set; }
        public int ProductId { get; set; }
        public string InsurerProduct { get; set; }
        public string Sheet { get; set; }
        public string SectionName { get; set; }
        public string Combination { get; set; }
        public int MemberPerFamily { get; set; }
        public int MembersCount { get; set; }
        public decimal Price { get; set; }
        public decimal CostPolicy { get; set; }
        public decimal AdminFees { get; set; }
        public string Features { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
