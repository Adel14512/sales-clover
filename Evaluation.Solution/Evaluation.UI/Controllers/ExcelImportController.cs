using Evaluation.UI.DTO.BL021502;
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.DTO.BL051807;
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL311703;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.DTO.Product;
using Evaluation.UI.ExcelImportModel;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Request;
using Evaluation.UI.Request.AF1ColHeader;
using Evaluation.UI.Response;
using Evaluation.UI.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Globalization;
using Spire.Pdf;
using Spire.Xls;
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.DTO.BL030904;
using Evaluation.UI.DTO.BL061005;
using Evaluation.UI.Consume.Api;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Request.BL041312;

namespace Evaluation.UI.Controllers
{
    public class ExcelImportController : Controller
    {
        private readonly ITransactionApi _transactionApi;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConvertFromToExcel _convertFromToExcel;
        private readonly IGeneralListApi _generalApi;
        private readonly IUserApi _userApi;
        private readonly IProductApi _productApi;
        private readonly IGlobal _global;
        private readonly IBusinessLineApi _businessLineApi;
        private readonly IComparitiveQuotationBusiness _comparitiveQuotationBusiness;
        private readonly ILogger<ExcelImportController> _logger;

        public ExcelImportController(IWebHostEnvironment hostingEnvironment, IConvertFromToExcel convertFromToExcel, ILogger<ExcelImportController> logger, ITransactionApi transactionApi, IGeneralListApi generalApi, IUserApi userApi, IProductApi productApi, IComparitiveQuotationBusiness comparitiveQuotationBusiness, IBusinessLineApi businessLineApi, IGlobal global)
        {
            _hostingEnvironment = hostingEnvironment;
            _convertFromToExcel = convertFromToExcel;
            _logger = logger;
            _transactionApi = transactionApi;
            _generalApi = generalApi;
            _userApi = userApi;
            _productApi = productApi;
            _comparitiveQuotationBusiness = comparitiveQuotationBusiness;
            _businessLineApi = businessLineApi;
            _global = global;
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        dataTable.Columns.Add(firstRowCell.Value.ToString());
                    }
                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1Bl77EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1Bl77EM record = new Af1Bl77EM();

                        record.Serial = int.Parse(row["SERIAL"].ToString());
                        if (int.TryParse(row["SERIAL"]?.ToString(), out int nbr))
                        {
                            record.Serial = nbr;
                        }
                        else
                        {
                            record.Serial = 0; // or set it to some default value
                        }
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        //if (int.TryParse(row["STAFF NO."]?.ToString(), out int nbr2))
                        //{
                        //    record.StaffNbr = nbr2;
                        //}
                        //else
                        //{
                        //    record.StaffNbr = null; // or set it to some default value
                        //}
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.GenderCode = row["GENDER"].ToString();
                        record.DOB = DateTime.Parse(row["DOB"].ToString()).ToString("yyyy-MM-dd");

                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.CountryOfDepartureCode = row["Country of Departure"].ToString();
                        record.CountryOfDestinationCode = row["Country Of Destination"].ToString();
                        record.StayTripOption = row["Stay/Trip Option"].ToString();
                        if (int.TryParse(row["No. Of Days When Less Than 92 Days"]?.ToString(), out int nbr1))
                        {
                            record.NbrDaysWhenLess92 = nbr1;
                        }
                        else
                        {
                            record.NbrDaysWhenLess92 = null; // or set it to some default value
                        }

