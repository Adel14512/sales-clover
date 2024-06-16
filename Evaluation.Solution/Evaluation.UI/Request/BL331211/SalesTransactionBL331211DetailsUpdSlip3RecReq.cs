
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL331211
{
    public class SalesTransactionBL331211DetailsUpdSlip3RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        //[Required]
        public List<Slip3BL331211Dto> Slip3BL331211 { get; set; }
    }
}
