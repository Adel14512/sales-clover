
using Evaluation.UI.DTO.ProductDetailsPOIAllNetwork;
using Evaluation.UI.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation.CAL.Request.ProductDetailsPOIAllNetwork
{
    public class ProductDetailsPOINetworkUpdRecReq : GenericEmptyReq
    {
        [Required]
        public ProductDetailsPOINetworkUpdDto ProductDetailsPOINetwork { get; set; }
    }
}
