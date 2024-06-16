using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.AF1ColHeader
{
    public class AF1ColHeaderFindWithColFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string AF1Code { get; set; }
        [Required]
        public string AF1ColHeader { get; set; }
    }
}
