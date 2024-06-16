using Evaluation.CAL.DTO.BL010602Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL010602Consolidation
{
    public class PolicyBL010602UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL010602Dto> PolicyBL010602 { get; set; }
    }
}
