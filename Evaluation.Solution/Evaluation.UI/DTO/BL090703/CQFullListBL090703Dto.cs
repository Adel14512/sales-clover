using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.BL090703
{
    public class CQFullListBL090703Dto
    {
        public int FamilyId { get; set; }
        public string Insurred { get; set; }
        public int ProductId { get; set; }
        public string InsurerProduct { get; set; }
        public string Combination { get; set; }
        public int MemberPerFamily { get; set; }
        public decimal IP { get; set; }
        public decimal AMB { get; set; }
        public decimal PM { get; set; }
        public decimal DV { get; set; }
        public decimal Total { get; set; }
        public decimal CP { get; set; }
        public decimal AF { get; set; }
        public decimal TotalNet { get; set; }
        public string Features { get; set; }
        public int ClassId { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
