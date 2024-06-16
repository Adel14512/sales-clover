using Evaluation.UI.DTO;

namespace Evaluation.UI.Response
{
    public class SalesTransactionFindWithContactIdFilterResp : GenericWebResponse
    {
        public List<SalesTransactionDto> SalesTransaction { get; set; }
    }
}
