
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.Response;
using System.Collections.Generic;


namespace Evaluation.UI.Response.BL301401
{
    public class SalesTransactionBL301401CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL301401Dto> CQFullListBL301401 { get; set; }
        public List<CQShortListBL301401Dto> CQShortListBL301401 { get; set; }
        public List<CQHeader> CQHeaderBL301401 { get; set; }
    }
}
