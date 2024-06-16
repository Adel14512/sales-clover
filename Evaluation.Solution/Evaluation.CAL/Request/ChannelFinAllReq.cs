using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ChannelFindAllReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
    }
}
