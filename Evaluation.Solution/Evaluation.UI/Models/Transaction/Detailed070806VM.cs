
using Evaluation.UI.DTO.BL070806;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed070806VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL070806Dto> CQFullListBL070806 { get; set; }
        public List<CQShortListBL070806Dto> CQShortListBL070806 { get; set; }
        public List<CQHeader070806Dto> CQHeaderBL070806 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
