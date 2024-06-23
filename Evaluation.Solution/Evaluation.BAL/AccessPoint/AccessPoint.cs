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
using Evaluation.CAL.Wrapper;
using Evaluation.DAL.IDao;
using System;
using System.Collections.Generic;

namespace Evaluation.BAL.AccessPoint
{
    public class AccessPoint : IAccessPoint
    {
        public static readonly IDaoFactory factory = DaoFactories.GetFactory();
        public static readonly IUserCredDao userCredDao = factory.UserCredDao;

        public List<UserDto> CheckUserCred(string userName, string userPassword)
        {
            Logger.Info("");
            return userCredDao.CheckUserCred(userName, userPassword);
        }

        public List<UserDto> IsUserAvailable(string userName)
        {
            Logger.Info("");
            return userCredDao.IsUserAvailable(userName);
        }

        public List<UserDto> RegisterUser(UserRegisterDto userRegisterDto)
        {
            Logger.Info("");
            return userCredDao.RegisterUser(userRegisterDto);
        }

        public List<UserDto> UpdateUserPassword(UserChangePasswordDto userChangePasswordDto)
        {
            Logger.Info("");
            return userCredDao.UpdateUserPassword(userChangePasswordDto);
        }
        public List<RegionDto> RegionFindAll()
        {
            //Logger.Info("");
            return userCredDao.RegionFindAll();
        }

        public RegionDto RegionNewRec(RegionNewDto regionDto, string createdBy)
        {
            //Logger.Info("");
            return userCredDao.RegionNewRec(regionDto, createdBy);
        }

        public RegionDto RegionUpdRec(RegionUpdDto regionDto, string lastModifiedBy)
        {
            //Logger.Info("");
            return userCredDao.RegionUpdRec(regionDto, lastModifiedBy);
        }

        public List<GenderDto> GenderFindAll()
        {
            //Logger.Info("");
            return userCredDao.GenderFindAll();
        }

        public GenderDto GenderNewRec(GenderNewDto genderNewDto, string createdBy)
        {
            //Logger.Info("");
            return userCredDao.GenderNewRec(genderNewDto, createdBy);
        }

        public GenderDto GenderUpdRec(GenderUpdDto genderDto, string lastModifiedBy)
        {
            //Logger.Info("");
            return userCredDao.GenderUpdRec(genderDto, lastModifiedBy);
        }

        public List<ChannelDto> ChannelFindAll()
        {
            //Logger.Info("");
            return userCredDao.ChannelFindAll();
        }

        public ChannelDto ChannelNewRec(ChannelNewDto channelNewDto, string createdBy)
        {
            //Logger.Info("");
            return userCredDao.ChannelNewRec(channelNewDto, createdBy);
        }

        public ChannelDto ChannelUpdRec(ChannelUpdDto channelDto, string lastModifiedBy)
        {
            //Logger.Info("");
            return userCredDao.ChannelUpdRec(channelDto, lastModifiedBy);
        }

        public TokenDto TokenKey(AuthDto authDto)
        {
            return userCredDao.TokenKey(authDto);
        }

        public List<ContactDto> ContactFindWithAnyValue(string searchValue)
        {
            return userCredDao.ContactFindWithAnyValue(searchValue);
        }

        public List<ContactDto> ContactFindWithAnyFilter(ContactChannelSearchWithFilterReq contactChannelSearchWithFilterReq)
        {
            return userCredDao.ContactFindWithAnyFilter(contactChannelSearchWithFilterReq);
        }
        public List<ContactDto> ContactFindWithRecIdFilter(int recId)
        {
            return userCredDao.ContactFindWithRecIdFilter(recId);
        }

        public AF1BL80Dto AF1BL80NewRec(AF1BL80NewDto aF1BL80NewDto, string createdBy)
        {
            return userCredDao.AF1BL80NewRec(aF1BL80NewDto, createdBy);
        }
        public List<ContactDto> ContactChannelNewRec(ContactNewDto contactNewDto, string createdBy)
        {
            return userCredDao.ContactChannelNewRec(contactNewDto, createdBy);
        }
        public List<ContactDto> ContactChannelUpdRec(ContactUpdDto contactUpdDto, string createdBy)
        {
            return userCredDao.ContactChannelUpdRec(contactUpdDto, createdBy);
        }
        public List<LookupDto> LookupFindAll()
        {
            //Logger.Info("");
            return userCredDao.LookupFindAll();
        }
        public List<LeadLookupDto> LeadLookupFindAll()
        {
            //Logger.Info("");
            return userCredDao.LeadLookupFindAll();
        }

        public List<BusinessLineDto> BusinessLineFindAll()
        {
            //Logger.Info("");
            return userCredDao.BusinessLineFindAll();
        }
        public List<MaritalStatusDto> MaritalStatusFindAll()
        {
            //Logger.Info("");
            return userCredDao.MaritalStatusFindAll();
        }

        public MaritalStatusDto MaritalStatusNewRec(MaritalStatusNewDto maritalStatusDto, string createdBy)
        {
            //Logger.Info("");
            return userCredDao.MaritalStatusNewRec(maritalStatusDto, createdBy);
        }

