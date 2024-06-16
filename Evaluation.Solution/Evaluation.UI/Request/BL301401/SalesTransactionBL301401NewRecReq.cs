using Evaluation.UI.DTO.BL301401;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL301401
{
    public class SalesTransactionBL301401NewRecReq : GenericEmptyReq
    {
       
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL301401Dto> AF1BL301401 { get; set; }
    }
}
