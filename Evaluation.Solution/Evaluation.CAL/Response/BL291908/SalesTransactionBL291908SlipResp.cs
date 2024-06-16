using Evaluation.CAL.DTO.BL291908;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL291908
{
    public class SalesTransactionBL291908SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL291908Dto SalesTransactionBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeaderBL291908 { get; set; }
    }
}
