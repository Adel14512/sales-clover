using Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Request.ProductDetailsPOIAllNetwork
{
    public class ProductDetailsPOINetworkUpdRecReq
    {
        [Required]
        public WebRequestCommon WebRequestCommon { get; set; }
        [Required]
        public ProductDetailsPOINetworkUpdDto ProductDetailsPOINetwork { get; set; }
    }
}
