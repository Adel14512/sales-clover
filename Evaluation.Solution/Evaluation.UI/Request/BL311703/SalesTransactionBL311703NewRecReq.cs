
using Evaluation.UI.DTO.BL311703;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL311703
{
    public class SalesTransactionBL311703NewRecReq : GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL311703Dto> AF1BL311703 { get; set; }
    }
}
