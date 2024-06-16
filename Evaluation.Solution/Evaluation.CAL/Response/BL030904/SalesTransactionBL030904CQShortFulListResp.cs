using Evaluation.CAL.DTO.BL030904;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.BL030904
{
    public class SalesTransactionBL030904CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL030904Dto> CQFullListBL030904 { get; set; }
        public List<CQShortListBL030904Dto> CQShortListBL030904 { get; set; }
        public List<CQHeader030904Dto> CQHeaderBL030904 { get; set; }
    }
}
