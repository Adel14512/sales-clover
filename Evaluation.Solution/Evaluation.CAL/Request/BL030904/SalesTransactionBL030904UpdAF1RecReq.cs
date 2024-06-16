using Evaluation.CAL.DTO.BL030904;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL030904
{
    public class SalesTransactionBL030904UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL030904Dto> AF1BL030904 { get; set; }
    }
}
