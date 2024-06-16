using Evaluation.CAL.DTO.BL090703;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL090703
{
    public class SalesTransactionBL090703UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public AF1BL090703Dtco AF1BL090703 { get; set; }
    }
}
