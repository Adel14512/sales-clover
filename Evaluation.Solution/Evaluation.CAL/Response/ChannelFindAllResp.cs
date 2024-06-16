using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class ChannelFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ChannelDto> Channel { get; set; }
    }
}
