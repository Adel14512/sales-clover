using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request
{
    public class SalesTransactionFindWithContactIdFilterReq :GenericEmptyReq
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the ContactId field")]
        public int ContactId { get; set; }
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Please enter a valid Number in the InternalStatus field")]
        public int InternalStatus { get; set; }
    }
}
