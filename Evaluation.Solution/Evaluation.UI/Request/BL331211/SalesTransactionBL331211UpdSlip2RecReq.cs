
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211UpdSlip2RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip2BL331211Dto> Slip2BL331211 { get; set; }
    }
}
