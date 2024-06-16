
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312UpdSlip4RecReq : GenericEmptyReq
    {
  
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip4BL041312Dto> Slip4BL041312 { get; set; }
    }
}
