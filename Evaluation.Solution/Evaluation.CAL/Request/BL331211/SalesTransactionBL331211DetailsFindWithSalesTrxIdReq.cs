﻿using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL331211
{
    public class SalesTransactionBL331211DetailsFindWithSalesTrxIdReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int SalesTransactionId { get; set; }
    }
}
