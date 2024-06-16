
using Evaluation.UI.DTO.BL090703;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed090703VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL090703Dto> CQFullListBL090703 { get; set; }
        public List<CQShortListBL090703Dto> CQShortListBL090703 { get; set; }
        public List<CQHeader090703Dto> CQHeaderBL090703 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
