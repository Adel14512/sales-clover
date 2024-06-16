using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL77
{
    public class SalesTransactionBL77FindWithColFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the RecId field")]
        public int ContactId { get; set; }
        public int BusinessLineId { get; set; }
    }
}
