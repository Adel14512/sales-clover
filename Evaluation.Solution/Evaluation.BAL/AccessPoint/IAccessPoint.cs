using Evaluation.CAL.DTO;
using Evaluation.CAL.DTO.AF1ColHeader;
using Evaluation.CAL.DTO.BL010602;
using Evaluation.CAL.DTO.BL010602Consolidation;
using Evaluation.CAL.DTO.BL021502;
using Evaluation.CAL.DTO.BL021502Consolidation;
using Evaluation.CAL.DTO.BL030904;
using Evaluation.CAL.DTO.BL041312;
using Evaluation.CAL.DTO.BL041312Consolidation;
using Evaluation.CAL.DTO.BL051807;
using Evaluation.CAL.DTO.BL051807Consolidation;
using Evaluation.CAL.DTO.BL061005;
using Evaluation.CAL.DTO.BL070806;
using Evaluation.CAL.DTO.BL070806Consolidation;
using Evaluation.CAL.DTO.BL080501;
using Evaluation.CAL.DTO.BL090703;
using Evaluation.CAL.DTO.BL090703Consolidation;
using Evaluation.CAL.DTO.BL281609;
using Evaluation.CAL.DTO.BL281609Consolidation;
using Evaluation.CAL.DTO.BL291908;
using Evaluation.CAL.DTO.BL291908Consolidation;
using Evaluation.CAL.DTO.BL301401;
using Evaluation.CAL.DTO.BL301401Consolidation;
using Evaluation.CAL.DTO.BL311703;
using Evaluation.CAL.DTO.BL321110;
using Evaluation.CAL.DTO.BL321110Consolidation;
using Evaluation.CAL.DTO.BL331211;
using Evaluation.CAL.DTO.BL331211Consolidation;
using Evaluation.CAL.DTO.BL77;
using Evaluation.CAL.DTO.BLDuplication;
using Evaluation.CAL.DTO.BusinessLineDetailsProduct;
using Evaluation.CAL.DTO.Consolidation;
using Evaluation.CAL.DTO.Dashboard;
using Evaluation.CAL.DTO.Global;
using Evaluation.CAL.DTO.Kyc;
using Evaluation.CAL.DTO.Product;
using Evaluation.CAL.DTO.ProductBenefits;
using Evaluation.CAL.DTO.ProductCombination;
using Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.DTO.ProductPriceList;
using Evaluation.CAL.DTO.Renewal;
using Evaluation.CAL.DTO.SpecialCondition;
using Evaluation.CAL.DTO.Ticket;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response.Renewal;
using System;
using System.Collections.Generic;

namespace Evaluation.BAL.AccessPoint
{
    public interface IAccessPoint
    {
        List<UserDto> CheckUserCred(string userName, string userPassword);

        List<UserDto> IsUserAvailable(string userName);

        List<UserDto> RegisterUser(UserRegisterDto userRegisterDto);

        List<UserDto> UpdateUserPassword(UserChangePasswordDto userChangePasswordDto);

        List<RegionDto> RegionFindAll();
        RegionDto RegionNewRec(RegionNewDto regionDto, string createdBy);
        RegionDto RegionUpdRec(RegionUpdDto regionDto, string lastModifiedBy);

        List<GenderDto> GenderFindAll();
        GenderDto GenderNewRec(GenderNewDto genderNewDto, string createdBy);
        GenderDto GenderUpdRec(GenderUpdDto genderDto, string lastModifiedBy);

