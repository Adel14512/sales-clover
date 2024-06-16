

using Evaluation.UI.DTO.BL021502;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL021502
{
    public class SalesTransactionBL021502CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL021502Dto> CQFullListBL021502 { get; set; }
        public List<CQShortListBL021502Dto> CQShortListBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
    }
}
