using Evaluation.CAL.DTO.BL041312;
using Evaluation.CAL.DTO.BL051807;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL051807
{
    public class SalesTransactionBL051807UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL051807Dto> AF1BL051807 { get; set; }
    }
}
