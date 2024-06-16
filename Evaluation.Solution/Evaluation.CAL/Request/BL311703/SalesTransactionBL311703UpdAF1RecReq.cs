using Evaluation.CAL.DTO.BL311703;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL311703
{
    public class SalesTransactionBL311703UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
       // [Required]
        public List<AF1BL311703Dto> AF1BL311703 { get; set; }
    }
}
