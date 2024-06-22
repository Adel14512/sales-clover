﻿using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Dashboard
{
    public class TicketHistoryReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int NbrDays { get; set; }
    }
}
