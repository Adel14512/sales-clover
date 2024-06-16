using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL281609;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed281609VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL281609Dto> CQFullListBL281609 { get; set; }
        public List<CQShortListBL281609Dto> CQShortListBL281609 { get; set; }
        public List<CQHeader281609Dto> CQHeaderBL281609 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
