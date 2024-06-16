using Evaluation.UI.Request;
using System.ComponentModel.DataAnnotations;


namespace Evaluation.UI.Request.BL331211Consolidation
{
    public class PolicyRelatedDocBL331211UpdRecReq : GenericEmptyReq
    {
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
