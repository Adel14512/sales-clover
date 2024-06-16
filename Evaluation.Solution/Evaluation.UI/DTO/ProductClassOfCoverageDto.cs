using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO
{
    public class ProductClassOfCoverageDto
    {
        public int RecId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
 
    }
}
