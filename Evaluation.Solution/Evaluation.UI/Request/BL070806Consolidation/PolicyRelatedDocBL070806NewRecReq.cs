

using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL070806Consolidation
{
    public class PolicyRelatedDocBL070806NewRecReq : GenericEmptyReq
    {
        public int SalesTransactionId { get; set; }
        public int TicketId { get; set; }
        public string ParentPolicyId { get; set; }
        public string PolicyId { get; set; }
        public string BusinessLineCode { get; set; }
        public string DocumentType { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