        public MaritalStatusDto MaritalStatusUpdRec(MaritalStatusUpdDto maritalStatusDto, string lastModifiedBy)
        {
            //Logger.Info("");
            return userCredDao.MaritalStatusUpdRec(maritalStatusDto, lastModifiedBy);
        }
        public List<SalesTransactionMenuDto> SalesTransactionMenuFindWithColFilter(string ClientType, int contactId)
        {
            return userCredDao.SalesTransactionMenuFindWithColFilter(ClientType, contactId);
        }
        public SalesTransactionBL77Dto SalesTransactionBL77NewRec(int businessLineId, int contactId, List<AF1BL77Dto> aF1BL77Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL77NewRec(businessLineId, contactId, aF1BL77Dto, createdBy);
        }
        public SalesTransactionBL77Dto SalesTransactionBL77UpdRec(int recId, List<AF1BL77Dto> aF1BL77Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL77UpdRec(recId, aF1BL77Dto, lastModifiedBy);
        }
        public SalesTransactionBL77Dto SalesTransactionBL77FindWithRecIdFilter(int recId)
        {
            return userCredDao.SalesTransactionBL77FindWithRecIdFilter(recId);
        }
        public SalesTransactionMenuDto SalesTransactionMenuFindWithRecIdFilter(int recId)
        {
            return userCredDao.SalesTransactionMenuFindWithRecIdFilter(recId);
        }
        public BusinessLineRelatedDocDto BusinessLineRelatedDocFindWithBusinessLineCodeFilter(string businessLineCode, string applicationForm)
        {
            return userCredDao.BusinessLineRelatedDocFindWithBusinessLineCodeFilter(businessLineCode, applicationForm);
        }
        public SalesTransactionBL77Dto SalesTransactionBL77FindWithColFilter(int businessLineId, int contactId)
        {
            return userCredDao.SalesTransactionBL77FindWithColFilter(businessLineId, contactId);
        }
        public LeadDto LeadNewRec(LeadNewDto leadNewDto, string createdBy)
        {
            //Logger.Info("");
            return userCredDao.LeadNewRec(leadNewDto, createdBy);
        }
        public List<LeadDto> LeadFindAll()
        {
            //Logger.Info("");
            return userCredDao.LeadFindAll();
        }
        public SalesTransactionBL301401Dto SalesTransactionBL301401NewRec(string businessLineCode, int contactId, List<AF1BL301401Dto> aF1BL301401Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL301401NewRec(businessLineCode, contactId, aF1BL301401Dto, createdBy);
        }
        public SalesTransactionBL321110Dto SalesTransactionBL321110NewRec(string businessLineCode, int contactId, List<AF1BL321110Dto> aF1BL321110Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL321110NewRec(businessLineCode, contactId, aF1BL321110Dto, createdBy);
        }
        public SalesTransactionBL080501Dto SalesTransactionBL080501NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL080501Dtco aF1BL080501Dtco, string createdBy, string policyId = "")
        {
            return userCredDao.SalesTransactionBL080501NewRec(businessLineCode, contactId, clientId, masterId, aF1BL080501Dtco, createdBy, policyId);
        }

        public List<SalesTransactionDto> SalesTransactionFindWithContactIdFilter(int contactId, int internalStatus)
        {
            return userCredDao.SalesTransactionFindWithContactIdFilter(contactId, internalStatus);
        }

        public SalesTransactionBL080501Dto SalesTransactionBL080501FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401UpdAF1Rec(int recId, List<AF1BL301401Dto> aF1BL301401Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL301401UpdAF1Rec(recId, aF1BL301401Dto, lastModifiedBy);
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdAF1Rec(int recId, List<AF1BL321110Dto> aF1BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110UpdAF1Rec(recId, aF1BL321110Dto, lastModifiedBy);
        }
        public SalesTransactionBL080501Dto SalesTransactionBL080501UpdAF1Rec(int recId, int clientId, int masterId, AF1BL080501Dtco aF1BL080501Dtco, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL080501UpdAF1Rec(recId, clientId, masterId, aF1BL080501Dtco, lastModifiedBy);
        }

        public List<CQDetailsBL080501Dto> SalesTransactionBL080501FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL080501Dto> SalesTransactionBL080501FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL301401Dto> SalesTransactionBL301401FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL301401Dto> SalesTransactionBL301401FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQSummaryWithRecIdFilter(salesTransactionId);
        }
        public List<CQDetailsBL321110Dto> SalesTransactionBL321110FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL321110FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQSummaryWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL331211FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL080501FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL301401FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL321110FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL321110FindCQPivotListPricesWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQPivotListPricesWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL041312FindCQPivotListPricesWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQPivotListPricesWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL331211FindCQPivotListPricesWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQPivotListPricesWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL080501FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL301401FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL321110FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQBenefitWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL321110FindCQPivotBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQPivotBenefitWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL041312FindCQPivotBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQPivotBenefitWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL331211FindCQPivotBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQPivotBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL080501FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL301401FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL321110FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader301401Dto> SalesTransactionBL301401FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader030904Dto> SalesTransactionBL030904FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL030904FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory> SalesTransactionBL301401FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader080501> SalesTransactionBL080501FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory080501> SalesTransactionBL080501FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader321110> SalesTransactionBL321110FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader041312Dto> SalesTransactionBL041312FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory321110> SalesTransactionBL321110FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public SpecialConditionDto SpecialConditionNewRec(int SalesTrxId, string businessLineCode, int ProductId, int Sheet, decimal DiscountPer, decimal DiscountAmount, string createdBy)
        {
            return userCredDao.SpecialConditionNewRec(SalesTrxId, businessLineCode, ProductId,
                 Sheet, DiscountPer, DiscountAmount, createdBy);
        }

        public SpecialConditionDto SpecialConditionFindWithColFilter(int salesTrxId, string businessLineCode, int productId, int sheet)
        {
            return userCredDao.SpecialConditionFindWithColFilter(salesTrxId, businessLineCode, productId,
                sheet);
        }

        public AF1ColHeaderDto AF1ColHeaderWithColFilter(string aF1Code, string aF1ColHeader)
        {
            return userCredDao.AF1ColHeaderWithColFilter(aF1Code, aF1ColHeader);
        }

        public SalesTransactionBL021502Dto SalesTransactionBL021502UpdAF1Rec(int recId, List<AF1BL021502Dto> aF1BL021502Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL021502UpdAF1Rec(recId, aF1BL021502Dto, lastModifiedBy);
        }

