
using Evaluation.UI.DTO.BL051807Consolidation;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL051807Consolidation
{
    public class PolicyBL051807UpdResp : GenericWebResponse
    {
        public List<PolicyBL051807Dto> PolicyBL051807 { get; set; }
    }
}
