using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.BL321110Consolidation
{
    public class PolicyBL321110NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public string InsurerCode { get; set; }
        public string ThirdPartyAdminCode { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
