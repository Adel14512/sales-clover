using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class ContactChannelFindAnyResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ContactDto> Contact { get; set; }
    }
}