                        // Add additional columns as needed

                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_30(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = code;
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_30EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_30EM record = new Af1_30EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.ClientName = row["CLIENT NAME"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        record.DOB = GetDateFromString(row["DOB"]?.ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.RelationCode = row["RELATION"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.NSSF = row["NSSF"].ToString();
                        record.ClassOfCoveragCode = row["CLASS OF COVERAGE"].ToString();
                        record.Ambulatory = row["AMBULATORY"].ToString();
                        record.PrescriptionMedecine = row["PRESCRIPTION MEDICINE"].ToString();
                        record.DoctorVisit = row["DOCTOR VISIT"].ToString();
                        record.NetworkLevelCode = row["Network"].ToString();

                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_31(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_31";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_31EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_31EM record = new Af1_31EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.ClientName = row["CLIENT NAME"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        //record.DOB = DateTime.Parse(row["DOB"].ToString()).ToString("yyyy-MM-dd");
                        record.DOB = GetDateFromString(row["DOB"].ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.RelationCode = row["RELATION"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.NSSF = row["NSSF"].ToString();
                        record.ClassOfCoveragCode = row["CLASS OF COVERAGE"].ToString();
                        record.Ambulatory = row["AMBULATORY"].ToString();
                        record.PrescriptionMedecine = row["PRESCRIPTION MEDICINE"].ToString();


                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_4(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_4";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_4EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_4EM record = new Af1_4EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        // record.DOB = DateTime.Parse(row["DOB"].ToString()).ToString("yyyy-MM-dd");
                        record.DOB = GetDateFromString(row["DOB"].ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.Grade = row["GRADE"].ToString();
                        record.Currency = row["Currency"].ToString();
                    //    record.AnnualWages = row["Annual Wages"].ToString();
                        record.LimitOfCoverage = row["Limit of Coverage"].ToString();
                        record.MobileNumber = row["Mobile"].ToString();
                        record.Email = row["Email"].ToString();
                        record.Shop = row["Shop"].ToString();
                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_28(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_28";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_28EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_28EM record = new Af1_28EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.SponsorName = row["Sponsor Name"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        record.DOB = GetDateFromString(row["DOB"].ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();


                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_5(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = code;
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_5EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_5EM record = new Af1_5EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO. *"].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME *"].ToString();
                        //r = DateTime.Parse(row["DOB (DD/MM/YYYY)"].ToString()).ToString("dd-MM-yyyy");
                        record.DOB = GetDateFromString(row["DOB (DD/MM/YYYY)"]?.ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.Currency = row["Currency"].ToString();
                        record.AnnualWages = row["Annual Wages"].ToString();
                        record.LimitOfCoverage = row["Limit of Coverage"].ToString();
                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_29(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = code;
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_29EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_29EM record = new Af1_29EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO. *"].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME *"].ToString();
                        //r = DateTime.Parse(row["DOB (DD/MM/YYYY)"].ToString()).ToString("dd-MM-yyyy");
                        record.DOB = GetDateFromString(row["DOB (DD/MM/YYYY)"]?.ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.Currency = row["Currency"].ToString();
                        record.AnnualWages = row["Annual Wages"].ToString();
                        record.LimitOfCoverage = row["Limit of Coverage"].ToString();
                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_33(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_33";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        try
                        {
                            var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                            var newRow = dataTable.NewRow();
                            foreach (var cell in row)
                            {
                                if (cell.Value != null)
                                    newRow[cell.Start.Column - 1] = cell.Value;
                            }
                            dataTable.Rows.Add(newRow);
                        }
                        catch (Exception e)
                        {

                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_33EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_33EM record = new Af1_33EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        //r = DateTime.Parse(row["DOB (DD/MM/YYYY)"].ToString()).ToString("dd-MM-yyyy");
                        record.DOB = GetDateFromString(row["DOB"]?.ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.Grade = row["GRADE"].ToString();
                        record.Currency = row["Currency"].ToString();
                        //record.AnnualWages = row["Annual Wages"].ToString();
                        record.LimitOfCoverage = row["Limit of Coverage"].ToString();
                        record.MobileNumber = row["Mobile"].ToString();
                        record.Email = row["Email"].ToString();
                        record.Shop = row["Shop"].ToString();
                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_04(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_4";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        try
                        {
                            var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                            var newRow = dataTable.NewRow();
                            foreach (var cell in row)
                            {
                                if (cell.Value != null)
                                    newRow[cell.Start.Column - 1] = cell.Value;
                            }
                            dataTable.Rows.Add(newRow);
                        }
                        catch (Exception e)
                        {

                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_4EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_4EM record = new Af1_4EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        //r = DateTime.Parse(row["DOB (DD/MM/YYYY)"].ToString()).ToString("dd-MM-yyyy");
                        record.DOB = GetDateFromString(row["DOB"]?.ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.Grade = row["GRADE"].ToString();
                        record.Currency = row["Currency"].ToString();
                        //record.AnnualWages = row["Annual Wages"].ToString();
                        record.LimitOfCoverage = row["Limit of Coverage"].ToString();
                        record.MobileNumber = row["Mobile"].ToString();
                        record.Email = row["Email"].ToString();
                        record.Shop = row["Shop"].ToString();
                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelProductPrice(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }

                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_33";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        try
                        {
                            var cell1 = worksheet.Cells[rowNumber, 2].Value; // Second column
                            var cell2 = worksheet.Cells[rowNumber, 3].Value; // Third column

                            // Check if both second and third columns are not empty
                            if (cell1 != null && cell2 != null)
                            {
                                var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                                var newRow = dataTable.NewRow();

                                foreach (var cell in row)
                                {
                                    if (cell.Value != null)
                                        newRow[cell.Start.Column - 1] = cell.Value;
                                }

                                dataTable.Rows.Add(newRow);
                            }
                        }
                        catch (Exception e)
                        {
                            // Handle exceptions if needed
                        }
                    }

                    // Use the data table to retrieve the records
                    var records = new List<ProductPriceEM>();
                    foreach (DataRow row in dataTable.Rows)
                    {

                        ProductPriceEM record = new ProductPriceEM();
                        if (dataTable.Columns.Contains("RecId"))
                            record.RecId = row["RecId"].ToString();
                        if (code.IsNullOrEmpty())
                        {
                            if (dataTable.Columns.Contains("ProductId"))
                                record.ProductId = row["ProductId"].ToString();
                        }
                        else
                        {
                            if (dataTable.Columns.Contains("ProductId"))
                                record.ProductId = code;
                        }

                        if (dataTable.Columns.Contains("TechnicalSheet"))
                            record.TechnicalSheet = row["TechnicalSheet"].ToString();
                        if (dataTable.Columns.Contains("FamilyCountMinRange"))
                            record.FamilyCountMinRange = row["FamilyCountMinRange"].ToString();
                        if (dataTable.Columns.Contains("FamilyCountMaxRange"))
                            record.FamilyCountMaxRange = row["FamilyCountMaxRange"].ToString();
                        if (dataTable.Columns.Contains("Dependency"))
                            record.Dependency = row["Dependency"].ToString();
                        if (dataTable.Columns.Contains("Period"))
                            record.Period = row["Period"].ToString();
                        if (dataTable.Columns.Contains("Gender"))
                            record.Gender = row["Gender"].ToString();
                        if (dataTable.Columns.Contains("AgeMinRange"))
                            record.AgeMinRange = row["AgeMinRange"].ToString();
                        if (dataTable.Columns.Contains("AgeMaxRange"))
                            record.AgeMaxRange = row["AgeMaxRange"].ToString();
                        if (dataTable.Columns.Contains("DaysCountMinRange"))
                            record.DaysCountMinRange = row["DaysCountMinRange"].ToString();
                        if (dataTable.Columns.Contains("DaysCountMaxRange"))
                            record.DaysCountMaxRange = row["DaysCountMaxRange"].ToString();
                        if (dataTable.Columns.Contains("MaritalStatus"))
                            record.MaritalStatus = row["MaritalStatus"].ToString();
                        if (dataTable.Columns.Contains("CostSharing"))
                            record.CostSharing = row["CostSharing"].ToString();
                        if (dataTable.Columns.Contains("Premium"))
                            record.Premium = row["Premium"].ToString();
                        if (dataTable.Columns.Contains("Pa_Premium"))
                            record.PaPremiium = row["Pa_Premium"].ToString();
                        if (dataTable.Columns.Contains("Rate"))
                            record.Rate = row["Rate"].ToString();
                        if (dataTable.Columns.Contains("NbrChildFree"))
                            record.NbrChildFree = row["NbrChildFree"].ToString();

                        records.Add(record);
                        ;
                    }

                    return Ok(new { status = "success", data = records, message = result, columns = records });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        private string GetDateFromString(string dobString)
        {

            // string dobString = row["DOB"]?.ToString();

            if (!string.IsNullOrEmpty(dobString))
            {
                double julianDate;
                if (double.TryParse(dobString, out julianDate))
                {
                    DateTime dob = DateTime.FromOADate(julianDate);
                    return dob.ToString("yyyy-MM-dd");
                }
                else
                {
                    if (!string.IsNullOrEmpty(dobString))
                    {
                        DateTime dob;
                        if (DateTime.TryParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                        {
                            return dob.ToString("yyyy-MM-dd");
                        }
                        else if (DateTime.TryParseExact(dobString, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                        {
                            return dob.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            return DateTime.Parse(dobString).ToString("yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        return String.Empty;// Handle null or empty value
                    }
                }
            }
            else
            {
                return String.Empty; // Handle null or empty value
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_2(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_2";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }

                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            newRow[cell.Start.Column - 1] = cell.Value;
                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_2EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_2EM record = new Af1_2EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        record.NationalityCode = row["Nationality"].ToString();
                        record.DOB = GetDateFromString(row["DOB"].ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.CountryOfDepartureCode = row["Country of Departure"].ToString();
                        record.CountryOfDestinationCode = row["Country Of Destination"].ToString();
                        record.StayTripOptionCode = row["Stay/Trip Option"].ToString();
                        record.NbrDaysWhenLess92 = row["No. Of Days When Less Than 92 Days"].ToString();


                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_32_SlipStep4(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32_Slip_Step4";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}


                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            try
                            {
                                if (cell.Value == null)
                                {
                                    newRow[cell.Start.Column - 1] = "";
                                }
                                else
                                {
                                    newRow[cell.Start.Column - 1] = cell.Value;
                                }
                            }
                            catch (Exception e)
                            {

                            }


                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<SlipStep4AF_32>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        SlipStep4AF_32 record = new SlipStep4AF_32();

                        record.RecId = row["RecId"].ToString();
                        record.BranchId = row["BranchId"].ToString();
                        record.BusinessLineCode = row["BLCode"].ToString();
                        record.Category = row["Category"].ToString();
                        record.BenefitNumber = row["BenefitNbr"].ToString();
                        record.BenefitName = row["BenefitName"].ToString();
                        record.BenefitAnswer = row["BenefitAnswer"].ToString();
                        record.LifeTime = row["LifeTime"].ToString();
                        record.Excess = row["Excess"].ToString();

                        records.Add(record);

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_33_SlipStep4(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32_Slip_Step4";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}


                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            try
                            {
                                if (cell.Value == null)
                                {
                                    newRow[cell.Start.Column - 1] = "";
                                }
                                else
                                {
                                    newRow[cell.Start.Column - 1] = cell.Value;
                                }
                            }
                            catch (Exception e)
                            {

                            }


                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<SlipStep4AF_32>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        SlipStep4AF_32 record = new SlipStep4AF_32();

                        record.RecId = row["RecId"].ToString();
                        record.BranchId = row["BranchId"].ToString();
                        record.BusinessLineCode = row["BLCode"].ToString();
                        record.Category = row["Category"].ToString();
                        record.BenefitNumber = row["BenefitNbr"].ToString();
                        record.BenefitName = row["BenefitName"].ToString();
                        record.BenefitAnswer = row["BenefitAnswer"].ToString();
                        record.LifeTime = row["LifeTime"].ToString();
                        record.Excess = row["Excess"].ToString();
                        if (record.RecId != String.Empty)
                        {
                            records.Add(record);
                        }
                     

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }     
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_04_SlipStep4(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32_Slip_Step4";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}


                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            try
                            {
                                if (cell.Value == null)
                                {
                                    newRow[cell.Start.Column - 1] = "";
                                }
                                else
                                {
                                    newRow[cell.Start.Column - 1] = cell.Value;
                                }
                            }
                            catch (Exception e)
                            {

                            }


                        }
                        dataTable.Rows.Add(newRow);
                    }

                    // Use the data table to retrieve the records
                    var records = new List<SlipStep4AF_32>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        SlipStep4AF_32 record = new SlipStep4AF_32();

                        record.RecId = row["RecId"].ToString();
                        record.BranchId = row["BranchId"].ToString();
                        record.BusinessLineCode = row["BLCode"].ToString();
                        record.Category = row["Category"].ToString();
                        record.BenefitNumber = row["BenefitNbr"].ToString();
                        record.BenefitName = row["BenefitName"].ToString();
                        record.BenefitAnswer = row["BenefitAnswer"].ToString();
                        record.LifeTime = row["LifeTime"].ToString();
                        record.Excess = row["Excess"].ToString();
                        if (record.RecId != String.Empty)
                        {
                            records.Add(record);
                        }
                     

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_32_DetailsStep5(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32_Slip_Step4";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}


                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            try
                            {
                                if (cell.Value == null)
                                {
                                    newRow[cell.Start.Column - 1] = "";
                                }
                                else
                                {
                                    newRow[cell.Start.Column - 1] = cell.Value;
                                }
                            }
                            catch (Exception e)
                            {

                            }


                        }
                        if (newRow.ItemArray[1].ToString() == "" && newRow.ItemArray[2].ToString() == "")
                        {

                        }
                        else
                        {
                            dataTable.Rows.Add(newRow);
                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<DetailsPriceStep5EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DetailsPriceStep5EM record = new DetailsPriceStep5EM();

                        record.SalesTrxDetailsId = row["RecId"].ToString();
                        record.SectionName = row["SectionName"].ToString();
                        record.Category = row["Category"].ToString();
                        record.Dependency = row["Dependency"].ToString();
                        record.Gender = row["Gender"].ToString();
                        record.MaritalStatus = row["MaritalStatus"].ToString();
                        record.CostSharing = row["CostSharing"].ToString();
                        record.AgeMinRange = row["AgeMinRange"].ToString();
                        record.AgeMaxRange = row["AgeMaxRange"].ToString();
                        record.Premium = row["Premium"].ToString();

                        records.Add(record);

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_04_DetailsStep5(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32_Slip_Step4";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}


                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            try
                            {
                                if (cell.Value == null)
                                {
                                    newRow[cell.Start.Column - 1] = "";
                                }
                                else
                                {
                                    newRow[cell.Start.Column - 1] = cell.Value;
                                }
                            }
                            catch (Exception e)
                            {

                            }


                        }
                        if (newRow.ItemArray[1].ToString() == "" && newRow.ItemArray[2].ToString() == "")
                        {

                        }
                        else
                        {
                            dataTable.Rows.Add(newRow);
                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<DetailsPriceStep5EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DetailsPriceStep5EM record = new DetailsPriceStep5EM();

                        record.SalesTrxDetailsId = code;
                        record.SectionName = row["SectionName"].ToString();
                        record.Category = row["Category"].ToString();
                        record.Dependency = row["Dependency"].ToString();
                        record.Gender = row["Gender"].ToString();
                        record.MaritalStatus = row["MaritalStatus"].ToString();
                        record.Limit = row["Limit"].ToString();
                        record.AgeMinRange = row["AgeMinRange"].ToString();
                        record.AgeMaxRange = row["AgeMaxRange"].ToString();
                        record.Premium = row["Premium"].ToString();
                        record.Rate = row["Rate"].ToString();

                        if (record.Gender != "1")
                        {
                            records.Add(record);
                        }

                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_33_DetailsStep5(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();

                    List<string> listFromExcel = new List<string>();
                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }
                    //AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    //aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32_Slip_Step4";
                    //aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    //var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    ////validation same columns
                    //if (!res.AF1ColHeader.IsColHeaderValid)
                    //{
                    //    result = "Column name of the excel is not matching";
                    //    return Ok(new { status = "warning", message = result });
                    //}


                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            try
                            {
                                if (cell.Value == null)
                                {
                                    newRow[cell.Start.Column - 1] = "";
                                }
                                else
                                {
                                    newRow[cell.Start.Column - 1] = cell.Value;
                                }
                            }
                            catch (Exception e)
                            {

                            }


                        }
                        if (newRow.ItemArray[1].ToString() == "" && newRow.ItemArray[2].ToString() == "")
                        {

                        }
                        else
                        {
                            dataTable.Rows.Add(newRow);
                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<DetailsPriceStep5EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DetailsPriceStep5EM record = new DetailsPriceStep5EM();

                        record.SalesTrxDetailsId = code;
                        record.SectionName = row["SectionName"].ToString();
                        record.Category = row["Category"].ToString();
                        record.Dependency = row["Dependency"].ToString();
                        record.Gender = row["Gender"].ToString();
                        record.MaritalStatus = row["MaritalStatus"].ToString();
                        record.Limit = row["Limit"].ToString();
                        record.AgeMinRange = row["AgeMinRange"].ToString();
                        record.AgeMaxRange = row["AgeMaxRange"].ToString();
                        record.Premium = row["Premium"].ToString();
                        record.Rate = row["Rate"].ToString();
                        if (record.Gender != "1")
                        {
                            records.Add(record);
                        }
                        
                        
                    }

                    return Ok(new { status = "success", data = records, message = result });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_32(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();
                    List<string> listFromExcel = new List<string>();

                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }

                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }
                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        try
                        {
                            var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                            var newRow = dataTable.NewRow();
                            foreach (var cell in row)
                            {
                                newRow[cell.Start.Column - 1] = cell.Value;
                            }
                            dataTable.Rows.Add(newRow);
                        }
                        catch
                        {

                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_32EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_32EM record = new Af1_32EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        record.DOB = GetDateFromString(row["DOB"].ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.RelationCode = row["RELATION"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.NSSF = row["NSSF"].ToString();
                        record.Grade = row["Grade"].ToString();
                        record.Dental = row["Dental"].ToString();
                        record.Optical = row["Optical"].ToString();
                        record.ClassOfCoveragCode = row["CLASS OF COVERAGE"].ToString();
                        record.Ambulatory = row["AMBULATORY"].ToString();
                        record.PrescriptionMedecine = row["PRESCRIPTION MEDICINE"].ToString();
                        record.DoctorVisit = row["DOCTORS VISIT"].ToString();
                        record.MobileNumber = row["Mobile"].ToString();
                        record.Email = row["Email"].ToString();
                        record.Shop = row["Shop"].ToString();

                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ImportExcelAF1_32_Step4(IFormFile file, string code, CancellationToken ct)
        {
            try
            {
                string result = string.Empty;
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using (var excelFile = new ExcelPackage(memoryStream))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    var worksheet = excelFile.Workbook.Worksheets[0];
                    var dataTable = new DataTable();
                    List<string> listFromExcel = new List<string>();

                    foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                    {
                        if (firstRowCell.Value != null)
                        {
                            dataTable.Columns.Add(firstRowCell.Value.ToString());
                            listFromExcel.Add(firstRowCell.Value.ToString());
                        }
                    }

                    AF1ColHeaderFindWithColFilterReq aF1ColHeaderFindWithColFilterReq = new AF1ColHeaderFindWithColFilterReq();
                    aF1ColHeaderFindWithColFilterReq.AF1Code = "AF1_32";
                    aF1ColHeaderFindWithColFilterReq.AF1ColHeader = string.Join('|', listFromExcel);
                    var res = await _generalApi.CheckExcelImportValidation(aF1ColHeaderFindWithColFilterReq, ct);
                    //validation same columns
                    if (!res.AF1ColHeader.IsColHeaderValid)
                    {
                        result = "Column name of the excel is not matching";
                        return Ok(new { status = "warning", message = result });
                    }
                    for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                    {
                        try
                        {
                            var row = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                            var newRow = dataTable.NewRow();
                            foreach (var cell in row)
                            {
                                newRow[cell.Start.Column - 1] = cell.Value;
                            }
                            dataTable.Rows.Add(newRow);
                        }
                        catch
                        {

                        }

                    }

                    // Use the data table to retrieve the records
                    var records = new List<Af1_32EM>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Af1_32EM record = new Af1_32EM();

                        record.Serial = row["SERIAL"].ToString();
                        record.Company = row["COMPANY"].ToString();
                        record.StaffNbr = row["STAFF NO."].ToString();
                        record.FirstName = row["FIRST NAME"].ToString();
                        record.LastName = row["LAST NAME"].ToString();
                        record.MiddleName = row["FATHER/MIDDLE NAME"].ToString();
                        record.DOB = GetDateFromString(row["DOB"].ToString());
                        record.GenderCode = row["GENDER"].ToString();
                        record.MaritalStatusCode = row["MARITAL STATUS"].ToString();
                        record.RelationCode = row["RELATION"].ToString();
                        record.NationalityCode = row["NATIONALITY"].ToString();
                        record.NSSF = row["NSSF"].ToString();
                        record.Grade = row["Grade"].ToString();
                        record.Dental = row["Dental"].ToString();
                        record.Optical = row["Optical"].ToString();
                        record.ClassOfCoveragCode = row["CLASS OF COVERAGE"].ToString();
                        record.Ambulatory = row["AMBULATORY"].ToString();
                        record.PrescriptionMedecine = row["PRESCRIPTION MEDICINE"].ToString();
                        record.DoctorVisit = row["DOCTORS VISIT"].ToString();

                        if (record.FirstName.IsNullOrEmpty() && record.LastName.IsNullOrEmpty() && record.MiddleName.IsNullOrEmpty())
                        {
                            break;
                        }
                        else
                        {
                            records.Add(record);
                        }
                    }

                    return Ok(new { status = "success", data = records });
                }
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcel(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                var businesstype = JsonConvert.DeserializeObject<string>(keyValues["businessPage"]);
                var user = await _userApi.GetUserClaims(User.Claims);
                string businesLineID = keyValues["businesscode"].ToString();
                string type = JsonConvert.DeserializeObject<string>(keyValues["type"]);
                int trxID = 0;
                string param = string.Empty;
                bool isPdf = false;
                bool isEmptyDownload = false;
                bool isShort = false;
                try
                {
                    trxID = JsonConvert.DeserializeObject<int>(keyValues["trxID"]);
                }
                catch
                {

                }
                try
                {
                    param = JsonConvert.DeserializeObject<string>(keyValues["params"]);
                }
                catch
                {

                }
                try
                {
                    isPdf = JsonConvert.DeserializeObject<bool>(keyValues["ispdf"]);
                }
                catch
                {

                }

                try
                {
                    isEmptyDownload = JsonConvert.DeserializeObject<bool>(keyValues["isemptydownload"]);
                }
                catch
                {

                }
                try
                {
                    isShort = JsonConvert.DeserializeObject<bool>(keyValues["isshort"]);
                }
                catch
                {

                }
                int contactId = JsonConvert.DeserializeObject<int>(keyValues["contactid"]);
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                req.WebRequestCommon.UserName = user.EmailAdress;
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = type;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                byte[] bytes = null;
                if (isEmptyDownload)
                {
                    var emptyDownloadFile = File(resFile.BusinessLineRelatedDoc.AttachDocBinary, System.Net.Mime.MediaTypeNames.Application.Octet, businesstype + "_" + resFile.BusinessLineRelatedDoc.BusinessLineCode + "_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");
                    return emptyDownloadFile;
                }
                switch (businesstype)
                {
                    case "AF1_30":
                        {
                            List<Af1_30EM> requestBody1 = JsonConvert.DeserializeObject<List<Af1_30EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF30(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody1);
                        }
                        break;
                    case "AF1_32":
                        {
                            List<Af1_32EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_32EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF32(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "AF1_33":
                        {
                            List<Af1_33EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_33EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF33(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "AF1_4":
                        {
                            List<Af1_4EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_4EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF4(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "AF1_28":
                        {
                            List<Af1_28EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_28EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF28(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "AF1_29":
                        {
                            List<Af1_29EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_29EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF29(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "AF1_5":
                        {
                            List<Af1_5EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_5EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF5(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "AF1_2":
                        {
                            List<Af1_2EM> requestBody2 = JsonConvert.DeserializeObject<List<Af1_2EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelAF2(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody2);
                        }
                        break;
                    case "BL77":
                        {
                            List<Af1Bl77EM> requestBody = JsonConvert.DeserializeObject<List<Af1Bl77EM>>(keyValues["data"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelBl77(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody);
                        }
                        break;

                    case "CQ_1_8":
                        {
                            List<IDictionary<string, string>> requestBody = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> benefitList = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> billsList = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> compareList = new List<IDictionary<string, string>>();
                            List<CQHeader080501> cQHeader = new List<CQHeader080501>();
                            List<CQCategory080501> cQCategory = new List<CQCategory080501>();
                            if (!param.IsNullOrEmpty())
                            {
                                CQAf8VM cqaf8 = new CQAf8VM();
                                cqaf8 = await _comparitiveQuotationBusiness.GetCQ_1_8(param, User.Claims, isShort, ct);

                                requestBody = cqaf8.CQPivotList;
                                benefitList = cqaf8.CQBenefitList;
                                billsList = cqaf8.CQBillsList;
                                cQHeader = cqaf8.CQHeader;
                                cQCategory = cqaf8.CQCategory;
                                compareList = cqaf8.CQCompareList;
                            }
                            else
                            {
                                requestBody = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["data"]);
                                benefitList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["benefitList"]);
                                billsList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["billsList"]);
                                cQHeader = JsonConvert.DeserializeObject<List<CQHeader080501>>(keyValues["cqheader"]);
                                cQCategory = JsonConvert.DeserializeObject<List<CQCategory080501>>(keyValues["cqcategory"]);
                                compareList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["compareList"]);

                            }
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ1_8(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody, benefitList, billsList, cQHeader, cQCategory, compareList);

                        }
                        break;
                    case "CQ_6":
                        {
                            List<IDictionary<string, string>> requestBody = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> benefitList = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> billsList = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> compareList = new List<IDictionary<string, string>>();
                            List<CQHeader070806Dto> cQHeader = new List<CQHeader070806Dto>();
                            List<CQCategory070806Dto> cQCategory = new List<CQCategory070806Dto>();
                            if (!param.IsNullOrEmpty())
                            {
                                CQAf07VM cqaf8 = new CQAf07VM();
                                cqaf8 = await _comparitiveQuotationBusiness.GetCQ6(param, User.Claims, isShort, ct);

                                requestBody = cqaf8.CQPivotList;
                                benefitList = cqaf8.CQBenefitList;
                                billsList = cqaf8.CQBillsList;
                                cQHeader = cqaf8.CQHeader;
                                cQCategory = cqaf8.CQCategory;
                                compareList = cqaf8.CQCompareList;
                            }
                            else
                            {
                                requestBody = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["data"]);
                                benefitList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["benefitList"]);
                                billsList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["billsList"]);
                                cQHeader = JsonConvert.DeserializeObject<List<CQHeader070806Dto>>(keyValues["cqheader"]);
                                cQCategory = JsonConvert.DeserializeObject<List<CQCategory070806Dto>>(keyValues["cqcategory"]);
                                compareList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["compareList"]);

                            }
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ6(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody, benefitList, billsList, cQHeader, cQCategory, compareList);

                        }
                        break;
                    case "CQ_1":
                        {
                            //cq af1 30
                            SalesTransactionBL301401FindCQWithRecIdFilterReq request = new SalesTransactionBL301401FindCQWithRecIdFilterReq();
                            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            request.WebRequestCommon.UserName = user.EmailAdress;
                            request.SalesTransactionId = trxID;
                            var result = await _businessLineApi.GetCQAF30(request, ct);
                            List<List<IDictionary<string, string>>> pivots = _global.ConvertDictionaryListOfListDynamicListOfList(result.CQPivotBL301401);
                            List<List<IDictionary<string, string>>> pivotsMembers = _global.ConvertDictionaryListOfListDynamicListOfList(result.CQPivotMemberBL301401);
                            List<List<IDictionary<string, string>>> benefitsCompares = _global.ConvertDictionaryListOfListDynamicListOfList(result.CQBenefitCompareBL301401);
                            List<List<IDictionary<string, string>>> benefits = _global.ConvertDictionaryListOfListDynamicListOfList(result.CQBenefitBL301401);
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ30New(resFile.BusinessLineRelatedDoc.AttachDocBinary, pivots, pivotsMembers, benefitsCompares, benefits, result.CQHeaderBL301401, result.CQCategoryBL301401);
                        }
                        break;
                    case "CQ_10":
                        {

                            SalesTransactionBL321110FindCQWithRecIdFilterReq request = new SalesTransactionBL321110FindCQWithRecIdFilterReq();
                            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            request.WebRequestCommon.UserName = user.EmailAdress;
                            request.SalesTransactionId = trxID;
                            var result = await _businessLineApi.GetCQAF32(request, ct);
        
                            List<IDictionary<string, string>> dynamicSummary = _global.GetDictoinaryListFromDynamicList(result.CQPivotSummaryBL321110);

                            List<IDictionary<string, string>> dynamicSection = _global.GetDictoinaryListFromDynamicList(result.CQPivotSectionBL321110);

                            List<IDictionary<string, string>> dynamicMember = _global.GetDictoinaryListFromDynamicList(result.CQPivotMemberBL321110);

        List<IDictionary<string, string>> dynamicPivotBenifit = _global.GetDictoinaryListFromDynamicList(result.CQPivotBenefitBL321110);
        List<IDictionary<string, string>> dynamicPriceList = _global.GetDictoinaryListFromDynamicList(result.CQPivotPricesListBL321110);
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ10(resFile.BusinessLineRelatedDoc.AttachDocBinary, dynamicSummary, dynamicSection, dynamicMember, dynamicPivotBenifit, dynamicPriceList, result.CQHeaderBL321110 );
                            //List<IDictionary<string, string>> requestBody = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["data"]);
                            //List<IDictionary<string, string>> benefitList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["benefitList"]);
                            //List<IDictionary<string, string>> billsList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["billsList"]);
                            //List<CQHeader> CQHeader = JsonConvert.DeserializeObject<List<CQHeader>>(keyValues["cqheader"]);
                            //List<CQCategory> CQCategory = JsonConvert.DeserializeObject<List<CQCategory>>(keyValues["cqcategory"]);
                            //bytes = await _convertFromToExcel.ConvetFormToExcelCQ30(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody, benefitList, billsList, CQHeader, CQCategory);
                        }
                        break;
                    case "CQ_2":
                        {
                            if (businesLineID == "021502")
                            {
                                SalesTransactionBL021502FindCQWithRecIdFilterReq request = new SalesTransactionBL021502FindCQWithRecIdFilterReq();
                                request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                                request.WebRequestCommon.UserName = user.EmailAdress;
                                request.SalesTransactionId = trxID;
                                var result = await _businessLineApi.GetCQAF02(request, ct);

                                List<IDictionary<string, string>> dynamicPivot= _global.GetDictoinaryListFromDynamicList(result.CQPivotBL021502);

                                List<IDictionary<string, string>> dynamicBinefit= _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL021502);

                                List<IDictionary<string, string>> dynamicPayment = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL021502);
                              
                                //List<CQCategory021502Dto> CQCategory = JsonConvert.DeserializeObject<List<CQCategory021502Dto>>(keyValues["cqcategory"]);
                                bytes = await _convertFromToExcel.ConvetFormToExcelCQ2(resFile.BusinessLineRelatedDoc.AttachDocBinary, dynamicPivot, dynamicBinefit, dynamicPayment, result.CQHeaderBL021502, null);
                            }
                            else if (businesLineID == "010602")
                            {
                                SalesTransactionBL010602FindCQWithRecIdFilterReq request = new SalesTransactionBL010602FindCQWithRecIdFilterReq();
                                request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                                request.WebRequestCommon.UserName = user.EmailAdress;
                                request.SalesTransactionId = trxID;
                                var result = await _businessLineApi.GetCQAF01(request, ct);

                                List<IDictionary<string, string>> dynamicPivot = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL010602);

                                List<IDictionary<string, string>> dynamicBinefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL010602);

                                List<IDictionary<string, string>> dynamicPayment = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL010602);

                                //List<CQCategory010602Dto> CQCategory = JsonConvert.DeserializeObject<List<CQCategory010602Dto>>(keyValues["cqcategory"]);
                                bytes = await _convertFromToExcel.ConvetFormToExcelCQ2AF01(resFile.BusinessLineRelatedDoc.AttachDocBinary, dynamicPivot, dynamicBinefit, dynamicPayment, result.CQHeaderBL010602, null);
                            }
        
                        }
                        break;
                    case "CQ_3":
                        {
                            SalesTransactionBL090703FindCQWithRecIdFilterReq request = new SalesTransactionBL090703FindCQWithRecIdFilterReq();
                            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            request.WebRequestCommon.UserName = user.EmailAdress;
                            request.SalesTransactionId = trxID;
                            var result = await _businessLineApi.GetCQAF09(request, ct);

                            List<IDictionary<string, string>> dynamicPivot = _global.GetDictoinaryListFromDynamicList(result.CQPivotBL090703);

                            List<IDictionary<string, string>> dynamicBinefit = _global.GetDictoinaryListFromDynamicList(result.CQBenefitBL090703);

                            List<IDictionary<string, string>> dynamicPayment = _global.GetDictoinaryListFromDynamicList(result.CQBillsBL090703);
                            List<IDictionary<string, string>> dynamicCompare = _global.GetDictoinaryListFromDynamicList(result.CQBenefitComapreBL090703);

                         
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ3(resFile.BusinessLineRelatedDoc.AttachDocBinary, dynamicPivot, dynamicBinefit, dynamicPayment, dynamicCompare, result.CQHeaderBL090703, null);
                        }
                        break;
                    case "CQ_7":
                        {
                            List<IDictionary<string, string>> requestBody = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["data"]);
                            List<IDictionary<string, string>> benefitList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["benefitList"]);
                            List<IDictionary<string, string>> billsList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["billsList"]);
                            List<CQHeader051807Dto> CQHeader = JsonConvert.DeserializeObject<List<CQHeader051807Dto>>(keyValues["cqheader"]);
                            List<CQCategory051807Dto> CQCategory = JsonConvert.DeserializeObject<List<CQCategory051807Dto>>(keyValues["cqcategory"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ7(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody, benefitList, billsList, CQHeader, CQCategory);
                        }
                        break;
                    case "CQ_8":
                        {
                            List<IDictionary<string, string>> requestBody = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["data"]);
                            List<IDictionary<string, string>> benefitList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["benefitList"]);
                            List<IDictionary<string, string>> billsList = JsonConvert.DeserializeObject<List<IDictionary<string, string>>>(keyValues["billsList"]);
                            List<CQHeader291908Dto> CQHeader = JsonConvert.DeserializeObject<List<CQHeader291908Dto>>(keyValues["cqheader"]);
                            List<CQCategory291908Dto> CQCategory = JsonConvert.DeserializeObject<List<CQCategory291908Dto>>(keyValues["cqcategory"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ8(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody, benefitList, billsList, CQHeader, CQCategory);
                        }
                        break;
                    case "CQ_9":
                        {
                            List<IDictionary<string, string>> requestBody = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> benefitList = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> billsList = new List<IDictionary<string, string>>();
                            List<IDictionary<string, string>> compareList = new List<IDictionary<string, string>>();
                            List<CQHeader281609Dto> cQHeader = new List<CQHeader281609Dto>();
                            List<CQCategory281609Dto> cQCategory = new List<CQCategory281609Dto>();
                            CQAf28VM cqaf8 = new CQAf28VM();
                            cqaf8 = await _comparitiveQuotationBusiness.GetCQ9(param, User.Claims, isShort, ct);

                            requestBody = cqaf8.CQPivotList;
                            benefitList = cqaf8.CQBenefitList;
                            billsList = cqaf8.CQBillsList;
                            cQHeader = cqaf8.CQHeader;
                            compareList = cqaf8.CQBenefitCompareList;
                              bytes = await _convertFromToExcel.ConvetFormToExcelCQ9(resFile.BusinessLineRelatedDoc.AttachDocBinary, requestBody, benefitList, billsList, compareList, cQHeader, cQCategory);
                        }
                        break;
                    case "CQ_11":
                        {
                            SalesTransactionBL331211FindCQWithRecIdFilterReq request = new SalesTransactionBL331211FindCQWithRecIdFilterReq();
                            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            request.WebRequestCommon.UserName = user.EmailAdress;
                            request.SalesTransactionId = trxID;
                            SalesTransactionBL331211CQResp result = await _businessLineApi.GetCQAF33(request, ct);
                            //header
                            //summy
                            //pricelist
                            //pivot
                            //pivot member
                            //benifits
                            
                       

                            List<IDictionary<string, string>> dynamicPivotMember = _global.GetDictoinaryListFromDynamicList(result.CQPivotMemberBL331211);
                            List<IDictionary<string, string>> dynamicPivot = _global.GetDictoinaryListFromDynamicList(result.CQPivotSectionBL331211);
                            List<IDictionary<string, string>> dynamicPivotpricelist = _global.GetDictoinaryListFromDynamicList(result.CQPivotPricesListBL331211);


                            List<IDictionary<string, string>> dynamicBenifit = _global.GetDictoinaryListFromDynamicList(result.CQPivotBenefitBL331211);
                            List<IDictionary<string, string>> dynamicSummary = _global.GetDictoinaryListFromDynamicList(result.CQPivotSummaryBL331211);
                     

                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ11(resFile.BusinessLineRelatedDoc.AttachDocBinary, dynamicPivot, dynamicBenifit, dynamicPivotpricelist, dynamicPivotMember, dynamicSummary, result.CQHeaderBL331211, null);
                        }
                        break;
                    case "CQ_12":
                        {
                            SalesTransactionBL041312FindCQWithRecIdFilterReq request = new SalesTransactionBL041312FindCQWithRecIdFilterReq();
                            request.WebRequestCommon.CorrelationId = Guid.NewGuid().ToString();
                            request.WebRequestCommon.UserName = user.EmailAdress;
                            request.SalesTransactionId = trxID;
                            SalesTransactionBL041312CQResp result = await _businessLineApi.GetCQAF4(request, ct);
                            //header
                            //summy
                            //pricelist
                            //pivot
                            //pivot member
                            //benifits



                            List<IDictionary<string, string>> dynamicPivotMember = _global.GetDictoinaryListFromDynamicList(result.CQPivotMemberBL041312);
                            List<IDictionary<string, string>> dynamicPivot = _global.GetDictoinaryListFromDynamicList(result.CQPivotSectionBL041312);
                            List<IDictionary<string, string>> dynamicPivotpricelist = _global.GetDictoinaryListFromDynamicList(result.CQPivotPricesListBL041312);


                            List<IDictionary<string, string>> dynamicBenifit = _global.GetDictoinaryListFromDynamicList(result.CQPivotBenefitBL041312);
                            List<IDictionary<string, string>> dynamicSummary = _global.GetDictoinaryListFromDynamicList(result.CQPivotSummaryBL041312);


                            bytes = await _convertFromToExcel.ConvetFormToExcelCQ12(resFile.BusinessLineRelatedDoc.AttachDocBinary, dynamicPivot, dynamicBenifit, dynamicPivotpricelist, dynamicPivotMember, dynamicSummary, result.CQHeaderBL041312, null);
                        }
                        break;
                    default:
                        {


                        }
                        break;
                }

                // var downloadFile = File(resFile.BusinessLineRelatedDoc.AttachDocBinary, System.Net.Mime.MediaTypeNames.Application.Octet, "MyExcelFile.xlsx");
                // Load the Excel file using EPPlus

                FileContentResult downloadFile = null;
                //if (isPdf)
                //{
                //    byte[] pdfBytes = null;


                //    // Load the Excel file
                //    Workbook workbook = new Workbook();
                //    using (var stream = new MemoryStream(bytes))
                //    {
                //        workbook.LoadFromStream(stream);
                //        foreach (Worksheet sheet in workbook.Worksheets)
                //        {
                //            sheet.PageSetup.LeftHeader = "";
                //        }
                //        // Set PDF options
                //        PdfDocument pdfDocument = new PdfDocument();
                //        pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
                //        pdfDocument.PageSettings.Width = 1000;
                //        pdfDocument.PageSettings.Height = 900;
                //        // Convert each worksheet to PDF
                //        // Set page setup for each worksheet
                //        foreach (Worksheet sheet in workbook.Worksheets)
                //        {
                //            PageSetup setup = sheet.PageSetup;
                //            setup.FitToPagesWide = 1;
                //            setup.FitToPagesTall = 1;
                //        }

                //        // Convert the entire workbook to PDF
                //        using (var pdfStream = new MemoryStream())
                //        {
                //            workbook.SaveToStream(pdfStream, Spire.Xls.FileFormat.PDF);

                //            pdfBytes = pdfStream.ToArray();
                //            downloadFile = File(pdfBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, businesstype + "_" + resFile.BusinessLineRelatedDoc.BusinessLineCode + "_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".pdf");
                //        }
                //    }

                //}
                //else
                //{
                switch (businesstype)
                {
                    case "CQ_1_8":
                        {
                            if (isShort)
                            {
                                downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, businesstype + "_" + resFile.BusinessLineRelatedDoc.BusinessLineCode + "_" + DateTime.UtcNow.ToString("yyyyMMdd") + "_Short.xlsx");
                            }
                            else
                            {
                                downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, businesstype + "_" + resFile.BusinessLineRelatedDoc.BusinessLineCode + "_" + DateTime.UtcNow.ToString("yyyyMMdd") + "_Long.xlsx");
                            }

                        }
                        break;
                    default:
                        {
                            downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, businesstype + "_" + resFile.BusinessLineRelatedDoc.BusinessLineCode + "_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                        }
                        break;
                }

                //}


                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelProduct(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                List<ProductDto> data = JsonConvert.DeserializeObject<List<ProductDto>>(keyValues["data"]);
                byte[] bytes = null;

                bytes = await _convertFromToExcel.ConvetFormToExcelProductList(bytes, data);

                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "ProductList_" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new { status = "error", message = e.Message });
            }

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = GlobalWords.CustomAuth)]
        public async Task<IActionResult> ExportExcelTransactionDetailed(IFormCollection keyValues, CancellationToken ct)
        {
            try
            {
                string businesLineID = keyValues["businesscode"].ToString();
                string type = JsonConvert.DeserializeObject<string>(keyValues["type"]);
                byte[] bytes = null;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterReq req = new BusinessLineRelatedDocFindWithBusinessLineIdFilterReq();
                req.BusinessLineCode = businesLineID;
                req.ApplicationForm = type;
                BusinessLineRelatedDocFindWithBusinessLineIdFilterResp resFile = await _transactionApi.GetDocumentByBussinessID(req, ct);
                switch (businesLineID)
                {

                    case "080501":
                        {
                            List<CQShortListBL080501Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL080501Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL080501Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL080501Dto>>(keyValues["longlist"]);
                            List<CQHeader080501> headerlist = JsonConvert.DeserializeObject<List<CQHeader080501>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL080501(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "010602":
                        {
                            List<CQShortListBL010602Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL010602Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL010602Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL010602Dto>>(keyValues["longlist"]);
                            List<CQHeader010602Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader010602Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL010602(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "090703":
                        {
                            List<CQShortListBL090703Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL090703Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL090703Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL090703Dto>>(keyValues["longlist"]);
                            List<CQHeader090703Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader090703Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL090703(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "030904":
                        {
                            List<CQShortListBL030904Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL030904Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL030904Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL030904Dto>>(keyValues["longlist"]);
                            List<CQHeader030904Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader030904Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL030904(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "061005":
                        {
                            List<CQShortListBL061005Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL061005Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL061005Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL061005Dto>>(keyValues["longlist"]);
                            List<CQHeader061005Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader061005Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL061005(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "070806":
                        {
                            List<CQShortListBL070806Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL070806Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL070806Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL070806Dto>>(keyValues["longlist"]);
                            List<CQHeader070806Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader070806Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL070806(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "021502":
                        {
                            List<CQShortListBL021502Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL021502Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL021502Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL021502Dto>>(keyValues["longlist"]);
                            List<CQHeader021502Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader021502Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL021502(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "051807":
                        {
                            List<CQShortListBL051807Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL051807Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL051807Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL051807Dto>>(keyValues["longlist"]);
                            List<CQHeader051807Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader051807Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL051807(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "291908":
                        {
                            List<CQShortListBL291908Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL291908Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL291908Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL291908Dto>>(keyValues["longlist"]);
                            List<CQHeader291908Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader291908Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL291908(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "281609":
                        {
                            List<CQShortListBL281609Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL281609Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL281609Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL281609Dto>>(keyValues["longlist"]);
                            List<CQHeader281609Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader281609Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL281609(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "301401":
                        {
                            List<CQShortListBL301401Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL301401Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL301401Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL301401Dto>>(keyValues["longlist"]);
                            List<CQHeader> headerlist = JsonConvert.DeserializeObject<List<CQHeader>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL301401(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "311703":
                        {
                            List<CQShortListBL311703Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL311703Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL311703Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL311703Dto>>(keyValues["longlist"]);
                            List<CQHeader311703Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader311703Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL311703(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "321110":
                        {
                            List<CQShortListBL321110Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL321110Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL321110Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL321110Dto>>(keyValues["longlist"]);
                            List<CQHeader321110> headerlist = JsonConvert.DeserializeObject<List<CQHeader321110>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL321110(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "331211":
                        {
                            List<CQShortListBL331211Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL331211Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL331211Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL331211Dto>>(keyValues["longlist"]);
                            List<CQHeader331211Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader331211Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL331211(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                    case "041312":
                        {
                            List<CQShortListBL041312Dto> shortlist = JsonConvert.DeserializeObject<List<CQShortListBL041312Dto>>(keyValues["shortlist"]);
                            List<CQFullListBL041312Dto> longlist = JsonConvert.DeserializeObject<List<CQFullListBL041312Dto>>(keyValues["longlist"]);
                            List<CQHeader041312Dto> headerlist = JsonConvert.DeserializeObject<List<CQHeader041312Dto>>(keyValues["headerlist"]);
                            bytes = await _convertFromToExcel.ConvetFormToExcelShortLongListtBL041312(resFile.BusinessLineRelatedDoc.AttachDocBinary, shortlist, longlist, headerlist);
                        }
                        break;
                }
                var downloadFile = File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, type + businesLineID + "-" + DateTime.UtcNow.ToString("yyyyMMdd") + ".xlsx");

                return downloadFile;
            }
            catch (Exception e)
            {
                return Ok(new
                {
                    status = "error",
                    message = e.Message
                });
            }

        }

    }

}


