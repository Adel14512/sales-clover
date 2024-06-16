
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL281609
{
    public class SalesTransactionBL281609NewRecReq : GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL281609Dto> AF1BL281609 { get; set; }
    }
}
