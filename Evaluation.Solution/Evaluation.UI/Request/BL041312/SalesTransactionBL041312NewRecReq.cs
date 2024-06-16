
using Evaluation.UI.DTO.BL041312;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312
{
    public class SalesTransactionBL041312NewRecReq : GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL041312Dto> AF1BL041312 { get; set; }
    }
}
