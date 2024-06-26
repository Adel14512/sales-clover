﻿using Evaluation.UI.DTO.BL041312;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312UpdSlip5RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip5BL041312Dto> Slip5BL041312 { get; set; }
    }
}
