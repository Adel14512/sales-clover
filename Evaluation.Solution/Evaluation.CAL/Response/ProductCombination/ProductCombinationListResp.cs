using Evaluation.CAL.DTO.ProductCombination;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.ProductCombination
{
    public class ProductCombinationListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ProductCombinationDto> ProductCombination { get; set; }
    }
}