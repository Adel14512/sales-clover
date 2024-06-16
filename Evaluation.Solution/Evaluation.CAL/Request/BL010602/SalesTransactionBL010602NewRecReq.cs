using Evaluation.CAL.DTO.BL010602;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL010602
{
    public class SalesTransactionBL010602NewRecReq
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
        public AF1BL010602Dtco AF1BL010602 { get; set; }
    }
}
