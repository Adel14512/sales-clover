using Evaluation.UI.DTO;

namespace Evaluation.UI.Models
{
    public class SalesTransactionDashboardVM
    {
        public List<SalesTransactionDto> SalesTransactions { get; set; }
        public ContactVM ContactVM { get; set; }
    }
}
