using Dapper;
using Evaluation.CAL;
using Evaluation.CAL.DTO;
using Evaluation.CAL.DTO.AF1ColHeader;
using Evaluation.CAL.DTO.BL010602;
using Evaluation.CAL.DTO.BL010602Consolidation;
using Evaluation.CAL.DTO.BL021502;
using Evaluation.CAL.DTO.BL030904;
using Evaluation.CAL.DTO.BL041312;
using Evaluation.CAL.DTO.BL051807;
using Evaluation.CAL.DTO.BL070806;
using Evaluation.CAL.DTO.BL070806Consolidation;
using Evaluation.CAL.DTO.BL080501;
using Evaluation.CAL.DTO.BL281609;
using Evaluation.CAL.DTO.BL291908;
using Evaluation.CAL.DTO.BL301401;
using Evaluation.CAL.DTO.BL301401Consolidation;
using Evaluation.CAL.DTO.BL311703;
using Evaluation.CAL.DTO.BL321110;
using Evaluation.CAL.DTO.BL321110Consolidation;
using Evaluation.CAL.DTO.BL331211;
using Evaluation.CAL.DTO.BL77;
using Evaluation.CAL.DTO.BLDuplication;
using Evaluation.CAL.DTO.Consolidation;
using Evaluation.CAL.DTO.Global;
using Evaluation.CAL.DTO.Product;
using Evaluation.CAL.DTO.SpecialCondition;
using Evaluation.CAL.DTO.Ticket;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Response.BL010602;
using Evaluation.CAL.Response.BL021502;
using Evaluation.CAL.Response.BL030904;
using Evaluation.CAL.Response.BL041312;
using Evaluation.CAL.Response.BL051807;
using Evaluation.CAL.Response.BL070806;
using Evaluation.CAL.Response.BL080501;
using Evaluation.CAL.Response.BL281609;
using Evaluation.CAL.Response.BL291908;
using Evaluation.CAL.Response.BL301401;
using Evaluation.CAL.Response.BL311703;
using Evaluation.CAL.Response.BL321110;
using Evaluation.CAL.Response.BL331211;
using Evaluation.CAL.Response.BL090703;
using Evaluation.CAL.DTO.BL090703Consolidation;
using Evaluation.CAL.Response.BL77;
using Evaluation.CAL.Wrapper;
using Evaluation.DAL.IDao;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Evaluation.CAL.DTO.BL090703;
using Evaluation.CAL.DTO.BL061005;
using Evaluation.CAL.Response.BL061005;
using Evaluation.CAL.DTO.BusinessLineDetailsProduct;
using Evaluation.CAL.DTO.ProductPriceList;
using Evaluation.CAL.DTO.ProductBenefits;
using Evaluation.CAL.DTO.ProductCombination;
using Evaluation.CAL.DTO.Kyc;
using Microsoft.AspNetCore.Http.HttpResults;
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.Request.BL321110;
using Evaluation.CAL.DTO.BL281609Consolidation;
using Evaluation.CAL.DTO.BL021502Consolidation;
using Evaluation.CAL.DTO.BL051807Consolidation;
using Evaluation.CAL.DTO.BL291908Consolidation;
using Evaluation.CAL.DTO.BL041312Consolidation;
using Evaluation.CAL.DTO.BL331211Consolidation;
using Evaluation.CAL.DTO.Dashboard;
using Evaluation.CAL.DTO.Renewal;

namespace Evaluation.DAL.Dapper
{
    public class UserCredDao : IUserCredDao
    {
        public List<UserDto> CheckUserCred(string userName, string userPassword)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.Query<UserDto>("Usp_CheckUserCredential", new { UserName = userName, UserPassword = userPassword }, cmdType: CommandType.StoredProcedure);
        }

