using Evaluation.CAL.DTO.BL010602;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL010602
{
    public class SalesTransactionBL010602SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL010602Dto SalesTransactionBL010602 { get; set; }
        public List<CQHeader010602Dto> CQHeaderBL010602 { get; set; }
    }
}