        List<ChannelDto> ChannelFindAll();
        ChannelDto ChannelNewRec(ChannelNewDto channelNewDto, string createdBy);
        ChannelDto ChannelUpdRec(ChannelUpdDto channelDto, string lastModifiedBy);
        TokenDto TokenKey(AuthDto authDto);
        List<ContactDto> ContactFindWithAnyValue(string searchValue);
        List<ContactDto> ContactFindWithAnyFilter(ContactChannelSearchWithFilterReq contactChannelSearchWithFilterReq);
        List<ContactDto> ContactFindWithRecIdFilter(int recId);
        AF1BL80Dto AF1BL80NewRec(AF1BL80NewDto aF1BL80NewDto, string createdBy);
        List<ContactDto> ContactChannelNewRec(ContactNewDto contactNewDto, string createdBy);
        List<ContactDto> ContactChannelUpdRec(ContactUpdDto contactUpdDto, string createdBy);
        List<LookupDto> LookupFindAll();
        List<LeadLookupDto> LeadLookupFindAll();
        List<BusinessLineDto> BusinessLineFindAll();
        List<MaritalStatusDto> MaritalStatusFindAll();
        MaritalStatusDto MaritalStatusNewRec(MaritalStatusNewDto maritalStatusDto, string createdBy);
        MaritalStatusDto MaritalStatusUpdRec(MaritalStatusUpdDto maritalStatusDto, string lastModifiedBy);
        List<SalesTransactionMenuDto> SalesTransactionMenuFindWithColFilter(string clientType, int contactId);
        SalesTransactionMenuDto SalesTransactionMenuFindWithRecIdFilter(int recId);
        SalesTransactionBL77Dto SalesTransactionBL77NewRec(int businessLinId, int contactId, List<AF1BL77Dto> aF1BL77Dto, string createdBy);
        SalesTransactionBL77Dto SalesTransactionBL77UpdRec(int recId, List<AF1BL77Dto> aF1BL77Dto, string lastModifiedBy);
        SalesTransactionBL77Dto SalesTransactionBL77FindWithRecIdFilter(int recId);
        BusinessLineRelatedDocDto BusinessLineRelatedDocFindWithBusinessLineCodeFilter(string businessLineCode, string applicationForm);
        SalesTransactionBL77Dto SalesTransactionBL77FindWithColFilter(int businessLineId, int contactId);
        LeadDto LeadNewRec(LeadNewDto leadNewDto, string createdBy);
        List<LeadDto> LeadFindAll();
        SalesTransactionBL301401Dto SalesTransactionBL301401NewRec(string businessLineCode, int contactId, List<AF1BL301401Dto> aF1BL301401Dto, string createdBy);
        SalesTransactionBL321110Dto SalesTransactionBL321110NewRec(string businessLineCode, int contactId, List<AF1BL321110Dto> aF1BL321110Dto, string createdBy);
        SalesTransactionBL080501Dto SalesTransactionBL080501NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL080501Dtco aF1BL080501Dtco, string createdBy, string policyId = "");
        List<SalesTransactionDto> SalesTransactionFindWithContactIdFilter(int contactId, int internalStatus);
        SalesTransactionBL080501Dto SalesTransactionBL080501FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL301401Dto SalesTransactionBL301401FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL321110Dto SalesTransactionBL321110FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL301401Dto SalesTransactionBL301401UpdAF1Rec(int recId, List<AF1BL301401Dto> aF1BL301401Dto, string lastModifiedBy);
        SalesTransactionBL321110Dto SalesTransactionBL321110UpdAF1Rec(int recId, List<AF1BL321110Dto> aF1BL321110Dto, string lastModifiedBy);
        SalesTransactionBL080501Dto SalesTransactionBL080501UpdAF1Rec(int recId, int clientId, int masterId, AF1BL080501Dtco aF1BL080501Dtco, string lastModifiedBy);
        List<CQDetailsBL080501Dto> SalesTransactionBL080501FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL080501Dto> SalesTransactionBL080501FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL301401Dto> SalesTransactionBL301401FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL301401Dto> SalesTransactionBL301401FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL321110Dto> SalesTransactionBL321110FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL321110FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL331211FindCQSummaryWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL080501FindCQPivotWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL080501FindCQBenefitCompareWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL301401FindCQPivotWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL321110FindCQPivotWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL080501FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL301401FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL321110FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL321110FindCQPivotBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL331211FindCQPivotBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL041312FindCQPivotBenefitWithRecIdFilter(int salesTransactionId);


        List<dynamic> SalesTransactionBL080501FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL301401FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL321110FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader301401Dto> SalesTransactionBL301401FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory> SalesTransactionBL301401FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQHeader080501> SalesTransactionBL080501FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory080501> SalesTransactionBL080501FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQHeader321110> SalesTransactionBL321110FindCQHeaderWithRecIdFilter(int salesTransactionId);
        //List<CQHeader041312Dto> SalesTransactionBL041312FindCQHeaderWithRecIdFilter(int salesTransactionId);

