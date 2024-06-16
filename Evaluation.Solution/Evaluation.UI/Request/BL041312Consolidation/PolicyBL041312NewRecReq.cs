using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.BL041312Consolidation
{
    public class PolicyBL041312NewRecReq : GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public string InsurerCode { get; set; }
        public string ThirdPartyAdminCode { get; set; }
        public string BusinessLineCode { get; set; }
    }
}
