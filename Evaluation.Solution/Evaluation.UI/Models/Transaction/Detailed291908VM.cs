using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL291908;

namespace Evaluation.UI.Models.Transaction
{
    public class Detailed291908VM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL291908Dto> CQFullListBL291908 { get; set; }
        public List<CQShortListBL291908Dto> CQShortListBL291908 { get; set; }
        public List<CQHeader291908Dto> CQHeaderBL291908 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
