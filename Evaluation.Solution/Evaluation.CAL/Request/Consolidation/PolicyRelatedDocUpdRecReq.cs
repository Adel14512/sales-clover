using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.Consolidation
{
    public class PolicyRelatedDocUpdRecReq
    {
        public WebRequestCommon WebRequestCommon { get; set; }
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
