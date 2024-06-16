using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class MaritalStatusFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
