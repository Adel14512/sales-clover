

using Evaluation.UI.DTO.BusinessLineDetailsProduct;
using Evaluation.UI.Response;

namespace Evaluation.UI.Response.BusinessLineDetailsProduct
{
    public class BusinessLineDetailsProductResp : GenericWebResponse
    {
        public BusinessLineDetailsProductDto BusinessLineDetailsProduct { get; set; }
    }
}
