using Evaluation.CAL.DTO.BL281609;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL281609
{
    public class SalesTransactionBL281609UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL281609Dto> AF1BL281609 { get; set; }
    }
}
