using Evaluation.CAL.DTO.BL77;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Evaluation.CAL.Request.BL77
{
    public class SalesTransactionBL77NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int BusinessLineId { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL77Dto> AF1BL77 { get; set; }
    }
}