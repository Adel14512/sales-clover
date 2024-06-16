using Evaluation.CAL.DTO.BLDuplication;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BLDuplication
{
    public class BusinessLineDuplicationNewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }

        [Required]
        public BusinessLineDuplicationNewDto BusinessLineDuplication  { get; set; }
    }
}
