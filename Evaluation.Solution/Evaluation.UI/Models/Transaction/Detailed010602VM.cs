
using Evaluation.UI.DTO.BL010602;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed010602VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL010602Dto> CQFullListBL010602 { get; set; }
        public List<CQShortListBL010602Dto> CQShortListBL010602 { get; set; }
        public List<CQHeader010602Dto> CQHeaderBL010602 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
