using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.SpecialCondition
{
    public class SpecialConditionNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the SalesTrxId field")]
        public int SalesTrxId { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the ProductId field")]
        public int ProductId { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the Sheet field")]
        public int Sheet { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
