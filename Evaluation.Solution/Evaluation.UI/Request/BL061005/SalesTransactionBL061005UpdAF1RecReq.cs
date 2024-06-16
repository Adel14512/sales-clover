
using Evaluation.UI.DTO.BL061005;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL061005
{
    public class SalesTransactionBL061005UpdAF1RecReq : GenericEmptyReq
    {
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public List<AF1BL061005Dto> AF1BL061005 { get; set; }
    }
}
