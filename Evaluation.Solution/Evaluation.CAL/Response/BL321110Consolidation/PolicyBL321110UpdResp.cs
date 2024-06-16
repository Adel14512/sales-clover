using Evaluation.CAL.DTO.BL321110Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL321110Consolidation
{
    public class PolicyBL321110UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL321110Dto> PolicyBL321110 { get; set; }
    }
}
