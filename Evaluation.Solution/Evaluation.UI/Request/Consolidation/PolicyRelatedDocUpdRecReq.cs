using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.Consolidation
{
    public class PolicyRelatedDocUpdRecReq:GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
