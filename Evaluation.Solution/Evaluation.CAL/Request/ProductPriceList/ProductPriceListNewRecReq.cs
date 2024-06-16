using Evaluation.CAL.DTO.ProductPriceList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.CAL.Request.ProductPriceList
{
    public class ProductPriceListNewRecReq
    {

        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public List<ProductPriceListNewDto> ProductPriceList { get; set; }
    }
}
