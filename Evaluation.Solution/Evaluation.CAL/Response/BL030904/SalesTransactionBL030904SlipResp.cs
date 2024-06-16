using Evaluation.CAL.DTO.BL030904;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL030904
{
    public class SalesTransactionBL030904SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL030904Dto SalesTransactionBL030904 { get; set; }
        public List<CQHeader030904Dto> CQHeaderBL030904 { get; set; }
    }
}
