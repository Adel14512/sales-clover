

using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL090703Consolidation
{
    public class PolicyRelatedDocBL090703UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
