using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL321110;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed321110VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL321110Dto> CQFullListBL321110 { get; set; }
        public List<CQShortListBL321110Dto> CQShortListBL321110 { get; set; }
        public List<CQHeader321110> CQHeaderBL321110 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
