
namespace Evaluation.UI.Request.BL010602Consolidation
{
    public class PolicyRelatedDocBL010602UpdRecReq:GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
