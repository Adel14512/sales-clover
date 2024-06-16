using System;

namespace Evaluation.CAL.DTO.Product
{
    public class ProductDetailsNewDto
    {
        public int ProductId { get; set; }
        public int ClassId { get; set; }
        public decimal AmlAmount { get; set; }
        public decimal CostPolicy { get; set; }
        public decimal AdminFees { get; set; }
        public decimal FirstYearDiscount { get; set; }
        public decimal Commision { get; set; }
        public decimal CostPolicyAmount { get; set; }
        public decimal FixedTaxAmount { get; set; }
        public decimal ProperTaxPer { get; set; }
        public decimal VatPer { get; set; }
    }
}
