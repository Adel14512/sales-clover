using Evaluation.UI.DTO.BL080501;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL080501
{
    public class SalesTransactionBL080501NewRecReq :GenericEmptyReq
    {

        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        [Required]
        public AF1BL080501Dtco AF1BL080501 { get; set; }
    }
}
