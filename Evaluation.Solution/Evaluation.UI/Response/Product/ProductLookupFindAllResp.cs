
using Evaluation.UI.DTO;

namespace Evaluation.UI.Response.Product
{
    public class ProductLookupFindAllResp : GenericWebResponse
    {
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
