

using Evaluation.UI.DTO.BL021502;

namespace Evaluation.UI.Response.BL021502
{
    public class SalesTransactionBL021502SlipResp : GenericWebResponse
    {
        public SalesTransactionBL021502Dto SalesTransactionBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
    }
}
