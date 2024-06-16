using Evaluation.CAL.DTO.BL051807Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL051807Consolidation
{
    public class PolicyBL051807UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL051807Dto> PolicyBL051807 { get; set; }
    }
}