        List<CQCategory321110> SalesTransactionBL321110FindCQCategoryWithRecIdFilter(int salesTransactionId);
        SpecialConditionDto SpecialConditionNewRec(int salesTrxId, string businessLineCode, int productId, int sheet,
            decimal discountPer, decimal discountAmount, string createdBy);
        SpecialConditionDto SpecialConditionFindWithColFilter(int salesTrxId, string businessLineCode, int productId,
           int sheet);
        AF1ColHeaderDto AF1ColHeaderWithColFilter(string aF1Code, string aF1ColHeader);
        SalesTransactionBL021502Dto SalesTransactionBL021502NewRec(string businessLineCode, int contactId, List<AF1BL021502Dto> aF1BL021502Dto, string createdBy);
        SalesTransactionBL021502Dto SalesTransactionBL021502FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL021502Dto SalesTransactionBL021502UpdAF1Rec(int recId, List<AF1BL021502Dto> aF1BL021502Dto, string lastModifiedBy);
        SalesTransactionBL041312Dto SalesTransactionBL041312NewRec(string businessLineCode, int contactId, List<AF1BL041312Dto> aF1BL041312Dto, string createdBy);
        SalesTransactionBL041312Dto SalesTransactionBL041312FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL041312Dto SalesTransactionBL041312UpdAF1Rec(int recId, List<AF1BL041312Dto> aF1BL041312Dto, string lastModifiedBy);
        SalesTransactionBL051807Dto SalesTransactionBL051807NewRec(string businessLineCode, int contactId, List<AF1BL051807Dto> aF1BL051807Dto, string createdBy);
        SalesTransactionBL051807Dto SalesTransactionBL051807FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL051807Dto SalesTransactionBL051807UpdAF1Rec(int recId, List<AF1BL051807Dto> aF1BL051807Dto, string lastModifiedBy);
        SalesTransactionBL281609Dto SalesTransactionBL281609NewRec(string businessLineCode, int contactId, List<AF1BL281609Dto> aF1BL281609Dto, string createdBy);
        SalesTransactionBL281609Dto SalesTransactionBL281609FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL281609Dto SalesTransactionBL281609UpdAF1Rec(int recId, List<AF1BL281609Dto> aF1BL281609Dto, string lastModifiedBy);
        SalesTransactionBL291908Dto SalesTransactionBL291908NewRec(string businessLineCode, int contactId, List<AF1BL291908Dto> aF1BL291908Dto, string createdBy);
        SalesTransactionBL291908Dto SalesTransactionBL291908FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL291908Dto SalesTransactionBL291908UpdAF1Rec(int recId, List<AF1BL291908Dto> aF1BL291908Dto, string lastModifiedBy);
        SalesTransactionBL311703Dto SalesTransactionBL311703NewRec(string businessLineCode, int contactId, List<AF1BL311703Dto> aF1BL311703Dto, string createdBy);
        SalesTransactionBL311703Dto SalesTransactionBL311703FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL311703Dto SalesTransactionBL311703UpdAF1Rec(int recId, List<AF1BL311703Dto> aF1BL311703Dto, string lastModifiedBy);
        SalesTransactionBL331211Dto SalesTransactionBL331211NewRec(string businessLineCode, int contactId, List<AF1BL331211Dto> aF1BL331211Dto, string createdBy);
        SalesTransactionBL331211Dto SalesTransactionBL331211FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL331211Dto SalesTransactionBL331211UpdAF1Rec(int recId, List<AF1BL331211Dto> aF1BL331211Dto, string lastModifiedBy);
        List<dynamic> SalesTransactionBL021502FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL021502FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader021502Dto> SalesTransactionBL021502FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory021502Dto> SalesTransactionBL021502FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL021502Dto> SalesTransactionBL021502FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL021502Dto> SalesTransactionBL021502FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL021502FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL041312FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL041312FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader041312Dto> SalesTransactionBL041312FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory041312Dto> SalesTransactionBL041312FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL041312Dto> SalesTransactionBL041312FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL041312FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL041312FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL051807FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL051807FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader051807Dto> SalesTransactionBL051807FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory051807Dto> SalesTransactionBL051807FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL051807Dto> SalesTransactionBL051807FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL051807Dto> SalesTransactionBL051807FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL051807FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL281609FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL281609FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader281609Dto> SalesTransactionBL281609FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory281609Dto> SalesTransactionBL281609FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL281609Dto> SalesTransactionBL281609FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL281609Dto> SalesTransactionBL281609FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL281609FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL291908FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL291908FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader291908Dto> SalesTransactionBL291908FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory291908Dto> SalesTransactionBL291908FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL291908Dto> SalesTransactionBL291908FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL291908Dto> SalesTransactionBL291908FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL291908FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL311703FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL311703FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader311703Dto> SalesTransactionBL311703FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory311703Dto> SalesTransactionBL311703FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL311703Dto> SalesTransactionBL311703FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL311703Dto> SalesTransactionBL311703FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL311703FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL331211FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL331211FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader331211Dto> SalesTransactionBL331211FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory331211Dto> SalesTransactionBL331211FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL331211Dto> SalesTransactionBL331211FindCQDetailsWithRecIdFilter(int salesTransactionId);
        //List<CQSummaryBL331211Dto> SalesTransactionBL331211FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL331211FindCQPivotWithRecIdFilter(int salesTransactionId);
        SalesTransactionBL010602Dto SalesTransactionBL010602FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL010602Dto SalesTransactionBL010602NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL010602Dtco aF1BL010602Dtco, string createdBy);
        SalesTransactionBL010602Dto SalesTransactionBL010602UpdAF1Rec(int recId, int clientId, int masterId, AF1BL010602Dtco aF1BL010602Dtco, string lastModifiedBy);

        List<dynamic> SalesTransactionBL010602FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL010602FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader010602Dto> SalesTransactionBL010602FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory010602Dto> SalesTransactionBL010602FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL010602Dto> SalesTransactionBL010602FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL010602Dto> SalesTransactionBL010602FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL010602FindCQPivotWithRecIdFilter(int salesTransactionId);

        SalesTransactionBL030904Dto SalesTransactionBL030904NewRec(string businessLineCode, int contactId, List<AF1BL030904Dto> aF1BL030904Dto, string createdBy);
        SalesTransactionBL030904Dto SalesTransactionBL030904FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL030904Dto SalesTransactionBL030904UpdAF1Rec(int recId, List<AF1BL030904Dto> aF1BL030904Dto, string lastModifiedBy);
        List<ProductDto> ProductFindAll(bool isActive);
        List<ProductLookupDto> ProductLookupFindAll();
        ProductFullDto ProductFullNewRec(ProductFullNewDto productFullNewDto, string createdBy);
        ProductFullDto ProductFullFindWithRecIdFilter(int productId);
        ProductFullDto ProductFullUpdRec(ProductFullUpdDto productFullDto, string lastModifiedBy);
        List<ProductDetailsDto> ProductDetailsFindWithProductIdFilter(int productId);
        ProductDetailsDto ProductDetailsNewRec(ProductDetailsNewDto productDetailsNewDto, string createdBy);
        ProductDetailsDto ProductDetailsUpdRec(ProductDetailsUpdDto productDetailsDto, string lastModifiedBy);
        List<ProductDetailsPOIDto> ProductDetailsPOIFindWithProductIdFilter(int productId);
        ProductDetailsPOIDto ProductDetailsPOINewRec(ProductDetailsPOINewDto productDetailsPOINewDto, string createdBy);
        ProductDetailsPOIDto ProductDetailsPOIUpdRec(ProductDetailsPOIUpdDto productDetailsPIODto, string lastModifiedBy);
        BusinessLineDuplicationDto BusinessLineDuplicationNewRec(BusinessLineDuplicationNewDto businessLineDuplicationNewDto, string createdBy);
        TicketDetailsDto TicketDetailsUpdRec(TicketDetailsUpdDto ticketDetailsUpdDto, string lastModifiedBy);
        List<CQShortListBL080501Dto> SalesTransactionBL080501FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL080501Dto> SalesTransactionBL080501FindCQFullListWithRecIdFilter(int salesTransactionId);
        List<GlobalLookupDto> GlobalLookupFindAll();
        List<PolicyDto> PolicyNewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);
        List<PolicyDto> PolicyFindAllWithParentPolicyId(string parentPolicyId);
        List<PaymentScheduleDto> PolicyPaymentSchedule(int salesTransactionId, string businessLineCode);
        SalesTransactionBL080501Dto SalesTransactionBL080501UpdGlobalRec(int recId, int clientId,
           int masterId, string lastModifiedBy, string policyId);
        SalesTransactionBL301401Dto SalesTransactionBL301401UpdGlobalRec(int recId, int clientId,
           int masterId, string lastModifiedBy, string policyId);
        SalesTransactionBL321110Dto SalesTransactionBL321110UpdGlobalRec(int recId, int clientId,
          int masterId, string lastModifiedBy, string policyId);
        SalesTransactionBL331211Dto SalesTransactionBL331211UpdGlobalRec(int recId, int clientId,
          int masterId, string lastModifiedBy, string policyId);
        SalesTransactionBL041312Dto SalesTransactionBL041312UpdGlobalRec(int recId, int clientId,
        int masterId, string lastModifiedBy, string policyId);
        SalesTransactionBL281609Dto SalesTransactionBL281609UpdGlobalRec(int recId, int clientId,
        int masterId, string lastModifiedBy, string policyId);
        List<PolicyRelatedDocDto> PolicyRelatedDoc(int salesTransactionId, string businessLineCode);
        List<ClientCodeDto> ClientCodeFindWithRecid(int recId);
        PolicyRelatedDocDto PolicyRelatedDocUpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);
        PolicyRelatedDocDto PolicyRelatedDocNewRec(int salesTransactionId, int ticketId, string parentPolicyId,
            string policyId, string businessLineCode, string documentType, byte[] attachDocBinary,
            string attachDocName, string attachedDocExt, string lastModifiedBy);

        List<PolicyDto> PolicyUpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL301401Dto> PolicyBL301401NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);
        List<PaymentScheduleBL301401Dto> PolicyPaymentScheduleBL301401(int salesTransactionId, string businessLineCode);
        //SalesTransactionBL301401Dto SalesTransactionBL301401UpdGlobalRec(int recId, int clientId,
        //   int masterId, string lastModifiedBy);
        List<PolicyRelatedDocBL301401Dto> PolicyRelatedDocBL301401(int salesTransactionId, string businessLineCode);


        PolicyRelatedDocBL301401Dto PolicyRelatedDocBL301401UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);
        PolicyRelatedDocBL301401Dto PolicyRelatedDocBL301401NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
           string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
           string attachedDocExt, string lastModifiedBy);
        List<PolicyBL301401Dto> PolicyBL301401UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL321110Dto> PolicyBL321110NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode,
            string businessLineCode, string createdBy);
        List<PaymentScheduleBL321110Dto> PolicyPaymentScheduleBL321110(int salesTransactionId, string businessLineCode);
        //SalesTransactionBL301401Dto SalesTransactionBL301401UpdGlobalRec(int recId, int clientId,
        //   int masterId, string lastModifiedBy);
        List<PolicyRelatedDocBL321110Dto> PolicyRelatedDocBL321110(int salesTransactionId, string businessLineCode);


        PolicyRelatedDocBL321110Dto PolicyRelatedDocBL321110UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);
        PolicyRelatedDocBL321110Dto PolicyRelatedDocBL321110NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
           string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
           string attachedDocExt, string lastModifiedBy);
        List<PolicyBL321110Dto> PolicyBL321110UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate);

        List<CQShortListBL301401Dto> SalesTransactionBL301401FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL301401Dto> SalesTransactionBL301401FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL321110Dto> SalesTransactionBL321110FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL321110Dto> SalesTransactionBL321110FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<PolicyBL010602Dto> PolicyBL010602NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);

        List<PolicyBL010602Dto> PolicyBL010602UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PaymentScheduleBL010602Dto> PolicyPaymentScheduleBL010602(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL010602Dto> PolicyRelatedDocBL010602(int salesTransactionId, string businessLineCode);

        PolicyRelatedDocBL010602Dto PolicyRelatedDocBL010602UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL010602Dto PolicyRelatedDocBL010602NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
           string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
           string attachedDocExt, string lastModifiedBy);


        SalesTransactionBL070806Dto SalesTransactionBL070806FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL070806Dto SalesTransactionBL070806NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL070806Dtco aF1BL070806Dtco, string createdBy);
        SalesTransactionBL070806Dto SalesTransactionBL070806UpdAF1Rec(int recId, int clientId, int masterId, AF1BL070806Dtco aF1BL070806Dtco, string lastModifiedBy);

        List<dynamic> SalesTransactionBL070806FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL070806FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader070806Dto> SalesTransactionBL070806FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory070806Dto> SalesTransactionBL070806FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL070806Dto> SalesTransactionBL070806FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL070806Dto> SalesTransactionBL070806FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL070806FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<PolicyBL070806Dto> PolicyBL070806NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);

        List<PolicyBL070806Dto> PolicyBL070806UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PaymentScheduleBL070806Dto> PolicyPaymentScheduleBL070806(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL070806Dto> PolicyRelatedDocBL070806(int salesTransactionId, string businessLineCode);

        PolicyRelatedDocBL070806Dto PolicyRelatedDocBL070806UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL070806Dto PolicyRelatedDocBL070806NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
           string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
           string attachedDocExt, string lastModifiedBy);

        SalesTransactionBL090703Dto SalesTransactionBL090703FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL090703Dto SalesTransactionBL090703NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL090703Dtco aF1BL090703Dtco, string createdBy);
        SalesTransactionBL090703Dto SalesTransactionBL090703UpdAF1Rec(int recId, int clientId, int masterId, AF1BL090703Dtco aF1BL090703Dtco, string lastModifiedBy);

        List<dynamic> SalesTransactionBL090703FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL090703FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader090703Dto> SalesTransactionBL090703FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory090703Dto> SalesTransactionBL090703FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL090703Dto> SalesTransactionBL090703FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL090703Dto> SalesTransactionBL090703FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL090703FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<PolicyBL090703Dto> PolicyBL090703NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);

        List<PolicyBL090703Dto> PolicyBL090703UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PaymentScheduleBL090703Dto> PolicyPaymentScheduleBL090703(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL090703Dto> PolicyRelatedDocBL090703(int salesTransactionId, string businessLineCode);

        PolicyRelatedDocBL090703Dto PolicyRelatedDocBL090703UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL090703Dto PolicyRelatedDocBL090703NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
           string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
           string attachedDocExt, string lastModifiedBy);

        SalesTransactionBL061005Dto SalesTransactionBL061005FindAF1WithRecIdFilter(int salesTransactionId);
        SalesTransactionBL061005Dto SalesTransactionBL061005NewRec(string businessLineCode, int contactId, int clientId, int masterId, List<AF1BL061005Dto> aF1BL061005Dto, string createdBy);
        SalesTransactionBL061005Dto SalesTransactionBL061005UpdAF1Rec(int recId, int clientId, int masterId, List<AF1BL061005Dto> aF1BL061005Dto, string lastModifiedBy);

        List<dynamic> SalesTransactionBL061005FindCQBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL061005FindCQBillsWithRecIdFilter(int salesTransactionId);
        List<CQHeader061005Dto> SalesTransactionBL061005FindCQHeaderWithRecIdFilter(int salesTransactionId);
        List<CQCategory061005Dto> SalesTransactionBL061005FindCQCategoryWithRecIdFilter(int salesTransactionId);
        List<CQDetailsBL061005Dto> SalesTransactionBL061005FindCQDetailsWithRecIdFilter(int salesTransactionId);
        List<CQSummaryBL061005Dto> SalesTransactionBL061005FindCQSummaryWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL061005FindCQPivotWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL070806Dto> SalesTransactionBL070806FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL070806Dto> SalesTransactionBL070806FindCQFullListWithRecIdFilter(int salesTransactionId);
        List<CQShortListBL090703Dto> SalesTransactionBL090703FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL090703Dto> SalesTransactionBL090703FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL010602Dto> SalesTransactionBL010602FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL010602Dto> SalesTransactionBL010602FindCQFullListWithRecIdFilter(int salesTransactionId);
        List<CQShortListBL021502Dto> SalesTransactionBL021502FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL021502Dto> SalesTransactionBL021502FindCQFullListWithRecIdFilter(int salesTransactionId);
        List<CQShortListBL281609Dto> SalesTransactionBL281609FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL281609Dto> SalesTransactionBL281609FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL291908Dto> SalesTransactionBL291908FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL291908Dto> SalesTransactionBL291908FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL331211Dto> SalesTransactionBL331211FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL331211Dto> SalesTransactionBL331211FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL311703Dto> SalesTransactionBL311703FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL311703Dto> SalesTransactionBL311703FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL030904Dto> SalesTransactionBL030904FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL030904Dto> SalesTransactionBL030904FindCQFullListWithRecIdFilter(int salesTransactionId);
        List<CQShortListBL041312Dto> SalesTransactionBL041312FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL041312Dto> SalesTransactionBL041312FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL051807Dto> SalesTransactionBL051807FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL051807Dto> SalesTransactionBL051807FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQShortListBL061005Dto> SalesTransactionBL061005FindCQShortListWithRecIdFilter(int salesTransactionId);
        List<CQFullListBL061005Dto> SalesTransactionBL061005FindCQFullListWithRecIdFilter(int salesTransactionId);

        List<CQHeader030904Dto> SalesTransactionBL030904FindCQHeaderWithRecIdFilter(int salesTransactionId);
        ProductFullDto ProductFullUpdIsActiveRec(int productId, bool isActive, string lastModifiedBy);
        BusinessLineDetailsProductDto BusinessLineDetailsProductFindWithProductIdFilter(int productId);
        List<ProductPriceListDto> ProductPriceListFindWithProductIdFilter(int productId);
        List<ProductBenefitsDto> ProductBenefitsFindWithProductIdFilter(int productId);
        List<ProductBenefitsTemplateDto> ProductBenefitsTemplateFindAllFilter();
        List<ProductBenefitsDto> ProductBenefitsNewRec(List<ProductBenefitsNewDto> productBenefits, string createdBy);
        List<ProductCombinationDto> ProductCombinationFindWithProductIdFilter(int productId);
        ProductCombinationDto ProductCombinationDeacRec(int recId);

        ProductCombinationDto ProductCombinationNewRec(ProductCombinationNewDto productCombinationNewDto, string createdBy);
        ProductCombinationDto ProductCombinationUpdRec(ProductCombinationUpdDto productCombinationUpdDto, string lastModifiedBy);
        List<ProductPriceListDto> ProductPriceListNewRec(List<ProductPriceListNewDto> productPriceList, string createdBy);
        List<KycDto> ClientFindAll();

        List<KycDto> KycUpd(string shuftiReference, string shuftiStatus, string declinedReason);

        List<dynamic> SalesTransactionBL080501FindCQShortBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL080501FindCQShortPivotWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL080501FindCQShortBillsWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL080501FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL301401FindCQBenefitCompareWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL301401FindCQPivotMemberWithRecIdFilter(int salesTransactionId);
        ProductDetailsPOINetworkDto ProductDetailsPOINetworkUpdRec(ProductDetailsPOINetworkUpdDto productDetailsPIONetworkDto, string lastModifiedBy);
        List<dynamic> SalesTransactionBL070806FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL281609FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL070806FindCQShortPivotWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL281609FindCQShortPivotWithRecIdFilter(int salesTransactionId);

        List<dynamic> SalesTransactionBL070806FindCQShortBenefitWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL281609FindCQShortBenefitWithRecIdFilter(int salesTransactionId);


        List<dynamic> SalesTransactionBL070806FindCQShortBillsWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL281609FindCQShortBillsWithRecIdFilter(int salesTransactionId);


        List<dynamic> SalesTransactionBL070806FindCQBenefitCompareWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL090703FindCQBenefitCompareWithRecIdFilter(int salesTransactionId);

        SalesTransactionBL070806Dto SalesTransactionBL070806UpdGlobalRec(int recId, int clientId,
          int masterId, string lastModifiedBy);

        SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip2Rec(int recId, List<Slip2BL321110Dto> slip2BL321110Dto, string lastModifiedBy);
        SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip2Rec(int recId, List<Slip2BL041312Dto> slip2BL041312Dto, string lastModifiedBy);
        SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip2Rec(int recId, List<Slip2BL331211Dto> slip2BL331211Dto, string lastModifiedBy);

        SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip3Rec(int recId, List<Slip3BL321110Dto> slip3BL321110Dto, string lastModifiedBy);
        SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip3Rec(int recId, List<Slip3BL041312Dto> slip3BL041312Dto, string lastModifiedBy);
        SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip3Rec(int recId, List<Slip3BL331211Dto> slip3BL331211Dto, string lastModifiedBy);
        SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip4Rec(int recId, List<Slip4BL321110Dto> slip4BL321110Dto, string lastModifiedBy);
        SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip4Rec(int recId, List<Slip4BL041312Dto> slip4BL041312Dto, string lastModifiedBy);
        SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip4Rec(int recId, List<Slip4BL331211Dto> slip4BL331211Dto, string lastModifiedBy);
        SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip5Rec(int recId, List<Slip5BL321110Dto> slip5BL321110Dto, string lastModifiedBy);
        SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip5Rec(int recId, List<Slip5BL041312Dto> slip5BL041312Dto, string lastModifiedBy);
        SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip5Rec(int recId, List<Slip5BL331211Dto> slip5BL331211Dto, string lastModifiedBy);
        List<dynamic> salesTransactionBL041312FindAF1WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL041312FindStep2WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL041312FindStep3WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL041312FindStep4WithRecId(int salesTransactionId);

        List<dynamic> salesTransactionBL331211FindAF1WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL331211FindStep2WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL331211FindStep3WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL331211FindStep4WithRecId(int salesTransactionId);






        List<dynamic> salesTransactionBL321110FindAF1WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL321110FindStep2WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL321110FindStep3WithRecId(int salesTransactionId);
        List<dynamic> salesTransactionBL321110FindStep4WithRecId(int salesTransactionId);
        List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter(int salesTransactionId);
        List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter(int salesTransactionId);
        List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter(int salesTransactionId);
        List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip2Rec(int recId, List<Slip2BL321110Dto> slip2BL321110Dto, string lastModifiedBy);
        List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip2Rec(int recId, List<Slip2BL041312Dto> slip2BL041312Dto, string lastModifiedBy);
        List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip2Rec(int recId, List<Slip2BL331211Dto> slip2BL331211Dto, string lastModifiedBy);
        List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip3Rec(int recId, List<Slip3BL321110Dto> slip3BL321110Dto, string lastModifiedBy);
        List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip3Rec(int recId, List<Slip3BL041312Dto> slip3BL041312Dto, string lastModifiedBy);
        List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip3Rec(int recId, List<Slip3BL331211Dto> slip3BL331211Dto, string lastModifiedBy);

        List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip4Rec(int recId, List<Slip4BL321110Dto> slip4BL321110Dto, string lastModifiedBy);
        List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip4Rec(int recId, List<Slip4BL041312Dto> slip4BL041312Dto, string lastModifiedBy);
        List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip4Rec(int recId, List<Slip4BL331211Dto> slip4BL331211Dto, string lastModifiedBy);
        List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId);
        List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId);
        List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId);
        List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPricesNewRec(List<SalesTransactionDetailsPricesNewDto> salesTransactionBL321110DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, bool AgeCalculationFullDate, bool AgeCalculationYear, DateTime AgeCalculationStartDate, string createdBy);
        List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPricesNewRec(List<SalesTransactionBL041312DetailsPricesNewDto> salesTransactionBL041312DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, string createdBy);
        List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPricesNewRec(List<SalesTransactionBL331211DetailsPricesNewDto> salesTransactionBL331211DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, string createdBy);
        SalesTransactionBL321110DetailsNewDto SalesTransactionBL321110DetailsFindWithRecIdFilter(int recId);
        SalesTransactionBL041312DetailsNewDto SalesTransactionBL041312DetailsFindWithRecIdFilter(int recId);
        SalesTransactionBL331211DetailsNewDto SalesTransactionBL331211DetailsFindWithRecIdFilter(int recId);


        List<dynamic> SalesTransactionBL321110FindCQPivotListPricesWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL331211FindCQPivotListPricesWithRecIdFilter(int salesTransactionId);
        List<dynamic> SalesTransactionBL041312FindCQPivotListPricesWithRecIdFilter(int salesTransactionId);


        List<PaymentScheduleBL281609Dto> PolicyPaymentScheduleBL281609(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL281609Dto> PolicyRelatedDocBL281609(int salesTransactionId, string businessLineCode);
        PolicyRelatedDocBL281609Dto PolicyRelatedDocBL281609UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL281609Dto PolicyRelatedDocBL281609NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
      string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
      string attachedDocExt, string lastModifiedBy);

        List<PolicyBL281609Dto> PolicyBL281609UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
        DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL281609Dto> PolicyBL281609NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);
        List<dynamic> SalesTransactionBL281609FindCQBenefitCompareWithRecIdFilter(int salesTransactionId);
        List<PaymentScheduleBL021502Dto> PolicyPaymentScheduleBL021502(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL021502Dto> PolicyRelatedDocBL021502(int salesTransactionId, string businessLineCode);
        PolicyRelatedDocBL021502Dto PolicyRelatedDocBL021502UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL021502Dto PolicyRelatedDocBL021502NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
      string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
      string attachedDocExt, string lastModifiedBy);

        List<PolicyBL021502Dto> PolicyBL021502UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
        DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL021502Dto> PolicyBL021502NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);

        List<PaymentScheduleBL051807Dto> PolicyPaymentScheduleBL051807(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL051807Dto> PolicyRelatedDocBL051807(int salesTransactionId, string businessLineCode);
        PolicyRelatedDocBL051807Dto PolicyRelatedDocBL051807UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL051807Dto PolicyRelatedDocBL051807NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
      string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
      string attachedDocExt, string lastModifiedBy);

        List<PolicyBL051807Dto> PolicyBL051807UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
        DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL051807Dto> PolicyBL051807NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);
        List<PaymentScheduleBL291908Dto> PolicyPaymentScheduleBL291908(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL291908Dto> PolicyRelatedDocBL291908(int salesTransactionId, string businessLineCode);
        PolicyRelatedDocBL291908Dto PolicyRelatedDocBL291908UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL291908Dto PolicyRelatedDocBL291908NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
      string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
      string attachedDocExt, string lastModifiedBy);

        List<PolicyBL291908Dto> PolicyBL291908UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
        DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL291908Dto> PolicyBL291908NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy);
        List<PaymentScheduleBL041312Dto> PolicyPaymentScheduleBL041312(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL041312Dto> PolicyRelatedDocBL041312(int salesTransactionId, string businessLineCode);
        PolicyRelatedDocBL041312Dto PolicyRelatedDocBL041312UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL041312Dto PolicyRelatedDocBL041312NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
      string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
      string attachedDocExt, string lastModifiedBy);

        List<PolicyBL041312Dto> PolicyBL041312UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
        DateTime PolicyExpiryDate, DateTime PolicyIssuedDate);

        List<PolicyBL041312Dto> PolicyBL041312NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode,
            string businessLineCode, string createdBy);

        List<PaymentScheduleBL331211Dto> PolicyPaymentScheduleBL331211(int salesTransactionId, string businessLineCode);
        List<PolicyRelatedDocBL331211Dto> PolicyRelatedDocBL331211(int salesTransactionId, string businessLineCode);
        PolicyRelatedDocBL331211Dto PolicyRelatedDocBL331211UpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy);

        PolicyRelatedDocBL331211Dto PolicyRelatedDocBL331211NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
      string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName,
      string attachedDocExt, string lastModifiedBy);

        List<PolicyBL331211Dto> PolicyBL331211UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
         string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
         decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
         decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
         decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
         decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
        DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder);

        List<PolicyBL331211Dto> PolicyBL331211NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode,
          string businessLineCode, string createdBy);
        List<ProductPriceControlDto> ProductPriceControlFindAll();
        List<TicketHistoryDto> TicketHistoryFindDataWithNbrDaysFilter(int NbrDays, string UserName);
        List<RenewalParameterDto> RenewalParameterFindAll();
        List<RenewalPolicyDto> RenewalPolicyFindAll();
        List<PolicyInquiryDto> PolicyInquiryFindAll();
        List<RenewalProcessDto> RenewalProcessFindAll();
        List<PolicyBL010602Dto> PolicyBL010602FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL021502Dto> PolicyBL021502FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL041312Dto> PolicyBL041312FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL051807Dto> PolicyBL051807FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL070806Dto> PolicyBL070806FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL090703Dto> PolicyBL090703FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL281609Dto> PolicyBL281609FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL291908Dto> PolicyBL291908FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL301401Dto> PolicyBL301401FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL321110Dto> PolicyBL321110FindAllWithParentPolicyId(string parentPolicyId);
        List<PolicyBL331211Dto> PolicyBL331211FindAllWithParentPolicyId(string parentPolicyId);
    }
}
