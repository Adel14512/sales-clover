using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.SpecialCondition
{
    public class SpecialConditionDto
    {
        public int RecId { get; set; }
        public int SalesTrxId { get; set; }
        public string BusinessLineCode { get; set; }
        public int ProductId { get; set; }
        public int Sheet { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal DiscountAmount { get; set; }
        public bool IsActive { get; set; }       
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
