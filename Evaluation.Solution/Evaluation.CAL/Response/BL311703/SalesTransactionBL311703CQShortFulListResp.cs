using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evaluation.CAL.DTO.BL311703;

namespace Evaluation.CAL.Response.BL311703
{
    public class SalesTransactionBL311703CQShortFulListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<CQFullListBL311703Dto> CQFullListBL311703 { get; set; }
        public List<CQShortListBL311703Dto> CQShortListBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
    }
}
