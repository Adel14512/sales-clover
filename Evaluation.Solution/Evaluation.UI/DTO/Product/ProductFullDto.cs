using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Evaluation.UI.DTO.Product
{
    public class ProductFullDto
    {
        public int RecId { get; set; }
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
        public int SchedulePaymentInitial { get; set; }
        public int SchedulePaymentDuringYear { get; set; }
        public int SchedulePaymentNewBusiness { get; set; }
        public int SchedulePaymentIndividualDuringYear { get; set; }
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
        public List<ProductDetailsDto> ProductDetails { get; set; }
        public decimal CommisionFromGP { get; set; }
        public decimal VATOnCommision { get; set; }
        public decimal FixedTaxes { get; set; }
        public decimal BuiltInPropTaxes { get; set; }
        public decimal BuiltInCostOfPolicy { get; set; }
        public decimal InsurerLoading { get; set; }
        public List<ProductDetailsPOIDto> ProductDetailsPOI { get; set; }
        public bool NoClaimBonus { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime LastModifiedDate { get; set; }
        [JsonIgnore]
        public string Reserved1 { get; set; }
        [JsonIgnore]
        public string Reserved2 { get; set; }
    }
}
