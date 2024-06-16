
using Evaluation.UI.DTO.ProductCombination;
using Evaluation.UI.Response;
using System.Collections.Generic;

namespace Evaluation.UI.Response.ProductCombination
{
    public class ProductCombinationListResp : GenericWebResponse
    {
        public List<ProductCombinationDto> ProductCombination { get; set; }
    }
}