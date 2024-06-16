using Evaluation.CAL.DTO.BL041312;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL041312
{
    public class SalesTransactionBL041312UpdSlip2RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip2BL041312Dto> Slip2BL041312 { get; set; }
    }
}
