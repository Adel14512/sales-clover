
using Evaluation.UI.DTO.BL291908Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;


namespace Evaluation.UI.Response.BL291908Consolidation
{
    public class PolicyBL291908UpdResp : GenericWebResponse
    {
        public List<PolicyBL291908Dto> PolicyBL291908 { get; set; }
    }
}
