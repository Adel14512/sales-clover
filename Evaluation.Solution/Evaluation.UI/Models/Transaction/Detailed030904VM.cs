using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL030904;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed030904VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL030904Dto> CQFullListBL030904 { get; set; }
        public List<CQShortListBL030904Dto> CQShortListBL030904 { get; set; }
        public List<CQHeader030904Dto> CQHeaderBL030904 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
