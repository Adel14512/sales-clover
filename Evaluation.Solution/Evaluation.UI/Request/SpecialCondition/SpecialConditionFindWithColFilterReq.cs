using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.SpecialCondition
{
    public class SpecialConditionFindWithColFilterReq : GenericEmptyReq
    {

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the SalesTrxId field")]
        public int SalesTrxId { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the BusinessLineId field")]
        public string BusinessLineCode { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the ProductId field")]
        public int ProductId { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the Sheet field")]
        public int Sheet { get; set; }
    }
}
