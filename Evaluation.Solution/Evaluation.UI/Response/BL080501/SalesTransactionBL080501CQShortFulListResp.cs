using Evaluation.UI.DTO.BL080501;


namespace Evaluation.UI.Response.BL080501
{
    public class SalesTransactionBL080501CQShortFulListResp:GenericWebResponse
    {
        public List<CQFullListBL080501Dto> CQFullListBL080501 { get; set; }
        public List<CQShortListBL080501Dto> CQShortListBL080501 { get; set; }
        public List<CQHeader080501> CQHeaderBL080501 { get; set; }
    }
}
