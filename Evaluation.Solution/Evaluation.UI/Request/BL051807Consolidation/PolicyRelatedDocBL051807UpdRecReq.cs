
using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL051807Consolidation
{
    public class PolicyRelatedDocBL051807UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
