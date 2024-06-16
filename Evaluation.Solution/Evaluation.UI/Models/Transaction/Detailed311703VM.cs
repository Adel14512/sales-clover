using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL311703;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed311703VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL311703Dto> CQFullListBL311703 { get; set; }
        public List<CQShortListBL311703Dto> CQShortListBL311703 { get; set; }
        public List<CQHeader311703Dto> CQHeaderBL311703 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
