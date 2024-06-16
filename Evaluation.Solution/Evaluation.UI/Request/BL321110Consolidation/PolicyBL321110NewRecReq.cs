using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL321110Consolidation
{
    public class PolicyBL321110NewRecReq : GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public string InsurerCode { get; set; }
        public string ThirdPartyAdminCode { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
