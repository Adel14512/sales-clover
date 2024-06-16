using Evaluation.CAL.DTO.BL090703;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703
{
    public class SalesTransactionBL090703NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public AF1BL090703Dtco AF1BL090703 { get; set; }
    }
}
