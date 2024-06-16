using Evaluation.CAL.DTO.BL021502Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL021502Consolidation
{
    public class PolicyBL021502UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL021502Dto> PolicyBL021502 { get; set; }
    }
}
