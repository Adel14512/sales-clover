using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ChannelUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ChannelUpdDto Channel { get; set; }
    }
}
