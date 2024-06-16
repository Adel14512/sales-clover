using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL291908
{
    public class SalesTransactionBL291908CQShortFulListResp :GenderResp
    {
        public List<CQFullListBL291908Dto> CQFullListBL291908 { get; set; }
        public List<CQShortListBL291908Dto> CQShortListBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeaderBL291908 { get; set; }
    }
}
