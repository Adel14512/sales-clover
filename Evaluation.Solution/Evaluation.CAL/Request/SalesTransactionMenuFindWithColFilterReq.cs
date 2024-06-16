using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request
{
    public class SalesTransactionMenuFindWithColFilterReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        public string ClientType { get; set; }
        public int ContactId { get; set; }
    }
}
