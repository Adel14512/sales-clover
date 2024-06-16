using Evaluation.CAL.DTO.BL021502;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL021502
{
    public class SalesTransactionBL021502UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL021502Dto> AF1BL021502 { get; set; }
    }
}
