
namespace Evaluation.CAL.Request.BL021502Consolidation
{
    public class PolicyRelatedDocBL021502UpdRecReq
    {
        public WebRequestCommon WebRequestCommon { get; set; }
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
