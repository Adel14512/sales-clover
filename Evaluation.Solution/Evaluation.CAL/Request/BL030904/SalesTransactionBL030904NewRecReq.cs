using Evaluation.CAL.DTO.BL030904;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL030904
{
    public class SalesTransactionBL030904NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        //[Required]
        public List<AF1BL030904Dto> AF1BL030904 { get; set; }
    }
}
