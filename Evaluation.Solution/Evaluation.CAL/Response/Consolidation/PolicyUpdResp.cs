using Evaluation.CAL.DTO.Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Consolidation
{
    public class PolicyUpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyDto> Policy { get; set; }
    }
}
