
using Evaluation.UI.DTO.BL051807;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL051807
{
    public class SalesTransactionBL051807NewRecReq : GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL051807Dto> AF1BL051807 { get; set; }
    }
}
