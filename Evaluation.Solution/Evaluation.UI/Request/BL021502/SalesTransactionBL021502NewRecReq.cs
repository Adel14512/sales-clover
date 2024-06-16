using Evaluation.UI.DTO.BL021502;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL021502
{
    public class SalesTransactionBL021502NewRecReq: GenericEmptyReq
    {
       
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL021502Dto> AF1BL021502 { get; set; }
    }
}
