using System;

namespace Evaluation.CAL.DTO.Product
{
    public class ProductDetailsPOINewDto
    {
        public int ProductId { get; set; }
        public int TechnicalSheet { get; set; }
        public int SectionId { get; set; }
        public bool Covered { get; set; }
        public int? TerritorialScope { get; set; }
        public int? ClassId { get; set; }
        public decimal? CommissionInsurance { get; set; }
        public decimal? LimitAmount { get; set; }
        public decimal? LimitAmountMaxRange { get; set; }
        public int NetworkId { get; set; }
        //public decimal Commision { get; set; }
    }
}
