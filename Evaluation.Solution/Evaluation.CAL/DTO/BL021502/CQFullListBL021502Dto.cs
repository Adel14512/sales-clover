using System.Text.Json.Serialization;

namespace Evaluation.CAL.DTO.BL021502
{
    public class CQFullListBL021502Dto
    {
        public int SalesTrxID { get; set; }
        public string Insurred { get; set; }
        public int AF1Age { get; set; }
        public int ProductId { get; set; }
        public int ClassId { get; set; }
        public string InsurerProduct { get; set; }
        public int Sheet { get; set; }
        public string SectionName { get; set; }
        public string Combination { get; set; }
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
