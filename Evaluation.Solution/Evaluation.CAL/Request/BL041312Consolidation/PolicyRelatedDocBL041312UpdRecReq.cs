using System.ComponentModel.DataAnnotations;


namespace Evaluation.CAL.Request.BL041312Consolidation
{
    public class PolicyRelatedDocBL041312UpdRecReq
    {
        public WebRequestCommon WebRequestCommon { get; set; }
        public int RecId { get; set; }
        public byte[] AttachDocBinary { get; set; }
        public string AttachDocName { get; set; }
        public string AttachDocExt { get; set; }
    }
}
