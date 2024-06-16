using Evaluation.UI.DTO.BL321110;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110
{
    public class SalesTransactionBL321110NewRecReq :GenericEmptyReq
    {
       
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL321110Dto> AF1BL321110 { get; set; }
    }
}
