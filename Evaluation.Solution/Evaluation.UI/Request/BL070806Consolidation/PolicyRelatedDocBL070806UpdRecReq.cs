
using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL070806Consolidation
{
    public class PolicyRelatedDocBL070806UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
