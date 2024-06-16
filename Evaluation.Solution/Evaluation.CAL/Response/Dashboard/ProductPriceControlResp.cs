using Evaluation.CAL.DTO.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.Dashboard
{
    public class ProductPriceControlResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ProductPriceControlDto> ProductPriceControl { get; set; }
    }
}