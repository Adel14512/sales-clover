
using Evaluation.UI.DTO.BL090703Consolidation;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL090703Consolidation
{
    public class PolicyBL090703UpdResp : GenericWebResponse
    {
        public List<PolicyBL090703Dto> PolicyBL090703 { get; set; }
    }
}
