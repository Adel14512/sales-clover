﻿
using Evaluation.UI.DTO.BL041312;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312UpdSlip3RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip3BL041312Dto> Slip3BL041312 { get; set; }
    }
}