        public SalesTransactionBL021502Dto SalesTransactionBL021502FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL021502Dto SalesTransactionBL021502NewRec(string businessLineCode, int contactId, List<AF1BL021502Dto> aF1BL021502Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL021502NewRec(businessLineCode, contactId, aF1BL021502Dto, createdBy);
        }
        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdAF1Rec(int recId, List<AF1BL041312Dto> aF1BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312UpdAF1Rec(recId, aF1BL041312Dto, lastModifiedBy);
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312NewRec(string businessLineCode, int contactId, List<AF1BL041312Dto> aF1BL041312Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL041312NewRec(businessLineCode, contactId, aF1BL041312Dto, createdBy);
        }
        public SalesTransactionBL051807Dto SalesTransactionBL051807UpdAF1Rec(int recId, List<AF1BL051807Dto> aF1BL051807Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL051807UpdAF1Rec(recId, aF1BL051807Dto, lastModifiedBy);
        }

        public SalesTransactionBL051807Dto SalesTransactionBL051807FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL051807Dto SalesTransactionBL051807NewRec(string businessLineCode, int contactId, List<AF1BL051807Dto> aF1BL051807Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL051807NewRec(businessLineCode, contactId, aF1BL051807Dto, createdBy);
        }

        public SalesTransactionBL281609Dto SalesTransactionBL281609UpdAF1Rec(int recId, List<AF1BL281609Dto> aF1BL281609Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL281609UpdAF1Rec(recId, aF1BL281609Dto, lastModifiedBy);
        }

        public SalesTransactionBL281609Dto SalesTransactionBL281609FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL281609Dto SalesTransactionBL281609NewRec(string businessLineCode, int contactId, List<AF1BL281609Dto> aF1BL281609Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL281609NewRec(businessLineCode, contactId, aF1BL281609Dto, createdBy);
        }

        public SalesTransactionBL291908Dto SalesTransactionBL291908UpdAF1Rec(int recId, List<AF1BL291908Dto> aF1BL291908Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL291908UpdAF1Rec(recId, aF1BL291908Dto, lastModifiedBy);
        }

        public SalesTransactionBL291908Dto SalesTransactionBL291908FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL291908Dto SalesTransactionBL291908NewRec(string businessLineCode, int contactId, List<AF1BL291908Dto> aF1BL291908Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL291908NewRec(businessLineCode, contactId, aF1BL291908Dto, createdBy);
        }

        public SalesTransactionBL311703Dto SalesTransactionBL311703UpdAF1Rec(int recId, List<AF1BL311703Dto> aF1BL311703Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL311703UpdAF1Rec(recId, aF1BL311703Dto, lastModifiedBy);
        }

        public SalesTransactionBL311703Dto SalesTransactionBL311703FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL311703Dto SalesTransactionBL311703NewRec(string businessLineCode, int contactId, List<AF1BL311703Dto> aF1BL311703Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL311703NewRec(businessLineCode, contactId, aF1BL311703Dto, createdBy);
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdAF1Rec(int recId, List<AF1BL331211Dto> aF1BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211UpdAF1Rec(recId, aF1BL331211Dto, lastModifiedBy);
        }

        public SalesTransactionBL331211Dto SalesTransactionBL331211FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL331211Dto SalesTransactionBL331211NewRec(string businessLineCode, int contactId, List<AF1BL331211Dto> aF1BL331211Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL331211NewRec(businessLineCode, contactId, aF1BL331211Dto, createdBy);
        }

        public List<CQDetailsBL021502Dto> SalesTransactionBL021502FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL021502Dto> SalesTransactionBL021502FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL021502FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL021502FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL021502FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader021502Dto> SalesTransactionBL021502FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory021502Dto> SalesTransactionBL021502FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL041312Dto> SalesTransactionBL041312FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL041312FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL041312FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL041312FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL041312FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory041312Dto> SalesTransactionBL041312FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL051807Dto> SalesTransactionBL051807FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL051807Dto> SalesTransactionBL051807FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL051807FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL051807FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL051807FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader051807Dto> SalesTransactionBL051807FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory051807Dto> SalesTransactionBL051807FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL281609Dto> SalesTransactionBL281609FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL281609Dto> SalesTransactionBL281609FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL281609FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL281609FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL281609FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader281609Dto> SalesTransactionBL281609FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory281609Dto> SalesTransactionBL281609FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL291908Dto> SalesTransactionBL291908FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL291908Dto> SalesTransactionBL291908FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL291908FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL291908FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL291908FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader291908Dto> SalesTransactionBL291908FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory291908Dto> SalesTransactionBL291908FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL311703Dto> SalesTransactionBL311703FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL311703Dto> SalesTransactionBL311703FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL311703FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL311703FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL311703FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader311703Dto> SalesTransactionBL311703FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory311703Dto> SalesTransactionBL311703FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQCategoryWithRecIdFilter(salesTransactionId);
        }
        public List<CQDetailsBL331211Dto> SalesTransactionBL331211FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQDetailsWithRecIdFilter(salesTransactionId);
        }


