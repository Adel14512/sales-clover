using Evaluation.CAL.DTO.BL281609;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL281609
{
    public class SalesTransactionBL281609SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL281609Dto SalesTransactionBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeaderBL281609 { get; set; }
    }
}
