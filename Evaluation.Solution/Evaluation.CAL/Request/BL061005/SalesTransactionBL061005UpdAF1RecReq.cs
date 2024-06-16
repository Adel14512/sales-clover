using Evaluation.CAL.DTO.BL061005;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL061005
{
    public class SalesTransactionBL061005UpdAF1RecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public int RecId { get; set; }
        public int ClientId { get; set; }
        public int MasterId { get; set; }
        //[Required]
        public List<AF1BL061005Dto> AF1BL061005 { get; set; }
    }
}
