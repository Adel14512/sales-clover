using Evaluation.CAL.DTO.ProductBenefits;
using Evaluation.CAL.DTO.ProductPriceList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Response.ProductBenefits
{
    public class ProductBenefitsResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<ProductBenefitsDto> ProductBenefitsList { get; set; }
    }
}
