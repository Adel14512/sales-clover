
namespace Evaluation.CAL.Request.BL070806Consolidation
{
    public class PolicyRelatedDocBL070806UpdRecReq
    {
        public WebRequestCommon WebRequestCommon { get; set; }
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
