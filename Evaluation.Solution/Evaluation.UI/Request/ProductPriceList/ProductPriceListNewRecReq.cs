
using Evaluation.UI.DTO.ProductPriceList;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluation.UI.Request.ProductPriceList
{
    public class ProductPriceListNewRecReq :GenericEmptyReq
    {

        [Required]
        public List<ProductPriceListNewDto> ProductPriceList { get; set; }
    }
}
