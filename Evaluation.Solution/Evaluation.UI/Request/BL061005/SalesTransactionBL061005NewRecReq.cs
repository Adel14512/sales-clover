
using Evaluation.UI.DTO.BL061005;
using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL061005
{
    public class SalesTransactionBL061005NewRecReq : GenericEmptyReq
    {
        [Required]
        public string BusinessLineCode { get; set; }
        [Required]
        public int ContactId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public List<AF1BL061005Dto> AF1BL061005 { get; set; }
    }
}
