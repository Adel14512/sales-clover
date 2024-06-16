
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL041312
{
    public class SalesTransactionBL041312CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL041312Dto> CQFullListBL041312 { get; set; }
        public List<CQShortListBL041312Dto> CQShortListBL041312 { get; set; }
        public List<CQHeader041312Dto> CQHeaderBL041312 { get; set; }
    }
}
