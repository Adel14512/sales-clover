﻿using Evaluation.UI.DTO.BL010602;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL010602
{
    public class SalesTransactionBL010602UpdAF1RecReq :GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public AF1BL010602Dtco AF1BL010602 { get; set; }
    }
}
