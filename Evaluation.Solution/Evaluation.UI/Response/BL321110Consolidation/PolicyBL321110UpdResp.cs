using Evaluation.UI.DTO.BL321110Consolidation;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BL321110Consolidation
{
    public class PolicyBL321110UpdResp : GenericWebResponse
    {
        public List<PolicyBL321110Dto> PolicyBL321110 { get; set; }
    }
}
