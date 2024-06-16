﻿using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL281609Consolidation
{
    public class PolicyBL281609NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public string Combination { get; set; }
        public string BusinessLineCode { get; set; }
    }
}