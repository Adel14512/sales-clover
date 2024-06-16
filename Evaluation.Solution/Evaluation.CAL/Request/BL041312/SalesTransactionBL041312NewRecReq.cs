using Evaluation.CAL.DTO.BL041312;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL041312
{
    public class SalesTransactionBL041312NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        //[Required]
        public List<AF1BL041312Dto> AF1BL041312 { get; set; }
    }
}