        public List<UserDto> IsUserAvailable(string userName)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.Query<UserDto>("Usp_CheckIfUserAvailable", new { UserName = userName }, cmdType: CommandType.StoredProcedure);
        }

        public List<UserDto> RegisterUser(UserRegisterDto userRegisterDto)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.Query<UserDto>("Usp_RegisterUser",
                new
                {
                    userRegisterDto.UserName,
                    userRegisterDto.FirstName,
                    userRegisterDto.LastName,
                    userRegisterDto.EmailAdress,
                    userRegisterDto.Password,
                    userRegisterDto.RoleId
                },
                cmdType: CommandType.StoredProcedure);
        }

        public List<UserDto> UpdateUserPassword(UserChangePasswordDto userChangePasswordDto)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.Query<UserDto>("Usp_ChangeUserPassword",
                new
                {
                    userChangePasswordDto.NewPassword,
                    userChangePasswordDto.UserName
                },
                cmdType: CommandType.StoredProcedure);
        }
        public List<RegionDto> RegionFindAll()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var regionList = DapperDbAccess.Query<RegionDto>("usp_Region_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            RegionFindAllResp _classToXml;
            _classToXml = new()
            {
                Region = regionList
            };
            //string srtXml = XmlConverter.FromClass(_classToXml);
            //var xmlToClass = XmlConverter.ToClass<RegionFindAllResp>(srtXml);
            return regionList;
        }
        public RegionDto RegionNewRec(RegionNewDto regionDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<RegionDto>("usp_Region_New_Rec",
                new
                {
                    pCode = regionDto.Code,
                    pDescription = regionDto.Description,
                    //pIsActive = regionDto.IsActive,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }
        public RegionDto RegionUpdRec(RegionUpdDto regionDto, string lastModifiedBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<RegionDto>("usp_Region_Upd_Rec",
                new
                {
                    //check ig code is updated to submit message to client
                    pRecId = regionDto.RecId,
                    pDescription = regionDto.Description,
                    pIsActive = regionDto.IsActive,
                    pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public List<GenderDto> GenderFindAll()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var genderList = DapperDbAccess.Query<GenderDto>("usp_Gender_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return genderList;
        }

        public GenderDto GenderNewRec(GenderNewDto genderNewDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<GenderDto>("usp_Gender_New_Rec",
                new
                {
                    pCode = genderNewDto.Code,
                    pDescription = genderNewDto.Description,
                    //pIsActive = genderNewDto.IsActive,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }
        public GenderDto GenderUpdRec(GenderUpdDto genderDto, string lastModifiedBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var gender = DapperDbAccess.QuerySingle<GenderDto>("usp_Gender_Upd_Rec",
                new
                {
                    //check ig code is updated to submit message to client
                    pRecId = genderDto.RecId,
                    pDescription = genderDto.Description,
                    pIsActive = genderDto.IsActive,
                    pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            return gender;
        }
        public List<ChannelDto> ChannelFindAll()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var channelList = DapperDbAccess.Query<ChannelDto>("usp_Channel_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return channelList;
        }
        public ChannelDto ChannelNewRec(ChannelNewDto channelNewDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<ChannelDto>("usp_Channel_New_Rec",
                new
                {
                    pCode = channelNewDto.Code,
                    pDescription = channelNewDto.Description,
                    //pIsActive = channelNewDto.IsActive,
                    pType = channelNewDto.Type,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }
        public ChannelDto ChannelUpdRec(ChannelUpdDto channelDto, string lastModifiedBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<ChannelDto>("usp_Channel_Upd_Rec",
                new
                {
                    //check ig code is updated to submit message to client
                    pRecId = channelDto.RecId,
                    pDescription = channelDto.Description,
                    pIsActive = channelDto.IsActive,
                    pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public TokenDto TokenKey(AuthDto authDto)
        {
            var token = DapperDbAccess.QueryFirst<TokenDto>("usp_Clover_Auth_Find_Data_By_Credential",
               new
               {
                   pClientId = authDto.ClientId,
                   pScope = authDto.Scope,
                   pClientSecret = authDto.Client_Secret,
                   pGrantType = authDto.Grant_Type
               },
               cmdType: CommandType.StoredProcedure);

            return token;
        }

        public List<ContactDto> ContactFindWithAnyValue(string searchValue)
        {
            string connString = string.Empty;
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                var contactDictionary = new Dictionary<int, ContactDto>();
                var resp = db.Query<ContactDto, ContactChannelDto, ContactDto>("usp_Contact_Find_With_Any_Value",
                   (contact, contactChannel) =>
                   {
                       if (!contactDictionary.TryGetValue(contact.RecId, out ContactDto contactEntry))
                       {
                           contactEntry = contact;
                           contactEntry.ContactChannel = new List<ContactChannelDto>();
                           contactDictionary.Add(contactEntry.RecId, contactEntry);
                       }
                       contactEntry.ContactChannel.Add(contactChannel);
                       return contactEntry;
                   },
               new
               {
                   pSearchValue = searchValue
               }, commandType: CommandType.StoredProcedure
              , splitOn: "RecId")
                    .Distinct()
                    .ToList();
                return resp;
            }
        }

        public List<BusinessLineDto> BusinessLineFindAll()
        {
            //string connString = string.Empty;
            //connString = Global.ConnString;
            //using (IDbConnection db = new SqlConnection(connString))
            //{
            //    if (db.State != ConnectionState.Open)
            //        db.Open();
            //    var businessDictionary = new Dictionary<int, BusinessLineDto>();
            //    var resp = db.Query<BusinessLineDto, ProductCategoryDto, BusinessLineDto>("usp_BusinessLine_Find_All",
            //       (business, productCategory) =>
            //       {
            //           if (!businessDictionary.TryGetValue(business.Id, out BusinessLineDto businessEntry))
            //           {
            //               businessEntry = business;
            //               businessEntry.ProductCategory = new List<ProductCategoryDto>();
            //               businessDictionary.Add(businessEntry.RecId, businessEntry);
            //           }
            //           businessEntry.ProductCategory.Add(productCategory);
            //           return businessEntry;
            //       },
            //   null, commandType: CommandType.StoredProcedure
            //  , splitOn: "ProductCategory")
            //        .Distinct()
            //        .ToList();
            //    return resp;
            //}
            var businessLIneList = DapperDbAccess.Query<BusinessLineDto>("usp_BusinessLine_Find_All",
               null,
               cmdType: CommandType.StoredProcedure);
            return businessLIneList;
        }
        //public List<ContactDto> ContactFindWithAnyFilter(ContactChannelSearchWithFilterReq contactChannelSearchWithFilterReq)
        //{
        //    string connString = string.Empty;
        //    string sql = string.Empty;
        //    string sqlChnValue = string.Empty;
        //    sqlChnValue += "(";
        //    connString = Global.ConnString;

        //    using (IDbConnection db = new SqlConnection(connString))
        //    {
        //        if (db.State != ConnectionState.Open)
        //            db.Open();
        //        //var dynamicParams = new DynamicParameters();
        //        //var query = db.QueryBuilder($"SELECT * FROM [Product] WHERE 1=1");
        //        //sql = "1=1";

        //        if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.FirstName))
        //            sql += $" AND FirstName LIKE '%{contactChannelSearchWithFilterReq.FirstName}%'";

        //        if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.LastName))
        //            sql += $" AND LastName LIKE '%{contactChannelSearchWithFilterReq.LastName}%'";

        //        if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.MiddleName))
        //            sql += $" AND MiddleName LIKE '%{contactChannelSearchWithFilterReq.MiddleName}%'";

        //        if (contactChannelSearchWithFilterReq.DOB != null)
        //            sql += $" AND DOB LIKE '%{string.Format("{0:yyyy-MM-dd}", contactChannelSearchWithFilterReq.DOB)}%'";

        //        if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.Email))
        //            sqlChnValue += $"ContactChannelValue LIKE '%{contactChannelSearchWithFilterReq.Email}%' OR ";

        //        if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.LineNbr))
        //            sqlChnValue += $"ContactChannelValue LIKE '%{contactChannelSearchWithFilterReq.LineNbr}%' OR ";

        //        sqlChnValue = sqlChnValue.Length > 4 ? sqlChnValue[0..^4] : sqlChnValue;
        //        sqlChnValue += ")";
        //        sqlChnValue = sqlChnValue.Length > 2 ? " AND " + sqlChnValue : string.Empty;
        //        sql += sqlChnValue;
        //        if (string.IsNullOrEmpty(sql))
        //            return new List<ContactDto>();
        //        var contactDictionary = new Dictionary<int, ContactDto>();
        //        var resp = db.Query<ContactDto, ContactChannelDto, ContactDto>("usp_Contact_Find_With_Any_Filter",
        //           (contact, contactChannel) =>
        //           {
        //               if (!contactDictionary.TryGetValue(contact.RecId, out ContactDto contactEntry))
        //               {
        //                   contactEntry = contact;
        //                   contactEntry.ContactChannel = new List<ContactChannelDto>();
        //                   contactDictionary.Add(contactEntry.RecId, contactEntry);
        //               }
        //               contactEntry.ContactChannel.Add(contactChannel);
        //               return contactEntry;
        //           },
        //       new
        //       {
        //           pWhereFilter = sql
        //       }, commandType: CommandType.StoredProcedure
        //      , splitOn: "RecId")
        //            .Distinct()
        //            .ToList();
        //        return resp;
        //    }
        //}
        public List<ContactDto> ContactFindWithRecIdFilter(int recId)
        {
            string connString = string.Empty;
            connString = Global.ConnString;
            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                var contactDictionary = new Dictionary<int, ContactDto>();
                var resp = db.Query<ContactDto, ContactChannelDto, ContactDto>("usp_Contact_Find_With_RecId_Filter",
                   (contact, contactChannel) =>
                   {
                       if (!contactDictionary.TryGetValue(contact.RecId, out ContactDto contactEntry))
                       {
                           contactEntry = contact;
                           contactEntry.ContactChannel = new List<ContactChannelDto>();
                           contactDictionary.Add(contactEntry.RecId, contactEntry);
                       }
                       contactEntry.ContactChannel.Add(contactChannel);
                       return contactEntry;
                   },
               new
               {
                   pRecId = recId
               }, commandType: CommandType.StoredProcedure
              , splitOn: "RecId")
                    .Distinct()
                    .ToList();
                return resp;
            }
        }
        public AF1BL80Dto AF1BL80NewRec(AF1BL80NewDto aF1BL80NewDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            string strXml = string.Empty;
            XmlDocument xmlDoc = new();   //Represents an XML document, 
                                          // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new(aF1BL80NewDto.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new())
            {
                xmlSerializer.Serialize(xmlStream, aF1BL80NewDto);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                strXml = xmlDoc.InnerXml;
            }
            var aF1BL80 = DapperDbAccess.QuerySingle<AF1BL80Dto>("usp_AF1BL80_Add_New_RecId",
                new
                {
                    pAF1 = strXml,   //transfer the   aF1BL80NewDto object to xml              
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
            return aF1BL80;
        }

        public List<ContactDto> ContactChannelNewRec(ContactNewDto contactNewDto, string createdBy)
        {
            string connString = string.Empty;
            connString = Global.ConnString;

            DataTable dtContactChannel = new();
            dtContactChannel.Columns.Add("ChannelCode", typeof(string));
            dtContactChannel.Columns.Add("ContactChannelValue", typeof(string));
            dtContactChannel.Columns.Add("CountryCode", typeof(int));
            dtContactChannel.Columns.Add("AreaCode", typeof(int));
            dtContactChannel.Columns.Add("Extension", typeof(int));

            foreach (var item in contactNewDto.ContactChannel)
            {
                DataRow dataRow = dtContactChannel.NewRow();
                dataRow["ChannelCode"] = item.ChannelCode;
                dataRow["ContactChannelValue"] = item.ContactChannelValue;
                //dataRow["CountryCode"] = item.CountryCode;
                //dataRow["AreaCode"] = item.AreaCode;
                dataRow["CountryCode"] = DBNull.Value;
                dataRow["AreaCode"] = DBNull.Value;
                dataRow["Extension"] = item.Extension == null ? DBNull.Value : item.Extension;
                dtContactChannel.Rows.Add(dataRow);
            }

            var param = new DynamicParameters();
            param.Add("pFirstName", contactNewDto.FirstName);
            param.Add("pLastName", contactNewDto.LastName);
            param.Add("pMiddleName", contactNewDto.MiddleName);
            param.Add("pYOB", contactNewDto.YOB);
            param.Add("pGenderCode", contactNewDto.GenderCode);
            param.Add("pRegistrationNo", contactNewDto.RegistrationNo);
            //param.Add("pLocalCode", contactNewDto.LocalCode);
            param.Add("pRegionCode", contactNewDto.RegionCode);
            param.Add("pJob", contactNewDto.Job);
            param.Add("pCompany", contactNewDto.Company);
            param.Add("pcreatedBy", createdBy);
            param.Add("tvpContactChannel", SqlMapper.AsTableValuedParameter(dtContactChannel, "dbo.tvp_ContactChannel_New_Rec"));

            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                var contactDictionary = new Dictionary<int, ContactDto>();
                var resp = db.Query<ContactDto, ContactChannelDto, ContactDto>("usp_Contact_New_Rec",
                   (contact, contactChannel) =>
                   {
                       if (!contactDictionary.TryGetValue(contact.RecId, out ContactDto contactEntry))
                       {
                           contactEntry = contact;
                           contactEntry.ContactChannel = new List<ContactChannelDto>();
                           contactDictionary.Add(contactEntry.RecId, contactEntry);
                       }
                       contactEntry.ContactChannel.Add(contactChannel);
                       return contactEntry;
                   },
                 param
               , commandType: CommandType.StoredProcedure
              , splitOn: "RecId")
                    .Distinct()
                    .ToList();
                return resp;
            }
        }
        public List<ContactDto> ContactChannelUpdRec(ContactUpdDto contactUpdDto, string createdBy)
        {
            string connString = string.Empty;
            connString = Global.ConnString;

            DataTable dtContactChannel = new();
            dtContactChannel.Columns.Add("RecId", typeof(int));
            dtContactChannel.Columns.Add("ChannelCode", typeof(string));
            dtContactChannel.Columns.Add("ContactChannelValue", typeof(string));
            dtContactChannel.Columns.Add("CountryCode", typeof(int));
            dtContactChannel.Columns.Add("AreaCode", typeof(int));
            dtContactChannel.Columns.Add("Extension", typeof(int));
            dtContactChannel.Columns.Add("IsActive", typeof(bool));

            foreach (var item in contactUpdDto.ContactChannel)
            {
                DataRow dataRow = dtContactChannel.NewRow();
                dataRow["RecId"] = item.RecId;
                dataRow["ChannelCode"] = item.ChannelCode;
                dataRow["ContactChannelValue"] = item.ContactChannelValue;
                dataRow["CountryCode"] = DBNull.Value;
                dataRow["AreaCode"] = DBNull.Value;
                dataRow["Extension"] = item.Extension == null ? DBNull.Value : item.Extension;
                dataRow["IsActive"] = 0;
                dtContactChannel.Rows.Add(dataRow);
            }

            var param = new DynamicParameters();
            param.Add("pRecId", contactUpdDto.RecId);
            param.Add("pFirstName", contactUpdDto.FirstName);
            param.Add("pLastName", contactUpdDto.LastName);
            param.Add("pMiddleName", contactUpdDto.MiddleName);
            param.Add("pYOB", contactUpdDto.YOB);
            param.Add("pRegistrationNo", contactUpdDto.RegistrationNo);
            param.Add("pGenderCode", contactUpdDto.GenderCode);
            //param.Add("pLocalCode", contactNewDto.LocalCode);
            //param.Add("pRegionCode", contactUpdDto.RegionCode);
            param.Add("pJob", contactUpdDto.Job);
            param.Add("pCompany", contactUpdDto.Company);
            param.Add("pcreatedBy", createdBy);
            param.Add("tvpContactChannel", SqlMapper.AsTableValuedParameter(dtContactChannel, "dbo.tvp_ContactChannel_Upd_Rec"));

            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                var contactDictionary = new Dictionary<int, ContactDto>();
                var resp = db.Query<ContactDto, ContactChannelDto, ContactDto>("usp_Contact_Upd_Rec",
                   (contact, contactChannel) =>
                   {
                       if (!contactDictionary.TryGetValue(contact.RecId, out ContactDto contactEntry))
                       {
                           contactEntry = contact;
                           contactEntry.ContactChannel = new List<ContactChannelDto>();
                           contactDictionary.Add(contactEntry.RecId, contactEntry);
                       }
                       contactEntry.ContactChannel.Add(contactChannel);
                       return contactEntry;
                   },
                 param
               , commandType: CommandType.StoredProcedure
              , splitOn: "RecId")
                    .Distinct()
                    .ToList();
                return resp;
            }
        }
        public List<ContactDto> ContactFindWithAnyFilter(ContactChannelSearchWithFilterReq contactChannelSearchWithFilterReq)
        {
            string connString = string.Empty;
            string sql = string.Empty;
            string sqlChnValue = string.Empty;
            //sqlChnValue += "(";
            connString = Global.ConnString;

            using (IDbConnection db = new SqlConnection(connString))
            {
                if (db.State != ConnectionState.Open)
                    db.Open();
                //var dynamicParams = new DynamicParameters();
                //var query = db.QueryBuilder($"SELECT * FROM [Product] WHERE 1=1");
                //sql = "1=1";

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.FirstName))
                    sql += $" AND SOUNDEX(FirstName) = SOUNDEX('{contactChannelSearchWithFilterReq.FirstName}')";// AND FirstName LIKE '{contactChannelSearchWithFilterReq.FirstName.Substring(0, 1)}%'";

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.LastName))
                    if (!char.IsLetter(contactChannelSearchWithFilterReq.LastName[0]))
                        sql += $" AND LastName LIKE '%{contactChannelSearchWithFilterReq.LastName}%'";// AND LastName LIKE '{contactChannelSearchWithFilterReq.LastName.Substring(0, 1)}%'";
                    else
                        sql += $" AND SOUNDEX(LastName) = SOUNDEX('{contactChannelSearchWithFilterReq.LastName}')";// AND LastName LIKE '{contactChannelSearchWithFilterReq.LastName.Substring(0, 1)}%'";

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.MiddleName))
                    if (!char.IsLetter(contactChannelSearchWithFilterReq.MiddleName[0]))
                        sql += $" AND MiddleName LIKE '%{contactChannelSearchWithFilterReq.MiddleName}%'";// AND MiddleName LIKE '{contactChannelSearchWithFilterReq.MiddleName.Substring(0, 1)}%'";
                    else
                        sql += $" AND SOUNDEX(MiddleName) = SOUNDEX('{contactChannelSearchWithFilterReq.MiddleName}')";// AND MiddleName LIKE '{contactChannelSearchWithFilterReq.MiddleName.Substring(0, 1)}%'";

                if (contactChannelSearchWithFilterReq.YOB.ToString().Length == 4)
                    sql += $" AND YOB LIKE '%{contactChannelSearchWithFilterReq.YOB}%'";

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.RegistrationNo))
                    sql += $" AND RegistrationNo LIKE '%{contactChannelSearchWithFilterReq.RegistrationNo}%'";// AND LastName LIKE '{contactChannelSearchWithFilterReq.LastName.Substring(0, 1)}%'";

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.Email))
                    //sql += $" AND SOUNDEX(ContactChannelValue) = SOUNDEX('{contactChannelSearchWithFilterReq.Email}') AND ContactChannelValue LIKE '{contactChannelSearchWithFilterReq.Email.Substring(0, 1)}%'";
                    if (!char.IsLetter(contactChannelSearchWithFilterReq.Email[0]))
                        sqlChnValue += $" AND (ContactChannelValue LIKE '%{contactChannelSearchWithFilterReq.Email}%'";
                    else
                        sqlChnValue += $" AND (SOUNDEX(ContactChannelValue) = SOUNDEX('{contactChannelSearchWithFilterReq.Email}')";

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.LineNbr))
                    sqlChnValue += $" OR ContactChannelValue LIKE '%{contactChannelSearchWithFilterReq.LineNbr}%') ";

                if (string.IsNullOrEmpty(contactChannelSearchWithFilterReq.Email) &&
                    !string.IsNullOrEmpty(contactChannelSearchWithFilterReq.LineNbr))
                    sqlChnValue = " AND (" + sqlChnValue.Replace("OR", string.Empty);

                if (!string.IsNullOrEmpty(contactChannelSearchWithFilterReq.Email) &&
                    string.IsNullOrEmpty(contactChannelSearchWithFilterReq.LineNbr))
                    sqlChnValue += ")";
                //sqlChnValue = sqlChnValue.Length > 4 ? sqlChnValue[0..^4] : sqlChnValue;
                //sqlChnValue += ")";
                //sqlChnValue = sqlChnValue.Length > 2 ? " AND " + sqlChnValue : string.Empty;
                sql += sqlChnValue != string.Empty ? sqlChnValue : string.Empty;
                if (string.IsNullOrEmpty(sql))
                    return new List<ContactDto>();
                var contactDictionary = new Dictionary<int, ContactDto>();
                var resp = db.Query<ContactDto, ContactChannelDto, ContactDto>("usp_Contact_Find_With_Any_Filter",
                   (contact, contactChannel) =>
                   {
                       if (!contactDictionary.TryGetValue(contact.RecId, out ContactDto contactEntry))
                       {
                           contactEntry = contact;
                           contactEntry.ContactChannel = new List<ContactChannelDto>();
                           contactDictionary.Add(contactEntry.RecId, contactEntry);
                       }
                       contactEntry.ContactChannel.Add(contactChannel);
                       return contactEntry;
                   },
               new
               {
                   pWhereFilter = sql
               }, commandType: CommandType.StoredProcedure
              , splitOn: "RecId")
                    .Distinct()
                    .ToList();
                return resp;
            }
        }
        public List<LookupDto> LookupFindAll()
        {
            //Logger.Info//


            //var userCred = new List<UserCredResp>();
            var lokupList = DapperDbAccess.Query<LookupDto>("usp_Lookup_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return lokupList;
        }
        public List<LeadLookupDto> LeadLookupFindAll()
        {
            //Logger.Info//


            //var userCred = new List<UserCredResp>();
            var lokupList = DapperDbAccess.Query<LeadLookupDto>("usp_Lead_Lookup_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return lokupList;
        }

        public List<MaritalStatusDto> MaritalStatusFindAll()
        {
            var marialStatusList = DapperDbAccess.Query<MaritalStatusDto>("usp_MaritalStatus_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return marialStatusList;
        }
        public MaritalStatusDto MaritalStatusNewRec(MaritalStatusNewDto maritalStatusDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<MaritalStatusDto>("usp_MaritalStatus_New_Rec",
                new
                {
                    pCode = maritalStatusDto.Code,
                    pDescription = maritalStatusDto.Description,
                    //pIsActive = regionDto.IsActive,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }
        public MaritalStatusDto MaritalStatusUpdRec(MaritalStatusUpdDto maritalStatusDto, string lastModifiedBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<MaritalStatusDto>("usp_MaritalStatus_Upd_Rec",
                new
                {
                    //check ig code is updated to submit message to client
                    pRecId = maritalStatusDto.RecId,
                    pDescription = maritalStatusDto.Description,
                    pIsActive = maritalStatusDto.IsActive,
                    pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public List<SalesTransactionMenuDto> SalesTransactionMenuFindWithColFilter(string ClientType, int contactId)
        {
            var salesTransactionMenuList = DapperDbAccess.Query<SalesTransactionMenuDto>("usp_SalesTransaction_Menu_Find_With_Col_Filter",
              new
              {                  //check ig code is updated to submit message to client
                  pClientType = ClientType,
                  pContactId = contactId
              },
               cmdType: CommandType.StoredProcedure);
            return salesTransactionMenuList;
        }
        public SalesTransactionBL77Dto SalesTransactionBL77NewRec(int businessLineId, int contactId, List<AF1BL77Dto> aF1BL77Dto, string createdBy)
        {
            AF1BL77Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL77 = aF1BL77Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL77Xml>("usp_SalesTransactionBL77_New_Rec",
                new
                {
                    @pBusinessLineId = businessLineId,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL77Root>(salesTransaction.AF1BL77);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL77Dto salesTransactionBL77Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineId = salesTransaction.BusinessLineId,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL77 = xmlToClass.ArrayOfAF1BL77
            };
            return salesTransactionBL77Dto;

            //RegionFindAllResp _classToXml;
            //_classToXml = new()
            //{
            //    Region = regionList
            //};
            //string srtXml = XmlConverter.FromClass(_classToXml);
            //jjjj
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401NewRec(string businessLineCode, int contactId, List<AF1BL301401Dto> aF1BL301401Dto, string createdBy)
        {
            AF1BL301401Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL301401 = aF1BL301401Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL301401Xml>("usp_SalesTransactionBL301401_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL301401Root>(salesTransaction.AF1BL301401);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL301401Dto salesTransactionBL301401Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL301401 = xmlToClass.ArrayOfAF1BL301401
            };
            return salesTransactionBL301401Dto;

            //RegionFindAllResp _classToXml;
            //_classToXml = new()
            //{
            //    Region = regionList
            //};
            //string srtXml = XmlConverter.FromClass(_classToXml);
            //jjjj
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110NewRec(string businessLineCode, int contactId, List<AF1BL321110Dto> aF1BL321110Dto, string createdBy)
        {
            AF1BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL321110 = aF1BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var slip2 = DapperDbAccess.Query<Slip2BL321110Dto>("usp_SalesTransactionBL321110_SlipPreparation_Step2",
                new
                {
                    @pSalesTrx = salesTransaction.RecId
                },
                cmdType: CommandType.StoredProcedure);

            Slip2BL321110Root _slip2ClassToXml;
            _slip2ClassToXml = new()
            {
                ArrayOfSlip2BL321110 = slip2
            };
            var strSlip2Xml = XmlConverter.FromClass(_slip2ClassToXml);

            var slip3 = DapperDbAccess.Query<Slip3BL321110Dto>("usp_SalesTransactionBL321110_SlipPreparation_Step3",
                new
                {
                    @pSalesTrx = salesTransaction.RecId
                },
                cmdType: CommandType.StoredProcedure);

            Slip3BL321110Root _slip3ClassToXml;
            _slip3ClassToXml = new()
            {
                ArrayOfSlip3BL321110 = slip3
            };
            var strSlip3Xml = XmlConverter.FromClass(_slip3ClassToXml);

            var slip4 = DapperDbAccess.Query<Slip4BL321110Dto>("usp_SalesTransactionBL321110_SlipPreparation_Step4",
                new
                {
                    @pSalesTrx = salesTransaction.RecId
                },
                cmdType: CommandType.StoredProcedure);

            Slip4BL321110Root _slip4ClassToXml;
            _slip4ClassToXml = new()
            {
                ArrayOfSlip4BL321110 = slip4
            };
            var strSlip4Xml = XmlConverter.FromClass(_slip4ClassToXml);

            var salesTransactionSlip = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_AF1_Rec",
                new
                {
                    @pRecId = salesTransaction.RecId,
                    @pAF1 = strXml,
                    @pSlip2 = strSlip2Xml,
                    @pSlip3 = strSlip3Xml,
                    @pSlip4 = strSlip4Xml,
                    @pLastModifiedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = salesTransaction.RecId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransactionSlip.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransactionSlip.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(salesTransactionSlip.Slip4BL321110);
                //var strip5XmlToClass = XmlConverter.ToClass<Slip5BL321110Root>(salesTransactionSlip.Slip5BL321110);

                //xmlToClass.AF1BL77= 
                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass.ArrayOfSlip4BL321110,
                    Slip5BL321110 = new List<Slip5BL321110Dto>()
                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL080501Dto SalesTransactionBL080501NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL080501Dtco aF1BL080501Dtco, string createdBy)
        {
            AF1BL080501Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL080501 = aF1BL080501Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL080501Root>(salesTransaction.AF1BL080501);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL080501Dto salesTransactionBL080501Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                ClientId = salesTransaction.ClientId,
                MasterId = salesTransaction.MasterId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL080501 = xmlToClass.ArrayOfAF1BL080501
            };
            return salesTransactionBL080501Dto;
        }

        public SalesTransactionBL77Dto SalesTransactionBL77UpdRec(int recId, List<AF1BL77Dto> aF1BL77Dto, string lastModifiedBy)
        {
            AF1BL77Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL77 = aF1BL77Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL77Xml>("usp_SalesTransactionBL77_Upd_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL77Dto salesTransactionBL77Dto;
            if (salesTransaction.AF1BL77 == null)
            {
                salesTransactionBL77Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL77Root>(salesTransaction.AF1BL77);
                salesTransactionBL77Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineId = salesTransaction.BusinessLineId,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL77 = xmlToClass.ArrayOfAF1BL77,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL77Dto;

            //RegionFindAllResp _classToXml;
            //_classToXml = new()
            //{
            //    Region = regionList
            //};
            //string srtXml = XmlConverter.FromClass(_classToXml);
            //jjjj
        }
        public SalesTransactionBL77Dto SalesTransactionBL77FindWithRecIdFilter(int recId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL77Xml>("usp_SalesTransactionBL77_Find_With_RecId_Filter",
                new
                {
                    @pRecId = recId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL77Dto salesTransactionBL77Dto;
            if (salesTransaction.AF1BL77 == null)
            {
                salesTransactionBL77Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL77Root>(salesTransaction.AF1BL77);
                salesTransactionBL77Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineId = salesTransaction.BusinessLineId,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL77 = xmlToClass.ArrayOfAF1BL77,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL77Dto;
        }
        public SalesTransactionMenuDto SalesTransactionMenuFindWithRecIdFilter(int recId)
        {
            var salesTransactionMenu = DapperDbAccess.QueryFirstOrDefault<SalesTransactionMenuDto>("usp_SalesTransaction_Menu_Find_With_RecId_Filter",
              new
              {                  //check ig code is updated to submit message to client
                  @pRecId = recId
              },
               cmdType: CommandType.StoredProcedure);
            return salesTransactionMenu;
        }
        public BusinessLineRelatedDocDto BusinessLineRelatedDocFindWithBusinessLineCodeFilter(string businessLineCode, string applicationForm)
        {
            var businessLineRelatedDoc = DapperDbAccess.QueryFirstOrDefault<BusinessLineRelatedDocDto>("usp_BusinessLine_RelatedDoc_Find_With_BusinessLineCode_Filter",
              new
              {                  //check ig code is updated to submit message to client
                  @pBusinessLineCode = businessLineCode,
                  @pApplicationForm = applicationForm
              },
               cmdType: CommandType.StoredProcedure);
            return businessLineRelatedDoc;
        }
        public SalesTransactionBL77Dto SalesTransactionBL77FindWithColFilter(int businessLineId, int contactId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL77Xml>("usp_SalesTransaction_Find_With_ContactId_BusinessLineId_Filter",
                new
                {
                    @pContactId = contactId,
                    @pBusinessLineId = businessLineId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL77Dto salesTransactionBL77Dto;
            if (salesTransaction.AF1BL77 == null)
            {
                salesTransactionBL77Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL77Root>(salesTransaction.AF1BL77);
                salesTransactionBL77Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineId = salesTransaction.BusinessLineId,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL77 = xmlToClass.ArrayOfAF1BL77,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL77Dto;
        }

        public LeadDto LeadNewRec(LeadNewDto leadNewDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<LeadDto>("usp_Lead_New_Rec",
                new
                {
                    pLeadStatusId = leadNewDto.LeadStatusId,
                    pCountryId = leadNewDto.CountryId != 0 ? leadNewDto.CountryId : null,
                    pOwner = leadNewDto.Owner,
                    pFirstName = leadNewDto.FirstName == "" ? null : leadNewDto.FirstName == null ? null : leadNewDto.FirstName,
                    pLastName = leadNewDto.LastName == "" ? null : leadNewDto.LastName == null ? null : leadNewDto.LastName,
                    pMobile = leadNewDto.Mobile == "" ? null : leadNewDto.Mobile == null ? null : leadNewDto.Mobile,
                    pEMail = leadNewDto.EMail == "" ? null : leadNewDto.EMail == null ? null : leadNewDto.EMail,
                    pJob = leadNewDto.Job == "" ? null : leadNewDto.Job == null ? null : leadNewDto.Job,
                    pCompany = leadNewDto.Company == "" ? null : leadNewDto.Company == null ? null : leadNewDto.Company,
                    pTopic = leadNewDto.Topic == "" ? null : leadNewDto.Topic == null ? null : leadNewDto.Topic,
                    pBusinessLine = leadNewDto.BusinessLine == "" ? null : leadNewDto.BusinessLine == null ? null : leadNewDto.BusinessLine,
                    pLeadSourceId = leadNewDto.LeadSourceId != 0 ? leadNewDto.LeadSourceId : null,
                    pLeadSaleId = leadNewDto.LeadSaleId != 0 ? leadNewDto.LeadSaleId : null,
                    pSummaryFeedback = leadNewDto.SummaryFeedback == "" ? null : leadNewDto.SummaryFeedback == null ? null : leadNewDto.SummaryFeedback,
                    pNextActionDate = leadNewDto.NextActionDate,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }
        public List<LeadDto> LeadFindAll()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var leadList = DapperDbAccess.Query<LeadDto>("usp_Lead_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return leadList;
        }

        public List<SalesTransactionDto> SalesTransactionFindWithContactIdFilter(int contactId, int internalStatus)
        {
            var salesTransactionList = DapperDbAccess.Query<SalesTransactionDto>("usp_SalesTransaction_Find_ContactId_InternalStatus_Filter",
              new
              {
                  pContactid = contactId,
                  pInternalStatus = internalStatus
              },
               cmdType: CommandType.StoredProcedure);
            return salesTransactionList;
        }

        public SalesTransactionBL080501Dto SalesTransactionBL080501FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL080501Dto salesTransactionBL080501Dto;
            if (salesTransaction.AF1BL080501 == null)
            {
                salesTransactionBL080501Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL080501Root>(salesTransaction.AF1BL080501);
                salesTransactionBL080501Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL080501 = xmlToClass.ArrayOfAF1BL080501,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL080501Dto;
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL301401Xml>("usp_SalesTransactionBL301401_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL301401Dto salesTransactionBL301401Dto;
            if (salesTransaction.AF1BL301401 == null)
            {
                salesTransactionBL301401Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL301401Root>(salesTransaction.AF1BL301401);
                salesTransactionBL301401Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL301401 = xmlToClass.ArrayOfAF1BL301401,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL301401Dto;
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);
            var strip5XmlToClass = new Slip5BL321110Root();

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransaction.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransaction.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(salesTransaction.Slip4BL321110);
                if (salesTransaction.Slip5BL321110 != null)
                    strip5XmlToClass = XmlConverter.ToClass<Slip5BL321110Root>(salesTransaction.Slip5BL321110);

                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    MasterId = salesTransaction.MasterId,
                    ClientId = salesTransaction.ClientId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass.ArrayOfSlip4BL321110,
                    Slip5BL321110 = strip5XmlToClass.ArrayOfSlip5BL321110 != null ? strip5XmlToClass.ArrayOfSlip5BL321110 : new List<Slip5BL321110Dto>(),
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401UpdAF1Rec(int recId, List<AF1BL301401Dto> aF1BL301401Dto, string lastModifiedBy)
        {
            AF1BL301401Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL301401 = aF1BL301401Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL301401Xml>("usp_SalesTransactionBL301401_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL301401Dto salesTransactionBL301401Dto;
            if (salesTransaction.AF1BL301401 == null)
            {
                salesTransactionBL301401Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL301401Root>(salesTransaction.AF1BL301401);
                salesTransactionBL301401Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL301401 = xmlToClass.ArrayOfAF1BL301401,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL301401Dto;
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdAF1Rec(int recId, List<AF1BL321110Dto> aF1BL321110Dto, string lastModifiedBy)
        {
            AF1BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL321110 = aF1BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pSlip2 = "",
                    @pSlip3 = "",
                    @pSlip4 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

            var slip2 = DapperDbAccess.Query<Slip2BL321110Dto>("usp_SalesTransactionBL321110_SlipPreparation_Step2",
         new
         {
             @pSalesTrx = salesTransaction.RecId
         },
         cmdType: CommandType.StoredProcedure);

            Slip2BL321110Root _slip2ClassToXml;
            _slip2ClassToXml = new()
            {
                ArrayOfSlip2BL321110 = slip2
            };
            var strSlip2Xml = XmlConverter.FromClass(_slip2ClassToXml);

            var slip3 = DapperDbAccess.Query<Slip3BL321110Dto>("usp_SalesTransactionBL321110_SlipPreparation_Step3",
                new
                {
                    @pSalesTrx = salesTransaction.RecId
                },
                cmdType: CommandType.StoredProcedure);

            Slip3BL321110Root _slip3ClassToXml;
            _slip3ClassToXml = new()
            {
                ArrayOfSlip3BL321110 = slip3
            };
            var strSlip3Xml = XmlConverter.FromClass(_slip3ClassToXml);

            var slip4 = DapperDbAccess.Query<Slip4BL321110Dto>("usp_SalesTransactionBL321110_SlipPreparation_Step4",
        new
        {
            @pSalesTrx = salesTransaction.RecId
        },
        cmdType: CommandType.StoredProcedure);

            Slip4BL321110Root _slip4ClassToXml;
            _slip4ClassToXml = new()
            {
                ArrayOfSlip4BL321110 = slip4
            };
            var strSlip4Xml = XmlConverter.FromClass(_slip4ClassToXml);

            var salesTransactionSlip = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_AF1_Rec",
        new
        {
            @pRecId = salesTransaction.RecId,
            @pAF1 = strXml,
            @pSlip2 = strSlip2Xml,
            @pSlip3 = strSlip3Xml,
            @pSlip4 = strSlip4Xml,
            @pLastModifiedBy = lastModifiedBy
        },
        cmdType: CommandType.StoredProcedure);

            var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransactionSlip.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransactionSlip.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(salesTransactionSlip.Slip4BL321110);
                //var strip5XmlToClass = XmlConverter.ToClass<Slip5BL321110Root>(salesTransactionSlip.Slip5BL321110);

                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass.ArrayOfSlip4BL321110,
                    Slip5BL321110 = new List<Slip5BL321110Dto>()

                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL080501Dto SalesTransactionBL080501UpdAF1Rec(int recId, int clientId, int masterId, AF1BL080501Dtco aF1BL080501Dtco, string lastModifiedBy)
        {
            AF1BL080501Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL080501 = aF1BL080501Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL080501Dto salesTransactionBL080501Dto;
            if (salesTransaction.AF1BL080501 == null)
            {
                salesTransactionBL080501Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL080501Root>(salesTransaction.AF1BL080501);
                salesTransactionBL080501Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL080501 = xmlToClass.ArrayOfAF1BL080501,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL080501Dto;
        }

        public List<CQDetailsBL080501Dto> SalesTransactionBL080501FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL080501Dto>("usp_SalesTransactionBL080501_CQ_Calculation_Details",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }
        public List<CQSummaryBL080501Dto> SalesTransactionBL080501FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL080501Dto>("usp_SalesTransactionBL080501_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<CQDetailsBL301401Dto> SalesTransactionBL301401FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL301401Dto>("usp_SalesTransactionBL301401_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL301401Dto> SalesTransactionBL301401FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            //var cqSummaryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot",
            //new
            //{
            //    pSalesTrx = salesTransactionId
            //},
            // cmdType: CommandType.StoredProcedure);

            //dynamic dynamicObject = new ExpandoObject();
            //dynamicObject.Key1 = "Value1";
            //dynamicObject.Key2 = "Value2";
            //dynamicObject.Key3 = "Value3";

            //foreach (KeyValuePair<string, object> kvp in dynamicObject)
            //{
            //    string key = kvp.Key;
            //    object value = kvp.Value;

            //    Console.WriteLine("Key: " + key);
            //    Console.WriteLine("Value: " + value);
            //    Console.WriteLine();
            //}


            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL301401Dto>("usp_SalesTransactionBL301401_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<CQDetailsBL321110Dto> SalesTransactionBL321110FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL321110Dto>("usp_SalesTransactionBL321110_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<dynamic> SalesTransactionBL321110FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<dynamic>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_Summary_1",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL331211FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<dynamic>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_Summary_1",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL080501FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_Short",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL301401FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            //var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot",
            //            new
            //            {
            //                pSalesTrx = salesTransactionId
            //            },
            //             cmdType: CommandType.StoredProcedure);

            //return cqPivotListDynamic;

            string connString = string.Empty;
            connString = Global.ConnString;
            //var res = new ProductCombinationDto();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("usp_SalesTransactionBL301401_CQ_Calculation_Pivot",
                    new
                    {
                        pSalesTrx = salesTransactionId,
                    }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var resultList = new List<dynamic>();
                    while (!multi.IsConsumed)
                    {
                        resultList.Add(multi.Read<dynamic>());
                    }
                    // Read from the first result set
                    //var result1 = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel1 with the appropriate class

                    // Read from the second result set
                    //res = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel2 with the appropriate class

                    // Process or use result1 and result2 as needed
                    return resultList;
                }
            }
        }

        public List<dynamic> SalesTransactionBL321110FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_Sections_Prices",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL321110FindCQPivotListPricesWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotPricesListListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_List_Prices",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotPricesListListDynamic;
        }
        public List<dynamic> SalesTransactionBL041312FindCQPivotListPricesWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotPricesListListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_List_Prices",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotPricesListListDynamic;
        }
        public List<dynamic> SalesTransactionBL331211FindCQPivotListPricesWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotPricesListListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_List_Prices",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotPricesListListDynamic;
        }

        public List<dynamic> SalesTransactionBL080501FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_Benefits",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_Benefits_Short",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL301401FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            //var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_Benefits",
            //            new
            //            {
            //                pSalesTrx = salesTransactionId
            //            },
            //             cmdType: CommandType.StoredProcedure);          



            string connString = string.Empty;
            connString = Global.ConnString;
            //var res = new ProductCombinationDto();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_Benefits",
                    new
                    {
                        pSalesTrx = salesTransactionId,
                    }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var resultList = new List<dynamic>();
                    while (!multi.IsConsumed)
                    {
                        resultList.Add(multi.Read<dynamic>());
                    }
                    // Read from the first result set
                    //var result1 = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel1 with the appropriate class

                    // Read from the second result set
                    //res = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel2 with the appropriate class

                    // Process or use result1 and result2 as needed
                    return resultList;
                }
            }
            //return res;

        }

        public List<dynamic> SalesTransactionBL301401FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            //var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_Benefits",
            //            new
            //            {
            //                pSalesTrx = salesTransactionId
            //            },
            //             cmdType: CommandType.StoredProcedure);          



            string connString = string.Empty;
            connString = Global.ConnString;
            //var res = new ProductCombinationDto();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_BenefitsCompare",
                    new
                    {
                        pSalesTrx = salesTransactionId,
                    }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var resultList = new List<dynamic>();
                    while (!multi.IsConsumed)
                    {
                        resultList.Add(multi.Read<dynamic>());
                    }
                    // Read from the first result set
                    //var result1 = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel1 with the appropriate class

                    // Read from the second result set
                    //res = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel2 with the appropriate class

                    // Process or use result1 and result2 as needed
                    return resultList;
                }
            }
            //return res;

        }

        public List<dynamic> SalesTransactionBL301401FindCQPivotMemberWithRecIdFilter(int salesTransactionId)
        {
            //var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_Benefits",
            //            new
            //            {
            //                pSalesTrx = salesTransactionId
            //            },
            //             cmdType: CommandType.StoredProcedure);          



            string connString = string.Empty;
            connString = Global.ConnString;
            //var res = new ProductCombinationDto();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("usp_SalesTransactionBL301401_CQ_Calculation_PivotMembers",
                    new
                    {
                        pSalesTrx = salesTransactionId,
                    }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var resultList = new List<dynamic>();
                    while (!multi.IsConsumed)
                    {
                        resultList.Add(multi.Read<dynamic>());
                    }
                    // Read from the first result set
                    //var result1 = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel1 with the appropriate class

                    // Read from the second result set
                    //res = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel2 with the appropriate class

                    // Process or use result1 and result2 as needed
                    return resultList;
                }
            }
            //return res;

        }

        public List<dynamic> SalesTransactionBL321110FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_members_Prices",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL321110FindCQPivotBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }
        public List<dynamic> SalesTransactionBL041312FindCQPivotBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }
        public List<dynamic> SalesTransactionBL331211FindCQPivotBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL080501FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_payment",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_Payment_Short",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<dynamic> SalesTransactionBL301401FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_payment",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<dynamic> SalesTransactionBL321110FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader301401Dto> SalesTransactionBL301401FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader301401Dto>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQHeader030904Dto> SalesTransactionBL030904FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader030904Dto>("usp_SalesTransactionBL030904_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory> SalesTransactionBL301401FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory>("usp_SalesTransactionBL301401_CQ_Calculation_Pivot_Categories",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQHeader080501> SalesTransactionBL080501FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader080501>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory080501> SalesTransactionBL080501FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory080501>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQHeader321110> SalesTransactionBL321110FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader321110>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory321110> SalesTransactionBL321110FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory321110>("usp_SalesTransactionBL321110_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public SpecialConditionDto SpecialConditionNewRec(int salesTrxId, string businessLineCode,
            int productId, int sheet, decimal discountPer, decimal discountAmount, string createdBy)
        {
            return DapperDbAccess.QueryFirst<SpecialConditionDto>("usp_SpecialCondition_New_Rec",
                new
                {
                    pSalesTrxId = salesTrxId,
                    pBusinessLineCode = businessLineCode,
                    pProductId = productId,
                    pSheet = sheet,
                    pDiscountPer = discountPer,
                    pDiscountAmount = discountAmount,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public SpecialConditionDto SpecialConditionFindWithColFilter(int salesTrxId, string businessLineCode,
            int productId, int sheet)
        {
            var specialCondition = DapperDbAccess.QueryFirstOrDefault<SpecialConditionDto>("usp_SpecialCondition_Find_With_Col_Filter",
              new
              {
                  pSalesTrxId = salesTrxId,
                  pBusinessLineCode = businessLineCode,
                  pProductId = productId,
                  pSheet = sheet
              },
               cmdType: CommandType.StoredProcedure);
            return specialCondition;
        }

        public AF1ColHeaderDto AF1ColHeaderWithColFilter(string aF1Code, string aF1ColHeader)
        {
            var aF1ColHeaderResp = DapperDbAccess.QueryFirstOrDefault<AF1ColHeaderDto>("usp_AF1_Header_Verification",
             new
             {
                 pAF1 = aF1Code,
                 pAF1Columns = aF1ColHeader
             },
              cmdType: CommandType.StoredProcedure);
            return aF1ColHeaderResp;
        }

        public SalesTransactionBL021502Dto SalesTransactionBL021502UpdAF1Rec(int recId, List<AF1BL021502Dto> aF1BL021502Dto, string lastModifiedBy)
        {
            AF1BL021502Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL021502 = aF1BL021502Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL021502Xml>("usp_SalesTransactionBL021502_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL021502Dto salesTransactionBL021502Dto;
            if (salesTransaction.AF1BL021502 == null)
            {
                salesTransactionBL021502Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL021502Root>(salesTransaction.AF1BL021502);
                salesTransactionBL021502Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL021502 = xmlToClass.ArrayOfAF1BL021502,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL021502Dto;
        }

        public SalesTransactionBL021502Dto SalesTransactionBL021502FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL021502Xml>("usp_SalesTransactionBL021502_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL021502Dto salesTransactionBL021502Dto;
            if (salesTransaction.AF1BL021502 == null)
            {
                salesTransactionBL021502Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL021502Root>(salesTransaction.AF1BL021502);
                salesTransactionBL021502Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL021502 = xmlToClass.ArrayOfAF1BL021502,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL021502Dto;
        }

        public SalesTransactionBL021502Dto SalesTransactionBL021502NewRec(string businessLineCode, int contactId, List<AF1BL021502Dto> aF1BL021502Dto, string createdBy)
        {
            AF1BL021502Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL021502 = aF1BL021502Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL021502Xml>("usp_SalesTransactionBL021502_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL021502Root>(salesTransaction.AF1BL021502);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL021502Dto salesTransactionBL021502Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL021502 = xmlToClass.ArrayOfAF1BL021502
            };
            return salesTransactionBL021502Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdAF1Rec(int recId, List<AF1BL041312Dto> aF1BL041312Dto, string lastModifiedBy)
        {
            AF1BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL041312 = aF1BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pSlip2 = "",
                    @pSlip3 = "",
                    @pSlip4 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

            var slip2 = DapperDbAccess.Query<Slip2BL041312Dto>("usp_SalesTransactionBL041312_SlipPreparation_Step2",
         new
         {
             @pSalesTrx = salesTransaction.RecId
         },
         cmdType: CommandType.StoredProcedure);

            Slip2BL041312Root _slip2ClassToXml;
            _slip2ClassToXml = new()
            {
                ArrayOfSlip2BL041312 = slip2
            };
            var strSlip2Xml = XmlConverter.FromClass(_slip2ClassToXml);

            var slip3 = DapperDbAccess.Query<Slip3BL041312Dto>("usp_SalesTransactionBL041312_SlipPreparation_Step3",
                new
                {
                    @pSalesTrx = salesTransaction.RecId
                },
                cmdType: CommandType.StoredProcedure);

            Slip3BL041312Root _slip3ClassToXml;
            _slip3ClassToXml = new()
            {
                ArrayOfSlip3BL041312 = slip3
            };
            var strSlip3Xml = XmlConverter.FromClass(_slip3ClassToXml);

            var slip4 = DapperDbAccess.Query<Slip4BL041312Dto>("usp_SalesTransactionBL041312_SlipPreparation_Step4",
        new
        {
            @pSalesTrx = salesTransaction.RecId
        },
        cmdType: CommandType.StoredProcedure);

            Slip4BL041312Root _slip4ClassToXml;
            _slip4ClassToXml = new()
            {
                ArrayOfSlip4BL041312 = slip4
            };
            var strSlip4Xml = XmlConverter.FromClass(_slip4ClassToXml);
            var salesTransactionSlip = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_AF1_Rec",
        new
        {
            @pRecId = salesTransaction.RecId,
            @pAF1 = strXml,
            @pSlip2 = strSlip2Xml,
            @pSlip3 = strSlip3Xml,
            @pSlip4 = strSlip4Xml,
            @pLastModifiedBy = lastModifiedBy
        },
        cmdType: CommandType.StoredProcedure);

            var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransactionSlip.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransactionSlip.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(salesTransactionSlip.Slip4BL041312);
                //var strip5XmlToClass = XmlConverter.ToClass<Slip5BL321110Root>(salesTransactionSlip.Slip5BL321110);

                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass.ArrayOfSlip4BL041312,
                    Slip5BL041312 = new List<Slip5BL041312Dto>()

                };
            }
            return salesTransactionBL041312Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);
            var strip5XmlToClass = new Slip5BL041312Root();

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransaction.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransaction.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(salesTransaction.Slip4BL041312);
                if (salesTransaction.Slip5BL041312 != null)
                    strip5XmlToClass = XmlConverter.ToClass<Slip5BL041312Root>(salesTransaction.Slip5BL041312);
                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    MasterId = salesTransaction.MasterId,
                    ClientId = salesTransaction.ClientId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass.ArrayOfSlip4BL041312,
                    Slip5BL041312 = strip5XmlToClass.ArrayOfSlip5BL041312 != null ? strip5XmlToClass.ArrayOfSlip5BL041312 : new List<Slip5BL041312Dto>(),
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL041312Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312NewRec(string businessLineCode, int contactId, List<AF1BL041312Dto> aF1BL041312Dto, string createdBy)
        {
            AF1BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL041312 = aF1BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
            var slip2 = DapperDbAccess.Query<Slip2BL041312Dto>("usp_SalesTransactionBL041312_SlipPreparation_Step2",
            new
            {
                @pSalesTrx = salesTransaction.RecId
            },
            cmdType: CommandType.StoredProcedure);

            Slip2BL041312Root _slip2ClassToXml;
            _slip2ClassToXml = new()
            {
                ArrayOfSlip2BL041312 = slip2
            };
            var strSlip2Xml = XmlConverter.FromClass(_slip2ClassToXml);

            var slip3 = DapperDbAccess.Query<Slip3BL041312Dto>("usp_SalesTransactionBL041312_SlipPreparation_Step3",
        new
        {
            @pSalesTrx = salesTransaction.RecId
        },
        cmdType: CommandType.StoredProcedure);

            Slip3BL041312Root _slip3ClassToXml;
            _slip3ClassToXml = new()
            {
                ArrayOfSlip3BL041312 = slip3
            };
            var strSlip3Xml = XmlConverter.FromClass(_slip3ClassToXml);

            var slip4 = DapperDbAccess.Query<Slip4BL041312Dto>("usp_SalesTransactionBL041312_SlipPreparation_Step4",
            new
            {
                @pSalesTrx = salesTransaction.RecId
            },
        cmdType: CommandType.StoredProcedure);

            Slip4BL041312Root _slip4ClassToXml;
            _slip4ClassToXml = new()
            {
                ArrayOfSlip4BL041312 = slip4
            };
            var strSlip4Xml = XmlConverter.FromClass(_slip4ClassToXml);

            var salesTransactionSlip = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_AF1_Rec",
        new
        {
            @pRecId = salesTransaction.RecId,
            @pAF1 = strXml,
            @pSlip2 = strSlip2Xml,
            @pSlip3 = strSlip3Xml,
            @pSlip4 = strSlip4Xml,
            @pLastModifiedBy = createdBy
        },
        cmdType: CommandType.StoredProcedure);

            var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Details_Upd_IsActive_Rec",
        new
        {
            @pSalesTrxId = salesTransaction.RecId,
            //@pAF1 = strXml,
            //@pSlip5 = strXml,
            //@pSlip3 = "",
            @pLastModifiedBy = createdBy
        },
        cmdType: CommandType.StoredProcedure);

            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransactionSlip.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransactionSlip.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(salesTransactionSlip.Slip4BL041312);
                //var strip5XmlToClass = XmlConverter.ToClass<Slip5BL041312Root>(salesTransactionSlip.Slip5BL041312);

                //xmlToClass.AF1BL77= 
                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass.ArrayOfSlip4BL041312,
                    Slip5BL041312 = new List<Slip5BL041312Dto>()
                };
            }
            return salesTransactionBL041312Dto;
        }

        public SalesTransactionBL051807Dto SalesTransactionBL051807UpdAF1Rec(int recId, List<AF1BL051807Dto> aF1BL051807Dto, string lastModifiedBy)
        {
            AF1BL051807Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL051807 = aF1BL051807Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL051807Xml>("usp_SalesTransactionBL051807_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL051807Dto salesTransactionBL051807Dto;
            if (salesTransaction.AF1BL051807 == null)
            {
                salesTransactionBL051807Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL051807Root>(salesTransaction.AF1BL051807);
                salesTransactionBL051807Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL051807 = xmlToClass.ArrayOfAF1BL051807,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL051807Dto;
        }

        public SalesTransactionBL051807Dto SalesTransactionBL051807FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL051807Xml>("usp_SalesTransactionBL051807_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL051807Dto salesTransactionBL051807Dto;
            if (salesTransaction.AF1BL051807 == null)
            {
                salesTransactionBL051807Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL051807Root>(salesTransaction.AF1BL051807);
                salesTransactionBL051807Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL051807 = xmlToClass.ArrayOfAF1BL051807,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL051807Dto;
        }

        public SalesTransactionBL051807Dto SalesTransactionBL051807NewRec(string businessLineCode, int contactId, List<AF1BL051807Dto> aF1BL051807Dto, string createdBy)
        {
            AF1BL051807Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL051807 = aF1BL051807Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL051807Xml>("usp_SalesTransactionBL051807_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL051807Root>(salesTransaction.AF1BL051807);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL051807Dto salesTransactionBL051807Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL051807 = xmlToClass.ArrayOfAF1BL051807
            };
            return salesTransactionBL051807Dto;
        }

        public SalesTransactionBL281609Dto SalesTransactionBL281609UpdAF1Rec(int recId, List<AF1BL281609Dto> aF1BL281609Dto, string lastModifiedBy)
        {
            AF1BL281609Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL281609 = aF1BL281609Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL281609Xml>("usp_SalesTransactionBL281609_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL281609Dto salesTransactionBL281609Dto;
            if (salesTransaction.AF1BL281609 == null)
            {
                salesTransactionBL281609Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL281609Root>(salesTransaction.AF1BL281609);
                salesTransactionBL281609Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL281609 = xmlToClass.ArrayOfAF1BL281609,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL281609Dto;
        }

        public SalesTransactionBL281609Dto SalesTransactionBL281609FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL281609Xml>("usp_SalesTransactionBL281609_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL281609Dto salesTransactionBL281609Dto;
            if (salesTransaction.AF1BL281609 == null)
            {
                salesTransactionBL281609Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL281609Root>(salesTransaction.AF1BL281609);
                salesTransactionBL281609Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL281609 = xmlToClass.ArrayOfAF1BL281609,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL281609Dto;
        }

        public SalesTransactionBL281609Dto SalesTransactionBL281609NewRec(string businessLineCode, int contactId, List<AF1BL281609Dto> aF1BL281609Dto, string createdBy)
        {
            AF1BL281609Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL281609 = aF1BL281609Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL281609Xml>("usp_SalesTransactionBL281609_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL281609Root>(salesTransaction.AF1BL281609);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL281609Dto salesTransactionBL281609Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL281609 = xmlToClass.ArrayOfAF1BL281609
            };
            return salesTransactionBL281609Dto;
        }

        public SalesTransactionBL291908Dto SalesTransactionBL291908UpdAF1Rec(int recId, List<AF1BL291908Dto> aF1BL291908Dto, string lastModifiedBy)
        {
            AF1BL291908Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL291908 = aF1BL291908Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL291908Xml>("usp_SalesTransactionBL291908_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL291908Dto salesTransactionBL291908Dto;
            if (salesTransaction.AF1BL291908 == null)
            {
                salesTransactionBL291908Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL291908Root>(salesTransaction.AF1BL291908);
                salesTransactionBL291908Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL291908 = xmlToClass.ArrayOfAF1BL291908,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL291908Dto;
        }

        public SalesTransactionBL291908Dto SalesTransactionBL291908FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL291908Xml>("usp_SalesTransactionBL291908_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL291908Dto salesTransactionBL291908Dto;
            if (salesTransaction.AF1BL291908 == null)
            {
                salesTransactionBL291908Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL291908Root>(salesTransaction.AF1BL291908);
                salesTransactionBL291908Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL291908 = xmlToClass.ArrayOfAF1BL291908,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL291908Dto;
        }

        public SalesTransactionBL291908Dto SalesTransactionBL291908NewRec(string businessLineCode, int contactId, List<AF1BL291908Dto> aF1BL291908Dto, string createdBy)
        {
            AF1BL291908Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL291908 = aF1BL291908Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL291908Xml>("usp_SalesTransactionBL291908_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL291908Root>(salesTransaction.AF1BL291908);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL291908Dto salesTransactionBL291908Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL291908 = xmlToClass.ArrayOfAF1BL291908
            };
            return salesTransactionBL291908Dto;
        }

        public SalesTransactionBL311703Dto SalesTransactionBL311703UpdAF1Rec(int recId, List<AF1BL311703Dto> aF1BL311703Dto, string lastModifiedBy)
        {
            AF1BL311703Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL311703 = aF1BL311703Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL311703Xml>("usp_SalesTransactionBL311703_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL311703Dto salesTransactionBL311703Dto;
            if (salesTransaction.AF1BL311703 == null)
            {
                salesTransactionBL311703Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL311703Root>(salesTransaction.AF1BL311703);
                salesTransactionBL311703Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL311703 = xmlToClass.ArrayOfAF1BL311703,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL311703Dto;
        }

        public SalesTransactionBL311703Dto SalesTransactionBL311703FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL311703Xml>("usp_SalesTransactionBL311703_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL311703Dto salesTransactionBL311703Dto;
            if (salesTransaction.AF1BL311703 == null)
            {
                salesTransactionBL311703Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL311703Root>(salesTransaction.AF1BL311703);
                salesTransactionBL311703Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL311703 = xmlToClass.ArrayOfAF1BL311703,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL311703Dto;
        }

        public SalesTransactionBL311703Dto SalesTransactionBL311703NewRec(string businessLineCode, int contactId, List<AF1BL311703Dto> aF1BL311703Dto, string createdBy)
        {
            AF1BL311703Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL311703 = aF1BL311703Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL311703Xml>("usp_SalesTransactionBL311703_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL311703Root>(salesTransaction.AF1BL311703);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL311703Dto salesTransactionBL311703Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL311703 = xmlToClass.ArrayOfAF1BL311703
            };
            return salesTransactionBL311703Dto;
        }

        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdAF1Rec(int recId, List<AF1BL331211Dto> aF1BL331211Dto, string lastModifiedBy)
        {
            AF1BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL331211 = aF1BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pSlip2 = "",
                    @pSlip3 = "",
                    @pSlip4 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

            var slip2 = DapperDbAccess.Query<Slip2BL331211Dto>("usp_SalesTransactionBL331211_SlipPreparation_Step2",
         new
         {
             @pSalesTrx = salesTransaction.RecId
         },
         cmdType: CommandType.StoredProcedure);

            Slip2BL331211Root _slip2ClassToXml;
            _slip2ClassToXml = new()
            {
                ArrayOfSlip2BL331211 = slip2
            };
            var strSlip2Xml = XmlConverter.FromClass(_slip2ClassToXml);

            var slip3 = DapperDbAccess.Query<Slip3BL331211Dto>("usp_SalesTransactionBL331211_SlipPreparation_Step3",
                new
                {
                    @pSalesTrx = salesTransaction.RecId
                },
                cmdType: CommandType.StoredProcedure);

            Slip3BL331211Root _slip3ClassToXml;
            _slip3ClassToXml = new()
            {
                ArrayOfSlip3BL331211 = slip3
            };
            var strSlip3Xml = XmlConverter.FromClass(_slip3ClassToXml);

            var slip4 = DapperDbAccess.Query<Slip4BL331211Dto>("usp_SalesTransactionBL331211_SlipPreparation_Step4",
        new
        {
            @pSalesTrx = salesTransaction.RecId
        },
        cmdType: CommandType.StoredProcedure);

            Slip4BL331211Root _slip4ClassToXml;
            _slip4ClassToXml = new()
            {
                ArrayOfSlip4BL331211 = slip4
            };
            var strSlip4Xml = XmlConverter.FromClass(_slip4ClassToXml);

            var salesTransactionSlip = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Upd_AF1_Rec",
        new
        {
            @pRecId = salesTransaction.RecId,
            @pAF1 = strXml,
            @pSlip2 = strSlip2Xml,
            @pSlip3 = strSlip3Xml,
            @pSlip4 = strSlip4Xml,
            @pLastModifiedBy = lastModifiedBy
        },
        cmdType: CommandType.StoredProcedure);

            var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(salesTransactionSlip.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(salesTransactionSlip.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(salesTransactionSlip.Slip4BL331211);
                //var strip5XmlToClass = XmlConverter.ToClass<Slip5BL331211Root>(salesTransactionSlip.Slip5BL331211);

                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL331211 = strip2XmlToClass.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass.ArrayOfSlip4BL331211,
                    Slip5BL331211 = new List<Slip5BL331211Dto>()

                };
            }
            return salesTransactionBL331211Dto;
        }

        public SalesTransactionBL331211Dto SalesTransactionBL331211FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);
            var strip5XmlToClass = new Slip5BL331211Root();

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(salesTransaction.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(salesTransaction.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(salesTransaction.Slip4BL331211);
                if (salesTransaction.Slip5BL331211 != null)
                    strip5XmlToClass = XmlConverter.ToClass<Slip5BL331211Root>(salesTransaction.Slip5BL331211);

                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    MasterId = salesTransaction.MasterId,
                    ClientId = salesTransaction.ClientId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Slip2BL331211 = strip2XmlToClass.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass.ArrayOfSlip4BL331211,
                    Slip5BL331211 = strip5XmlToClass.ArrayOfSlip5BL331211 != null ? strip5XmlToClass.ArrayOfSlip5BL331211 : new List<Slip5BL331211Dto>(),
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL331211Dto;
        }

        public SalesTransactionBL331211Dto SalesTransactionBL331211NewRec(string businessLineCode, int contactId, List<AF1BL331211Dto> aF1BL331211Dto, string createdBy)
        {
            AF1BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL331211 = aF1BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var slip2 = DapperDbAccess.Query<Slip2BL331211Dto>("usp_SalesTransactionBL331211_SlipPreparation_Step2",
            new
            {
                @pSalesTrx = salesTransaction.RecId
            },
            cmdType: CommandType.StoredProcedure);

            Slip2BL331211Root _slip2ClassToXml;
            _slip2ClassToXml = new()
            {
                ArrayOfSlip2BL331211 = slip2
            };
            var strSlip2Xml = XmlConverter.FromClass(_slip2ClassToXml);

            var slip3 = DapperDbAccess.Query<Slip3BL331211Dto>("usp_SalesTransactionBL331211_SlipPreparation_Step3",
        new
        {
            @pSalesTrx = salesTransaction.RecId
        },
        cmdType: CommandType.StoredProcedure);

            Slip3BL331211Root _slip3ClassToXml;
            _slip3ClassToXml = new()
            {
                ArrayOfSlip3BL331211 = slip3
            };
            var strSlip3Xml = XmlConverter.FromClass(_slip3ClassToXml);

            var slip4 = DapperDbAccess.Query<Slip4BL331211Dto>("usp_SalesTransactionBL331211_SlipPreparation_Step4",
            new
            {
                @pSalesTrx = salesTransaction.RecId
            },
        cmdType: CommandType.StoredProcedure);

            Slip4BL331211Root _slip4ClassToXml;
            _slip4ClassToXml = new()
            {
                ArrayOfSlip4BL331211 = slip4
            };
            var strSlip4Xml = XmlConverter.FromClass(_slip4ClassToXml);

            var salesTransactionSlip = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL331211_Upd_AF1_Rec",
        new
        {
            @pRecId = salesTransaction.RecId,
            @pAF1 = strXml,
            @pSlip2 = strSlip2Xml,
            @pSlip3 = strSlip3Xml,
            @pSlip4 = strSlip4Xml,
            @pLastModifiedBy = createdBy
        },
        cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL331211Dto salesTransactionBL331211Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL331211 = xmlToClass.ArrayOfAF1BL331211
            };
            return salesTransactionBL331211Dto;
        }

        public List<CQDetailsBL021502Dto> SalesTransactionBL021502FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL021502Dto>("usp_SalesTransactionBL021502_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL021502Dto> SalesTransactionBL021502FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL021502Dto>("usp_SalesTransactionBL021502_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL021502FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL021502_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL021502FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL021502_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL021502FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL021502_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader021502Dto> SalesTransactionBL021502FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader021502Dto>("usp_SalesTransactionBL021502_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory021502Dto> SalesTransactionBL021502FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory021502Dto>("usp_SalesTransactionBL021502_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL041312Dto> SalesTransactionBL041312FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL041312Dto>("usp_SalesTransactionBL041312_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<dynamic> SalesTransactionBL041312FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<dynamic>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_Summary_1",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL041312FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_Sections_Prices",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL041312FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_members_Prices",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL041312FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader041312Dto> SalesTransactionBL041312FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader041312Dto>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory041312Dto> SalesTransactionBL041312FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory041312Dto>("usp_SalesTransactionBL041312_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL051807Dto> SalesTransactionBL051807FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL051807Dto>("usp_SalesTransactionBL051807_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL051807Dto> SalesTransactionBL051807FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL051807Dto>("usp_SalesTransactionBL051807_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL051807FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL051807_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL051807FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL051807_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL051807FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL051807_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader051807Dto> SalesTransactionBL051807FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader051807Dto>("usp_SalesTransactionBL051807_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory051807Dto> SalesTransactionBL051807FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory051807Dto>("usp_SalesTransactionBL051807_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL281609Dto> SalesTransactionBL281609FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL281609Dto>("usp_SalesTransactionBL281609_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL281609Dto> SalesTransactionBL281609FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL281609Dto>("usp_SalesTransactionBL281609_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL281609FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL281609FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL281609FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader281609Dto> SalesTransactionBL281609FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader281609Dto>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory281609Dto> SalesTransactionBL281609FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory281609Dto>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL291908Dto> SalesTransactionBL291908FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL291908Dto>("usp_SalesTransactionBL291908_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL291908Dto> SalesTransactionBL291908FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL291908Dto>("usp_SalesTransactionBL291908_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL291908FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL291908_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL291908FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL291908_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL291908FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL291908_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader291908Dto> SalesTransactionBL291908FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader291908Dto>("usp_SalesTransactionBL291908_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory291908Dto> SalesTransactionBL291908FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory291908Dto>("usp_SalesTransactionBL291908_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL311703Dto> SalesTransactionBL311703FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL311703Dto>("usp_SalesTransactionBL311703_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL311703Dto> SalesTransactionBL311703FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL311703Dto>("usp_SalesTransactionBL311703_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL311703FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL311703_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL311703FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL311703_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL311703FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL311703_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader311703Dto> SalesTransactionBL311703FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader311703Dto>("usp_SalesTransactionBL311703_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory311703Dto> SalesTransactionBL311703FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory311703Dto>("usp_SalesTransactionBL311703_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL331211Dto> SalesTransactionBL331211FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL331211Dto>("usp_SalesTransactionBL331211_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        //public List<CQSummaryBL331211Dto> SalesTransactionBL331211FindCQSummaryWithRecIdFilter(int salesTransactionId)
        //{
        //    var cqSummaryList = DapperDbAccess.Query<CQSummaryBL331211Dto>("usp_SalesTransactionBL331211_CQ_Calculation_Summary",
        //     new
        //     {
        //         pSalesTrx = salesTransactionId
        //     },
        //      cmdType: CommandType.StoredProcedure);

        //    return cqSummaryList;
        //}

        public List<dynamic> SalesTransactionBL331211FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_Sections_Prices",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL331211FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_members_Prices",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL331211FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader331211Dto> SalesTransactionBL331211FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader331211Dto>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory331211Dto> SalesTransactionBL331211FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory331211Dto>("usp_SalesTransactionBL331211_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public SalesTransactionBL010602Dto SalesTransactionBL010602FindAF1WithRecIdFilter(int salesTransactionId)
        {

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL010602Xml>("usp_SalesTransactionBL010602_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL010602Dto salesTransactionBL010602Dto;
            if (salesTransaction.AF1BL010602 == null)
            {
                salesTransactionBL010602Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL010602Root>(salesTransaction.AF1BL010602);
                salesTransactionBL010602Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL010602 = xmlToClass.ArrayOfAF1BL010602,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL010602Dto;
        }

        public SalesTransactionBL010602Dto SalesTransactionBL010602NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL010602Dtco aF1BL010602Dtco, string createdBy)
        {
            AF1BL010602Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL010602 = aF1BL010602Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL010602Xml>("usp_SalesTransactionBL010602_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL010602Root>(salesTransaction.AF1BL010602);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL010602Dto salesTransactionBL010602Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                ClientId = salesTransaction.ClientId,
                MasterId = salesTransaction.MasterId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL010602 = xmlToClass.ArrayOfAF1BL010602
            };
            return salesTransactionBL010602Dto;
        }

        public SalesTransactionBL010602Dto SalesTransactionBL010602UpdAF1Rec(int recId, int clientId, int masterId, AF1BL010602Dtco aF1BL010602Dtco, string lastModifiedBy)
        {
            AF1BL010602Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL010602 = aF1BL010602Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL010602Xml>("usp_SalesTransactionBL010602_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL010602Dto salesTransactionBL010602Dto;
            if (salesTransaction.AF1BL010602 == null)
            {
                salesTransactionBL010602Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL010602Root>(salesTransaction.AF1BL010602);
                salesTransactionBL010602Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL010602 = xmlToClass.ArrayOfAF1BL010602,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL010602Dto;
        }

        public List<CQDetailsBL010602Dto> SalesTransactionBL010602FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL010602Dto>("usp_SalesTransactionBL010602_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL010602Dto> SalesTransactionBL010602FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL010602Dto>("usp_SalesTransactionBL010602_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL010602FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL010602_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL010602FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL010602_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL010602FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL010602_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader010602Dto> SalesTransactionBL010602FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader010602Dto>("usp_SalesTransactionBL010602_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory010602Dto> SalesTransactionBL010602FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory010602Dto>("usp_SalesTransactionBL010602_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }
        public SalesTransactionBL030904Dto SalesTransactionBL030904UpdAF1Rec(int recId, List<AF1BL030904Dto> aF1BL030904Dto, string lastModifiedBy)
        {
            AF1BL030904Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL030904 = aF1BL030904Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL030904Xml>("usp_SalesTransactionBL030904_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL030904Dto salesTransactionBL030904Dto;
            if (salesTransaction.AF1BL030904 == null)
            {
                salesTransactionBL030904Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL030904Root>(salesTransaction.AF1BL030904);
                salesTransactionBL030904Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL030904 = xmlToClass.ArrayOfAF1BL030904,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL030904Dto;
        }

        public SalesTransactionBL030904Dto SalesTransactionBL030904FindAF1WithRecIdFilter(int salesTransactionId)
        {
            //AF1BL77Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfAF1BL77 = aF1BL77Dto
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL030904Xml>("usp_SalesTransactionBL030904_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL030904Dto salesTransactionBL030904Dto;
            if (salesTransaction.AF1BL030904 == null)
            {
                salesTransactionBL030904Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL030904Root>(salesTransaction.AF1BL030904);
                salesTransactionBL030904Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL030904 = xmlToClass.ArrayOfAF1BL030904,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL030904Dto;
        }

        public SalesTransactionBL030904Dto SalesTransactionBL030904NewRec(string businessLineCode, int contactId, List<AF1BL030904Dto> aF1BL030904Dto, string createdBy)
        {
            AF1BL030904Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL030904 = aF1BL030904Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL030904Xml>("usp_SalesTransactionBL030904_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL030904Root>(salesTransaction.AF1BL030904);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL030904Dto salesTransactionBL030904Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL030904 = xmlToClass.ArrayOfAF1BL030904
            };
            return salesTransactionBL030904Dto;
        }
        public List<ProductDto> ProductFindAll(bool isActive)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>(bool isActive);
            var productList = DapperDbAccess.Query<ProductDto>("usp_Product_Find_All",
               new
               {
                   @pIsActive = isActive
               },
                cmdType: CommandType.StoredProcedure);
            return productList;
        }

        public List<ProductLookupDto> ProductLookupFindAll()
        {
            var productLokupList = DapperDbAccess.Query<ProductLookupDto>("usp_Product_Lookup_Find_All",
               null,
               cmdType: CommandType.StoredProcedure);
            return productLokupList;
        }

        public ProductFullDto ProductFullNewRec(ProductFullNewDto productFullNewDto, string createdBy)
        {
            return DapperDbAccess.QueryFirst<ProductFullDto>("usp_Product_New_Rec",
                new
                {
                    pBranchId = productFullNewDto.BranchId,
                    pThirdPartyAdminId = productFullNewDto.ThirdPartyAdminId,
                    pInsurerId = productFullNewDto.InsurerId,
                    pCurrencyId = productFullNewDto.CurrencyId,
                    pInsurerProductName = productFullNewDto.InsurerProductName,
                    pCreationDate = productFullNewDto.CreationDate,
                    pActivationDate = productFullNewDto.ActivationDate,
                    pCountryOfResidence = productFullNewDto.CountryOfResidence,
                    pFromCountry = productFullNewDto.FromCountry,
                    pToCountry = productFullNewDto.ToCountry,
                    pPolicyCreationId = productFullNewDto.PolicyCreationId,
                    pSubjectToProrata = productFullNewDto.SubjectToProrata,
                    pStandalone = productFullNewDto.Standalone,
                    pNoWaitingPeriod = productFullNewDto.NoWaitingPeriod,
                    pNewBusinessAgeMinRange = productFullNewDto.NewBusinessAgeMinRange,
                    pNewBusinessAgeMaxRange = productFullNewDto.NewBusinessAgeMaxRange,
                    pNoUnderWriting = productFullNewDto.NoUnderwriting,
                    pChildStandalone = productFullNewDto.ChildStandalone,
                    pRenewalAgeMinRange = productFullNewDto.RenewalAgeMinRange,
                    pRenewalAgeMaxRange = productFullNewDto.RenewalAgeMaxRange,
                    pFamilyRatesCalculation = productFullNewDto.FamilyRatesCalculation,
                    pContinuity = productFullNewDto.Continuity,
                    pGuaranteeRenewability = productFullNewDto.GuaranteeRenewability,
                    pAgeCalculationYear = productFullNewDto.AgeCalculationYear,
                    pAgeCalculationFullDate = productFullNewDto.AgeCalculationFullDate,
                    pCommisionFromGP = productFullNewDto.CommisionFromGP,
                    pVATOnCommision = productFullNewDto.VATOnCommision,
                    pFixedTaxes = productFullNewDto.FixedTaxes,
                    pBuiltInPropTaxes = productFullNewDto.BuiltInPropTaxes,
                    pBuiltInCostOfPolicy = productFullNewDto.BuiltInCostOfPolicy,
                    pInsurerLoading = productFullNewDto.InsurerLoading,
                    pNoClaimBonus = productFullNewDto.NoClaimBonus,
                    pIsActive = productFullNewDto.IsActive,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public ProductFullDto ProductFullFindWithRecIdFilter(int productId)
        {
            var productFull = DapperDbAccess.QueryFirstOrDefault<ProductFullDto>("usp_Product_Find_With_Recd_Filter",
              new
              {                  //check ig code is updated to submit message to client
                  @pRecId = productId
              },
               cmdType: CommandType.StoredProcedure);
            return productFull;
        }

        public ProductFullDto ProductFullUpdRec(ProductFullUpdDto productFullDto, string lastModifiedBy)
        {
            return DapperDbAccess.QueryFirst<ProductFullDto>("usp_Product_Upd_Rec",
                new
                {
                    //check ig code is updated to submit message to client
                    pRecId = productFullDto.RecId,
                    pCurrencyId = productFullDto.CurrencyId,
                    pInsurerProductName = productFullDto.InsurerProductName,
                    pCreationDate = productFullDto.CreationDate,
                    pActivationDate = productFullDto.ActivationDate,

                    pCountryOfResidence = productFullDto.CountryOfResidence,
                    pFromCountry = productFullDto.FromCountry,
                    pToCountry = productFullDto.ToCountry,
                    pPolicyCreationId = productFullDto.PolicyCreationId,
                    pSubjectToProrata = productFullDto.SubjectToProrata,

                    pStandalone = productFullDto.Standalone,
                    pNoWaitingPeriod = productFullDto.NoWaitingPeriod,
                    pNewBusinessAgeMinRange = productFullDto.NewBusinessAgeMinRange,
                    pNewBusinessAgeMaxRange = productFullDto.NewBusinessAgeMaxRange,
                    pNoUnderWriting = productFullDto.NoUnderwriting,

                    pChildStandalone = productFullDto.ChildStandalone,
                    pRenewalAgeMinRange = productFullDto.RenewalAgeMinRange,
                    pRenewalAgeMaxRange = productFullDto.RenewalAgeMaxRange,
                    pFamilyRatesCalculation = productFullDto.FamilyRatesCalculation,
                    pContinuity = productFullDto.Continuity,

                    pGuaranteeRenewability = productFullDto.GuaranteeRenewability,
                    pAgeCalculationYear = productFullDto.AgeCalculationYear,
                    pAgeCalculationFullDate = productFullDto.AgeCalculationFullDate,

                    pCommisionFromGP = productFullDto.CommisionFromGP,
                    pVATOnCommision = productFullDto.VATOnCommision,
                    pFixedTaxes = productFullDto.FixedTaxes,
                    pBuiltInPropTaxes = productFullDto.BuiltInPropTaxes,
                    pBuiltInCostOfPolicy = productFullDto.BuiltInCostOfPolicy,
                    pInsurerLoading = productFullDto.InsurerLoading,
                    pNoClaimBonus = productFullDto.NoClaimBonus,


                    pIsActive = productFullDto.IsActive,
                    pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public ProductFullDto ProductFullUpdIsActiveRec(int productId, bool isActive, string lastModifiedBy)
        {
            return DapperDbAccess.QueryFirst<ProductFullDto>("usp_Product_Upd_IsActive",
                new
                {
                    //check ig code is updated to submit message to client
                    @pProductId = productId,
                    @pIsActive = isActive,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public List<ProductDetailsDto> ProductDetailsFindWithProductIdFilter(int productId)
        {
            var productDetailsList = DapperDbAccess.Query<ProductDetailsDto>("usp_ProductDetailsClassesAmountAndFees_Find_With_ProductId_Filter",
                         new
                         {                  //check ig code is updated to submit message to client
                             @pProductId = productId
                         },
                          cmdType: CommandType.StoredProcedure);
            return productDetailsList;
        }

        public ProductDetailsDto ProductDetailsNewRec(ProductDetailsNewDto productDetailsNewDto, string createdBy)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            return DapperDbAccess.QueryFirst<ProductDetailsDto>("usp_ProductDetailsClassesAmountAndFees_New_Record",
                new
                {
                    @pProductId = productDetailsNewDto.ProductId,
                    @pClassId = productDetailsNewDto.ClassId,
                    @pAmlAmount = productDetailsNewDto.AmlAmount,
                    @pCostPolicy = productDetailsNewDto.CostPolicy,
                    @pAdminFees = productDetailsNewDto.AdminFees,
                    @pFirstYearDiscount = productDetailsNewDto.FirstYearDiscount,
                    @pCommission = productDetailsNewDto.Commision,
                    @pCostPolicyAmount = productDetailsNewDto.CostPolicyAmount,
                    @pFixedTaxAmount = productDetailsNewDto.FixedTaxAmount,
                    @pProperTaxPer = productDetailsNewDto.ProperTaxPer,
                    @pVatPer = productDetailsNewDto.VatPer,
                    @pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public ProductDetailsDto ProductDetailsUpdRec(ProductDetailsUpdDto productDetailsDto, string lastModifiedBy)
        {
            return DapperDbAccess.QueryFirst<ProductDetailsDto>("usp_ProductDetailsClassesAmountAndFees_Upd_Record",
                new
                {
                    //check ig code is updated to submit message to client
                    pRecId = productDetailsDto.RecId,
                    @pAmlAmount = productDetailsDto.AmlAmount,
                    @pCostPolicy = productDetailsDto.CostPolicy,
                    @pAdminFees = productDetailsDto.AdminFees,
                    @pFirstYearDiscount = productDetailsDto.FirstYearDiscount,
                    @pCommission = productDetailsDto.Commision,
                    @pLastModifiedBy = lastModifiedBy,
                    @pClassId = productDetailsDto.ClassId,
                    @pCostPolicyAmount = productDetailsDto.CostPolicyAmount,
                    @pFixedTaxAmount = productDetailsDto.FixedTaxAmount,
                    @pProperTaxPer = productDetailsDto.ProperTaxPer,
                    @pVatPer = productDetailsDto.VatPer,
                    @pIsActive = productDetailsDto.IsActive
                },
                cmdType: CommandType.StoredProcedure);
        }

        public List<ProductDetailsPOIDto> ProductDetailsPOIFindWithProductIdFilter(int productId)
        {
            var productDetailsPOIList = DapperDbAccess.Query<ProductDetailsPOIDto>("usp_ProductDetailsPOI_Find_With_ProductId_Filter",
                                     new
                                     {                  //check ig code is updated to submit message to client
                                         @pProductId = productId
                                     },
                                      cmdType: CommandType.StoredProcedure);
            return productDetailsPOIList;
        }

        public ProductDetailsPOIDto ProductDetailsPOINewRec(ProductDetailsPOINewDto productDetailsPOINewDto, string createdBy)
        {
            return DapperDbAccess.QueryFirst<ProductDetailsPOIDto>("usp_ProductDetailsPOI_New_Record",
                           new
                           {
                               @pProductId = productDetailsPOINewDto.ProductId,
                               @pTechnicalSheet = productDetailsPOINewDto.TechnicalSheet,
                               @pSectionId = productDetailsPOINewDto.SectionId,
                               @pCovered = productDetailsPOINewDto.Covered,
                               @pTerritorialScope = productDetailsPOINewDto.TerritorialScope,
                               @pClassId = productDetailsPOINewDto.ClassId,
                               @pCommissionInsurance = productDetailsPOINewDto.CommissionInsurance,
                               @pLimitAmount = productDetailsPOINewDto.LimitAmount,
                               @pLimitAmountMaxRange = productDetailsPOINewDto.LimitAmountMaxRange,
                               @pNetworkId = productDetailsPOINewDto.NetworkId,
                               @pCreatedBy = createdBy
                           },
                           cmdType: CommandType.StoredProcedure);
        }
        public ProductDetailsPOIDto ProductDetailsPOIUpdRec(ProductDetailsPOIUpdDto productDetailsPIODto, string lastModifiedBy)
        {
            return DapperDbAccess.QueryFirst<ProductDetailsPOIDto>("usp_ProductDetailsPOI_Upd_Record",
                            new
                            {
                                //check ig code is updated to submit message to client
                                pRecId = productDetailsPIODto.RecId,
                                @pTechnicalSheet = productDetailsPIODto.TechnicalSheet,
                                @pSectionId = productDetailsPIODto.SectionId,
                                @pCovered = productDetailsPIODto.Covered,
                                @pTerritorialScope = productDetailsPIODto.TerritorialScope,
                                @pClassId = productDetailsPIODto.ClassId,
                                @pCommissionInsurance = productDetailsPIODto.CommissionInsurance,
                                @pLimitAmount = productDetailsPIODto.LimitAmount,
                                @pLimitAmountMaxRange = productDetailsPIODto.LimitAmountMaxRange,
                                @pNetworkId = productDetailsPIODto.NetworkId,
                                @pLastModifiedBy = lastModifiedBy
                            },
                            cmdType: CommandType.StoredProcedure);
        }

        public BusinessLineDuplicationDto BusinessLineDuplicationNewRec(BusinessLineDuplicationNewDto businessLineDuplicationNewDto, string createdBy)
        {
            return DapperDbAccess.QueryFirst<BusinessLineDuplicationDto>("usp_SalesTransaction_Dup_Rec",
                new
                {
                    @pTicketId = businessLineDuplicationNewDto.TicketId,
                    @pTicketCode = businessLineDuplicationNewDto.TicketCode,
                    @pBusinessLineCode = businessLineDuplicationNewDto.BusinessLineCode,
                    @pSalesTransactionId = businessLineDuplicationNewDto.SalesTransactionId,
                    @pParentSalesTransactionId = businessLineDuplicationNewDto.ParentSalesTransactionId,
                    @pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);
        }

        public TicketDetailsDto TicketDetailsUpdRec(TicketDetailsUpdDto ticketDetailsUpdDto, string lastModifiedBy)
        {
            return DapperDbAccess.QueryFirst<TicketDetailsDto>("usp_TicketDetails_Upd_Rec",
                            new
                            {
                                @pTicketId = ticketDetailsUpdDto.TicketId,
                                @pTicketCode = ticketDetailsUpdDto.TicketCode,
                                @pBusinessLineCode = ticketDetailsUpdDto.BusinessLineCode,
                                @pSalesTransactionId = ticketDetailsUpdDto.SalesTransactionId,
                                @pParentSalesTransactionId = ticketDetailsUpdDto.ParentSalesTransactionId,
                                @pLastModifiedBy = lastModifiedBy
                            },
                            cmdType: CommandType.StoredProcedure);
        }

        public List<CQShortListBL080501Dto> SalesTransactionBL080501FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL080501Dto>("usp_SalesTransactionBL080501_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL080501Dto> SalesTransactionBL080501FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL080501Dto>("usp_SalesTransactionBL080501_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            CQFullBL080501Root _classToXml;
            _classToXml = new()
            {
                ArrayOfCQBL080501 = cqFullList
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
                new
                {
                    @pRecId = salesTransactionId,
                    @pCQ = strXml,
                    @pLastModifiedBy = ""
                },
                cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }
        public List<GlobalLookupDto> GlobalLookupFindAll()
        {
            var lokupList = DapperDbAccess.QueryV2<GlobalLookupDto>("usp_Lookup_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return lokupList;
        }

        public List<PolicyDto> PolicyNewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyDto>("usp_SalesTransactionBL080501_PolicyConsolidation",
                                 new
                                 {
                                     @pSalesTrxId = salesTransactionId,
                                     @pProductId = productId,
                                     @pCombination = combination,
                                     //@pBusinessLineCode = businessLineCode,
                                     @pCreatedBy = createdBy
                                 },
                                  cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PaymentScheduleDto> PolicyPaymentSchedule(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleDto>("usp_SalesTransactionBL080501_PolicyConsolidation_Payment",
                                    new
                                    {
                                        @pSalesTrxId = salesTransactionId,
                                        //@pProductId = productId,
                                        //@pCombination = combination,
                                        @pBusinessLineCode = businessLineCode
                                        //@pCreatedBy = createdBy
                                    },
                                     cmdType: CommandType.StoredProcedure);

            //return payScheduleList;
            //var payScheduleList = new List<PaymentScheduleDto>();
            //payScheduleList.Add(new PaymentScheduleDto
            //{
            //    Amount = 100,
            //    Paid = true,
            //    PaymentDate = DateTime.Now,
            //    PaymentNumber = 1,
            //    Remaining = 50
            //}) ;
            return payScheduleList;
        }

        public SalesTransactionBL080501Dto SalesTransactionBL080501UpdGlobalRec(int recId,
            int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_Global_Rec", new
            {
                @pRecId = recId,
                @pClientId = clientId,
                @pMasterId = masterId,
                @pPolicyId = policyId,
                //@pAF1 = strXml,
                @pLastModifiedBy = lastModifiedBy
            }, cmdType: CommandType.StoredProcedure);

            SalesTransactionBL080501Dto salesTransactionBL080501Dto;
            if (salesTransaction.AF1BL080501 == null)
            {
                salesTransactionBL080501Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL080501Root>(salesTransaction.AF1BL080501);
                salesTransactionBL080501Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL080501 = xmlToClass.ArrayOfAF1BL080501,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL080501Dto;
        }

        public SalesTransactionBL301401Dto SalesTransactionBL301401UpdGlobalRec(int recId,
            int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL301401Xml>("usp_SalesTransactionBL301401_Upd_Global_Rec", new
            {
                @pRecId = recId,
                @pClientId = clientId,
                @pMasterId = masterId,
                @pPolicyId = policyId,
                //@pAF1 = strXml,
                @pLastModifiedBy = lastModifiedBy
            }, cmdType: CommandType.StoredProcedure);

            SalesTransactionBL301401Dto salesTransactionBL301401Dto;
            if (salesTransaction.AF1BL301401 == null)
            {
                salesTransactionBL301401Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL301401Root>(salesTransaction.AF1BL301401);
                salesTransactionBL301401Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL301401 = xmlToClass.ArrayOfAF1BL301401,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL301401Dto;
        }
        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdGlobalRec(int recId, int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>
    ("usp_SalesTransactionBL321110_Upd_Global_Rec",
        new
        {
            @pRecId = recId,
            @pClientId = clientId,
            @pMasterId = masterId,
            @pPolicyId = policyId,
            //@pAF1 = strXml,
            @pLastModifiedBy = lastModifiedBy
        },
    cmdType: CommandType.StoredProcedure);
            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdGlobalRec(int recId, int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>
    ("usp_SalesTransactionBL041312_Upd_Global_Rec",
        new
        {
            @pRecId = recId,
            @pClientId = clientId,
            @pMasterId = masterId,
            @pPolicyId = policyId,
            //@pAF1 = strXml,
            @pLastModifiedBy = lastModifiedBy
        },
    cmdType: CommandType.StoredProcedure);
            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL041312Dto;
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdGlobalRec(int recId, int clientId, int masterId, string lastModifiedBy, string policyId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>
    ("usp_SalesTransactionBL331211_Upd_Global_Rec",
        new
        {
            @pRecId = recId,
            @pClientId = clientId,
            @pMasterId = masterId,
            @pPolicyId = policyId,

            //@pAF1 = strXml,
            @pLastModifiedBy = lastModifiedBy
        },
    cmdType: CommandType.StoredProcedure);
            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL331211Dto;
        }

        public List<PolicyRelatedDocDto> PolicyRelatedDoc(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocDto>
                ("usp_SalesTransactionBL080501_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<ClientCodeDto> ClientCodeFindWithRecid(int recId)
        {
            var clientCodeList = DapperDbAccess.Query<ClientCodeDto>
                 ("usp_Clients_Find_With_RecId_Filter",
                                                 new
                                                 {
                                                     @pRecId = recId
                                                     //@pProductId = productId,
                                                     //@pCombination = combination,
                                                     //@pBusinessLineCode = businessLineCode
                                                     //@pCreatedBy = createdBy
                                                 },
                                                  cmdType: CommandType.StoredProcedure);

            return clientCodeList;
        }

        public PolicyRelatedDocDto PolicyRelatedDocUpdRec(int recId, byte[] attachDocBinary, string attachDocName,
            string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocDto>
                            ("usp_SalesTransactionBL080501_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocDto PolicyRelatedDocNewRec(int salesTransactionId,
            int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType,
            byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocDto>
                                       ("usp_SalesTransactionBL080501_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                       new
                                                                       {
                                                                           @pSalesTransactionId = salesTransactionId,
                                                                           @pTicketId = ticketId,
                                                                           @pParentPolicyId = parentPolicyId,
                                                                           @pPolicyId = policyId,
                                                                           @pBusinessLineCode = businessLineCode,
                                                                           @pDocumentType = documentType,
                                                                           @pAttachDocBinary = attachDocBinary,
                                                                           @pLastModifiedBy = lastModifiedBy,
                                                                           @pAttachDocName = attachDocName,
                                                                           @pAttachDocExt = attachedDocExt

                                                                       },
                                                                        cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public List<PolicyDto> PolicyUpdRec(int salesTransactionId, int TicketId, string ParentPolicyId,
            string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer,
            decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount,
            decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount,
            decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyDto>
                                                   ("usp_SalesTransactionBL080501_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public List<PolicyBL301401Dto> PolicyBL301401NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL301401Dto>("usp_SalesTransactionBL301401_PolicyConsolidation",
                                            new
                                            {
                                                @pSalesTrxId = salesTransactionId,
                                                @pProductId = productId,
                                                @pCombination = combination,
                                                //@pBusinessLineCode = businessLineCode,
                                                @pCreatedBy = createdBy
                                            },
                                             cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PaymentScheduleBL301401Dto> PolicyPaymentScheduleBL301401(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL301401Dto>("usp_SalesTransactionBL301401_PolicyConsolidation_Payment",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            //return payScheduleList;
            //var payScheduleList = new List<PaymentScheduleDto>();
            //payScheduleList.Add(new PaymentScheduleDto
            //{
            //    Amount = 100,
            //    Paid = true,
            //    PaymentDate = DateTime.Now,
            //    PaymentNumber = 1,
            //    Remaining = 50
            //}) ;
            return payScheduleList;
        }

        public List<PolicyRelatedDocBL301401Dto> PolicyRelatedDocBL301401(int salesTransactionId,
            string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL301401Dto>
                            ("usp_SalesTransactionBL301401_PolicyConsolidation_RelatedDoc",
                                                            new
                                                            {
                                                                @pSalesTrxId = salesTransactionId,
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                @pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public PolicyRelatedDocBL301401Dto PolicyRelatedDocBL301401UpdRec(int recId, byte[] attachDocBinary,
            string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL301401Dto>
                                        ("usp_SalesTransactionBL301401_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                                        new
                                                                        {
                                                                            @pRecId = recId,
                                                                            @pAttachDocBinary = attachDocBinary,
                                                                            @pLastModifiedBy = lastModifiedBy,
                                                                            @pAttachDocName = attachDocName,
                                                                            @pAttachDocExt = attachedDocExt
                                                                            //@pProductId = productId,
                                                                            //@pCombination = combination,
                                                                            //@pBusinessLineCode = businessLineCode
                                                                            //@pCreatedBy = createdBy
                                                                        },
                                                                         cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL301401Dto PolicyRelatedDocBL301401NewRec(int salesTransactionId, int ticketId, string parentPolicyId,
            string policyId, string businessLineCode, string documentType, byte[] attachDocBinary,
            string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL301401Dto>
                ("usp_SalesTransactionBL301401_PolicyConsolidation_RelatedDoc_New_Rec",
                new
                {
                    @pSalesTransactionId = salesTransactionId,
                    @pTicketId = ticketId,
                    @pParentPolicyId = parentPolicyId,
                    @pPolicyId = policyId,
                    @pBusinessLineCode = businessLineCode,
                    @pDocumentType = documentType,
                    @pAttachDocBinary = attachDocBinary,
                    @pLastModifiedBy = lastModifiedBy,
                    @pAttachDocName = attachDocName,
                    @pAttachDocExt = attachedDocExt

                },
                cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public List<PolicyBL301401Dto> PolicyBL301401UpdRec(int salesTransactionId, int TicketId,
            string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP,
            decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer,
            decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer,
            decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer,
            decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL301401Dto>
                                                               ("usp_SalesTransactionBL301401_Upd_PolicyConsolidation",
                                                               new
                                                               {
                                                                   @pSalesTrxId = salesTransactionId,
                                                                   @pBusinessLineCode = BusinessLineCode,
                                                                   @pTicketId = TicketId,
                                                                   @ParentPolicyId = ParentPolicyId,
                                                                   @pPolicyId = PolicyId,
                                                                   @pGrossPremiumGP = GrossPremiumGP,
                                                                   @pCommisionFromGP_Per = CommisionFromGPPer,
                                                                   @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                                   @pVATOnCommision_Per = VATOnCommisionPer,
                                                                   @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                                   @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                                   @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                                   @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                                   @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                                   @pInsurerLoading_Per = InsurerLoadingPer,
                                                                   @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                                   @pNetPremium_Amount = NetPremiumAmount,
                                                                   @pLastModifiedBy = lastModifiedBy,
                                                                   @pPolicyNumber = PolicyNumber,
                                                                   @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                                   @pPolicyExpiryDate = PolicyExpiryDate,
                                                                   @pPolicyIssuedDate = PolicyIssuedDate,
                                                                   @pPolicyHolder = PolicyHolder
                                                               },
                                                               cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public List<PolicyBL321110Dto> PolicyBL321110NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL321110Dto>
                ("usp_SalesTransactionBL321110_PolicyConsolidation",
                new
                {
                    @pSalesTrxId = salesTransactionId,
                    @pInsurerCode = InsurerCode,
                    @pThirdPartyAdminCode = ThirdPartyAdminCode,
                    //@pBusinessLineCode = businessLineCode,
                    @pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PaymentScheduleBL321110Dto> PolicyPaymentScheduleBL321110(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL321110Dto>
                ("usp_SalesTransactionBL321110_PolicyConsolidation_Payment",
                new
                {
                    @pSalesTrxId = salesTransactionId,
                    //@pProductId = productId,
                    //@pCombination = combination,
                    @pBusinessLineCode = businessLineCode
                    //@pCreatedBy = createdBy
                },
                                                             cmdType: CommandType.StoredProcedure);

            //return payScheduleList;
            //var payScheduleList = new List<PaymentScheduleDto>();
            //payScheduleList.Add(new PaymentScheduleDto
            //{
            //    Amount = 100,
            //    Paid = true,
            //    PaymentDate = DateTime.Now,
            //    PaymentNumber = 1,
            //    Remaining = 50
            //}) ;
            return payScheduleList;
        }

        public List<PolicyRelatedDocBL321110Dto> PolicyRelatedDocBL321110(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL321110Dto>
                ("usp_SalesTransactionBL321110_PolicyConsolidation_RelatedDoc",
                new
                {
                    @pSalesTrxId = salesTransactionId,
                    //@pProductId = productId,
                    //@pCombination = combination,
                    @pBusinessLineCode = businessLineCode
                    //@pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public PolicyRelatedDocBL321110Dto PolicyRelatedDocBL321110UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL321110Dto>
                ("usp_SalesTransactionBL321110_PolicyConsolidation_RelatedDoc_Upd_Rec",
                new
                {
                    @pRecId = recId,
                    @pAttachDocBinary = attachDocBinary,
                    @pLastModifiedBy = lastModifiedBy,
                    @pAttachDocName = attachDocName,
                    @pAttachDocExt = attachedDocExt
                    //@pProductId = productId,
                    //@pCombination = combination,
                    //@pBusinessLineCode = businessLineCode
                    //@pCreatedBy = createdBy
                },
                                                                                     cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL321110Dto PolicyRelatedDocBL321110NewRec(int salesTransactionId,
            int ticketId, string parentPolicyId, string policyId, string businessLineCode,
            string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt,
            string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL321110Dto>
                            ("usp_SalesTransactionBL321110_PolicyConsolidation_RelatedDoc_New_Rec",
                            new
                            {
                                @pSalesTransactionId = salesTransactionId,
                                @pTicketId = ticketId,
                                @pParentPolicyId = parentPolicyId,
                                @pPolicyId = policyId,
                                @pBusinessLineCode = businessLineCode,
                                @pDocumentType = documentType,
                                @pAttachDocBinary = attachDocBinary,
                                @pLastModifiedBy = lastModifiedBy,
                                @pAttachDocName = attachDocName,
                                @pAttachDocExt = attachedDocExt

                            },
                            cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public List<PolicyBL321110Dto> PolicyBL321110UpdRec(int salesTransactionId, int TicketId,
            string ParentPolicyId, string PolicyId, string BusinessLineCode,
            decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount,
            decimal VATOnCommisionPer, decimal VATOnCommisionAmount,
            decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer,
            decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount,
            decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount,
            string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate,
           DateTime PolicyExpiryDate, DateTime PolicyIssuedDate)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL321110Dto>
                ("usp_SalesTransactionBL321110_Upd_PolicyConsolidation",
                new
                {
                    @pSalesTrxId = salesTransactionId,
                    @pBusinessLineCode = BusinessLineCode,
                    @pTicketId = TicketId,
                    @ParentPolicyId = ParentPolicyId,
                    @pPolicyId = PolicyId,
                    @pGrossPremiumGP = GrossPremiumGP,
                    @pCommisionFromGP_Per = CommisionFromGPPer,
                    @pCommisionFromGP_Amount = CommisionFromGPAmount,
                    @pVATOnCommision_Per = VATOnCommisionPer,
                    @pVATOnCommision_Amount = VATOnCommisionAmount,
                    @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                    @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                    @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                    @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                    @pInsurerLoading_Per = InsurerLoadingPer,
                    @pInsurerLoading_Amount = InsurerLoadingAmount,
                    @pNetPremium_Amount = NetPremiumAmount,
                    @pLastModifiedBy = lastModifiedBy,
                    @pPolicyNumber = PolicyNumber,
                    @pPolicyEffectiveDate = PolicyEffectiveDate,
                    @pPolicyExpiryDate = PolicyExpiryDate,
                    @pPolicyIssuedDate = PolicyIssuedDate
                },
                cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public List<CQFullListBL301401Dto> SalesTransactionBL301401FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL301401Dto>("usp_SalesTransactionBL301401_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            CQFullBL301401Root _classToXml;
            _classToXml = new()
            {
                ArrayOfCQBL301401 = cqFullList
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL301401Xml>("usp_SalesTransactionBL301401_Upd_CQ_Rec",
                new
                {
                    @pRecId = salesTransactionId,
                    @pCQ = strXml,
                    @pLastModifiedBy = ""
                },
                cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }
        public List<CQShortListBL301401Dto> SalesTransactionBL301401FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL301401Dto>("usp_SalesTransactionBL301401_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }
        public List<CQFullListBL321110Dto> SalesTransactionBL321110FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL321110Dto>("usp_SalesTransactionBL321110_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            CQFullBL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfCQBL321110 = cqFullList
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_CQ_Rec",
                new
                {
                    @pRecId = salesTransactionId,
                    @pCQ = strXml,
                    @pLastModifiedBy = ""
                },
                cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }
        public List<CQShortListBL321110Dto> SalesTransactionBL321110FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL321110Dto>("usp_SalesTransactionBL321110_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<PolicyBL010602Dto> PolicyBL010602NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL010602Dto>("usp_SalesTransactionBL010602_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL010602Dto> PolicyBL010602UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL010602Dto>
                                                   ("usp_SalesTransactionBL010602_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public List<PaymentScheduleBL010602Dto> PolicyPaymentScheduleBL010602(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL010602Dto>("usp_SalesTransactionBL010602_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);

            //return payScheduleList;
            //var payScheduleList = new List<PaymentScheduleDto>();
            //payScheduleList.Add(new PaymentScheduleDto
            //{
            //    Amount = 100,
            //    Paid = true,
            //    PaymentDate = DateTime.Now,
            //    PaymentNumber = 1,
            //    Remaining = 50
            //}) ;
            return payScheduleList;
        }

        public List<PolicyRelatedDocBL010602Dto> PolicyRelatedDocBL010602(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL010602Dto>
                ("usp_SalesTransactionBL010602_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public PolicyRelatedDocBL010602Dto PolicyRelatedDocBL010602UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL010602Dto>
                            ("usp_SalesTransactionBL010602_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL010602Dto PolicyRelatedDocBL010602NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL010602Dto>
                                                   ("usp_SalesTransactionBL010602_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806FindAF1WithRecIdFilter(int salesTransactionId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL070806Xml>("usp_SalesTransactionBL070806_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL070806Dto salesTransactionBL070806Dto;
            if (salesTransaction.AF1BL070806 == null)
            {
                salesTransactionBL070806Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL070806Root>(salesTransaction.AF1BL070806);
                salesTransactionBL070806Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL070806 = xmlToClass.ArrayOfAF1BL070806,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL070806Dto;
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL070806Dtco aF1BL070806Dtco, string createdBy)
        {
            AF1BL070806Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL070806 = aF1BL070806Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL070806Xml>("usp_SalesTransactionBL070806_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL070806Root>(salesTransaction.AF1BL070806);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL070806Dto salesTransactionBL070806Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                ClientId = salesTransaction.ClientId,
                MasterId = salesTransaction.MasterId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL070806 = xmlToClass.ArrayOfAF1BL070806
            };
            return salesTransactionBL070806Dto;
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806UpdAF1Rec(int recId, int clientId, int masterId, AF1BL070806Dtco aF1BL070806Dtco, string lastModifiedBy)
        {
            AF1BL070806Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL070806 = aF1BL070806Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL070806Xml>("usp_SalesTransactionBL070806_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pAF1 = strXml,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL070806Dto salesTransactionBL070806Dto;
            if (salesTransaction.AF1BL070806 == null)
            {
                salesTransactionBL070806Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL070806Root>(salesTransaction.AF1BL070806);
                salesTransactionBL070806Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL070806 = xmlToClass.ArrayOfAF1BL070806,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL070806Dto;
        }

        public List<dynamic> SalesTransactionBL070806FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL070806FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader070806Dto> SalesTransactionBL070806FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader070806Dto>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory070806Dto> SalesTransactionBL070806FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory070806Dto>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL070806Dto> SalesTransactionBL070806FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL070806Dto>("usp_SalesTransactionBL070806_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL070806Dto> SalesTransactionBL070806FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL070806Dto>("usp_SalesTransactionBL070806_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL070806FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<PolicyBL070806Dto> PolicyBL070806NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL070806Dto>("usp_SalesTransactionBL070806_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL070806Dto> PolicyBL070806UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL070806Dto>
                                                   ("usp_SalesTransactionBL070806_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public List<PaymentScheduleBL070806Dto> PolicyPaymentScheduleBL070806(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL070806Dto>("usp_SalesTransactionBL070806_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }

        public List<PolicyRelatedDocBL070806Dto> PolicyRelatedDocBL070806(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL070806Dto>
                ("usp_SalesTransactionBL070806_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public PolicyRelatedDocBL070806Dto PolicyRelatedDocBL070806UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL070806Dto>
                            ("usp_SalesTransactionBL070806_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL070806Dto PolicyRelatedDocBL070806NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL070806Dto>
                                                   ("usp_SalesTransactionBL070806_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }


        public SalesTransactionBL090703Dto SalesTransactionBL090703FindAF1WithRecIdFilter(int salesTransactionId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL090703Xml>("usp_SalesTransactionBL090703_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL090703Dto salesTransactionBL090703Dto;
            if (salesTransaction.AF1BL090703 == null)
            {
                salesTransactionBL090703Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL090703Root>(salesTransaction.AF1BL090703);
                salesTransactionBL090703Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL090703 = xmlToClass.ArrayOfAF1BL090703,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL090703Dto;
        }

        public SalesTransactionBL090703Dto SalesTransactionBL090703NewRec(string businessLineCode, int contactId, int clientId, int masterId, AF1BL090703Dtco aF1BL090703Dtco, string createdBy)
        {
            AF1BL090703Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL090703 = aF1BL090703Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL090703Xml>("usp_SalesTransactionBL090703_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL090703Root>(salesTransaction.AF1BL090703);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL090703Dto salesTransactionBL090703Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                ClientId = salesTransaction.ClientId,
                MasterId = salesTransaction.MasterId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL090703 = xmlToClass.ArrayOfAF1BL090703
            };
            return salesTransactionBL090703Dto;
        }

        public SalesTransactionBL090703Dto SalesTransactionBL090703UpdAF1Rec(int recId, int clientId, int masterId, AF1BL090703Dtco aF1BL090703Dtco, string lastModifiedBy)
        {
            AF1BL090703Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL090703 = aF1BL090703Dtco
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL090703Xml>("usp_SalesTransactionBL090703_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL090703Dto salesTransactionBL090703Dto;
            if (salesTransaction.AF1BL090703 == null)
            {
                salesTransactionBL090703Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL090703Root>(salesTransaction.AF1BL090703);
                salesTransactionBL090703Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL090703 = xmlToClass.ArrayOfAF1BL090703,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL090703Dto;
        }

        public List<dynamic> SalesTransactionBL090703FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL090703_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL090703FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL090703_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader090703Dto> SalesTransactionBL090703FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader090703Dto>("usp_SalesTransactionBL090703_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory090703Dto> SalesTransactionBL090703FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory090703Dto>("usp_SalesTransactionBL090703_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL090703Dto> SalesTransactionBL090703FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL090703Dto>("usp_SalesTransactionBL090703_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL090703Dto> SalesTransactionBL090703FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL090703Dto>("usp_SalesTransactionBL090703_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL090703FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL090703_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<PolicyBL090703Dto> PolicyBL090703NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL090703Dto>("usp_SalesTransactionBL090703_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL090703Dto> PolicyBL090703UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL090703Dto>
                                                   ("usp_SalesTransactionBL090703_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public List<PaymentScheduleBL090703Dto> PolicyPaymentScheduleBL090703(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL090703Dto>("usp_SalesTransactionBL090703_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }

        public List<PolicyRelatedDocBL090703Dto> PolicyRelatedDocBL090703(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL090703Dto>
                ("usp_SalesTransactionBL090703_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public PolicyRelatedDocBL090703Dto PolicyRelatedDocBL090703UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL090703Dto>
                            ("usp_SalesTransactionBL090703_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL090703Dto PolicyRelatedDocBL090703NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL090703Dto>
                                                   ("usp_SalesTransactionBL090703_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public SalesTransactionBL061005Dto SalesTransactionBL061005FindAF1WithRecIdFilter(int salesTransactionId)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL061005Xml>("usp_SalesTransactionBL061005_Find_AF1_With_RecId_Filter",
                new
                {
                    pSalesTransactionId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL061005Dto salesTransactionBL061005Dto;
            if (salesTransaction.AF1BL061005 == null)
            {
                salesTransactionBL061005Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL061005Root>(salesTransaction.AF1BL061005);
                salesTransactionBL061005Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL061005 = xmlToClass.ArrayOfAF1BL061005,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL061005Dto;
        }

        public SalesTransactionBL061005Dto SalesTransactionBL061005NewRec(string businessLineCode, int contactId, int clientId, int masterId, List<AF1BL061005Dto> aF1BL061005Dto, string createdBy)
        {
            AF1BL061005Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL061005 = aF1BL061005Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL061005Xml>("usp_SalesTransactionBL061005_New_Rec",
                new
                {
                    @pBusinessLineCode = businessLineCode,
                    @pContactId = contactId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    pCreatedBy = createdBy
                },
                cmdType: CommandType.StoredProcedure);

            var xmlToClass = XmlConverter.ToClass<AF1BL061005Root>(salesTransaction.AF1BL061005);
            //xmlToClass.AF1BL77= 
            SalesTransactionBL061005Dto salesTransactionBL061005Dto = new()
            {
                RecId = salesTransaction.RecId,
                BusinessLineCode = salesTransaction.BusinessLineCode,
                ContactId = salesTransaction.ContactId,
                //ClientId = salesTransaction.ClientId,
                //MasterId = salesTransaction.MasterId,
                TransactionDate = salesTransaction.TransactionDate,
                ProductId = salesTransaction.ProductId,
                PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                PolicyNumber = salesTransaction.PolicyNumber,
                AF1BL061005 = xmlToClass.ArrayOfAF1BL061005
            };
            return salesTransactionBL061005Dto;
        }

        public SalesTransactionBL061005Dto SalesTransactionBL061005UpdAF1Rec(int recId, int clientId, int masterId, List<AF1BL061005Dto> aF1BL061005Dto, string lastModifiedBy)
        {
            AF1BL061005Root _classToXml;
            _classToXml = new()
            {
                ArrayOfAF1BL061005 = aF1BL061005Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL061005Xml>("usp_SalesTransactionBL061005_Upd_AF1_Rec",
                new
                {
                    @pRecId = recId,
                    @pClientId = clientId,
                    @pMasterId = masterId,
                    @pAF1 = strXml,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
            SalesTransactionBL061005Dto salesTransactionBL061005Dto;
            if (salesTransaction.AF1BL061005 == null)
            {
                salesTransactionBL061005Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL061005Root>(salesTransaction.AF1BL061005);
                salesTransactionBL061005Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    //ClientId = salesTransaction.ClientId,
                    //MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL061005 = xmlToClass.ArrayOfAF1BL061005,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL061005Dto;
        }

        public List<dynamic> SalesTransactionBL061005FindCQBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL061005_CQ_Calculation_Pivot_Benefits",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL061005FindCQBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL061005_CQ_Calculation_Pivot_payment",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<CQHeader061005Dto> SalesTransactionBL061005FindCQHeaderWithRecIdFilter(int salesTransactionId)
        {
            var cqHeaderList = DapperDbAccess.Query<CQHeader061005Dto>("usp_SalesTransactionBL061005_CQ_Calculation_Pivot_Header",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqHeaderList;
        }

        public List<CQCategory061005Dto> SalesTransactionBL061005FindCQCategoryWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryList = DapperDbAccess.Query<CQCategory061005Dto>("usp_SalesTransactionBL061005_CQ_Calculation_Pivot_Categories",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryList;
        }

        public List<CQDetailsBL061005Dto> SalesTransactionBL061005FindCQDetailsWithRecIdFilter(int salesTransactionId)
        {
            var cqDetailsList = DapperDbAccess.Query<CQDetailsBL061005Dto>("usp_SalesTransactionBL061005_CQ_Calculation_Details",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqDetailsList;
        }

        public List<CQSummaryBL061005Dto> SalesTransactionBL061005FindCQSummaryWithRecIdFilter(int salesTransactionId)
        {
            var cqSummaryList = DapperDbAccess.Query<CQSummaryBL061005Dto>("usp_SalesTransactionBL061005_CQ_Calculation_Summary",
             new
             {
                 pSalesTrx = salesTransactionId
             },
              cmdType: CommandType.StoredProcedure);

            return cqSummaryList;
        }

        public List<dynamic> SalesTransactionBL061005FindCQPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL061005_CQ_Calculation_Pivot",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<CQShortListBL070806Dto> SalesTransactionBL070806FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL070806Dto>("usp_SalesTransactionBL070806_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL070806Dto> SalesTransactionBL070806FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL070806Dto>("usp_SalesTransactionBL070806_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL090703Dto> SalesTransactionBL090703FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL090703Dto>("usp_SalesTransactionBL090703_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL090703Dto> SalesTransactionBL090703FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL090703Dto>("usp_SalesTransactionBL090703_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL010602Dto> SalesTransactionBL010602FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL010602Dto>("usp_SalesTransactionBL010602_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL010602Dto> SalesTransactionBL010602FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL010602Dto>("usp_SalesTransactionBL010602_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }
        public List<CQShortListBL021502Dto> SalesTransactionBL021502FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL021502Dto>("usp_SalesTransactionBL021502_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL021502Dto> SalesTransactionBL021502FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL021502Dto>("usp_SalesTransactionBL021502_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            CQFullBL021502Root _classToXml;
            _classToXml = new()
            {
                ArrayOfCQBL021502 = cqFullList
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL021502Xml>("usp_SalesTransactionBL021502_Upd_CQ_Rec",
                new
                {
                    @pRecId = salesTransactionId,
                    @pCQ = strXml,
                    @pLastModifiedBy = ""
                },
                cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL281609Dto> SalesTransactionBL281609FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL281609Dto>("usp_SalesTransactionBL281609_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL281609Dto> SalesTransactionBL281609FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL281609Dto>("usp_SalesTransactionBL281609_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL291908Dto> SalesTransactionBL291908FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL291908Dto>("usp_SalesTransactionBL291908_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL291908Dto> SalesTransactionBL291908FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL291908Dto>("usp_SalesTransactionBL291908_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL331211Dto> SalesTransactionBL331211FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL331211Dto>("usp_SalesTransactionBL331211_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL331211Dto> SalesTransactionBL331211FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL331211Dto>("usp_SalesTransactionBL331211_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL311703Dto> SalesTransactionBL311703FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL311703Dto>("usp_SalesTransactionBL311703_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL311703Dto> SalesTransactionBL311703FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL311703Dto>("usp_SalesTransactionBL311703_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL030904Dto> SalesTransactionBL030904FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL030904Dto>("usp_SalesTransactionBL030904_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL030904Dto> SalesTransactionBL030904FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL030904Dto>("usp_SalesTransactionBL030904_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL041312Dto> SalesTransactionBL041312FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL041312Dto>("usp_SalesTransactionBL041312_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL041312Dto> SalesTransactionBL041312FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL041312Dto>("usp_SalesTransactionBL041312_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL051807Dto> SalesTransactionBL051807FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL051807Dto>("usp_SalesTransactionBL051807_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL051807Dto> SalesTransactionBL051807FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL051807Dto>("usp_SalesTransactionBL051807_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public List<CQShortListBL061005Dto> SalesTransactionBL061005FindCQShortListWithRecIdFilter(int salesTransactionId)
        {
            var cqShortList = DapperDbAccess.Query<CQShortListBL061005Dto>("usp_SalesTransactionBL061005_CQ_Calculation_ShortList",
                         new
                         {
                             pSalesTrx = salesTransactionId
                         },
                          cmdType: CommandType.StoredProcedure);

            return cqShortList;
        }

        public List<CQFullListBL061005Dto> SalesTransactionBL061005FindCQFullListWithRecIdFilter(int salesTransactionId)
        {
            var cqFullList = DapperDbAccess.Query<CQFullListBL061005Dto>("usp_SalesTransactionBL061005_CQ_Calculation_FullList",
                                  new
                                  {
                                      pSalesTrx = salesTransactionId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            //CQFullBL080501Root _classToXml;
            //_classToXml = new()
            //{
            //    ArrayOfCQBL080501 = cqFullList
            //};
            //var strXml = XmlConverter.FromClass(_classToXml);

            //var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL080501Xml>("usp_SalesTransactionBL080501_Upd_CQ_Rec",
            //    new
            //    {
            //        @pRecId = salesTransactionId,
            //        @pCQ = strXml,
            //        @pLastModifiedBy = ""
            //    },
            //    cmdType: CommandType.StoredProcedure);

            return cqFullList;
        }

        public BusinessLineDetailsProductDto BusinessLineDetailsProductFindWithProductIdFilter(int productId)
        {
            var res = DapperDbAccess.QueryFirstOrDefault<BusinessLineDetailsProductDto>("usp_BusinessLineDetailsProduct_Find_With_ProductId_Filter",
                                  new
                                  {
                                      @pProductId = productId
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return res;
        }

        public List<ProductPriceListDto> ProductPriceListFindWithProductIdFilter(int productId)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>(bool isActive);
            var productList = DapperDbAccess.Query<ProductPriceListDto>("usp_ProductDetailsPOIPriceList_Find_With_ProductId_Filter",
               new
               {
                   @pProductId = productId
               },
                cmdType: CommandType.StoredProcedure);
            return productList;
        }

        public List<ProductBenefitsDto> ProductBenefitsFindWithProductIdFilter(int productId)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>(bool isActive);
            var productList = DapperDbAccess.Query<ProductBenefitsDto>("usp_ProductDetailsPOIBenefits_Find_With_ProductId_Filter",
               new
               {
                   @pProductId = productId
               },
                cmdType: CommandType.StoredProcedure);
            return productList;
        }

        public List<ProductBenefitsTemplateDto> ProductBenefitsTemplateFindAllFilter()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>(bool isActive);
            var productBenefitTemplateList = DapperDbAccess.Query<ProductBenefitsTemplateDto>("usp_ProductBenefitsTemplate_Find_All",
               null,
               cmdType: CommandType.StoredProcedure);
            return productBenefitTemplateList;
        }

        public List<ProductBenefitsDto> ProductBenefitsNewRec(List<ProductBenefitsNewDto> productBenefits, string createdBy)
        {
            DataTable dtProductBenefits = new();
            dtProductBenefits.Columns.Add("ProductId", typeof(int));
            dtProductBenefits.Columns.Add("ClassCode", typeof(string));
            dtProductBenefits.Columns.Add("BenefitNumber", typeof(int));
            dtProductBenefits.Columns.Add("BenefitName", typeof(string));
            dtProductBenefits.Columns.Add("BenefitAnswer", typeof(string));
            dtProductBenefits.Columns.Add("LifeTime", typeof(string));
            dtProductBenefits.Columns.Add("Excess", typeof(string));


            foreach (var item in productBenefits)
            {
                DataRow dataRow = dtProductBenefits.NewRow();
                dataRow["ProductId"] = item.ProductId;
                dataRow["ClassCode"] = item.ClassCode;
                dataRow["BenefitNumber"] = item.BenefitNumber;
                dataRow["BenefitName"] = item.BenefitName;
                dataRow["BenefitAnswer"] = item.BenefitAnswer;
                dataRow["LifeTime"] = item.LifeTime;
                dataRow["Excess"] = item.Excess;
                dtProductBenefits.Rows.Add(dataRow);
            }

            //var param = new DynamicParameters();
            //param.Add("pFirstName", contactNewDto.FirstName);
            //param.Add("pLastName", contactNewDto.LastName);
            //param.Add("pMiddleName", contactNewDto.MiddleName);
            //param.Add("pYOB", contactNewDto.YOB);
            //param.Add("pGenderCode", contactNewDto.GenderCode);
            //param.Add("pRegistrationNo", contactNewDto.RegistrationNo);
            ////param.Add("pLocalCode", contactNewDto.LocalCode);
            //param.Add("pRegionCode", contactNewDto.RegionCode);
            //param.Add("pJob", contactNewDto.Job);
            //param.Add("pCompany", contactNewDto.Company);
            //param.Add("pcreatedBy", createdBy);
            //param.Add("tvpContactChannel", SqlMapper.AsTableValuedParameter(dtContactChannel, "dbo.tvp_ContactChannel_New_Rec"));

            return DapperDbAccess.Query<ProductBenefitsDto>("usp_ProductDetailsPOIBenefits_New_Rec1",
                           new
                           {
                               @tvpProductBenefits = dtProductBenefits,
                               @pProductId = productBenefits[0].ProductId,
                               pCreatedBy = createdBy
                           },
                           cmdType: CommandType.StoredProcedure);
        }

        public List<ProductCombinationDto> ProductCombinationFindWithProductIdFilter(int productId)
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>(bool isActive);
            var productList = DapperDbAccess.Query<ProductCombinationDto>("usp_ProductDetailsPOICombination_Find_With_ProductId_Filter",
               new
               {
                   @pProductId = productId
               },
                cmdType: CommandType.StoredProcedure);
            return productList;
        }

        public ProductCombinationDto ProductCombinationDeacRec(int recId)
        {
            var res = DapperDbAccess.QueryFirst<ProductCombinationDto>("usp_ProductDetailsPOICombination_Deac_RecId",
                           new
                           {
                               @pRecId = recId
                           },
                            cmdType: CommandType.StoredProcedure);
            return res;
        }
        public ProductCombinationDto ProductCombinationNewRec(ProductCombinationNewDto productCombinationNewDto, string createdBy)
        {
            string connString = string.Empty;
            connString = Global.ConnString;
            var res = new ProductCombinationDto();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("usp_ProductDetailsPOICombination_New_Rec",
                    new
                    {
                        @pProductId = productCombinationNewDto.ProductId,
                        @pTechnicalSheet1 = productCombinationNewDto.TechnicalSheet1 == null || productCombinationNewDto.TechnicalSheet1 == 0 ? null : productCombinationNewDto.TechnicalSheet1,
                        @pTechnicalSheet2 = productCombinationNewDto.TechnicalSheet2 == null || productCombinationNewDto.TechnicalSheet2 == 0 ? null : productCombinationNewDto.TechnicalSheet2,
                        @pTechnicalSheet3 = productCombinationNewDto.TechnicalSheet3 == null || productCombinationNewDto.TechnicalSheet3 == 0 ? null : productCombinationNewDto.TechnicalSheet3,
                        @pTechnicalSheet4 = productCombinationNewDto.TechnicalSheet4 == null || productCombinationNewDto.TechnicalSheet4 == 0 ? null : productCombinationNewDto.TechnicalSheet4,
                        @pTechnicalSheet5 = productCombinationNewDto.TechnicalSheet5 == null || productCombinationNewDto.TechnicalSheet5 == 0 ? null : productCombinationNewDto.TechnicalSheet5,
                        @pTechnicalSheet6 = productCombinationNewDto.TechnicalSheet6 == null || productCombinationNewDto.TechnicalSheet6 == 0 ? null : productCombinationNewDto.TechnicalSheet6,
                        @pTechnicalSheet7 = productCombinationNewDto.TechnicalSheet7 == null || productCombinationNewDto.TechnicalSheet7 == 0 ? null : productCombinationNewDto.TechnicalSheet7,
                        @pTechnicalSheet8 = productCombinationNewDto.TechnicalSheet8 == null || productCombinationNewDto.TechnicalSheet8 == 0 ? null : productCombinationNewDto.TechnicalSheet8,
                        @pCreatedBy = createdBy,
                    }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    // Read from the first result set
                    var result1 = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel1 with the appropriate class

                    // Read from the second result set
                    res = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel2 with the appropriate class

                    // Process or use result1 and result2 as needed
                }
            }
            return res;
        }

        public ProductCombinationDto ProductCombinationUpdRec(ProductCombinationUpdDto productCombinationUpdDto, string lastModifiedBy)
        {
            string connString = string.Empty;
            connString = Global.ConnString;
            var res = new ProductCombinationDto();
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple("usp_ProductDetailsPOICombination_Upd_Rec",
                    new
                    {
                        @pRecId = productCombinationUpdDto.RecId,
                        @pProductId = productCombinationUpdDto.ProductId,
                        @pTechnicalSheet1 = productCombinationUpdDto.TechnicalSheet1 == null || productCombinationUpdDto.TechnicalSheet1 == 0 ? null : productCombinationUpdDto.TechnicalSheet1,
                        @pTechnicalSheet2 = productCombinationUpdDto.TechnicalSheet2 == null || productCombinationUpdDto.TechnicalSheet2 == 0 ? null : productCombinationUpdDto.TechnicalSheet2,
                        @pTechnicalSheet3 = productCombinationUpdDto.TechnicalSheet3 == null || productCombinationUpdDto.TechnicalSheet3 == 0 ? null : productCombinationUpdDto.TechnicalSheet3,
                        @pTechnicalSheet4 = productCombinationUpdDto.TechnicalSheet4 == null || productCombinationUpdDto.TechnicalSheet4 == 0 ? null : productCombinationUpdDto.TechnicalSheet4,
                        @pTechnicalSheet5 = productCombinationUpdDto.TechnicalSheet5 == null || productCombinationUpdDto.TechnicalSheet5 == 0 ? null : productCombinationUpdDto.TechnicalSheet5,
                        @pTechnicalSheet6 = productCombinationUpdDto.TechnicalSheet6 == null || productCombinationUpdDto.TechnicalSheet6 == 0 ? null : productCombinationUpdDto.TechnicalSheet6,
                        @pTechnicalSheet7 = productCombinationUpdDto.TechnicalSheet7 == null || productCombinationUpdDto.TechnicalSheet7 == 0 ? null : productCombinationUpdDto.TechnicalSheet7,
                        @pTechnicalSheet8 = productCombinationUpdDto.TechnicalSheet8 == null || productCombinationUpdDto.TechnicalSheet8 == 0 ? null : productCombinationUpdDto.TechnicalSheet8,
                        @pLastModifiedBy = lastModifiedBy,
                    }, commandType: System.Data.CommandType.StoredProcedure))
                {
                    // Read from the first result set
                    var result1 = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel1 with the appropriate class

                    // Read from the second result set
                    res = multi.Read<ProductCombinationDto>().FirstOrDefault(); // Replace YourModel2 with the appropriate class

                    // Process or use result1 and result2 as needed
                }
            }
            return res;
        }
        public List<ProductPriceListDto> ProductPriceListNewRec(List<ProductPriceListNewDto> productPriceList, string createdBy)
        {
            DataTable dtProductPriceList = new();
            dtProductPriceList.Columns.Add("ProductId", typeof(int));
            dtProductPriceList.Columns.Add("TechnicalSheet", typeof(int));
            dtProductPriceList.Columns.Add("FamilyCountMinRange", typeof(int));
            dtProductPriceList.Columns.Add("FamilyCountMaxRange", typeof(int));
            dtProductPriceList.Columns.Add("Period", typeof(string));
            dtProductPriceList.Columns.Add("DaysCountMinRange", typeof(int));
            dtProductPriceList.Columns.Add("DaysCountMaxRange", typeof(int));
            dtProductPriceList.Columns.Add("Dependency", typeof(string));
            dtProductPriceList.Columns.Add("Gender", typeof(string));
            dtProductPriceList.Columns.Add("MaritalStatus", typeof(string));
            dtProductPriceList.Columns.Add("CostSharing", typeof(string));
            dtProductPriceList.Columns.Add("AgeMinRange", typeof(int));
            dtProductPriceList.Columns.Add("AgeMaxRange", typeof(int));
            dtProductPriceList.Columns.Add("Rate", typeof(decimal));
            dtProductPriceList.Columns.Add("Premium", typeof(decimal));
            dtProductPriceList.Columns.Add("Pa_Premium", typeof(decimal));
            dtProductPriceList.Columns.Add("NbrChildFree", typeof(int));

            foreach (var item in productPriceList)
            {
                DataRow dataRow = dtProductPriceList.NewRow();
                dataRow["ProductId"] = item.ProductId;
                dataRow["TechnicalSheet"] = item.TechnicalSheet == null || item.TechnicalSheet == 0 ? DBNull.Value : item.TechnicalSheet;
                dataRow["FamilyCountMinRange"] = item.FamilyCountMinRange == null || item.FamilyCountMinRange == 0 ? DBNull.Value : item.FamilyCountMinRange;
                dataRow["FamilyCountMaxRange"] = item.FamilyCountMaxRange == null || item.FamilyCountMaxRange == 0 ? DBNull.Value : item.FamilyCountMaxRange;
                dataRow["Period"] = item.Period == null ? DBNull.Value : item.Period;
                dataRow["DaysCountMinRange"] = item.DaysCountMinRange == null || item.DaysCountMinRange == 0 ? DBNull.Value : item.DaysCountMinRange;
                dataRow["DaysCountMaxRange"] = item.DaysCountMaxRange == null || item.DaysCountMaxRange == 0 ? DBNull.Value : item.DaysCountMaxRange;
                dataRow["Dependency"] = item.Dependency == null ? DBNull.Value : item.Dependency;
                dataRow["Gender"] = item.Gender == null ? DBNull.Value : item.Gender;
                dataRow["MaritalStatus"] = item.MaritalStatus == null ? DBNull.Value : item.MaritalStatus;
                dataRow["CostSharing"] = item.CostSharing == null ? DBNull.Value : item.CostSharing;
                dataRow["AgeMinRange"] = item.AgeMinRange == null || item.AgeMinRange == 0 ? DBNull.Value : item.AgeMinRange;
                dataRow["AgeMaxRange"] = item.AgeMaxRange == null || item.AgeMaxRange == 0 ? DBNull.Value : item.AgeMaxRange;
                dataRow["Rate"] = item.Rate == null || item.Rate == 0 ? DBNull.Value : item.Rate;
                dataRow["Premium"] = item.Premium == null || item.Premium == 0 ? DBNull.Value : item.Premium;
                dataRow["Pa_Premium"] = item.PaPremiium == null || item.PaPremiium == 0 ? DBNull.Value : item.PaPremiium;
                dataRow["NbrChildFree"] = item.NbrChildFree == null ? 0 : item.NbrChildFree;
                dtProductPriceList.Rows.Add(dataRow);
            }

            return DapperDbAccess.Query<ProductPriceListDto>("usp_ProductDetailsPOIPriceList_New_Rec",
                           new
                           {
                               @tvpProductPriceList = dtProductPriceList,
                               @pProductId = productPriceList[0].ProductId,
                               pCreatedBy = createdBy
                           },
                           cmdType: CommandType.StoredProcedure);
        }

        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPricesNewRec(List<SalesTransactionDetailsPricesNewDto> salesTransactionBL321110DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, bool AgeCalculationFullDate, bool AgeCalculationYear, DateTime AgeCalculationStartDate, string createdBy)
        {
            DataTable dtProductPriceList = new();
            dtProductPriceList.Columns.Add("SalesTrxDetailsId", typeof(int));
            dtProductPriceList.Columns.Add("SectionName", typeof(string));
            dtProductPriceList.Columns.Add("Category", typeof(string));
            dtProductPriceList.Columns.Add("Dependency", typeof(string));
            dtProductPriceList.Columns.Add("Gender", typeof(string));
            dtProductPriceList.Columns.Add("MaritalStatus", typeof(string));
            dtProductPriceList.Columns.Add("CostSharing", typeof(string));
            dtProductPriceList.Columns.Add("AgeMinRange", typeof(int));
            dtProductPriceList.Columns.Add("AgeMaxRange", typeof(int));
            dtProductPriceList.Columns.Add("Premium", typeof(decimal));


            foreach (var item in salesTransactionBL321110DetailsPrices)
            {
                DataRow dataRow = dtProductPriceList.NewRow();
                dataRow["SalesTrxDetailsId"] = item.SalesTrxDetailsId;
                dataRow["SectionName"] = item.SectionName == null ? DBNull.Value : item.SectionName;
                dataRow["Category"] = item.Category == null ? DBNull.Value : item.Category;
                dataRow["Dependency"] = item.Dependency == null ? DBNull.Value : item.Dependency;
                dataRow["Gender"] = item.Gender == null ? DBNull.Value : item.Gender;
                dataRow["MaritalStatus"] = item.MaritalStatus == null ? DBNull.Value : item.MaritalStatus;
                dataRow["CostSharing"] = item.CostSharing == null ? DBNull.Value : item.CostSharing;
                dataRow["AgeMinRange"] = item.AgeMinRange;
                dataRow["AgeMaxRange"] = item.AgeMaxRange;
                dataRow["Premium"] = item.Premium;
                dtProductPriceList.Rows.Add(dataRow);
            }

            return DapperDbAccess.Query<SalesTransactionBL321110DetailsPriceDto>("usp_SalesTransactionBL321110DetailsPrices_New_Rec",
                           new
                           {
                               @tvpSalesTransactionDetailsPriceList = dtProductPriceList,
                               @pSalesTrxDetailsId = salesTransactionBL321110DetailsPrices[0].SalesTrxDetailsId,
                               @pCommisinOnGPPer = commisinOnGPPer,
                               @pAdminFeesAmount = adminFeesAmount,
                               @pCostOfPolicyPer = costOfPolicyPer,
                               @pCostOfPolicyAmount = costOfPolicyAmount,
                               @pFixedTaxesAmount = fixedTaxesAmount,
                               @pFixedTaxesPer = fixedTaxesPer,
                               @pVATPer = vATPer,
                               @pAgeCalculationFullDate = AgeCalculationFullDate,
                               @pAgeCalculationYear = AgeCalculationYear,
                               @pAgeCalculationStartDate = AgeCalculationStartDate,
                               pCreatedBy = createdBy
                           },
                           cmdType: CommandType.StoredProcedure);
        }

        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPricesNewRec(List<SalesTransactionBL041312DetailsPricesNewDto> salesTransactionBL041312DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, string createdBy)
        {
            DataTable dtProductPriceList = new();
            dtProductPriceList.Columns.Add("SalesTrxDetailsId", typeof(int));
            dtProductPriceList.Columns.Add("SectionName", typeof(string));
            dtProductPriceList.Columns.Add("Category", typeof(string));
            dtProductPriceList.Columns.Add("Dependency", typeof(string));
            dtProductPriceList.Columns.Add("Gender", typeof(string));
            dtProductPriceList.Columns.Add("MaritalStatus", typeof(string));
            dtProductPriceList.Columns.Add("Limit", typeof(string));
            dtProductPriceList.Columns.Add("AgeMinRange", typeof(int));
            dtProductPriceList.Columns.Add("AgeMaxRange", typeof(int));
            dtProductPriceList.Columns.Add("Premium", typeof(decimal));
            dtProductPriceList.Columns.Add("Rate", typeof(decimal));


            foreach (var item in salesTransactionBL041312DetailsPrices)
            {
                DataRow dataRow = dtProductPriceList.NewRow();
                dataRow["SalesTrxDetailsId"] = item.SalesTrxDetailsId;
                dataRow["SectionName"] = item.SectionName == null ? DBNull.Value : item.SectionName;
                dataRow["Category"] = item.Category == null ? DBNull.Value : item.Category;
                dataRow["Dependency"] = item.Dependency == null ? DBNull.Value : item.Dependency;
                dataRow["Gender"] = item.Gender == null ? DBNull.Value : item.Gender;
                dataRow["MaritalStatus"] = item.MaritalStatus == null ? DBNull.Value : item.MaritalStatus;
                dataRow["Limit"] = item.Limit == null ? DBNull.Value : item.Limit;
                dataRow["AgeMinRange"] = item.AgeMinRange;
                dataRow["AgeMaxRange"] = item.AgeMaxRange;
                dataRow["Premium"] = item.Premium;
                dataRow["Rate"] = item.Rate;
                dtProductPriceList.Rows.Add(dataRow);
            }

            return DapperDbAccess.Query<SalesTransactionBL041312DetailsPriceDto>("usp_SalesTransactionBL041312DetailsPrices_New_Rec",
                           new
                           {
                               @tvpSalesTransactionDetailsPriceList = dtProductPriceList,
                               @pSalesTrxDetailsId = salesTransactionBL041312DetailsPrices[0].SalesTrxDetailsId,
                               @pCommisinOnGPPer = commisinOnGPPer,
                               @pAdminFeesAmount = adminFeesAmount,
                               @pCostOfPolicyPer = costOfPolicyPer,
                               @pCostOfPolicyAmount = costOfPolicyAmount,
                               @pFixedTaxesAmount = fixedTaxesAmount,
                               @pFixedTaxesPer = fixedTaxesPer,
                               @pVATPer = vATPer,
                               pCreatedBy = createdBy
                           },
                           cmdType: CommandType.StoredProcedure);
        }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPricesNewRec(List<SalesTransactionBL331211DetailsPricesNewDto> salesTransactionBL331211DetailsPrices, decimal commisinOnGPPer, decimal adminFeesAmount, decimal costOfPolicyPer, decimal costOfPolicyAmount, decimal fixedTaxesAmount, decimal fixedTaxesPer, decimal vATPer, string createdBy)
        {
            DataTable dtProductPriceList = new();
            dtProductPriceList.Columns.Add("SalesTrxDetailsId", typeof(int));
            dtProductPriceList.Columns.Add("SectionName", typeof(string));
            dtProductPriceList.Columns.Add("Category", typeof(string));
            dtProductPriceList.Columns.Add("Dependency", typeof(string));
            dtProductPriceList.Columns.Add("Gender", typeof(string));
            dtProductPriceList.Columns.Add("MaritalStatus", typeof(string));
            dtProductPriceList.Columns.Add("Limit", typeof(string));
            dtProductPriceList.Columns.Add("AgeMinRange", typeof(int));
            dtProductPriceList.Columns.Add("AgeMaxRange", typeof(int));
            dtProductPriceList.Columns.Add("Premium", typeof(decimal));
            dtProductPriceList.Columns.Add("Rate", typeof(decimal));



            foreach (var item in salesTransactionBL331211DetailsPrices)
            {
                DataRow dataRow = dtProductPriceList.NewRow();
                dataRow["SalesTrxDetailsId"] = item.SalesTrxDetailsId;
                dataRow["SectionName"] = item.SectionName == null ? DBNull.Value : item.SectionName;
                dataRow["Category"] = item.Category == null ? DBNull.Value : item.Category;
                dataRow["Dependency"] = item.Dependency == null ? DBNull.Value : item.Dependency;
                dataRow["Gender"] = item.Gender == null ? DBNull.Value : item.Gender;
                dataRow["MaritalStatus"] = item.MaritalStatus == null ? DBNull.Value : item.MaritalStatus;
                dataRow["Limit"] = item.Limit == null ? DBNull.Value : item.Limit;
                dataRow["AgeMinRange"] = item.AgeMinRange;
                dataRow["AgeMaxRange"] = item.AgeMaxRange;
                dataRow["Premium"] = item.Premium;
                dataRow["Rate"] = item.Rate;
                dtProductPriceList.Rows.Add(dataRow);
            }

            return DapperDbAccess.Query<SalesTransactionBL331211DetailsPriceDto>("usp_SalesTransactionBL331211DetailsPrices_New_Rec",
                           new
                           {
                               @tvpSalesTransactionDetailsPriceList = dtProductPriceList,
                               @pSalesTrxDetailsId = salesTransactionBL331211DetailsPrices[0].SalesTrxDetailsId,
                               @pCommisinOnGPPer = commisinOnGPPer,
                               @pAdminFeesAmount = adminFeesAmount,
                               @pCostOfPolicyPer = costOfPolicyPer,
                               @pCostOfPolicyAmount = costOfPolicyAmount,
                               @pFixedTaxesAmount = fixedTaxesAmount,
                               @pFixedTaxesPer = fixedTaxesPer,
                               @pVATPer = vATPer,
                               pCreatedBy = createdBy
                           },
                           cmdType: CommandType.StoredProcedure);
        }

        public List<KycDto> ClientFindAll()
        {
            var kycList = DapperDbAccess.Query<KycDto>("usp_Client_Find_All",
                null,
                cmdType: CommandType.StoredProcedure);
            return kycList;
        }

        public List<KycDto> KycUpd(string shuftiReference, string shuftiStatus, string declinedReason)
        {
            var kycList = DapperDbAccess.Query<KycDto>("usp_Client_Upd_Rec",
                new
                {
                    @pShuftiReference = shuftiReference,
                    @pShuftiStatus = shuftiStatus,
                    @pDeclinedReason = declinedReason
                },
                           cmdType: CommandType.StoredProcedure);
            return kycList;
        }

        public List<dynamic> SalesTransactionBL080501FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_BenefitsCompare",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }
        public List<dynamic> SalesTransactionBL080501FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL080501_CQ_Calculation_Pivot_BenefitsCompare_Short",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }

        public ProductDetailsPOINetworkDto ProductDetailsPOINetworkUpdRec(ProductDetailsPOINetworkUpdDto productDetailsPIONetworkDto, string lastModifiedBy)
        {
            return DapperDbAccess.QueryFirst<ProductDetailsPOINetworkDto>("usp_ProductDetailsPOINetwork_Upd_Record",
                            new
                            {
                                //check ig code is updated to submit message to client
                                pRecId = productDetailsPIONetworkDto.RecId,
                                @pNetworkExplanation = productDetailsPIONetworkDto.NetworkExplanation,
                                @pLastModifiedBy = lastModifiedBy
                            },
                            cmdType: CommandType.StoredProcedure);
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_BenefitsCompare_Short",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }

        public List<dynamic> SalesTransactionBL281609FindCQShortBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_BenefitsCompare_Short",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_Short",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }
        public List<dynamic> SalesTransactionBL281609FindCQShortPivotWithRecIdFilter(int salesTransactionId)
        {
            var cqPivotListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_Short",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqPivotListDynamic;
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_Benefits_Short",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL281609FindCQShortBenefitWithRecIdFilter(int salesTransactionId)
        {
            var cqBenefitListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_Benefits_Short",
            new
            {
                pSalesTrx = salesTransactionId
            },
             cmdType: CommandType.StoredProcedure);

            return cqBenefitListDynamic;
        }

        public List<dynamic> SalesTransactionBL070806FindCQShortBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_Payment_Short",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<dynamic> SalesTransactionBL281609FindCQShortBillsWithRecIdFilter(int salesTransactionId)
        {
            var cqCategoryListDynamic = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_Payment_Short",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return cqCategoryListDynamic;
        }

        public List<dynamic> SalesTransactionBL070806FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL070806_CQ_Calculation_Pivot_BenefitsCompare",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }

        public List<dynamic> SalesTransactionBL090703FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL090703_CQ_Calculation_Pivot_BenefitsCompare",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }

        public SalesTransactionBL070806Dto SalesTransactionBL070806UpdGlobalRec(int recId, int clientId, int masterId, string lastModifiedBy)
        {
            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL070806Xml>("usp_SalesTransactionBL070806_Upd_Global_Rec", new
            {
                @pRecId = recId,
                @pClientId = clientId,
                @pMasterId = masterId,
                //@pAF1 = strXml,
                @pLastModifiedBy = lastModifiedBy
            },
             cmdType: CommandType.StoredProcedure);
            SalesTransactionBL070806Dto salesTransactionBL070806Dto;
            if (salesTransaction.AF1BL070806 == null)
            {
                salesTransactionBL070806Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL070806Root>(salesTransaction.AF1BL070806);
                salesTransactionBL070806Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    ClientId = salesTransaction.ClientId,
                    MasterId = salesTransaction.MasterId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL070806 = xmlToClass.ArrayOfAF1BL070806,
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            return salesTransactionBL070806Dto;
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip2Rec(int recId, List<Slip2BL321110Dto> slip2BL321110Dto, string lastModifiedBy)
        {
            Slip2BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip2BL321110 = slip2BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_Slip2_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip2 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransaction.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransaction.Slip3BL321110);
                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110
                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip2Rec(int recId, List<Slip2BL041312Dto> slip2BL041312Dto, string lastModifiedBy)
        {
            Slip2BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip2BL041312 = slip2BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_Slip2_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip2 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransaction.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransaction.Slip3BL041312);
                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312
                };
            }
            return salesTransactionBL041312Dto;
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip2Rec(int recId, List<Slip2BL331211Dto> slip2BL331211Dto, string lastModifiedBy)
        {
            Slip2BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip2BL331211 = slip2BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Upd_Slip2_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip2 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(salesTransaction.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(salesTransaction.Slip3BL331211);
                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL331211 = strip2XmlToClass.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass.ArrayOfSlip3BL331211
                };
            }
            return salesTransactionBL331211Dto;
        }

        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip3Rec(int recId, List<Slip3BL321110Dto> slip3BL321110Dto, string lastModifiedBy)
        {
            Slip3BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip3BL321110 = slip3BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_Slip3_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip3 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransaction.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransaction.Slip3BL321110);
                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110
                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip3Rec(int recId, List<Slip3BL041312Dto> slip3BL041312Dto, string lastModifiedBy)
        {
            Slip3BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip3BL041312 = slip3BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_Slip3_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip3 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransaction.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransaction.Slip3BL041312);
                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312
                };
            }
            return salesTransactionBL041312Dto;
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip3Rec(int recId, List<Slip3BL331211Dto> slip3BL331211Dto, string lastModifiedBy)
        {
            Slip3BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip3BL331211 = slip3BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Upd_Slip3_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip3 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(salesTransaction.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(salesTransaction.Slip3BL331211);
                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL331211 = strip2XmlToClass.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass.ArrayOfSlip3BL331211
                };
            }
            return salesTransactionBL331211Dto;
        }
        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip4Rec(int recId, List<Slip4BL321110Dto> slip4BL321110Dto, string lastModifiedBy)
        {
            Slip4BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip4BL321110 = slip4BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_Slip4_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip4 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransaction.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransaction.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(salesTransaction.Slip4BL321110);

                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass.ArrayOfSlip4BL321110
                };
            }
            return salesTransactionBL321110Dto;
        }
        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip4Rec(int recId, List<Slip4BL041312Dto> slip4BL041312Dto, string lastModifiedBy)
        {
            Slip4BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip4BL041312 = slip4BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_Slip4_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip4 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransaction.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransaction.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(salesTransaction.Slip4BL041312);

                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass.ArrayOfSlip4BL041312
                };
            }
            return salesTransactionBL041312Dto;
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip4Rec(int recId, List<Slip4BL331211Dto> slip4BL331211Dto, string lastModifiedBy)
        {
            Slip4BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip4BL331211 = slip4BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Upd_Slip4_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip4 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(salesTransaction.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(salesTransaction.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(salesTransaction.Slip4BL331211);

                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL331211 = strip2XmlToClass.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass.ArrayOfSlip4BL331211
                };
            }
            return salesTransactionBL331211Dto;
        }
        public SalesTransactionBL321110Dto SalesTransactionBL321110UpdSlip5Rec(int recId, List<Slip5BL321110Dto> slip5BL321110Dto, string lastModifiedBy)
        {
            Slip5BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip5BL321110 = slip5BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Upd_Slip5_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110Dto salesTransactionBL321110Dto;
            if (salesTransaction.AF1BL321110 == null)
            {
                salesTransactionBL321110Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

                foreach (var item in slip5BL321110Dto)
                {
                    var salesTransactionDetailsNewRec = DapperDbAccess.Query<SalesTransactionBL321110Xml>("usp_SalesTransactionBL321110_Details_New_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    @pInsurerCode = item.InsurerCode,
                    @pThirdPartyAdminCode = item.TpaCode,
                    @pContactId = salesTransactionDetails.ContactId,
                    @pSlip2 = salesTransactionDetails.Slip2BL321110,
                    @pSlip3 = salesTransactionDetails.Slip3BL321110,
                    @pSlip4 = salesTransactionDetails.Slip4BL321110,
                    @pAF1 = salesTransactionDetails.AF1BL321110,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
                }

                //previous code
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(salesTransaction.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(salesTransaction.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(salesTransaction.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(salesTransaction.Slip4BL321110);
                var strip5XmlToClass = XmlConverter.ToClass<Slip5BL321110Root>(salesTransaction.Slip5BL321110);

                salesTransactionBL321110Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL321110 = xmlToClass.ArrayOfAF1BL321110,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL321110 = strip2XmlToClass.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass.ArrayOfSlip4BL321110,
                    Slip5BL321110 = strip5XmlToClass.ArrayOfSlip5BL321110
                };
            }
            return salesTransactionBL321110Dto;
        }

        public SalesTransactionBL041312Dto SalesTransactionBL041312UpdSlip5Rec(int recId, List<Slip5BL041312Dto> slip5BL041312Dto, string lastModifiedBy)
        {
            Slip5BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip5BL041312 = slip5BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Upd_Slip5_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312Dto salesTransactionBL041312Dto;
            if (salesTransaction.AF1BL041312 == null)
            {
                salesTransactionBL041312Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

                foreach (var item in slip5BL041312Dto)
                {
                    var salesTransactionDetailsNewRec = DapperDbAccess.Query<SalesTransactionBL041312Xml>("usp_SalesTransactionBL041312_Details_New_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    @pInsurerCode = item.InsurerCode,
                    @pThirdPartyAdminCode = item.TpaCode,
                    @pContactId = salesTransactionDetails.ContactId,
                    @pSlip2 = salesTransactionDetails.Slip2BL041312,
                    @pSlip3 = salesTransactionDetails.Slip3BL041312,
                    @pSlip4 = salesTransactionDetails.Slip4BL041312,
                    @pAF1 = salesTransactionDetails.AF1BL041312,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
                }

                //previous code
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(salesTransaction.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(salesTransaction.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(salesTransaction.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(salesTransaction.Slip4BL041312);
                var strip5XmlToClass = XmlConverter.ToClass<Slip5BL041312Root>(salesTransaction.Slip5BL041312);

                salesTransactionBL041312Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL041312 = xmlToClass.ArrayOfAF1BL041312,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL041312 = strip2XmlToClass.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass.ArrayOfSlip4BL041312,
                    Slip5BL041312 = strip5XmlToClass.ArrayOfSlip5BL041312
                };
            }
            return salesTransactionBL041312Dto;
        }
        public SalesTransactionBL331211Dto SalesTransactionBL331211UpdSlip5Rec(int recId, List<Slip5BL331211Dto> slip5BL331211Dto, string lastModifiedBy)
        {
            Slip5BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip5BL331211 = slip5BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransaction = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Upd_Slip5_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211Dto salesTransactionBL331211Dto;
            if (salesTransaction.AF1BL331211 == null)
            {
                salesTransactionBL331211Dto = new()
                {
                    Reserved1 = salesTransaction.Reserved1
                };
            }
            else
            {
                var salesTransactionDetails = DapperDbAccess.QueryFirst<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Details_Upd_IsActive_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    //@pAF1 = strXml,
                    //@pSlip5 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);

                foreach (var item in slip5BL331211Dto)
                {
                    var salesTransactionDetailsNewRec = DapperDbAccess.Query<SalesTransactionBL331211Xml>("usp_SalesTransactionBL331211_Details_New_Rec",
                new
                {
                    @pSalesTrxId = recId,
                    @pInsurerCode = item.InsurerCode,
                    @pThirdPartyAdminCode = item.TpaCode,
                    @pContactId = salesTransactionDetails.ContactId,
                    @pSlip2 = salesTransactionDetails.Slip2BL331211,
                    @pSlip3 = salesTransactionDetails.Slip3BL331211,
                    @pSlip4 = salesTransactionDetails.Slip4BL331211,
                    @pAF1 = salesTransactionDetails.AF1BL331211,
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);
                }

                //previous code
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(salesTransaction.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(salesTransaction.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(salesTransaction.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(salesTransaction.Slip4BL331211);
                var strip5XmlToClass = XmlConverter.ToClass<Slip5BL331211Root>(salesTransaction.Slip5BL331211);

                salesTransactionBL331211Dto = new()
                {
                    RecId = salesTransaction.RecId,
                    BusinessLineCode = salesTransaction.BusinessLineCode,
                    ContactId = salesTransaction.ContactId,
                    TransactionDate = salesTransaction.TransactionDate,
                    ProductId = salesTransaction.ProductId,
                    PolicyIssuedDate = salesTransaction.PolicyIssuedDate,
                    PolicyNumber = salesTransaction.PolicyNumber,
                    AF1BL331211 = xmlToClass.ArrayOfAF1BL331211,
                    Reserved1 = salesTransaction.Reserved1,
                    Slip2BL331211 = strip2XmlToClass.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass.ArrayOfSlip4BL331211,
                    Slip5BL331211 = strip5XmlToClass.ArrayOfSlip5BL331211
                };
            }
            return salesTransactionBL331211Dto;
        }

        public List<dynamic> salesTransactionBL321110FindAF1WithRecId(int salesTransactionId)
        {
            var af1Res = DapperDbAccess.Query<dynamic>("usp_SalesTransactionBL321110_SlipToExcel_Step1",
                      new
                      {
                          pSalesTrx = salesTransactionId
                      },
                       cmdType: CommandType.StoredProcedure);

            return af1Res;
        }
        public List<dynamic> salesTransactionBL041312FindAF1WithRecId(int salesTransactionId)
        {
            var af1Res = DapperDbAccess.Query<dynamic>("usp_SalesTransactionBL041312_SlipToExcel_Step1",
                      new
                      {
                          pSalesTrx = salesTransactionId
                      },
                       cmdType: CommandType.StoredProcedure);

            return af1Res;
        }
        public List<dynamic> salesTransactionBL331211FindAF1WithRecId(int salesTransactionId)
        {
            var af1Res = DapperDbAccess.Query<dynamic>("usp_SalesTransactionBL331211_SlipToExcel_Step1",
                      new
                      {
                          pSalesTrx = salesTransactionId
                      },
                       cmdType: CommandType.StoredProcedure);

            return af1Res;
        }

        public List<dynamic> salesTransactionBL321110FindStep2WithRecId(int salesTransactionId)
        {
            var step2Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_SlipToExcel_Step2",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return step2Res;
        }

        public List<dynamic> salesTransactionBL041312FindStep2WithRecId(int salesTransactionId)
        {
            var step2Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_SlipToExcel_Step2",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return step2Res;
        }
        public List<dynamic> salesTransactionBL331211FindStep2WithRecId(int salesTransactionId)
        {
            var step2Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_SlipToExcel_Step2",
           new
           {
               pSalesTrx = salesTransactionId
           },
            cmdType: CommandType.StoredProcedure);

            return step2Res;
        }

        public List<dynamic> salesTransactionBL321110FindStep3WithRecId(int salesTransactionId)
        {
            var step3Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_SlipToExcel_Step3",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return step3Res;
        }
        public List<dynamic> salesTransactionBL041312FindStep3WithRecId(int salesTransactionId)
        {
            var step3Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_SlipToExcel_Step3",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return step3Res;
        }
        public List<dynamic> salesTransactionBL331211FindStep3WithRecId(int salesTransactionId)
        {
            var step3Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_SlipToExcel_Step3",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return step3Res;
        }

        public List<dynamic> salesTransactionBL321110FindStep4WithRecId(int salesTransactionId)
        {
            var step4Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL321110_SlipToExcel_Step4",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return step4Res;
        }
        public List<dynamic> salesTransactionBL041312FindStep4WithRecId(int salesTransactionId)
        {
            var step4Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL041312_SlipToExcel_Step4",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return step4Res;
        }
        public List<dynamic> salesTransactionBL331211FindStep4WithRecId(int salesTransactionId)
        {
            var step4Res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL331211_SlipToExcel_Step4",
                       new
                       {
                           pSalesTrx = salesTransactionId
                       },
                        cmdType: CommandType.StoredProcedure);

            return step4Res;
        }

        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsFindWithSalesTrxIdFilter(int salesTransactionId)
        {
            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL321110DetailsXml>("usp_SalesTransactionBL321110_Details_Find_With_SalesTrxId_Filter",
                new
                {
                    @pSalesTrxId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL321110DetailsDto salesTransactionBL321110DetailsDto;
            List<SalesTransactionBL321110DetailsDto> res = new List<SalesTransactionBL321110DetailsDto>();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL321110DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(item.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(item.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(item.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(item.Slip4BL321110);
                salesTransactionBL321110DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AgeCalculationFullDate = item.AgeCalculationFullDate,
                    AgeCalculationYear = item.AgeCalculationYear,
                    AgeCalculationStartDate = item.AgeCalculationStartDate,
                    AF1BL321110 = xmlToClass?.ArrayOfAF1BL321110,
                    Slip2BL321110 = strip2XmlToClass?.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass?.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass?.ArrayOfSlip4BL321110,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL321110DetailsDto);
                //}
            }
            return res;
        }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsFindWithSalesTrxIdFilter(int salesTransactionId)
        {
            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL041312DetailsXml>("usp_SalesTransactionBL041312_Details_Find_With_SalesTrxId_Filter",
                new
                {
                    @pSalesTrxId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL041312DetailsDto salesTransactionBL041312DetailsDto;
            List<SalesTransactionBL041312DetailsDto> res = new List<SalesTransactionBL041312DetailsDto>();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL041312DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(item.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(item.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(item.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(item.Slip4BL041312);
                salesTransactionBL041312DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL041312 = xmlToClass?.ArrayOfAF1BL041312,
                    Slip2BL041312 = strip2XmlToClass?.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass?.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass?.ArrayOfSlip4BL041312,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL041312DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsFindWithSalesTrxIdFilter(int salesTransactionId)
        {
            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL331211DetailsXml>("usp_SalesTransactionBL331211_Details_Find_With_SalesTrxId_Filter",
                new
                {
                    @pSalesTrxId = salesTransactionId
                },
                cmdType: CommandType.StoredProcedure);

            SalesTransactionBL331211DetailsDto salesTransactionBL331211DetailsDto;
            List<SalesTransactionBL331211DetailsDto> res = new List<SalesTransactionBL331211DetailsDto>();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL331211DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(item.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(item.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(item.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(item.Slip4BL331211);
                salesTransactionBL331211DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL331211 = xmlToClass?.ArrayOfAF1BL331211,
                    Slip2BL331211 = strip2XmlToClass?.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass?.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass?.ArrayOfSlip4BL331211,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL331211DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip2Rec(int recId, List<Slip2BL321110Dto> slip2BL321110Dto, string lastModifiedBy)
        {
            Slip2BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip2BL321110 = slip2BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL321110DetailsXml>("usp_SalesTransactionBL321110_Details_Upd_Slip2_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip2 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110DetailsDto salesTransactionBL321110DetailsDto;
            List<SalesTransactionBL321110DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL321110DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(item.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(item.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(item.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(item.Slip4BL321110);
                salesTransactionBL321110DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AgeCalculationStartDate = item.AgeCalculationStartDate,
                    AgeCalculationFullDate = item.AgeCalculationFullDate,
                    AgeCalculationYear = item.AgeCalculationYear,
                    AF1BL321110 = xmlToClass?.ArrayOfAF1BL321110,
                    Slip2BL321110 = strip2XmlToClass?.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass?.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass?.ArrayOfSlip4BL321110,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL321110DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip2Rec(int recId, List<Slip2BL041312Dto> slip2BL041312Dto, string lastModifiedBy)
        {
            Slip2BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip2BL041312 = slip2BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL041312DetailsXml>("usp_SalesTransactionBL041312_Details_Upd_Slip2_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip2 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312DetailsDto salesTransactionBL041312DetailsDto;
            List<SalesTransactionBL041312DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL041312DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(item.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(item.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(item.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(item.Slip4BL041312);
                salesTransactionBL041312DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL041312 = xmlToClass?.ArrayOfAF1BL041312,
                    Slip2BL041312 = strip2XmlToClass?.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass?.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass?.ArrayOfSlip4BL041312,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL041312DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip2Rec(int recId, List<Slip2BL331211Dto> slip2BL331211Dto, string lastModifiedBy)
        {
            Slip2BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip2BL331211 = slip2BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL331211DetailsXml>("usp_SalesTransactionBL331211_Details_Upd_Slip2_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip2 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211DetailsDto salesTransactionBL331211DetailsDto;
            List<SalesTransactionBL331211DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL331211DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(item.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(item.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(item.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(item.Slip4BL331211);
                salesTransactionBL331211DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL331211 = xmlToClass?.ArrayOfAF1BL331211,
                    Slip2BL331211 = strip2XmlToClass?.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass?.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass?.ArrayOfSlip4BL331211,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL331211DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip3Rec(int recId, List<Slip3BL321110Dto> slip3BL321110Dto, string lastModifiedBy)
        {
            Slip3BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip3BL321110 = slip3BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL321110DetailsXml>("usp_SalesTransactionBL321110_Details_Upd_Slip3_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip3 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110DetailsDto salesTransactionBL321110DetailsDto;
            List<SalesTransactionBL321110DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL321110DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(item.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(item.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(item.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(item.Slip4BL321110);
                salesTransactionBL321110DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AgeCalculationYear = item.AgeCalculationYear,
                    AgeCalculationFullDate = item.AgeCalculationFullDate,
                    AgeCalculationStartDate = item.AgeCalculationStartDate,
                    AF1BL321110 = xmlToClass?.ArrayOfAF1BL321110,
                    Slip2BL321110 = strip2XmlToClass?.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass?.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass?.ArrayOfSlip4BL321110,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL321110DetailsDto);
                //}
            }
            return res;
        }
        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip3Rec(int recId, List<Slip3BL041312Dto> slip3BL041312Dto, string lastModifiedBy)
        {
            Slip3BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip3BL041312 = slip3BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL041312DetailsXml>("usp_SalesTransactionBL041312_Details_Upd_Slip3_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip3 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312DetailsDto salesTransactionBL041312DetailsDto;
            List<SalesTransactionBL041312DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL041312DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(item.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(item.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(item.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(item.Slip4BL041312);
                salesTransactionBL041312DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL041312 = xmlToClass?.ArrayOfAF1BL041312,
                    Slip2BL041312 = strip2XmlToClass?.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass?.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass?.ArrayOfSlip4BL041312,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL041312DetailsDto);
                //}
            }
            return res;
        }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip3Rec(int recId, List<Slip3BL331211Dto> slip3BL331211Dto, string lastModifiedBy)
        {
            Slip3BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip3BL331211 = slip3BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL331211DetailsXml>("usp_SalesTransactionBL331211_Details_Upd_Slip3_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip3 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211DetailsDto salesTransactionBL331211DetailsDto;
            List<SalesTransactionBL331211DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL331211DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(item.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(item.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(item.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(item.Slip4BL331211);
                salesTransactionBL331211DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL331211 = xmlToClass?.ArrayOfAF1BL331211,
                    Slip2BL331211 = strip2XmlToClass?.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass?.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass?.ArrayOfSlip4BL331211,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL331211DetailsDto);
                //}
            }
            return res;
        }
        public List<SalesTransactionBL321110DetailsDto> SalesTransactionBL321110DetailsUpdSlip4Rec(int recId, List<Slip4BL321110Dto> slip4BL321110Dto, string lastModifiedBy)
        {
            Slip4BL321110Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip4BL321110 = slip4BL321110Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL321110DetailsXml>("usp_SalesTransactionBL321110_Details_Upd_Slip4_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip4 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL321110DetailsDto salesTransactionBL321110DetailsDto;
            List<SalesTransactionBL321110DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL321110DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL321110Root>(item.AF1BL321110);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL321110Root>(item.Slip2BL321110);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL321110Root>(item.Slip3BL321110);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL321110Root>(item.Slip4BL321110);
                salesTransactionBL321110DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AgeCalculationStartDate = item.AgeCalculationStartDate,
                    AgeCalculationFullDate = item.AgeCalculationFullDate,
                    AgeCalculationYear = item.AgeCalculationYear,
                    AF1BL321110 = xmlToClass?.ArrayOfAF1BL321110,
                    Slip2BL321110 = strip2XmlToClass?.ArrayOfSlip2BL321110,
                    Slip3BL321110 = strip3XmlToClass?.ArrayOfSlip3BL321110,
                    Slip4BL321110 = strip4XmlToClass?.ArrayOfSlip4BL321110,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL321110DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL041312DetailsDto> SalesTransactionBL041312DetailsUpdSlip4Rec(int recId, List<Slip4BL041312Dto> slip4BL041312Dto, string lastModifiedBy)
        {
            Slip4BL041312Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip4BL041312 = slip4BL041312Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL041312DetailsXml>("usp_SalesTransactionBL041312_Details_Upd_Slip4_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip4 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL041312DetailsDto salesTransactionBL041312DetailsDto;
            List<SalesTransactionBL041312DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL041312DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL041312Root>(item.AF1BL041312);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL041312Root>(item.Slip2BL041312);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL041312Root>(item.Slip3BL041312);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL041312Root>(item.Slip4BL041312);
                salesTransactionBL041312DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL041312 = xmlToClass?.ArrayOfAF1BL041312,
                    Slip2BL041312 = strip2XmlToClass?.ArrayOfSlip2BL041312,
                    Slip3BL041312 = strip3XmlToClass?.ArrayOfSlip3BL041312,
                    Slip4BL041312 = strip4XmlToClass?.ArrayOfSlip4BL041312,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL041312DetailsDto);
                //}
            }
            return res;
        }
        public List<SalesTransactionBL331211DetailsDto> SalesTransactionBL331211DetailsUpdSlip4Rec(int recId, List<Slip4BL331211Dto> slip4BL331211Dto, string lastModifiedBy)
        {
            Slip4BL331211Root _classToXml;
            _classToXml = new()
            {
                ArrayOfSlip4BL331211 = slip4BL331211Dto
            };
            var strXml = XmlConverter.FromClass(_classToXml);

            var salesTransactionDetails = DapperDbAccess.Query<SalesTransactionBL331211DetailsXml>("usp_SalesTransactionBL331211_Details_Upd_Slip4_Rec",
                new
                {
                    @pRecId = recId,
                    //@pAF1 = strXml,
                    @pSlip4 = strXml,
                    //@pSlip3 = "",
                    @pLastModifiedBy = lastModifiedBy
                },
                cmdType: CommandType.StoredProcedure);


            SalesTransactionBL331211DetailsDto salesTransactionBL331211DetailsDto;
            List<SalesTransactionBL331211DetailsDto> res = new();
            //if (salesTransactionDetails == null)
            //{
            //    salesTransactionBL331211DetailsDto = new()
            //    {
            //        Reserved1 = salesTransactionDetails[0].Reserved1
            //    };
            //}
            //else
            //{
            foreach (var item in salesTransactionDetails)
            {
                var xmlToClass = XmlConverter.ToClass<AF1BL331211Root>(item.AF1BL331211);
                var strip2XmlToClass = XmlConverter.ToClass<Slip2BL331211Root>(item.Slip2BL331211);
                var strip3XmlToClass = XmlConverter.ToClass<Slip3BL331211Root>(item.Slip3BL331211);
                var strip4XmlToClass = XmlConverter.ToClass<Slip4BL331211Root>(item.Slip4BL331211);
                salesTransactionBL331211DetailsDto = new()
                {
                    RecId = item.RecId,
                    SalesTrxId = item.SalesTrxId,
                    Insurer_Code = item.Insurer_Code,
                    ThirdPartyAdmin_Code = item.ThirdPartyAdmin_Code,
                    ContactId = item.ContactId,
                    CommisinOnGPPer = item.CommisinOnGPPer,
                    AdminFeesAmount = item.AdminFeesAmount,
                    CostOfPolicyPer = item.CostOfPolicyPer,
                    CostOfPolicyAmount = item.CostOfPolicyAmount,
                    FixedTaxesAmount = item.FixedTaxesAmount,
                    FixedTaxesPer = item.FixedTaxesPer,
                    VATPer = item.VATPer,
                    AF1BL331211 = xmlToClass?.ArrayOfAF1BL331211,
                    Slip2BL331211 = strip2XmlToClass?.ArrayOfSlip2BL331211,
                    Slip3BL331211 = strip3XmlToClass?.ArrayOfSlip3BL331211,
                    Slip4BL331211 = strip4XmlToClass?.ArrayOfSlip4BL331211,
                    Reserved1 = item.Reserved1 ?? null,
                };
                res.Add(salesTransactionBL331211DetailsDto);
                //}
            }
            return res;
        }

        public List<SalesTransactionBL321110DetailsPriceDto> SalesTransactionBL321110DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId)
        {
            var salesTransactionDetailsPrices = DapperDbAccess.Query<SalesTransactionBL321110DetailsPriceDto>("usp_SalesTransactionBL321110_DetailsPrices_Find_With_SalesTrxId_Filter",
                new
                {
                    @pSalesTrxDetailsId = SalesTransactionDetailsId
                },
                cmdType: CommandType.StoredProcedure);
            return salesTransactionDetailsPrices;
        }

        public List<SalesTransactionBL041312DetailsPriceDto> SalesTransactionBL041312DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId)
        {
            var salesTransactionDetailsPrices = DapperDbAccess.Query<SalesTransactionBL041312DetailsPriceDto>("usp_SalesTransactionBL041312_DetailsPrices_Find_With_SalesTrxId_Filter",
                new
                {
                    @pSalesTrxDetailsId = SalesTransactionDetailsId
                },
                cmdType: CommandType.StoredProcedure);
            return salesTransactionDetailsPrices;
        }
        public List<SalesTransactionBL331211DetailsPriceDto> SalesTransactionBL331211DetailsPricesFindWithSalesTrxIdFilter(int SalesTransactionDetailsId)
        {
            var salesTransactionDetailsPrices = DapperDbAccess.Query<SalesTransactionBL331211DetailsPriceDto>("usp_SalesTransactionBL331211_DetailsPrices_Find_With_SalesTrxId_Filter",
                new
                {
                    @pSalesTrxDetailsId = SalesTransactionDetailsId
                },
                cmdType: CommandType.StoredProcedure);
            return salesTransactionDetailsPrices;
        }

        public SalesTransactionBL321110DetailsNewDto SalesTransactionBL321110DetailsFindWithRecIdFilter(int recId)
        {
            var res = DapperDbAccess.QueryFirst<SalesTransactionBL321110DetailsNewDto>("usp_SalesTransactionBL321110_Details_Find_With_RecId_Filter",
                          new
                          {
                              @pRecId = recId
                          },
                           cmdType: CommandType.StoredProcedure);
            return res;
        }
        public SalesTransactionBL041312DetailsNewDto SalesTransactionBL041312DetailsFindWithRecIdFilter(int recId)
        {
            var res = DapperDbAccess.QueryFirst<SalesTransactionBL041312DetailsNewDto>("usp_SalesTransactionBL041312_Details_Find_With_RecId_Filter",
                          new
                          {
                              @pRecId = recId
                          },
                           cmdType: CommandType.StoredProcedure);
            return res;
        }
        public SalesTransactionBL331211DetailsNewDto SalesTransactionBL331211DetailsFindWithRecIdFilter(int recId)
        {
            var res = DapperDbAccess.QueryFirst<SalesTransactionBL331211DetailsNewDto>("usp_SalesTransactionBL331211_Details_Find_With_RecId_Filter",
                          new
                          {
                              @pRecId = recId
                          },
                           cmdType: CommandType.StoredProcedure);
            return res;
        }

        public List<PolicyBL281609Dto> PolicyBL281609NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL281609Dto>("usp_SalesTransactionBL281609_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL281609Dto> PolicyBL281609UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL281609Dto>
                                                   ("usp_SalesTransactionBL281609_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }


        public PolicyRelatedDocBL281609Dto PolicyRelatedDocBL281609UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL281609Dto>
                            ("usp_SalesTransactionBL281609_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL281609Dto PolicyRelatedDocBL281609NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL281609Dto>
                                                   ("usp_SalesTransactionBL281609_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }



        public List<PolicyRelatedDocBL281609Dto> PolicyRelatedDocBL281609(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL281609Dto>
                ("usp_SalesTransactionBL281609_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<PaymentScheduleBL281609Dto> PolicyPaymentScheduleBL281609(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL281609Dto>("usp_SalesTransactionBL281609_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }

        public List<dynamic> SalesTransactionBL281609FindCQBenefitCompareWithRecIdFilter(int salesTransactionId)
        {
            var res = DapperDbAccess.QueryDynamic<dynamic>("usp_SalesTransactionBL281609_CQ_Calculation_Pivot_BenefitsCompare",
                        new
                        {
                            pSalesTrx = salesTransactionId
                        },
                         cmdType: CommandType.StoredProcedure);

            return res;
        }
        public List<PolicyBL021502Dto> PolicyBL021502NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL021502Dto>("usp_SalesTransactionBL021502_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL021502Dto> PolicyBL021502UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL021502Dto>
                                                   ("usp_SalesTransactionBL021502_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }


        public PolicyRelatedDocBL021502Dto PolicyRelatedDocBL021502UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL021502Dto>
                            ("usp_SalesTransactionBL021502_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL021502Dto PolicyRelatedDocBL021502NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL021502Dto>
                                                   ("usp_SalesTransactionBL021502_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }



        public List<PolicyRelatedDocBL021502Dto> PolicyRelatedDocBL021502(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL021502Dto>
                ("usp_SalesTransactionBL021502_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<PaymentScheduleBL021502Dto> PolicyPaymentScheduleBL021502(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL021502Dto>("usp_SalesTransactionBL021502_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }

        public List<PolicyBL051807Dto> PolicyBL051807NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL051807Dto>("usp_SalesTransactionBL051807_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL051807Dto> PolicyBL051807UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL051807Dto>
                                                   ("usp_SalesTransactionBL051807_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }


        public PolicyRelatedDocBL051807Dto PolicyRelatedDocBL051807UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL051807Dto>
                            ("usp_SalesTransactionBL051807_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL051807Dto PolicyRelatedDocBL051807NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL051807Dto>
                                                   ("usp_SalesTransactionBL051807_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }



        public List<PolicyRelatedDocBL051807Dto> PolicyRelatedDocBL051807(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL051807Dto>
                ("usp_SalesTransactionBL051807_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<PaymentScheduleBL051807Dto> PolicyPaymentScheduleBL051807(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL051807Dto>("usp_SalesTransactionBL051807_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }

        public List<PolicyBL291908Dto> PolicyBL291908NewRec(int salesTransactionId, int productId, string combination, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL291908Dto>("usp_SalesTransactionBL291908_PolicyConsolidation",
                                  new
                                  {
                                      @pSalesTrxId = salesTransactionId,
                                      @pProductId = productId,
                                      @pCombination = combination,
                                      //@pBusinessLineCode = businessLineCode,
                                      @pCreatedBy = createdBy
                                  },
                                   cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL291908Dto> PolicyBL291908UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL291908Dto>
                                                   ("usp_SalesTransactionBL291908_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }


        public PolicyRelatedDocBL291908Dto PolicyRelatedDocBL291908UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL291908Dto>
                            ("usp_SalesTransactionBL291908_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL291908Dto PolicyRelatedDocBL291908NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL291908Dto>
                                                   ("usp_SalesTransactionBL291908_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }



        public List<PolicyRelatedDocBL291908Dto> PolicyRelatedDocBL291908(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL291908Dto>
                ("usp_SalesTransactionBL291908_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<PaymentScheduleBL291908Dto> PolicyPaymentScheduleBL291908(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL291908Dto>("usp_SalesTransactionBL291908_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }
        public List<PolicyBL041312Dto> PolicyBL041312NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL041312Dto>
                ("usp_SalesTransactionBL041312_PolicyConsolidation",
                new
                {
                    @pSalesTrxId = salesTransactionId,
                    @pInsurerCode = InsurerCode,
                    //@pThirdPartyAdminCode = ThirdPartyAdminCode,
                    //@pBusinessLineCode = businessLineCode,
                    @pCreatedBy = createdBy
                }, cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL041312Dto> PolicyBL041312UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL041312Dto>
                                                   ("usp_SalesTransactionBL041312_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }


        public PolicyRelatedDocBL041312Dto PolicyRelatedDocBL041312UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL041312Dto>
                            ("usp_SalesTransactionBL041312_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL041312Dto PolicyRelatedDocBL041312NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL041312Dto>
                                                   ("usp_SalesTransactionBL041312_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }



        public List<PolicyRelatedDocBL041312Dto> PolicyRelatedDocBL041312(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL041312Dto>
                ("usp_SalesTransactionBL041312_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<PaymentScheduleBL041312Dto> PolicyPaymentScheduleBL041312(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL041312Dto>("usp_SalesTransactionBL041312_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }

        public List<PolicyBL331211Dto> PolicyBL331211NewRec(int salesTransactionId, string InsurerCode, string ThirdPartyAdminCode, string businessLineCode, string createdBy)
        {
            var policyList = DapperDbAccess.Query<PolicyBL331211Dto>
                ("usp_SalesTransactionBL331211_PolicyConsolidation",
                new
                {
                    @pSalesTrxId = salesTransactionId,
                    @pInsurerCode = InsurerCode,
                    //@pThirdPartyAdminCode = ThirdPartyAdminCode,
                    //@pBusinessLineCode = businessLineCode,
                    @pCreatedBy = createdBy
                },
                                                         cmdType: CommandType.StoredProcedure);

            return policyList;
        }

        public List<PolicyBL331211Dto> PolicyBL331211UpdRec(int salesTransactionId, int TicketId, string ParentPolicyId, string PolicyId, string BusinessLineCode, decimal GrossPremiumGP, decimal CommisionFromGPPer, decimal CommisionFromGPAmount, decimal VATOnCommisionPer, decimal VATOnCommisionAmount, decimal BuiltInFixedTaxesAmount, decimal BuiltInPropTaxesPer, decimal BuiltInPropTaxesAmount, decimal BuiltInCostOfPolicyAmount, decimal InsurerLoadingPer, decimal InsurerLoadingAmount, decimal NetPremiumAmount, string lastModifiedBy, string PolicyNumber, DateTime PolicyEffectiveDate, DateTime PolicyExpiryDate, DateTime PolicyIssuedDate, string PolicyHolder)
        {
            var policyRes = DapperDbAccess.Query<PolicyBL331211Dto>
                                                   ("usp_SalesTransactionBL331211_Upd_PolicyConsolidation",
                                                   new
                                                   {
                                                       @pSalesTrxId = salesTransactionId,
                                                       @pBusinessLineCode = BusinessLineCode,
                                                       @pTicketId = TicketId,
                                                       @ParentPolicyId = ParentPolicyId,
                                                       @pPolicyId = PolicyId,
                                                       @pGrossPremiumGP = GrossPremiumGP,
                                                       @pCommisionFromGP_Per = CommisionFromGPPer,
                                                       @pCommisionFromGP_Amount = CommisionFromGPAmount,
                                                       @pVATOnCommision_Per = VATOnCommisionPer,
                                                       @pVATOnCommision_Amount = VATOnCommisionAmount,
                                                       @pBuiltIn_FixedTaxes_Amount = BuiltInFixedTaxesAmount,
                                                       @pBuiltIn_PropTaxes_Per = BuiltInPropTaxesPer,
                                                       @pBuiltIn_PropTaxes_Amount = BuiltInPropTaxesAmount,
                                                       @pBuiltIn_CostOfPolicy_Amount = BuiltInCostOfPolicyAmount,
                                                       @pInsurerLoading_Per = InsurerLoadingPer,
                                                       @pInsurerLoading_Amount = InsurerLoadingAmount,
                                                       @pNetPremium_Amount = NetPremiumAmount,
                                                       @pLastModifiedBy = lastModifiedBy,
                                                       @pPolicyNumber = PolicyNumber,
                                                       @pPolicyEffectiveDate = PolicyEffectiveDate,
                                                       @pPolicyExpiryDate = PolicyExpiryDate,
                                                       @pPolicyIssuedDate = PolicyIssuedDate,
                                                       @pPolicyHolder = PolicyHolder
                                                   },
                                                   cmdType: CommandType.StoredProcedure);
            return policyRes;
        }

        public PolicyRelatedDocBL331211Dto PolicyRelatedDocBL331211UpdRec(int recId, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL331211Dto>
                            ("usp_SalesTransactionBL331211_PolicyConsolidation_RelatedDoc_Upd_Rec",
                                                            new
                                                            {
                                                                @pRecId = recId,
                                                                @pAttachDocBinary = attachDocBinary,
                                                                @pLastModifiedBy = lastModifiedBy,
                                                                @pAttachDocName = attachDocName,
                                                                @pAttachDocExt = attachedDocExt
                                                                //@pProductId = productId,
                                                                //@pCombination = combination,
                                                                //@pBusinessLineCode = businessLineCode
                                                                //@pCreatedBy = createdBy
                                                            },
                                                             cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }

        public PolicyRelatedDocBL331211Dto PolicyRelatedDocBL331211NewRec(int salesTransactionId, int ticketId, string parentPolicyId, string policyId, string businessLineCode, string documentType, byte[] attachDocBinary, string attachDocName, string attachedDocExt, string lastModifiedBy)
        {
            var policyRelatedDoc = DapperDbAccess.QueryFirstOrDefault<PolicyRelatedDocBL331211Dto>
                                                   ("usp_SalesTransactionBL331211_PolicyConsolidation_RelatedDoc_New_Rec",
                                                                                   new
                                                                                   {
                                                                                       @pSalesTransactionId = salesTransactionId,
                                                                                       @pTicketId = ticketId,
                                                                                       @pParentPolicyId = parentPolicyId,
                                                                                       @pPolicyId = policyId,
                                                                                       @pBusinessLineCode = businessLineCode,
                                                                                       @pDocumentType = documentType,
                                                                                       @pAttachDocBinary = attachDocBinary,
                                                                                       @pLastModifiedBy = lastModifiedBy,
                                                                                       @pAttachDocName = attachDocName,
                                                                                       @pAttachDocExt = attachedDocExt

                                                                                   },
                                                                                    cmdType: CommandType.StoredProcedure);

            return policyRelatedDoc;
        }



        public List<PolicyRelatedDocBL331211Dto> PolicyRelatedDocBL331211(int salesTransactionId, string businessLineCode)
        {
            var policyRelatedDocList = DapperDbAccess.Query<PolicyRelatedDocBL331211Dto>
                ("usp_SalesTransactionBL331211_PolicyConsolidation_RelatedDoc",
                                                new
                                                {
                                                    @pSalesTrxId = salesTransactionId,
                                                    //@pProductId = productId,
                                                    //@pCombination = combination,
                                                    @pBusinessLineCode = businessLineCode
                                                    //@pCreatedBy = createdBy
                                                },
                                                 cmdType: CommandType.StoredProcedure);

            return policyRelatedDocList;
        }

        public List<PaymentScheduleBL331211Dto> PolicyPaymentScheduleBL331211(int salesTransactionId, string businessLineCode)
        {
            var payScheduleList = DapperDbAccess.Query<PaymentScheduleBL331211Dto>("usp_SalesTransactionBL331211_PolicyConsolidation_Payment",
                                   new
                                   {
                                       @pSalesTrxId = salesTransactionId,
                                       //@pProductId = productId,
                                       //@pCombination = combination,
                                       @pBusinessLineCode = businessLineCode
                                       //@pCreatedBy = createdBy
                                   },
                                    cmdType: CommandType.StoredProcedure);
            return payScheduleList;
        }
        public List<ProductPriceControlDto> ProductPriceControlFindAll()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var res = DapperDbAccess.Query<ProductPriceControlDto>("usp_ProductPriceControle",
                null,
                cmdType: CommandType.StoredProcedure);
            return res;
        }

        public List<RenewalParameterDto> RenewalParameterFindAll()
        {
            //Logger.Info
            //var userCred = new List<UserCredResp>();
            var res = DapperDbAccess.Query<RenewalParameterDto>("usp_Renewal_Parameters",
                null,
                cmdType: CommandType.StoredProcedure);
            return res;
        }

        public List<TicketHistoryDto> TicketHistoryFindDataWithNbrDaysFilter(int NbrDays, string UserName)
        {
            var res = DapperDbAccess.Query<TicketHistoryDto>("usp_Dashboard_Ticket_1",
                new
                {
                    @pNbrDays = NbrDays
                },
                cmdType: CommandType.StoredProcedure);
            return res;
        }
    }
}
