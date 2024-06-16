
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.AF1ColHeader
{
    public class AF1ColHeaderFindWithColFilterReq : GenericEmptyReq
    {
        [Required]
        public string AF1Code { get; set; }
        [Required]
        public string AF1ColHeader { get; set; }
    }
}
