using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class GenderFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
