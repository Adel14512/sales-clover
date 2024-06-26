﻿using Evaluation.CAL.DTO.BL331211;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL331211
{
    public class SalesTransactionBL331211UpdSlip3RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip3BL331211Dto> Slip3BL331211 { get; set; }
    }
}
