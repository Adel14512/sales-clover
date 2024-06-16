using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.Request.Product;
using Evaluation.CAL.Response.Product;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using Evaluation.CAL.DTO.Product;
using Evaluation.CAL.DTO;
using Evaluation.CAL.Request;
using Evaluation.CAL.Response;
using Evaluation.CAL.Request.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.Response.ProductDetailsPOIAllNetwork;
using Evaluation.CAL.DTO.ProductDetailsPOIAllNetwork;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public ProductController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductFindAll(ProductFindAllReq productFindAllReq)
        {
            ProductFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                Product = new List<ProductDto>()
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = productFindAllReq == null ? Guid.NewGuid().ToString() :
                        productFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productFindAllReq.WebRequestCommon.CorrelationId, productFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productFindAllReq));

                resp.Product = InstManagerAccessPoint.GetNewAccessPoint().ProductFindAll(productFindAllReq.IsActive);

                if (resp != null && resp.Product != null && resp.Product.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.Product[0].Reserved1 != null ? resp.Product[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.Product[0].Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productFindAllReq.WebRequestCommon.CorrelationId;
                    if (resp.Product[0].Reserved1 != null)
                        resp.Product = new List<ProductDto>();
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductFindAll is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productFindAllReq.WebRequestCommon.CorrelationId;
                resp.Product = new List<ProductDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductLookupFindAll(ProductLookupFindAllReq productLookupFindAllReq)
        {
            ProductLookupFindAllResp resp;
            resp = new()
            {
                WebResponseCommon = new()
                {
                },

                ThirdPartyAdmin = new List<ThirdPartyAdminDto>(),
                Branch = new List<BranchDto>(),
                Region = new List<RegionDto>(),
                Currency = new List<CurrencyDto>(),
                Insurer = new List<InsurerDto>(),
                TerritorialScope = new List<TerritorialScope>(),
                ProductDetailsPOISection = new List<ProductDetailsPOISectionDto>(),
                ProductClassOfCoverage = new List<ProductClassOfCoverageDto>(),
                ProductDetailsPOINetwork = new List<ProductDetailsPOINetwork>()
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = productLookupFindAllReq == null ? Guid.NewGuid().ToString() :
                        productLookupFindAllReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productLookupFindAllReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productLookupFindAllReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productLookupFindAllReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();
                    return Ok(resp);
                }
                _logger.SetCorrelationId(productLookupFindAllReq.WebRequestCommon.CorrelationId, productLookupFindAllReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductLookupFindAll is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productLookupFindAllReq));

                List<ProductLookupDto> lookupList = InstManagerAccessPoint.GetNewAccessPoint().ProductLookupFindAll();
                if (lookupList != null && lookupList.Count > 0)
                {
                    var list = lookupList.FindAll(e => e.TableName == "t_ThirdPartyAdmin").ToList();
                    var thirdPartyAdminList = new List<ThirdPartyAdminDto>();
                    foreach (var item in list)
                    {
                        thirdPartyAdminList.Add(new ThirdPartyAdminDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Insurer").ToList();
                    var insurerList = new List<InsurerDto>();
                    foreach (var item in list)
                    {
                        insurerList.Add(new InsurerDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive)
                            //IsDefault = bool.Parse(item.IsDefault)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_TerritorialScope").ToList();
                    var territorialScopeList = new List<TerritorialScope>();
                    foreach (var item in list)
                    {
                        territorialScopeList.Add(new TerritorialScope
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Region").ToList();
                    var regionList = new List<RegionDto>();
                    foreach (var item in list)
                    {
                        regionList.Add(new RegionDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive),
                            IsDefault = bool.Parse(item.IsDefault)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Currency").ToList();
                    var currencyList = new List<CurrencyDto>();
                    foreach (var item in list)
                    {
                        currencyList.Add(new CurrencyDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_Branch").ToList();
                    var branchList = new List<BranchDto>();
                    foreach (var item in list)
                    {
                        branchList.Add(new BranchDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_ProductDetailsPOI_Section").ToList();
                    var productDetailsPOISectionList = new List<ProductDetailsPOISectionDto>();
                    foreach (var item in list)
                    {
                        productDetailsPOISectionList.Add(new ProductDetailsPOISectionDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive),
                            //IsDefault = bool.Parse(item.IsDefault)
                            BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_ProductClassOfCoverage").ToList();
                    var productClassOfCoverageList = new List<ProductClassOfCoverageDto>();
                    foreach (var item in list)
                    {
                        productClassOfCoverageList.Add(new ProductClassOfCoverageDto
                        {
                            RecId = item.RecId,
                            Code = item.Code,
                            Description = item.Description,
                            IsActive = bool.Parse(item.IsActive)
                            //BranchCategoryClassId = int.Parse(item.BranchCategoryClassId)
                        });
                    }

                    list = lookupList.FindAll(e => e.TableName == "t_ProductDetailsPOI_Network").ToList();
                    var productDetailsPOINetworkList = new List<ProductDetailsPOINetwork>();
                    foreach (var item in list)
                    {
                        productDetailsPOINetworkList.Add(new ProductDetailsPOINetwork
                        {
                            RecId = item.RecId,
                            ThirdPartyAdminId = int.Parse(item.Description),
                            NetworkLevel = int.Parse(item.IsActive),
                            NetworkName = item.IsDefault,
                            NetworkExplanation = item.BranchCategoryClassId
                        });
                    }

                    resp.Branch = branchList;
                    resp.Region = regionList;
                    resp.Currency = currencyList;
                    resp.ThirdPartyAdmin = thirdPartyAdminList;
                    resp.Insurer = insurerList;
                    resp.TerritorialScope = territorialScopeList;
                    resp.ProductDetailsPOISection = productDetailsPOISectionList;
                    resp.ProductClassOfCoverage = productClassOfCoverageList;
                    resp.ProductDetailsPOINetwork = productDetailsPOINetworkList;

                    //resp.Channel = channelList;
                }
                if (lookupList != null && lookupList.Count > 0)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = lookupList[0].Reserved1 != null ? lookupList[0].Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = lookupList == null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productLookupFindAllReq.WebRequestCommon.CorrelationId;
                    if (lookupList[0].Reserved1 != null)
                    {
                        resp.Insurer = new List<InsurerDto>();
                        resp.Region = new List<RegionDto>();
                        resp.ThirdPartyAdmin = new List<ThirdPartyAdminDto>();
                        resp.Currency = new List<CurrencyDto>();
                        resp.Branch = new List<BranchDto>();
                        resp.TerritorialScope = new List<TerritorialScope>();
                        resp.ProductDetailsPOISection = new List<ProductDetailsPOISectionDto>();
                        resp.ProductClassOfCoverage = new List<ProductClassOfCoverageDto>();
                        resp.ProductDetailsPOINetwork = new List<ProductDetailsPOINetwork>();
                    }
                }

                else
                {
                    //resp.
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductLookupFindAll is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productLookupFindAllReq.WebRequestCommon.CorrelationId;
                //resp.Lookup = new List<LookupDto>();
                //CorrelationId = channelFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult ProductFullNewRec(ProductFullNewRecReq productFullNewRecReq)
        {
            ProductFullResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductFull = new ProductFullDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = productFullNewRecReq == null ? Guid.NewGuid().ToString() :
                        productFullNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productFullNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productFullNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productFullNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productFullNewRecReq.WebRequestCommon.CorrelationId, productFullNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductFullNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productFullNewRecReq));
                resp.ProductFull = InstManagerAccessPoint.GetNewAccessPoint().ProductFullNewRec(productFullNewRecReq.ProductFull, productFullNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductFull != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductFull.Reserved1 != null ? resp.ProductFull.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductFull.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productFullNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductFull.Reserved1 != null)
                        resp.ProductFull = new ProductFullDto() { RecId = -1 };
                    //{
                    //    Code= regionNewRecReq.Region.Code,
                    //    Description= regionNewRecReq.Region.Description,
                    //    IsActive= regionNewRecReq.Region.IsActive                            
                    //};
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ProductFullNewRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productFullNewRecReq.WebRequestCommon.CorrelationId;
                resp.ProductFull = new ProductFullDto { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductFullFindWithRecIdFilter(ProductFindWithRecIdFilterReq productFindWithRecIdFilterReq)
        {
            ProductFullResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductFull = new ProductFullDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                       .SelectMany(v => v.Errors)
                       .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = productFindWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
                        productFindWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId, productFindWithRecIdFilterReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductFullFindWithRecIdFilter is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productFindWithRecIdFilterReq));

                resp.ProductFull = InstManagerAccessPoint.GetNewAccessPoint().ProductFullFindWithRecIdFilter(productFindWithRecIdFilterReq.RecId);
                resp.ProductFull.ProductDetails = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsFindWithProductIdFilter(productFindWithRecIdFilterReq.RecId);
                resp.ProductFull.ProductDetailsPOI = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsPOIFindWithProductIdFilter(productFindWithRecIdFilterReq.RecId);

                if (resp != null && resp.ProductFull != null)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductFull.Reserved1 != null ? resp.ProductFull.Reserved1 : "Enquiry Succeeded";
                    resp.WebResponseCommon.ReturnCode = resp.ProductFull.Reserved1 != null ? StatusCodes.Status204NoContent.ToString() : StatusCodes.Status200OK.ToString();
                    resp.WebResponseCommon.CorrelationId = productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductFull.Reserved1 != null)
                        resp.ProductFull = new ProductFullDto() { RecId = -1 };
                }
                //else
                //{
                //    //resp.
                //}
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductFullFindWithRecIdFilter is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productFindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
                resp.ProductFull = new ProductFullDto() { RecId = -1 };
                //CorrelationId = genderFindAllReq.WebRequestCommon.CorrelationId
                //Region = InstManagerAccessPoint.GetNewAccessPoint().RegionFindAll()
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductFullUpdRec(ProductFullUpdRecReq productFullUpdRecReq)
        {
            ProductFullResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductFull = new ProductFullDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = productFullUpdRecReq == null ? Guid.NewGuid().ToString() :
                            productFullUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            productFullUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            productFullUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            productFullUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(productFullUpdRecReq.WebRequestCommon.CorrelationId, productFullUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductFullUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productFullUpdRecReq));
                resp.ProductFull = InstManagerAccessPoint.GetNewAccessPoint().ProductFullUpdRec(productFullUpdRecReq.ProductFull, productFullUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductFull != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductFull.Reserved1 != null ? resp.ProductFull.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.ProductFull.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = productFullUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductFull.Reserved1 != null)
                        resp.ProductFull = new ProductFullDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductFullUpdRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productFullUpdRecReq.WebRequestCommon.CorrelationId;
                resp.ProductFull = new ProductFullDto() { RecId = -1 };                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductFullUpdIsActiveRec(ProductFullUpdIsActiveRecReq productFullUpdIsActiveRecReq)
        {
            ProductFullResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductFull = new ProductFullDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = productFullUpdIsActiveRecReq == null ? Guid.NewGuid().ToString() :
                            productFullUpdIsActiveRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            productFullUpdIsActiveRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            productFullUpdIsActiveRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            productFullUpdIsActiveRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(productFullUpdIsActiveRecReq.WebRequestCommon.CorrelationId, productFullUpdIsActiveRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductFullUpdIsActiveRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productFullUpdIsActiveRecReq));
                resp.ProductFull = InstManagerAccessPoint.GetNewAccessPoint().ProductFullUpdIsActiveRec(productFullUpdIsActiveRecReq.ProductId, productFullUpdIsActiveRecReq.IsActive, productFullUpdIsActiveRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductFull != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductFull.Reserved1 != null ? resp.ProductFull.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.ProductFull.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = productFullUpdIsActiveRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductFull.Reserved1 != null)
                        resp.ProductFull = new ProductFullDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductFullUpdIsActiveRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productFullUpdIsActiveRecReq.WebRequestCommon.CorrelationId;
                resp.ProductFull = new ProductFullDto() { RecId = -1 };                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult ProductDetailsNewRec(ProductDetailsNewRecReq productDetailsNewRecReq)
        {
            ProductDetailsResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductDetails = new ProductDetailsDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = productDetailsNewRecReq == null ? Guid.NewGuid().ToString() :
                        productDetailsNewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productDetailsNewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productDetailsNewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productDetailsNewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productDetailsNewRecReq.WebRequestCommon.CorrelationId, productDetailsNewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductDetailsNewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productDetailsNewRecReq));
                resp.ProductDetails = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsNewRec(productDetailsNewRecReq.ProductDetails, productDetailsNewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductDetails != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductDetails.Reserved1 != null ? resp.ProductDetails.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductDetails.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productDetailsNewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductDetails.Reserved1 != null)
                        resp.ProductDetails = new ProductDetailsDto() { RecId = -1 };
                    //{
                    //    Code= regionNewRecReq.Region.Code,
                    //    Description= regionNewRecReq.Region.Description,
                    //    IsActive= regionNewRecReq.Region.IsActive                            
                    //};
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ProductDetailsNewRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productDetailsNewRecReq.WebRequestCommon.CorrelationId;
                resp.ProductDetails = new ProductDetailsDto { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductDetailsUpdRec(ProductDetailsUpdRecReq productDetailsUpdRecReq)
        {
            ProductDetailsResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductDetails = new ProductDetailsDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = productDetailsUpdRecReq == null ? Guid.NewGuid().ToString() :
                            productDetailsUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            productDetailsUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            productDetailsUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            productDetailsUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(productDetailsUpdRecReq.WebRequestCommon.CorrelationId, productDetailsUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductDetailsUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productDetailsUpdRecReq));
                resp.ProductDetails = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsUpdRec(productDetailsUpdRecReq.ProductDetails, productDetailsUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductDetails != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductDetails.Reserved1 != null ? resp.ProductDetails.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.ProductDetails.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = productDetailsUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductDetails.Reserved1 != null)
                        resp.ProductDetails = new ProductDetailsDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductDetailsUpdRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productDetailsUpdRecReq.WebRequestCommon.CorrelationId;
                resp.ProductDetails = new ProductDetailsDto() { RecId = -1 };                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult ProductDetailsPOINewRec(ProductDetailsPOINewRecReq productDetailsPOINewRecReq)
        {
            ProductDetailsPOIResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductDetails = new ProductDetailsPOIDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                    resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    resp.WebResponseCommon.CorrelationId = productDetailsPOINewRecReq == null ? Guid.NewGuid().ToString() :
                        productDetailsPOINewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                        productDetailsPOINewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                        productDetailsPOINewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                        productDetailsPOINewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                    return Ok(resp);
                }
                _logger.SetCorrelationId(productDetailsPOINewRecReq.WebRequestCommon.CorrelationId, productDetailsPOINewRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductDetailsPOINewRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productDetailsPOINewRecReq));
                resp.ProductDetails = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsPOINewRec(productDetailsPOINewRecReq.ProductDetails, productDetailsPOINewRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductDetails != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductDetails.Reserved1 != null ? resp.ProductDetails.Reserved1 : "New record created";
                    resp.WebResponseCommon.ReturnCode = resp.ProductDetails.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
                    resp.WebResponseCommon.CorrelationId = productDetailsPOINewRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductDetails.Reserved1 != null)
                        resp.ProductDetails = new ProductDetailsPOIDto() { RecId = -1 };
                    //{
                    //    Code= regionNewRecReq.Region.Code,
                    //    Description= regionNewRecReq.Region.Description,
                    //    IsActive= regionNewRecReq.Region.IsActive                            
                    //};
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                _logger.LogInfo("Calling the Endpoint ProductDetailsPOINewRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productDetailsPOINewRecReq.WebRequestCommon.CorrelationId;
                resp.ProductDetails = new ProductDetailsPOIDto { RecId = -1 };
                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }


        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductDetailsPOIUpdRec(ProductDetailsPOIUpdRecReq productDetailsPOIUpdRecReq)
        {
            ProductDetailsPOIResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductDetails = new ProductDetailsPOIDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = productDetailsPOIUpdRecReq == null ? Guid.NewGuid().ToString() :
                            productDetailsPOIUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            productDetailsPOIUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            productDetailsPOIUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            productDetailsPOIUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(productDetailsPOIUpdRecReq.WebRequestCommon.CorrelationId, productDetailsPOIUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductDetailsPOIUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productDetailsPOIUpdRecReq));
                resp.ProductDetails = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsPOIUpdRec(productDetailsPOIUpdRecReq.ProductDetails, productDetailsPOIUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductDetails != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductDetails.Reserved1 != null ? resp.ProductDetails.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.ProductDetails.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = productDetailsPOIUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductDetails.Reserved1 != null)
                        resp.ProductDetails = new ProductDetailsPOIDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductDetailsPOIUpdRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productDetailsPOIUpdRecReq.WebRequestCommon.CorrelationId;
                resp.ProductDetails = new ProductDetailsPOIDto() { RecId = -1 };                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }

        [HttpPost]
        //[AuthorizeAttribute]
        public IActionResult ProductDetailsPOINetworkUpdRec(ProductDetailsPOINetworkUpdRecReq productDetailsPOINetworkUpdRecReq)
        {
            ProductDetailsPOINetworkResp resp;

            resp = new()
            {
                WebResponseCommon = new()
                {
                },
                ProductDetailsPOINetwork = new ProductDetailsPOINetworkDto() { RecId = -1 }
            };
            try
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        resp.WebResponseCommon.SuccessIndicator = "Success";
                        resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
                        resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                        resp.WebResponseCommon.CorrelationId = productDetailsPOINetworkUpdRecReq == null ? Guid.NewGuid().ToString() :
                            productDetailsPOINetworkUpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
                            productDetailsPOINetworkUpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
                            productDetailsPOINetworkUpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
                            productDetailsPOINetworkUpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

                        return Ok(resp);
                    }
                }
                _logger.SetCorrelationId(productDetailsPOINetworkUpdRecReq.WebRequestCommon.CorrelationId, productDetailsPOINetworkUpdRecReq.WebRequestCommon.UserName);
                _logger.LogInfo("Calling the Endpoint ProductDetailsPOINetworkUpdRec is started");
                _logger.LogDebug(JsonConvert.SerializeObject(productDetailsPOINetworkUpdRecReq));
                resp.ProductDetailsPOINetwork = InstManagerAccessPoint.GetNewAccessPoint().ProductDetailsPOINetworkUpdRec(productDetailsPOINetworkUpdRecReq.ProductDetailsPOINetwork, productDetailsPOINetworkUpdRecReq.WebRequestCommon.UserName);

                if (resp != null && resp.ProductDetailsPOINetwork != null)// && resp.Region.Count == 1)
                {
                    resp.WebResponseCommon.SuccessIndicator = "Success";
                    resp.WebResponseCommon.ReturnMessage = resp.ProductDetailsPOINetwork.Reserved1 != null ? resp.ProductDetailsPOINetwork.Reserved1 : "Record updated";
                    resp.WebResponseCommon.ReturnCode = resp.ProductDetailsPOINetwork.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status202Accepted.ToString();
                    resp.WebResponseCommon.CorrelationId = productDetailsPOINetworkUpdRecReq.WebRequestCommon.CorrelationId;
                    if (resp.ProductDetailsPOINetwork.Reserved1 != null)
                        resp.ProductDetailsPOINetwork = new ProductDetailsPOINetworkDto() { RecId = -1 };
                }
                else
                {
                    //
                }
                _logger.LogDebug(JsonConvert.SerializeObject(resp));

                _logger.LogInfo("Calling the Endpoint ProductDetailsPOINetworkUpdRec is completed");

                return Ok(resp);
                // UserCredDao t = new UserCredDao();
                //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error", ex);
                resp.WebResponseCommon.SuccessIndicator = "Error";
                resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
                resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
                resp.WebResponseCommon.CorrelationId = productDetailsPOINetworkUpdRecReq.WebRequestCommon.CorrelationId;
                resp.ProductDetailsPOINetwork = new ProductDetailsPOINetworkDto() { RecId = -1 };                //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
                _logger.LogDebug(JsonConvert.SerializeObject(resp));
                return Ok(resp);
            }
        }
    }
}
