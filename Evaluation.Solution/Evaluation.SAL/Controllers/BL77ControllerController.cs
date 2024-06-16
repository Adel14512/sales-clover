using Evaluation.BAL.AccessPoint;
using Evaluation.CAL.DTO.BL77;
using Evaluation.CAL.Request.BL77;
using Evaluation.CAL.Response.BL77;
using Evaluation.CAL.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evaluation.SAL.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BL77Controller : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public BL77Controller(ILoggerManager logger)
        {
            _logger = logger;
        }

        //[HttpPost]
        //public IActionResult SalesTransactionBL77NewRec([FromBody] SalesTransactionBL77NewRecReq salesTransactionBL77NewRecReq)
        //{
        //    SalesTransactionBL77Resp resp;
        //    resp = new()
        //    {
        //        WebResponseCommon = new()
        //        {
        //        },
        //        SalesTransactionBL77 = new SalesTransactionBL77Dto() { RecId = -1 }
        //    };

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
        //            resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77NewRecReq == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77NewRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77NewRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77NewRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
        //                salesTransactionBL77NewRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

        //            return Ok(resp);
        //        }
        //        _logger.SetCorrelationId(salesTransactionBL77NewRecReq.WebRequestCommon.CorrelationId, salesTransactionBL77NewRecReq.WebRequestCommon.UserName);
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77NewRec is started");
        //        _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL77NewRecReq));
        //        resp.SalesTransactionBL77 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL77NewRec(salesTransactionBL77NewRecReq.BusinessLineId, salesTransactionBL77NewRecReq.ContactId, salesTransactionBL77NewRecReq.AF1BL77, salesTransactionBL77NewRecReq.WebRequestCommon.UserName);

        //        if (resp != null)// && resp.Region.Count == 1)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL77.Reserved1 != null ? resp.SalesTransactionBL77.Reserved1 : "New record created";
        //            resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL77.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77NewRecReq.WebRequestCommon.CorrelationId;
        //            if (resp.SalesTransactionBL77.Reserved1 != null)
        //                resp.SalesTransactionBL77 = new SalesTransactionBL77Dto() { RecId = -1 };
        //            //{
        //            //    Code= regionNewRecReq.Region.Code,
        //            //    Description= regionNewRecReq.Region.Description,
        //            //    IsActive= regionNewRecReq.Region.IsActive                            
        //            //};
        //        }
        //        else
        //        {
        //            //
        //        }
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77NewRec is completed");

        //        return Ok(resp);
        //        // UserCredDao t = new UserCredDao();
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error", ex);
        //        resp.WebResponseCommon.SuccessIndicator = "Error";
        //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
        //        resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
        //        resp.WebResponseCommon.CorrelationId = salesTransactionBL77NewRecReq.WebRequestCommon.CorrelationId;
        //        resp.SalesTransactionBL77 = new SalesTransactionBL77Dto() { RecId = -1 };
        //        //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        return Ok(resp);
        //        //jjjj
        //    }
        //}

        //[HttpPost]
        //public IActionResult SalesTransactionBL77UpdRec([FromBody] SalesTransactionBL77UpdRecReq salesTransactionBL77UpdRecReq)
        //{
        //    SalesTransactionBL77Resp resp;
        //    resp = new()
        //    {
        //        WebResponseCommon = new()
        //        {
        //        },
        //        SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //        {
        //            RecId = -1,
        //            AF1BL77 = new List<AF1BL77Dto>()
        //        }
        //    };

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
        //            resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77UpdRecReq == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77UpdRecReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77UpdRecReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77UpdRecReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
        //                salesTransactionBL77UpdRecReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

        //            return Ok(resp);
        //        }
        //        _logger.SetCorrelationId(salesTransactionBL77UpdRecReq.WebRequestCommon.CorrelationId, salesTransactionBL77UpdRecReq.WebRequestCommon.UserName);
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77UpdRec is started");
        //        _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL77UpdRecReq));
        //        resp.SalesTransactionBL77 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL77UpdRec(salesTransactionBL77UpdRecReq.RecId, salesTransactionBL77UpdRecReq.AF1BL77, salesTransactionBL77UpdRecReq.WebRequestCommon.UserName);

        //        if (resp != null)// && resp.Region.Count == 1)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL77.Reserved1 != null ? resp.SalesTransactionBL77.Reserved1 : "New record created";
        //            resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL77.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77UpdRecReq.WebRequestCommon.CorrelationId;
        //            if (resp.SalesTransactionBL77.Reserved1 != null)
        //                resp.SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //                {
        //                    RecId = -1,
        //                    AF1BL77 = new List<AF1BL77Dto>()
        //                };
        //            //{
        //            //    Code= regionNewRecReq.Region.Code,
        //            //    Description= regionNewRecReq.Region.Description,
        //            //    IsActive= regionNewRecReq.Region.IsActive                            
        //            //};
        //        }
        //        else
        //        {
        //            //
        //        }
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77UpdRec is completed");

        //        return Ok(resp);
        //        // UserCredDao t = new UserCredDao();
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error", ex);
        //        resp.WebResponseCommon.SuccessIndicator = "Error";
        //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
        //        resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
        //        resp.WebResponseCommon.CorrelationId = salesTransactionBL77UpdRecReq.WebRequestCommon.CorrelationId;
        //        resp.SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //        {
        //            RecId = -1,
        //            AF1BL77 = new List<AF1BL77Dto>()
        //        };
        //        //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        return Ok(resp);
        //    }
        //}
        //[HttpPost]
        //public IActionResult SalesTransactionBL77FindWithRecIdFilter([FromBody] SalesTransactionBL77FindWithRecIdFilterReq salesTransactionBL77FindWithRecIdFilterReq)
        //{
        //    SalesTransactionBL77Resp resp;
        //    resp = new()
        //    {
        //        WebResponseCommon = new()
        //        {
        //        },
        //        SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //        {
        //            RecId = -1,
        //            AF1BL77 = new List<AF1BL77Dto>()
        //        }
        //    };

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
        //            resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77FindWithRecIdFilterReq == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
        //                salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

        //            return Ok(resp);
        //        }
        //        _logger.SetCorrelationId(salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.UserName);
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77FindWithRecIdFilter is started");
        //        _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL77FindWithRecIdFilterReq));
        //        resp.SalesTransactionBL77 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL77FindWithRecIdFilter(salesTransactionBL77FindWithRecIdFilterReq.RecId);

        //        if (resp != null)// && resp.Region.Count == 1)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL77.Reserved1 != null ? resp.SalesTransactionBL77.Reserved1 : "New record created";
        //            resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL77.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
        //            if (resp.SalesTransactionBL77.Reserved1 != null)
        //                resp.SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //                {
        //                    RecId = -1,
        //                    AF1BL77 = new List<AF1BL77Dto>()
        //                };
        //            //{
        //            //    Code= regionNewRecReq.Region.Code,
        //            //    Description= regionNewRecReq.Region.Description,
        //            //    IsActive= regionNewRecReq.Region.IsActive                            
        //            //};
        //        }
        //        else
        //        {
        //            //
        //        }
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77FindWithRecIdFilter is completed");
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        return Ok(resp);
        //        // UserCredDao t = new UserCredDao();
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error", ex);
        //        resp.WebResponseCommon.SuccessIndicator = "Error";
        //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
        //        resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
        //        resp.WebResponseCommon.CorrelationId = salesTransactionBL77FindWithRecIdFilterReq.WebRequestCommon.CorrelationId;
        //        resp.SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //        {
        //            RecId = -1,
        //            AF1BL77 = new List<AF1BL77Dto>()
        //        };
        //        //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
        //        return Ok(resp);
        //    }
        //}

        //[HttpPost]
        //public IActionResult SalesTransactionBL77FindWithColFilter([FromBody] SalesTransactionBL77FindWithColFilterReq salesTransactionBL77FindWithColFilterReq)
        //{
        //    SalesTransactionBL77Resp resp;
        //    resp = new()
        //    {
        //        WebResponseCommon = new()
        //        {
        //        },
        //        SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //        {
        //            RecId = -1,
        //            AF1BL77 = new List<AF1BL77Dto>()
        //        }
        //    };

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnCode = StatusCodes.Status400BadRequest.ToString();
        //            resp.WebResponseCommon.ReturnMessage = "Bad Request;" + string.Join(" | ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77FindWithColFilterReq == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77FindWithColFilterReq.WebRequestCommon == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77FindWithColFilterReq.WebRequestCommon.CorrelationId == null ? Guid.NewGuid().ToString() :
        //                salesTransactionBL77FindWithColFilterReq.WebRequestCommon.CorrelationId.Trim() != string.Empty ?
        //                salesTransactionBL77FindWithColFilterReq.WebRequestCommon.CorrelationId : Guid.NewGuid().ToString();

        //            return Ok(resp);
        //        }
        //        _logger.SetCorrelationId(salesTransactionBL77FindWithColFilterReq.WebRequestCommon.CorrelationId, salesTransactionBL77FindWithColFilterReq.WebRequestCommon.UserName);
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77FindWithColFilter is started");
        //        _logger.LogDebug(JsonConvert.SerializeObject(salesTransactionBL77FindWithColFilterReq));
        //        resp.SalesTransactionBL77 = InstManagerAccessPoint.GetNewAccessPoint().SalesTransactionBL77FindWithColFilter
        //            (salesTransactionBL77FindWithColFilterReq.BusinessLineId,
        //            salesTransactionBL77FindWithColFilterReq.ContactId);

        //        if (resp != null)// && resp.Region.Count == 1)
        //        {
        //            resp.WebResponseCommon.SuccessIndicator = "Success";
        //            resp.WebResponseCommon.ReturnMessage = resp.SalesTransactionBL77.Reserved1 != null ? resp.SalesTransactionBL77.Reserved1 : "New record created";
        //            resp.WebResponseCommon.ReturnCode = resp.SalesTransactionBL77.Reserved1 != null ? StatusCodes.Status302Found.ToString() : StatusCodes.Status201Created.ToString();
        //            resp.WebResponseCommon.CorrelationId = salesTransactionBL77FindWithColFilterReq.WebRequestCommon.CorrelationId;
        //            if (resp.SalesTransactionBL77.Reserved1 != null)
        //                resp.SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //                {
        //                    RecId = -1,
        //                    AF1BL77 = new List<AF1BL77Dto>()
        //                };
        //            //{
        //            //    Code= regionNewRecReq.Region.Code,
        //            //    Description= regionNewRecReq.Region.Description,
        //            //    IsActive= regionNewRecReq.Region.IsActive                            
        //            //};
        //        }
        //        else
        //        {
        //            //
        //        }
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        _logger.LogInfo("Calling the Endpoint SalesTransactionBL77FindWithColFilter is completed");

        //        return Ok(resp);
        //        // UserCredDao t = new UserCredDao();
        //        //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error", ex);
        //        resp.WebResponseCommon.SuccessIndicator = "Error";
        //        resp.WebResponseCommon.ReturnCode = StatusCodes.Status500InternalServerError.ToString();
        //        resp.WebResponseCommon.ReturnMessage = "Internal Server Error";
        //        resp.WebResponseCommon.CorrelationId = salesTransactionBL77FindWithColFilterReq.WebRequestCommon.CorrelationId;
        //        resp.SalesTransactionBL77 = new SalesTransactionBL77Dto()
        //        {
        //            RecId = -1,
        //            AF1BL77 = new List<AF1BL77Dto>()
        //        };
        //        //CorrelationId = regionFindAllReq.WebRequestCommon.CorrelationId
        //        _logger.LogDebug(JsonConvert.SerializeObject(resp));
        //        return Ok(resp);
        //    }
        //}
    }
}