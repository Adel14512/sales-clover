using Evaluation.CAL.DTO.BL070806;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL070806
{
    public class SalesTransactionBL070806UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public AF1BL070806Dtco AF1BL070806 { get; set; }
    }
}
