
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.UI.Response.BL331211
{
    public class SalesTransactionBL331211CQShortFulListResp : GenericWebResponse
    {
        public List<CQFullListBL331211Dto> CQFullListBL331211 { get; set; }
        public List<CQShortListBL331211Dto> CQShortListBL331211 { get; set; }
        public List<CQHeader331211Dto> CQHeaderBL331211 { get; set; }
    }
}
