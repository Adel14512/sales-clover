using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL080501
{
    public class SalesTransactionBL080501UpdAF1RecReq :GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        [Required]
        public AF1BL080501Dtco AF1BL080501 { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
    }
}
