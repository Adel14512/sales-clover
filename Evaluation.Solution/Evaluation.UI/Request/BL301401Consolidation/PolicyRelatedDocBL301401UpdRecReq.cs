using Evaluation.UI.Request;


namespace Evaluation.UI.Request.BL301401Consolidation
{
    public class PolicyRelatedDocBL301401UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