        public List<dynamic> SalesTransactionBL331211FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL331211FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL331211FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader331211Dto> SalesTransactionBL331211FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory331211Dto> SalesTransactionBL331211FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL010602Dto SalesTransactionBL010602FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL010602Dto SalesTransactionBL010602NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL010602Dtco aF1BL010602Dtco, string createdBy)
        {
            return userCredDao.SalesTransactionBL010602NewRec(businessLineCode, contactId, clientId, masterId, aF1BL010602Dtco, createdBy);

        }

        public SalesTransactionBL010602Dto SalesTransactionBL010602UpdAF1Rec(int recId, int clientId, int masterId, AF1BL010602Dtco aF1BL010602Dtco, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL010602UpdAF1Rec(recId, clientId, masterId, aF1BL010602Dtco, lastModifiedBy);
        }

        public List<CQDetailsBL010602Dto> SalesTransactionBL010602FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL010602Dto> SalesTransactionBL010602FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL010602FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL010602FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL010602FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader010602Dto> SalesTransactionBL010602FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQHeaderWithRecIdFilter(salesTransactionId);
        }
        public List<CQCategory010602Dto> SalesTransactionBL010602FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQCategoryWithRecIdFilter(salesTransactionId);
        }
        public SalesTransactionBL030904Dto SalesTransactionBL030904UpdAF1Rec(int recId, List<AF1BL030904Dto> aF1BL030904Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL030904UpdAF1Rec(recId, aF1BL030904Dto, lastModifiedBy);
        }

        public SalesTransactionBL030904Dto SalesTransactionBL030904FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL030904FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL030904Dto SalesTransactionBL030904NewRec(string businessLineCode, int contactId, List<AF1BL030904Dto> aF1BL030904Dto, string createdBy)
        {
            return userCredDao.SalesTransactionBL030904NewRec(businessLineCode, contactId, aF1BL030904Dto, createdBy);
        }

        public List<ProductDto> ProductFindAll(bool isActive)
        {
            //Logger.Info("");
            return userCredDao.ProductFindAll(isActive);
        }

        public List<ProductLookupDto> ProductLookupFindAll()
        {
            //Logger.Info("");
            return userCredDao.ProductLookupFindAll();
        }

        public ProductFullDto ProductFullNewRec(ProductFullNewDto productFullNewDto, string createdBy)
        {
            return userCredDao.ProductFullNewRec(productFullNewDto, createdBy);
        }
        public ProductFullDto ProductFullFindWithRecIdFilter(int productId)
        {
            return userCredDao.ProductFullFindWithRecIdFilter(productId);
        }

        public ProductFullDto ProductFullUpdRec(ProductFullUpdDto productFullDto, string lastModifiedBy)
        {
            return userCredDao.ProductFullUpdRec(productFullDto, lastModifiedBy);
        }

        public ProductFullDto ProductFullUpdIsActiveRec(int productId, bool isActive, string lastModifiedBy)
        {
            return userCredDao.ProductFullUpdIsActiveRec(productId, isActive, lastModifiedBy);
        }

        public List<ProductDetailsDto> ProductDetailsFindWithProductIdFilter(int productId)
        {
            return userCredDao.ProductDetailsFindWithProductIdFilter(productId);
        }

        public ProductDetailsDto ProductDetailsNewRec(ProductDetailsNewDto productDetailsNewDto, string createdBy)
        {
            return userCredDao.ProductDetailsNewRec(productDetailsNewDto, createdBy);
        }

        public ProductDetailsDto ProductDetailsUpdRec(ProductDetailsUpdDto productDetailsDto, string lastModifiedBy)
        {
            return userCredDao.ProductDetailsUpdRec(productDetailsDto, lastModifiedBy);
        }

        public List<ProductDetailsPOIDto> ProductDetailsPOIFindWithProductIdFilter(int productId)
        {
            return userCredDao.ProductDetailsPOIFindWithProductIdFilter(productId);
        }

        public ProductDetailsPOIDto ProductDetailsPOINewRec(ProductDetailsPOINewDto productDetailsPOINewDto, string createdBy)
        {
            return userCredDao.ProductDetailsPOINewRec(productDetailsPOINewDto, createdBy);
        }

        public ProductDetailsPOIDto ProductDetailsPOIUpdRec(ProductDetailsPOIUpdDto productDetailsPIODto, string lastModifiedBy)
        {
            return userCredDao.ProductDetailsPOIUpdRec(productDetailsPIODto, lastModifiedBy);
        }

        public BusinessLineDuplicationDto BusinessLineDuplicationNewRec(BusinessLineDuplicationNewDto businessLineDuplicationNewDto, string createdBy)
        {
            return userCredDao.BusinessLineDuplicationNewRec(businessLineDuplicationNewDto, createdBy);
        }

        public TicketDetailsDto TicketDetailsUpdRec(TicketDetailsUpdDto ticketDetailsUpdDto, string lastModifiedBy)
        {
            return userCredDao.TicketDetailsUpdRec(ticketDetailsUpdDto, lastModifiedBy);
        }

        public List<CQShortListBL080501Dto> SalesTransactionBL080501FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL080501Dto> SalesTransactionBL080501FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQFullListWithRecIdFilter(salesTransactionId);
        }
        public List<GlobalLookupDto> GlobalLookupFindAll()
        {
            return userCredDao.GlobalLookupFindAll();
        }

        public List<PolicyDto> PolicyNewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyNewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }
        public List<PaymentScheduleDto> PolicyPaymentSchedule(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentSchedule(salesTransactionId, businessLineCode);
        }

        public SalesTransactionBL080501Dto SalesTransactionBL080501UpdGlobalRec(int recId,
            int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            return userCredDao.SalesTransactionBL080501UpdGlobalRec(recId,
             clientId, masterId, lastModifiedBy, policyId);
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401UpdGlobalRec(int recId,
            int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            return userCredDao.SalesTransactionBL301401UpdGlobalRec(recId,
             clientId, masterId, lastModifiedBy, policyId);
        }
        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdGlobalRec(int recId,
            int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            return userCredDao.SalesTransactionBL321110UpdGlobalRec(recId,
             clientId, masterId, lastModifiedBy, policyId);
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdGlobalRec(int recId,
           int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            return userCredDao.SalesTransactionBL331211UpdGlobalRec(recId,
             clientId, masterId, lastModifiedBy, policyId);
        }
        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdGlobalRec(int recId,
           int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            return userCredDao.SalesTransactionBL041312UpdGlobalRec(recId,
             clientId, masterId, lastModifiedBy, policyId);
        }

        public List<PolicyRelatedDocDto> PolicyRelatedDoc(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDoc(salesTransactionId, businessLineCode);
        }

        public List<ClientCodeDto> ClientCodeFindWithRecid(int recId)
        {
            return userCredDao.ClientCodeFindWithRecid(recId);
        }

        public PolicyRelatedDocDto PolicyRelatedDocUpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocUpdRec(recId, attachDocBinary, attachDocName,
                attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocDto PolicyRelatedDocNewRec(int salesTransactionId, int ticketId,
            string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary,
            string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocNewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
            businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyDto> PolicyUpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyUpdRec(salesTransactionId, TicketId, ParentPolicyId,
             PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
             CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
             BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
             BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
             NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
            PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }

        public List<PolicyBL301401Dto> PolicyBL301401NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL301401NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PaymentScheduleBL301401Dto> PolicyPaymentScheduleBL301401(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL301401(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL301401Dto> PolicyRelatedDocBL301401(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL301401(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL301401Dto PolicyRelatedDocBL301401UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL301401UpdRec(recId, attachDocBinary, attachDocName,
                            attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL301401Dto PolicyRelatedDocBL301401NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL301401NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                        businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL301401Dto> PolicyBL301401UpdRec(int salesTransactionId, int TicketId,
            string ParentPolicyId, string PolicyId, string BusinessLineCode,
            decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount,
            decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount,
            decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount,
            decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount,
            string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL301401UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                        PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                        CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                        BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                        BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                        NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
            PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }


        public List<PolicyBL321110Dto> PolicyBL321110NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL321110NewRec(salesTransactionId, InsurerCode, ThirdPartyAdminCode, businessLineCode, createdBy);
        }

        public List<PaymentScheduleBL321110Dto> PolicyPaymentScheduleBL321110(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL321110(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL321110Dto> PolicyRelatedDocBL321110(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL321110(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL321110Dto PolicyRelatedDocBL321110UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL321110UpdRec(recId, attachDocBinary, attachDocName,
                            attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL321110Dto PolicyRelatedDocBL321110NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL321110NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                        businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL321110Dto> PolicyBL321110UpdRec(int salesTransactionId, int TicketId,
            string ParentPolicyId, string PolicyId, string BusinessLineCode,
            decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount,
            decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount,
            decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount,
            decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount,
            string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate)
        {
            return userCredDao.PolicyBL321110UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                        PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                        CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                        BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                        BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                        NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                        PolicyExpiryDate, PolicyIssuedDate);
        }

        public List<CQFullListBL301401Dto> SalesTransactionBL301401FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL301401Dto> SalesTransactionBL301401FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL321110Dto> SalesTransactionBL321110FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL321110Dto> SalesTransactionBL321110FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<PolicyBL010602Dto> PolicyBL010602NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL010602NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PolicyBL010602Dto> PolicyBL010602UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL010602UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                         PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                         CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                         BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                         BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                         NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                        PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }

        public List<PaymentScheduleBL010602Dto> PolicyPaymentScheduleBL010602(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL010602(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL010602Dto> PolicyRelatedDocBL010602(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL010602(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL010602Dto PolicyRelatedDocBL010602UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL010602UpdRec(recId, attachDocBinary, attachDocName,
                            attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL010602Dto PolicyRelatedDocBL010602NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL010602NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                        businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL070806Dtco aF1BL070806Dtco, string createdBy)
        {
            return userCredDao.SalesTransactionBL070806NewRec(businessLineCode, contactId, clientId, masterId, aF1BL070806Dtco, createdBy);
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806UpdAF1Rec(int recId, int clientId, int masterId, AF1BL070806Dtco aF1BL070806Dtco, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL070806UpdAF1Rec(recId, clientId, masterId, aF1BL070806Dtco, lastModifiedBy);
        }

        public List<dynamic> SalesTransactionBL070806FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL070806FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader070806Dto> SalesTransactionBL070806FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory070806Dto> SalesTransactionBL070806FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL070806Dto> SalesTransactionBL070806FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL070806Dto> SalesTransactionBL070806FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL070806FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<PolicyBL070806Dto> PolicyBL070806NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL070806NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PolicyBL070806Dto> PolicyBL070806UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL070806UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                     PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                     CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                     BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                     BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                     NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                    PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }

        public List<PaymentScheduleBL070806Dto> PolicyPaymentScheduleBL070806(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL070806(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL070806Dto> PolicyRelatedDocBL070806(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL070806(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL070806Dto PolicyRelatedDocBL070806UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL070806UpdRec(recId, attachDocBinary, attachDocName,
                                        attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL070806Dto PolicyRelatedDocBL070806NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL070806NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                   businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public SalesTransactionBL090703Dto SalesTransactionBL090703FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL090703Dto SalesTransactionBL090703NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL090703Dtco aF1BL090703Dtco, string createdBy)
        {
            return userCredDao.SalesTransactionBL090703NewRec(businessLineCode, contactId, clientId, masterId, aF1BL090703Dtco, createdBy);
        }

        public SalesTransactionBL090703Dto SalesTransactionBL090703UpdAF1Rec(int recId, int clientId, int masterId, AF1BL090703Dtco aF1BL090703Dtco, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL090703UpdAF1Rec(recId, clientId, masterId, aF1BL090703Dtco, lastModifiedBy);
        }

        public List<dynamic> SalesTransactionBL090703FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL090703FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader090703Dto> SalesTransactionBL090703FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory090703Dto> SalesTransactionBL090703FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL090703Dto> SalesTransactionBL090703FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL090703Dto> SalesTransactionBL090703FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL090703FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<PolicyBL090703Dto> PolicyBL090703NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL090703NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PolicyBL090703Dto> PolicyBL090703UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL090703UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                     PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                     CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                     BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                     BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                     NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                    PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }

        public List<PaymentScheduleBL090703Dto> PolicyPaymentScheduleBL090703(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL090703(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL090703Dto> PolicyRelatedDocBL090703(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL090703(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL090703Dto PolicyRelatedDocBL090703UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL090703UpdRec(recId, attachDocBinary, attachDocName,
                                        attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL090703Dto PolicyRelatedDocBL090703NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL090703NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                   businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public SalesTransactionBL061005Dto SalesTransactionBL061005FindAF1WithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindAF1WithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL061005Dto SalesTransactionBL061005NewRec(string businessLineCode, int contactId, int clientId, int masterId, List<AF1BL061005Dto> aF1BL061005Dtco, string createdBy)
        {
            return userCredDao.SalesTransactionBL061005NewRec(businessLineCode, contactId, clientId, masterId, aF1BL061005Dtco, createdBy);
        }

        public SalesTransactionBL061005Dto SalesTransactionBL061005UpdAF1Rec(int recId, int clientId, int masterId, List<AF1BL061005Dto> aF1BL061005Dtco, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL061005UpdAF1Rec(recId, clientId, masterId, aF1BL061005Dtco, lastModifiedBy);
        }

        public List<dynamic> SalesTransactionBL061005FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL061005FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQBillsWithRecIdFilter(salesTransactionId);
        }

        public List<CQHeader061005Dto> SalesTransactionBL061005FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQHeaderWithRecIdFilter(salesTransactionId);
        }

        public List<CQCategory061005Dto> SalesTransactionBL061005FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQCategoryWithRecIdFilter(salesTransactionId);
        }

        public List<CQDetailsBL061005Dto> SalesTransactionBL061005FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQDetailsWithRecIdFilter(salesTransactionId);
        }

        public List<CQSummaryBL061005Dto> SalesTransactionBL061005FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQSummaryWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL061005FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQPivotWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL070806Dto> SalesTransactionBL070806FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL070806Dto> SalesTransactionBL070806FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL090703Dto> SalesTransactionBL090703FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL090703Dto> SalesTransactionBL090703FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL010602Dto> SalesTransactionBL010602FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL010602Dto> SalesTransactionBL010602FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL010602FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL021502Dto> SalesTransactionBL021502FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL021502Dto> SalesTransactionBL021502FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL021502FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL291908Dto> SalesTransactionBL291908FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL291908Dto> SalesTransactionBL291908FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL291908FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL281609Dto> SalesTransactionBL281609FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL281609Dto> SalesTransactionBL281609FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL331211Dto> SalesTransactionBL331211FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL331211Dto> SalesTransactionBL331211FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL311703Dto> SalesTransactionBL311703FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL311703Dto> SalesTransactionBL311703FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL311703FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL030904Dto> SalesTransactionBL030904FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL030904FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL030904Dto> SalesTransactionBL030904FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL030904FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL041312Dto> SalesTransactionBL041312FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL041312Dto> SalesTransactionBL041312FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL061005Dto> SalesTransactionBL061005FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL061005Dto> SalesTransactionBL061005FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL061005FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public List<CQShortListBL051807Dto> SalesTransactionBL051807FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQShortListWithRecIdFilter(salesTransactionId);
        }

        public List<CQFullListBL051807Dto> SalesTransactionBL051807FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL051807FindCQFullListWithRecIdFilter(salesTransactionId);
        }

        public BusinessLineDetailsProductDto BusinessLineDetailsProductFindWithProductIdFilter(int productId)
        {
            return userCredDao.BusinessLineDetailsProductFindWithProductIdFilter(productId);
        }

        public List<ProductPriceListDto> ProductPriceListFindWithProductIdFilter(int productId)
        {
            return userCredDao.ProductPriceListFindWithProductIdFilter(productId);
        }
        public List<ProductBenefitsDto> ProductBenefitsFindWithProductIdFilter(int productId)
        {
            return userCredDao.ProductBenefitsFindWithProductIdFilter(productId);
        }

        public List<ProductBenefitsTemplateDto> ProductBenefitsTemplateFindAllFilter()
        {
            return userCredDao.ProductBenefitsTemplateFindAllFilter();
        }

        public List<ProductBenefitsDto> ProductBenefitsNewRec(List<ProductBenefitsNewDto> productBenefits, string createdBy)
        {
            return userCredDao.ProductBenefitsNewRec(productBenefits, createdBy);
        }

        public List<ProductCombinationDto> ProductCombinationFindWithProductIdFilter(int productId)
        {
            return userCredDao.ProductCombinationFindWithProductIdFilter(productId);
        }

        public ProductCombinationDto ProductCombinationDeacRec(int recId)
        {
            return userCredDao.ProductCombinationDeacRec(recId);
        }

        public ProductCombinationDto ProductCombinationNewRec(ProductCombinationNewDto productCombinationNewDto, string createdBy)
        {
            return userCredDao.ProductCombinationNewRec(productCombinationNewDto, createdBy);
        }
        public ProductCombinationDto ProductCombinationUpdRec(ProductCombinationUpdDto productCombinationUpdDto, string lastModifiedBy)
        {
            return userCredDao.ProductCombinationUpdRec(productCombinationUpdDto, lastModifiedBy);
        }
        public List<ProductPriceListDto> ProductPriceListNewRec(List<ProductPriceListNewDto> productPriceList, string createdBy)
        {
            return userCredDao.ProductPriceListNewRec(productPriceList, createdBy);
        }

        public List<KycDto> ClientFindAll()
        {
            return userCredDao.ClientFindAll();
        }

        public List<KycDto> KycUpd(string shuftiReference, string shuftiStatus, string declinedReason)
        {
            return userCredDao.KycUpd(shuftiReference, shuftiStatus, declinedReason);
        }

        public List<dynamic> SalesTransactionBL080501FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQBenefitCompareWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL080501FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQShortBenefitCompareWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQShortPivotWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQShortBillsWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL080501FindCQShortBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL301401FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQBenefitCompareWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL301401FindCQPivotMemberWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL301401FindCQPivotMemberWithRecIdFilter(salesTransactionId);
        }

        public ProductDetailsPOINetworkDto ProductDetailsPOINetworkUpdRec(ProductDetailsPOINetworkUpdDto productDetailsPIONetworkDto, string lastModifiedBy)
        {
            return userCredDao.ProductDetailsPOINetworkUpdRec(productDetailsPIONetworkDto, lastModifiedBy);
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQShortBenefitCompareWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL070806FindCQShortPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQShortPivotWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL281609FindCQShortPivotWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQShortPivotWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQShortBenefitWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL281609FindCQShortBenefitWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQShortBenefitWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQShortBillsWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL281609FindCQShortBillsWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQShortBillsWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL070806FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL070806FindCQBenefitCompareWithRecIdFilter(salesTransactionId);
        }

        public List<dynamic> SalesTransactionBL090703FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL090703FindCQBenefitCompareWithRecIdFilter(salesTransactionId);
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806UpdGlobalRec(int recId,
            int clientId, int masterId, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL070806UpdGlobalRec(recId,
             clientId, masterId, lastModifiedBy);
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip2Rec(int recId, List<Slip2BL321110Dto> slip2BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110UpdSlip2Rec(recId, slip2BL321110Dto, lastModifiedBy);
        }
        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip2Rec(int recId, List<Slip2BL041312Dto> slip2BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312UpdSlip2Rec(recId, slip2BL041312Dto, lastModifiedBy);
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip2Rec(int recId, List<Slip2BL331211Dto> slip2BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211UpdSlip2Rec(recId, slip2BL331211Dto, lastModifiedBy);
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip3Rec(int recId, List<Slip3BL321110Dto> slip3BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110UpdSlip3Rec(recId, slip3BL321110Dto, lastModifiedBy);
        }
        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip3Rec(int recId, List<Slip3BL041312Dto> slip3BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312UpdSlip3Rec(recId, slip3BL041312Dto, lastModifiedBy);
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip3Rec(int recId, List<Slip3BL331211Dto> slip3BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211UpdSlip3Rec(recId, slip3BL331211Dto, lastModifiedBy);
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip4Rec(int recId, List<Slip4BL321110Dto> slip4BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110UpdSlip4Rec(recId, slip4BL321110Dto, lastModifiedBy);
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip4Rec(int recId, List<Slip4BL041312Dto> slip4BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312UpdSlip4Rec(recId, slip4BL041312Dto, lastModifiedBy);
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip4Rec(int recId, List<Slip4BL331211Dto> slip4BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211UpdSlip4Rec(recId, slip4BL331211Dto, lastModifiedBy);
        }
        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip5Rec(int recId, List<Slip5BL321110Dto> slip5BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110UpdSlip5Rec(recId, slip5BL321110Dto, lastModifiedBy);
        }
        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip5Rec(int recId, List<Slip5BL041312Dto> slip5BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312UpdSlip5Rec(recId, slip5BL041312Dto, lastModifiedBy);
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip5Rec(int recId, List<Slip5BL331211Dto> slip5BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211UpdSlip5Rec(recId, slip5BL331211Dto, lastModifiedBy);
        }

        public List<dynamic> salesTransactionBL321110FindAF1WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL321110FindAF1WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL041312FindAF1WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL041312FindAF1WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL331211FindAF1WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL331211FindAF1WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL041312FindStep2WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL041312FindStep2WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL331211FindStep2WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL331211FindStep2WithRecId(salesTransactionId);
        }

        public List<dynamic> salesTransactionBL321110FindStep2WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL321110FindStep2WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL041312FindStep3WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL041312FindStep3WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL331211FindStep3WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL331211FindStep3WithRecId(salesTransactionId);
        }

        public List<dynamic> salesTransactionBL321110FindStep3WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL321110FindStep3WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL041312FindStep4WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL041312FindStep4WithRecId(salesTransactionId);
        }
        public List<dynamic> salesTransactionBL331211FindStep4WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL331211FindStep4WithRecId(salesTransactionId);
        }

        public List<dynamic> salesTransactionBL321110FindStep4WithRecId(int salesTransactionId)
        {
            return userCredDao.salesTransactionBL321110FindStep4WithRecId(salesTransactionId);
        }

        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter(salesTransactionId);
        }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter(salesTransactionId);
        }

        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter(salesTransactionId);
        }

        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip2Rec(int recId, List<Slip2BL321110Dto> slip2BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110DetailsUpdSlip2Rec(recId, slip2BL321110Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip2Rec(int recId, List<Slip2BL041312Dto> slip2BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312DetailsUpdSlip2Rec(recId, slip2BL041312Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip2Rec(int recId, List<Slip2BL331211Dto> slip2BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211DetailsUpdSlip2Rec(recId, slip2BL331211Dto, lastModifiedBy);
        }

        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip3Rec(int recId, List<Slip3BL321110Dto> slip3BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110DetailsUpdSlip3Rec(recId, slip3BL321110Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip3Rec(int recId, List<Slip3BL041312Dto> slip3BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312DetailsUpdSlip3Rec(recId, slip3BL041312Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip3Rec(int recId, List<Slip3BL331211Dto> slip3BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211DetailsUpdSlip3Rec(recId, slip3BL331211Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip4Rec(int recId, List<Slip4BL321110Dto> slip4BL321110Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL321110DetailsUpdSlip4Rec(recId, slip4BL321110Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip4Rec(int recId, List<Slip4BL041312Dto> slip4BL041312Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL041312DetailsUpdSlip4Rec(recId, slip4BL041312Dto, lastModifiedBy);
        }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip4Rec(int recId, List<Slip4BL331211Dto> slip4BL331211Dto, string lastModifiedBy)
        {
            return userCredDao.SalesTransactionBL331211DetailsUpdSlip4Rec(recId, slip4BL331211Dto, lastModifiedBy);
        }

        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId)
        {
            return userCredDao.SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter(SalesTransactionDetailsId);
        }
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId)
        {
            return userCredDao.SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter(SalesTransactionDetailsId);
        }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId)
        {
            return userCredDao.SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter(SalesTransactionDetailsId);
        }

        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPricesNewRec(List<SalesTransactionDetailsPricesNewDto> salesTransactionBL321110DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, bool AgeCalculationFullDate, bool AgeCalculationYear, DateTime AgeCalculationStartDate, string createdBy)
        {
            return userCredDao.SalesTransactionBL321110DetailsPricesNewRec(salesTransactionBL321110DetailsPrices, commisinOnGPPer, adminFeesAmount, costOfPolicyPer, costOfPolicyAmount, fixedTaxesAmount, fixedTaxesPer, vATPer, AgeCalculationFullDate, AgeCalculationYear, AgeCalculationStartDate, createdBy);
        }
        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPricesNewRec(List<SalesTransactionBL041312DetailsPricesNewDto> salesTransactionBL041312DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, string createdBy)
        {
            return userCredDao.SalesTransactionBL041312DetailsPricesNewRec(salesTransactionBL041312DetailsPrices, commisinOnGPPer, adminFeesAmount, costOfPolicyPer, costOfPolicyAmount, fixedTaxesAmount, fixedTaxesPer, vATPer, createdBy);
        }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPricesNewRec(List<SalesTransactionBL331211DetailsPricesNewDto> salesTransactionBL331211DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, string createdBy)
        {
            return userCredDao.SalesTransactionBL331211DetailsPricesNewRec(salesTransactionBL331211DetailsPrices, commisinOnGPPer, adminFeesAmount, costOfPolicyPer, costOfPolicyAmount, fixedTaxesAmount, fixedTaxesPer, vATPer, createdBy);
        }

        public SalesTransactionBL321110DetailsNewDto SalesTransactionBL321110DetailsFindWithRecIdFilter(int recId)
        {
            return userCredDao.SalesTransactionBL321110DetailsFindWithRecIdFilter(recId);
        }
        public SalesTransactionBL041312DetailsNewDto SalesTransactionBL041312DetailsFindWithRecIdFilter(int recId)
        {
            return userCredDao.SalesTransactionBL041312DetailsFindWithRecIdFilter(recId);
        }
        public SalesTransactionBL331211DetailsNewDto SalesTransactionBL331211DetailsFindWithRecIdFilter(int recId)
        {
            return userCredDao.SalesTransactionBL331211DetailsFindWithRecIdFilter(recId);
        }

        public List<PolicyBL281609Dto> PolicyBL281609NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL281609NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PaymentScheduleBL281609Dto> PolicyPaymentScheduleBL281609(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL281609(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL281609Dto> PolicyRelatedDocBL281609(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL281609(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL281609Dto PolicyRelatedDocBL281609UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL281609UpdRec(recId, attachDocBinary, attachDocName,
                                         attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL281609Dto PolicyRelatedDocBL281609NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL281609NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                               businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL281609Dto> PolicyBL281609UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL281609UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                                 PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                                 CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                                 BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                                 BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                                 NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                                PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }
        public List<dynamic> SalesTransactionBL281609FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQBenefitCompareWithRecIdFilter(salesTransactionId);
        }
        public List<dynamic> SalesTransactionBL281609FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            return userCredDao.SalesTransactionBL281609FindCQShortBenefitCompareWithRecIdFilter(salesTransactionId);
        }
        public List<PolicyBL021502Dto> PolicyBL021502NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL021502NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PaymentScheduleBL021502Dto> PolicyPaymentScheduleBL021502(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL021502(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL021502Dto> PolicyRelatedDocBL021502(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL021502(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL021502Dto PolicyRelatedDocBL021502UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL021502UpdRec(recId, attachDocBinary, attachDocName,
                                         attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL021502Dto PolicyRelatedDocBL021502NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL021502NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                               businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL021502Dto> PolicyBL021502UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL021502UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                                 PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                                 CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                                 BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                                 BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                                 NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                                PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }

        public List<PolicyBL051807Dto> PolicyBL051807NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL051807NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PaymentScheduleBL051807Dto> PolicyPaymentScheduleBL051807(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL051807(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL051807Dto> PolicyRelatedDocBL051807(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL051807(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL051807Dto PolicyRelatedDocBL051807UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL051807UpdRec(recId, attachDocBinary, attachDocName,
                                         attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL051807Dto PolicyRelatedDocBL051807NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL051807NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                               businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL051807Dto> PolicyBL051807UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL051807UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                                 PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                                 CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                                 BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                                 BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                                 NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                                PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }

        public List<PolicyBL291908Dto> PolicyBL291908NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL291908NewRec(salesTransactionId, productId, combination, businessLineCode, createdBy);
        }

        public List<PaymentScheduleBL291908Dto> PolicyPaymentScheduleBL291908(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL291908(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL291908Dto> PolicyRelatedDocBL291908(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL291908(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL291908Dto PolicyRelatedDocBL291908UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL291908UpdRec(recId, attachDocBinary, attachDocName,
                                         attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL291908Dto PolicyRelatedDocBL291908NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL291908NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                               businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL291908Dto> PolicyBL291908UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL291908UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                                 PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                                 CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                                 BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                                 BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                                 NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                                PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }
        public List<PolicyBL041312Dto> PolicyBL041312NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL041312NewRec(salesTransactionId, InsurerCode, ThirdPartyAdminCode, businessLineCode, createdBy);
        }
        public List<PaymentScheduleBL041312Dto> PolicyPaymentScheduleBL041312(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL041312(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL041312Dto> PolicyRelatedDocBL041312(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL041312(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL041312Dto PolicyRelatedDocBL041312UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL041312UpdRec(recId, attachDocBinary, attachDocName,
                                         attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL041312Dto PolicyRelatedDocBL041312NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL041312NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                               businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL041312Dto> PolicyBL041312UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate)
        {
            return userCredDao.PolicyBL041312UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                                 PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                                 CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                                 BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                                 BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                                 NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                                PolicyExpiryDate, PolicyIssuedDate);
        }

        public List<PolicyBL331211Dto> PolicyBL331211NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode, string businessLineCode, string createdBy)
        {
            return userCredDao.PolicyBL331211NewRec(salesTransactionId, InsurerCode, ThirdPartyAdminCode, businessLineCode, createdBy);
        }
        public List<PaymentScheduleBL331211Dto> PolicyPaymentScheduleBL331211(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyPaymentScheduleBL331211(salesTransactionId, businessLineCode);
        }

        public List<PolicyRelatedDocBL331211Dto> PolicyRelatedDocBL331211(int salesTransactionId, string businessLineCode)
        {
            return userCredDao.PolicyRelatedDocBL331211(salesTransactionId, businessLineCode);
        }

        public PolicyRelatedDocBL331211Dto PolicyRelatedDocBL331211UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL331211UpdRec(recId, attachDocBinary, attachDocName,
                                         attachedDocExt, lastModifiedBy);
        }

        public PolicyRelatedDocBL331211Dto PolicyRelatedDocBL331211NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            return userCredDao.PolicyRelatedDocBL331211NewRec(salesTransactionId, ticketId, parentPolicyId, policyId,
                                               businessLineCode, documentType, attachDocBinary, attachDocName, attachedDocExt, lastModifiedBy);
        }

        public List<PolicyBL331211Dto> PolicyBL331211UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            return userCredDao.PolicyBL331211UpdRec(salesTransactionId, TicketId, ParentPolicyId,
                                                 PolicyId, BusinessLineCode, GrossPremiumGP, CommisionFromGPPer,
                                                 CommisionFromGPAmount, VATOnCommisionPer, VATOnCommisionAmount,
                                                 BuiltInFixedTaxesAmount, BuiltInPropTaxesPer, BuiltInPropTaxesAmount,
                                                 BuiltInCostOfPolicyAmount, InsurerLoadingPer, InsurerLoadingAmount,
                                                 NetPremiumAmount, lastModifiedBy, PolicyNumber, PolicyEffectiveDate,
                                                PolicyExpiryDate, PolicyIssuedDate, PolicyHolder);
        }
        public List<ProductPriceControlDto> ProductPriceControlFindAll()
        {
            return userCredDao.ProductPriceControlFindAll();
        }

        public List<TicketHistoryDto> TicketHistoryFindDataWithNbrDaysFilter(int NbrDays, string UserName)
        {
            return userCredDao.TicketHistoryFindDataWithNbrDaysFilter(NbrDays, UserName);
        }

        public List<RenewalParameterDto> RenewalParameterFindAll()
        {
            return userCredDao.RenewalParameterFindAll();
        }
        public List<RenewalPolicyDto> RenewalPolicyFindAll()
        {
            return userCredDao.RenewalPolicyFindAll();
        }
        public List<PolicyInquiryDto> PolicyInquiryFindAll()
        {
            return userCredDao.PolicyInquiryFindAll();
        }
        public List<RenewalProcessDto> RenewalProcessFindAll()
        {
            return userCredDao.RenewalProcessFindAll();
        }
    }
}
