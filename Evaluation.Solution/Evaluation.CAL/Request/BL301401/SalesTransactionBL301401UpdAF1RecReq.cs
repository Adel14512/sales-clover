using Evaluation.CAL.DTO.BL301401;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL301401
{
    public class SalesTransactionBL301401UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<AF1BL301401Dto> AF1BL301401 { get; set; }
    }
}
