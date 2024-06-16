using Evaluation.CAL.DTO.BL281609Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL281609Consolidation
{
    public class PolicyBL281609UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL281609Dto> PolicyBL281609 { get; set; }
    }
}
