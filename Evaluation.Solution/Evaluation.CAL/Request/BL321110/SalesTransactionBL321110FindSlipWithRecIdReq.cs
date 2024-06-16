﻿using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL321110
{
    public class SalesTransactionBL321110FindSlipWithRecIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
