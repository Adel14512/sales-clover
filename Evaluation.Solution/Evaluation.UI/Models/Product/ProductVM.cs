using Evaluation.UI.DTO;
using Evaluation.UI.DTO.Product;
using Evaluation.UI.DTO.ProductBenefits;
using Evaluation.UI.DTO.ProductCombination;
using Evaluation.UI.DTO.ProductPriceList;
using Evaluation.UI.Response.ProductBenefits;

namespace Evaluation.UI.Models.Product
{
    public class ProductVM
    {
        public List<RegionDto> Regions { get; set; }
        public List<TerritorialScope> TerritorialScopes { get; set; }
        public List<ThirdPartyAdminDto> ThirdPartyAdmins { get; set; }
        public List<InsurerDto> Insurers { get; set; }
        public List<CurrencyDto> Currencys { get; set; }
        public List<BranchDto> Branchs { get; set; }
        public List<ProductDetailsPOISectionDto> ProductDetailsPOISections { get; set; }
        public List<ProductClassOfCoverageDto> ProductClassOfCoverages { get; set; }
        public List<ProductDetailsPOINetwork> ProductDetailsPOINetworks { get; set; }
        public ProductFullNewDto Product { get; set; }
        public List<ProductBenefitsDto> ProductBenefits { get; set; }
        public List<ProductPriceListDto> ProductPrices { get; set; }
        public ProductFullDto EditProduct { get; set; }
        public string BusinessLineCode { get; set; }
        public List<ProductCombinationDto> ProductCombination { get; set; }
    }
}
