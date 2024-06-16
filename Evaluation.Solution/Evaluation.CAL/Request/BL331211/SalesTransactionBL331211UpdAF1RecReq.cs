using Evaluation.CAL.DTO.BL331211;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL331211
{
    public class SalesTransactionBL331211UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL331211Dto> AF1BL331211 { get; set; }
    }
}
