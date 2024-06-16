
using Evaluation.UI.DTO.BL281609Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL281609Consolidation
{
    public class PolicyBL281609UpdResp : GenericWebResponse
    {
        public List<PolicyBL281609Dto> PolicyBL281609 { get; set; }
    }
}
