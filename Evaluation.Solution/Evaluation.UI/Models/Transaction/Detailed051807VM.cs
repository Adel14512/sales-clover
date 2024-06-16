using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL051807;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed051807VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL051807Dto> CQFullListBL051807 { get; set; }
        public List<CQShortListBL051807Dto> CQShortListBL051807 { get; set; }
        public List<CQHeader051807Dto> CQHeaderBL051807 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
