using Evaluation.CAL.DTO.BL051807;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL051807
{
    public class SalesTransactionBL051807SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL051807Dto SalesTransactionBL051807 { get; set; }
        public List<CQHeader051807Dto> CQHeaderBL051807 { get; set; }
    }
}
