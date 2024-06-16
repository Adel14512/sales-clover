using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IUtil;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Evaluation.UI.Controllers
{
    public class SlipController : Controller
    {
     
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly ISlipApi _slipApi;
        private readonly ITransactionApi _transactionApi;
        private readonly IConvertFromToExcel _convertFromToExcel;
        public SlipController(IUserApi userApi, IGlobal global, ISlipApi slipApi, ITransactionApi transactionApi, IConvertFromToExcel convertFromToExcel)
        {
            _userApi = userApi;
            _global = global;
            _slipApi = slipApi;
            _transactionApi = transactionApi;
            _convertFromToExcel = convertFromToExcel;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110UpdSlip2(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110UpdSlip2RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110UpdSlip2RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110UpdSlip2(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110UpdSlip3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110UpdSlip3RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110UpdSlip3RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110UpdSlip3(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110UpdSlip4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110UpdSlip4RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110UpdSlip4RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110UpdSlip4(requestBody, ct);
            return Ok(result);
        } 
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110UpdSlip5(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110UpdSlip5RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110UpdSlip5RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110UpdSlip5(requestBody, ct);
            return Ok(result);
        } 
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110DetailsUpdSlip2(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110DetailsUpdSlip2RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110DetailsUpdSlip2RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110DetailsUpdSlip2(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110DetailsUpdSlip3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110DetailsUpdSlip3RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110DetailsUpdSlip3RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110DetailsUpdSlip3(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110DetailsUpdSlip4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110DetailsUpdSlip4RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110DetailsUpdSlip4RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110DetailsUpdSlip4(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL321110DetailsPricesNewRec(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL321110DetailsPricesNewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL321110DetailsPricesNewRecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL321110DetailsPricesNewRec(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelStep4AF32(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<Slip4BL321110Dto> data = JsonConvert.DeserializeObject<List<Slip4BL321110Dto>>(keyValues["data"]);
               
                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "BN";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelAF32SlipStep4(resFile.BusinessLineRelatedDoc.AttachDocBinary, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Benefit_List_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelDetailsStep5AF32(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<SalesTransactionDetailsPricesNewDto> data = JsonConvert.DeserializeObject<List<SalesTransactionDetailsPricesNewDto>>(keyValues["data"]);

                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "PL";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelAF32DetailsStep5(resFile.BusinessLineRelatedDoc.AttachDocBinary, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Price_List_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelDetailsStep5AF33(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<SalesTransactionBL331211DetailsPricesNewDto> data = JsonConvert.DeserializeObject<List<SalesTransactionBL331211DetailsPricesNewDto>>(keyValues["data"]);

                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "PL";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelAF33DetailsStep5(resFile.BusinessLineRelatedDoc.AttachDocBinary, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Price_List_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelDetailsStep5AF04(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<SalesTransactionBL331211DetailsPricesNewDto> data = JsonConvert.DeserializeObject<List<SalesTransactionBL331211DetailsPricesNewDto>>(keyValues["data"]);

                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "PL";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelAF33DetailsStep5(resFile.BusinessLineRelatedDoc.AttachDocBinary, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Price_List_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211UpdSlip2(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211UpdSlip2RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211UpdSlip2RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211UpdSlip2(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211UpdSlip3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211UpdSlip3RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211UpdSlip3RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211UpdSlip3(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211UpdSlip4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211UpdSlip4RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211UpdSlip4RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211UpdSlip4(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211UpdSlip5(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211UpdSlip5RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211UpdSlip5RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211UpdSlip5(requestBody, ct);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211DetailsUpdSlip3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211DetailsUpdSlip3RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211DetailsUpdSlip3RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211DetailsUpdSlip3(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211DetailsUpdSlip4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211DetailsUpdSlip4RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211DetailsUpdSlip4RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211DetailsUpdSlip4(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL331211DetailsPricesNewRec(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL331211DetailsPricesNewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL331211DetailsPricesNewRecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL331211DetailsPricesNewRec(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelStep4AF33(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<Slip4BL331211Dto> data = JsonConvert.DeserializeObject<List<Slip4BL331211Dto>>(keyValues["data"]);

                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "BN";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelAF33SlipStep4(resFile.BusinessLineRelatedDoc.AttachDocBinary, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Benefit_List_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelStep4AF04(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<Slip4BL331211Dto> data = JsonConvert.DeserializeObject<List<Slip4BL331211Dto>>(keyValues["data"]);

                string businesLineID = keyValues["businesscode"].ToString();
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = "BN";
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                bytes = await _convertFromToExcel.ConvetFormToExcelAF33SlipStep4(resFile.BusinessLineRelatedDoc.AttachDocBinary, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Benefit_List_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312UpdSlip2(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312UpdSlip2RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312UpdSlip2RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312UpdSlip2(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312UpdSlip3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312UpdSlip3RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312UpdSlip3RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312UpdSlip3(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312UpdSlip4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312UpdSlip4RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312UpdSlip4RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312UpdSlip4(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312UpdSlip5(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312UpdSlip5RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312UpdSlip5RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312UpdSlip5(requestBody, ct);
            return Ok(result);
        }
                [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312DetailsUpdSlip3(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312DetailsUpdSlip3RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312DetailsUpdSlip3RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312DetailsUpdSlip3(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312DetailsUpdSlip4(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312DetailsUpdSlip4RecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312DetailsUpdSlip4RecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312DetailsUpdSlip4(requestBody, ct);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> SalesTransactionBL041312DetailsPricesNewRec(IFormCollection keyValues, CancellationToken ct)
        {
            var user = await _userApi.GetUserClaims(User.Claims);
            SalesTransactionBL041312DetailsPricesNewRecReq requestBody = JsonConvert.DeserializeObject<SalesTransactionBL041312DetailsPricesNewRecReq>(keyValues["slip"]);
            requestBody.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
            requestBody.WebRequestCommon.UserName = user.EmailAdress;
            var result = await _slipApi.SalesTransactionBL041312DetailsPricesNewRec(requestBody, ct);
            return Ok(result);
        }
    }
}
