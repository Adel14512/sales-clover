
using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL281609Consolidation
{
    public class PolicyRelatedDocBL281609UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
