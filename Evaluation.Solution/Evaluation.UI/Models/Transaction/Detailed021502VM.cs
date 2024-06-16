
using Evaluation.UI.DTO.BL021502;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed021502VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL021502Dto> CQFullListBL021502 { get; set; }
        public List<CQShortListBL021502Dto> CQShortListBL021502 { get; set; }
        public List<CQHeader021502Dto> CQHeaderBL021502 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
