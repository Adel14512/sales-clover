using Evaluation.CAL.DTO.BL291908Consolidation;
using System.Collections.Generic;


namespace Evaluation.CAL.Response.BL291908Consolidation
{
    public class PolicyBL291908UpdResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<PolicyBL291908Dto> PolicyBL291908 { get; set; }
    }
}
