using Evaluation.CAL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class ChannelNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public ChannelNewDto Channel { get; set; }
    }
}
