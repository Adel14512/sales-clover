using Evaluation.CAL.DTO.BL090703Consolidation;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL090703Consolidation
{
    public class PolicyBL090703UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL090703Dto> PolicyBL090703 { get; set; }
    }
}
