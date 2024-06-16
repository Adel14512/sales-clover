

using Evaluation.UI.Request;

namespace Evaluation.UI.Request.BL291908Consolidation
{
    public class PolicyRelatedDocBL291908UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
