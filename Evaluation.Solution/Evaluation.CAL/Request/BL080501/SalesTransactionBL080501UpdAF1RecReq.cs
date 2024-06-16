using Evaluation.CAL.DTO.BL080501;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL080501
{
    public class SalesTransactionBL080501UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public AF1BL080501Dtco AF1BL080501 { get; set; }
    }
}
