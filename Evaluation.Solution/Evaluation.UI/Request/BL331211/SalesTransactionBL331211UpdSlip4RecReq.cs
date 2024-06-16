
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211UpdSlip4RecReq : GenericEmptyReq
    {
        
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip4BL331211Dto> Slip4BL331211 { get; set; }
    }
}
