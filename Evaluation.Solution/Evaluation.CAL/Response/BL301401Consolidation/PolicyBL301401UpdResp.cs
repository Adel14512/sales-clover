using Evaluation.CAL.DTO.BL301401Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL301401Consolidation
{
    public class PolicyBL301401UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL301401Dto> PolicyBL301401 { get; set; }
    }
}
