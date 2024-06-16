using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL061005;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed061005VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL061005Dto> CQFullListBL061005 { get; set; }
        public List<CQShortListBL061005Dto> CQShortListBL061005 { get; set; }
        public List<CQHeader061005Dto> CQHeaderBL061005 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
