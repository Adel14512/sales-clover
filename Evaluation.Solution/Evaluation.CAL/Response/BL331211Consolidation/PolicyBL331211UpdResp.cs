using Evaluation.CAL.DTO.BL331211Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL331211Consolidation
{
    public class PolicyBL331211UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL331211Dto> PolicyBL331211 { get; set; }
    }
}
