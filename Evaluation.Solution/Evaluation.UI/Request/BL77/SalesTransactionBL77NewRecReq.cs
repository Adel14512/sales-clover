using Evaluation.UI.Models;
using System.ComponentModel.DataAnnotations;
namespace Evaluation.UI.Request.BL77
{
    public class SalesTransactionBL77NewRecReq :GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        public List<AF1BL77Dto> AF1BL77 { get; set; }
    }
}