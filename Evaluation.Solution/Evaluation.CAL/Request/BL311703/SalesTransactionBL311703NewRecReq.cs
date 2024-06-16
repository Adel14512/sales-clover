using Evaluation.CAL.DTO.BL311703;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL311703
{
    public class SalesTransactionBL311703NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        //[Required]
        public List<AF1BL311703Dto> AF1BL311703 { get; set; }
    }
}
