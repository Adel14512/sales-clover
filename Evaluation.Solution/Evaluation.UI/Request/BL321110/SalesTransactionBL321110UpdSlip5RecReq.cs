
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110UpdSlip5RecReq:GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip5BL321110Dto> Slip5BL321110 { get; set; }
    }
}
