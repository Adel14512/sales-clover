using Evaluation.CAL.DTO.ProductPriceList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.ProductPriceList
{
    public class ProductPriceListResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ProductPriceListDto> ProductPriceList { get; set; }
    }
}
