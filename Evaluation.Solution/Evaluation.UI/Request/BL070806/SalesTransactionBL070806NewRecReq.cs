
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL070806
{
    public class SalesTransactionBL070806NewRecReq : GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        //[Required]
        public AF1BL070806Dtco AF1BL070806 { get; set; }
    }
}
