﻿using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL070806
{
    public class SalesTransactionBL070806FindCQWithRecIdFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}