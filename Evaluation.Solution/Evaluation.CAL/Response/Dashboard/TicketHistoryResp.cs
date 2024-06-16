using Evaluation.CAL.DTO.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.Dashboard
{
    public class TicketHistoryResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<TicketHistoryDto> TicketHistory { get; set; }
    }
}
