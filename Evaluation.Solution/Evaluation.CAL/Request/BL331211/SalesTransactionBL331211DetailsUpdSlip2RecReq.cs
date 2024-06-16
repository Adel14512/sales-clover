using Evaluation.CAL.DTO.BL331211;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL331211
{
    public class SalesTransactionBL331211DetailsUpdSlip2RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip2BL331211Dto> Slip2BL331211 { get; set; }
    }
}
