using Evaluation.CAL.DTO.BL301401;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL301401
{
    public class SalesTransactionBL301401SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL301401Dto SalesTransactionBL301401 { get; set; }
        public List<CQHeader301401Dto> CQHeaderBL301401 { get; set; }
    }
}
