using System;

namespace Evaluation.CAL.DTO.Product
{
    public class ProductFullNewDto
    {
        public int BranchId { get; set; }
        public int InsurerId { get; set; }
        public string InsurerProductName { get; set; }
        public int ThirdPartyAdminId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public bool IsActive { get; set; }
        public int CurrencyId { get; set; }
        public int CountryOfResidence { get; set; }
        public int? ToCountry { get; set; }
        public int? FromCountry { get; set; }
        public bool SubjectToProrata { get; set; }
        public string PolicyCreationId { get; set; }
        public bool Standalone { get; set; }
        public bool NoUnderwriting { get; set; }
        public string Continuity { get; set; }
        public bool NoWaitingPeriod { get; set; }
        public bool GuaranteeRenewability { get; set; }
        public int NewBusinessAgeMinRange { get; set; }
        public int NewBusinessAgeMaxRange { get; set; }
        public int RenewalAgeMinRange { get; set; }
        public int RenewalAgeMaxRange { get; set; }
        public bool ChildStandalone { get; set; }
        public bool AgeCalculationYear { get; set; }
        public bool AgeCalculationFullDate { get; set; }
        public bool FamilyRatesCalculation { get; set; }
        public decimal CommisionFromGP { get; set; }
        public decimal VATOnCommision { get; set; }
        public decimal FixedTaxes { get; set; }
        public decimal BuiltInPropTaxes { get; set; }
        public decimal BuiltInCostOfPolicy { get; set; }
        public decimal InsurerLoading { get; set; }
        public bool NoClaimBonus { get; set; }
    }
}
