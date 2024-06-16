using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class BusinessLineRelatedDocFindWithBusinessLineCodeFilterReq
    {

        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public string ApplicationForm { get; set; }
    }
}
