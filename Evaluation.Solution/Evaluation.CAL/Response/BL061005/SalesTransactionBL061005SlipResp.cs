using Evaluation.CAL.DTO.BL061005;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.BL061005
{
    public class SalesTransactionBL061005SlipResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public SalesTransactionBL061005Dto SalesTransactionBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
    }
}
