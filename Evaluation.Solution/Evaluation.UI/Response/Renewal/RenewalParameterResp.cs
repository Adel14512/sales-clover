
using Evaluation.UI.DTO.Renewal;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.Renewal
{
    public class RenewalParameterResp : GenericWebResponse
	{
        public List<RenewalParameterDto> RenewalParameter { get; set; }
    }
}