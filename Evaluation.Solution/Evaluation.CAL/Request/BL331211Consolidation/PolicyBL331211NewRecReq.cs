using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL331211Consolidation
{
    public class PolicyBL331211NewRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public int SalesTransactionId { get; set; }
        public string InsurerCode { get; set; }
        public string ThirdPartyAdminCode { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
