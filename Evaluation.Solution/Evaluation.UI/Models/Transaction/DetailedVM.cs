using Evaluation.UI.DTO.BL080501;

namespace Evaluation.UI.Models.Transaction
{
    public class DetailedVM
    {
        public int SalesTransactionId { get; set; }
        public String BusinessLineCode { get; set; }
        public String PageType { get; set; }
        public List<CQFullListBL080501Dto> CQFullListBL080501 { get; set; }
        public List<CQShortListBL080501Dto> CQShortListBL080501 { get; set; }
        public List<CQHeader080501> CQHeaderBL080501 { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
