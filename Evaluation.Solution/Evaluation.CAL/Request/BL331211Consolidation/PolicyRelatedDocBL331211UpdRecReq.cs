using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL331211Consolidation
{
    public class PolicyRelatedDocBL331211UpdRecReq
    {
        public WebRequestCommon WebRequestCommon { get; set; }
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
