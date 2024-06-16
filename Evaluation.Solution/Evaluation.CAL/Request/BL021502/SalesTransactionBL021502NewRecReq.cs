using Evaluation.CAL.DTO.BL021502;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL021502
{
    public class SalesTransactionBL021502NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        //[Required]
        public List<AF1BL021502Dto> AF1BL021502 { get; set; }
    }
}
