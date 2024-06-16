using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response
{
    public class LeadFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<LeadDto> Lead { get; set; }
    }
}
