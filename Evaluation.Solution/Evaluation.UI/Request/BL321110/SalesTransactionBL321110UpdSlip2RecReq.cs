
using Evaluation.UI.DTO.BL321110;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110UpdSlip2RecReq:GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip2BL321110Dto> Slip2BL321110 { get; set; }
    }
}
