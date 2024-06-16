using Evaluation.CAL.DTO;
using System.Collections.Generic;

namespace Evaluation.CAL.Response.Product
{
    public class ProductLookupFindAllResp
    {
        public WebResponseCommon WebResponseCommon { get; set; }
        public List<RegionDto> Region { get; set; }
        public List<TerritorialScope> TerritorialScope { get; set; }
        public List<ThirdPartyAdminDto> ThirdPartyAdmin { get; set; }
        public List<InsurerDto> Insurer { get; set; }
        public List<CurrencyDto> Currency { get; set; }
        public List<BranchDto> Branch { get; set; }
        public List<ProductDetailsPOISectionDto> ProductDetailsPOISection { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverage { get; set; }
        public List<ProductDetailsPOINetwork> ProductDetailsPOINetwork { get; set; }

    }
}
