
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312DetailsUpdSlip2RecReq : GenericEmptyReq
    {
       
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip2BL041312Dto> Slip2BL041312 { get; set; }
    }                    
}
