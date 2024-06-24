
using Evaluation.UI.DTO.Dashboard;

namespace Evaluation.UI.Response.Dashboard
{
    public class PolicyInquiryResp : GenericWebResponse
	{
        public List<PolicyInquiryDto> PolicyInquiry { get; set; }
    }
}
