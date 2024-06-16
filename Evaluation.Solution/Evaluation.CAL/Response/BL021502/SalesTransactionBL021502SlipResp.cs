using Evaluation.CAL.DTO.BL021502;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL021502
{
    public class SalesTransactionBL021502SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL021502Dto SalesTransactionBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
    }
}
