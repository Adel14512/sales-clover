using Evaluation.CAL.DTO.BL291908;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL291908
{
    public class SalesTransactionBL291908UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL291908Dto> AF1BL291908 { get; set; }
    }
}
