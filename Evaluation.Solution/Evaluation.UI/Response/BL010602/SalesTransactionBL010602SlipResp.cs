
using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL010602
{
    public class SalesTransactionBL010602SlipResp : GenericWebResponse
    {
        public SalesTransactionBL010602Dto SalesTransactionBL010602 { get; set; }
        public List<CQHeader010602Dto> CQHeaderBL010602 { get; set; }
    }
}
