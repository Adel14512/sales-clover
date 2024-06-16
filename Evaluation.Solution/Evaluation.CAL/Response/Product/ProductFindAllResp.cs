using Evaluation.CAL.DTO.Product;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Product
{
    public class ProductFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ProductDto> Product { get; set; }
    }
}
