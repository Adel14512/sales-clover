﻿using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL311703
{
    public class SalesTransactionBL311703FindCQShortFullListWithRecIdFilterReq : GenericEmptyReq
    {
        
        [Required]
        public int SalesTransactionId { get; set; }
    }
}