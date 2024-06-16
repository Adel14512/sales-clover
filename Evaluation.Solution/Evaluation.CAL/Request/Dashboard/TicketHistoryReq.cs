using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Request.Dashboard
{
    public class TicketHistoryReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int NbrDays { get; set; }
    }
}
