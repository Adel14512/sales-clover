
using Evaluation.UI.DTO.BL061005;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.BL061005
{
    public class SalesTransactionBL061005SlipResp : GenericWebResponse
    {
        public SalesTransactionBL061005Dto SalesTransactionBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
    }
}
