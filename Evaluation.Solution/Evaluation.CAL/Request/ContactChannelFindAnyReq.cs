using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ContactChannelFindAnyReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string SearchValue { get; set; }
    }
}
