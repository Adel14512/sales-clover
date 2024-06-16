using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class SalesTransactionMenuFindWithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the RecId field")]
        public int RecId { get; set; }
    }
}
