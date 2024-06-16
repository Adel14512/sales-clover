
using Evaluation.UI.DTO.BL301401;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed301401VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL301401Dto> CQFullListBL301401 { get; set; }
        public List<CQShortListBL301401Dto> CQShortListBL301401 { get; set; }
        public List<CQHeader> CQHeaderBL301401 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
