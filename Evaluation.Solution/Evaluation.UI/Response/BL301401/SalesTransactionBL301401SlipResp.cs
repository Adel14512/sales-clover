
using Evaluation.UI.DTO.BL301401;
namespace Evaluation.UI.Response.BL301401
{
    public class SalesTransactionBL301401SlipResp:GenericWebResponse
    {
        public SalesTransactionBL301401Dto SalesTransactionBL301401 { get; set; }
        public List<CQHeader301401Dto> CQHeaderBL301401 { get; set; }
    }
}
