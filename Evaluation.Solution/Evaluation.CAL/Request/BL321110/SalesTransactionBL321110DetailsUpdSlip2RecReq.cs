using Evaluation.CAL.DTO.BL321110;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL321110
{
    public class SalesTransactionBL321110DetailsUpdSlip2RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip2BL321110Dto> Slip2BL321110 { get; set; }
    }
}
