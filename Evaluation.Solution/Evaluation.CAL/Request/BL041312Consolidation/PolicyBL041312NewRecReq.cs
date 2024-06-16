using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL041312Consolidation
{
    public class PolicyBL041312NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public string InsurerCode { get; set; }
        public string ThirdPartyAdminCode { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
