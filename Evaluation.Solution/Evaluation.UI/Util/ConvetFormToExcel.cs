
using AutoMapper.Execution;
using Evaluation.UI.DTO.BL010602;
using Evaluation.UI.DTO.BL021502;
using Evaluation.UI.DTO.BL030904;
using Evaluation.UI.DTO.BL041312;
using Evaluation.UI.DTO.BL051807;
using Evaluation.UI.DTO.BL061005;
using Evaluation.UI.DTO.BL070806;
using Evaluation.UI.DTO.BL080501;
using Evaluation.UI.DTO.BL090703;
using Evaluation.UI.DTO.BL281609;
using Evaluation.UI.DTO.BL291908;
using Evaluation.UI.DTO.BL301401;
using Evaluation.UI.DTO.BL311703;
using Evaluation.UI.DTO.BL321110;
using Evaluation.UI.DTO.BL331211;
using Evaluation.UI.DTO.Product;
using Evaluation.UI.ExcelImportModel;
using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IUtil;
using Evaluation.UI.Models;
using Evaluation.UI.Models.Transaction;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Response.BL030904;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL331211;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging.Abstractions;
using OfficeOpenXml;
using Spire.Xls;
using System.Collections;
using System.Reflection;

namespace Evaluation.UI.Util
{
    public class ConvetFormToExcel : IConvertFromToExcel
    {
        private readonly IGlobal _global;
        public ConvetFormToExcel(IGlobal global)
        {
            _global = global;
        }
        public async Task<byte[]> ConvetFormToExcelBl77(byte[] fileBytes, List<Af1Bl77EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");

            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, 1].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, 2].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, 3].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, 4].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, 5].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, 6].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, 7].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, 8].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, 9].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, 10].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, 11].Value = aF1BL77Dtos[i].CountryOfDepartureCode;
                worksheet.Cells[i + 2, 12].Value = aF1BL77Dtos[i].CountryOfDestinationCode;
                worksheet.Cells[i + 2, 13].Value = aF1BL77Dtos[i].StayTripOption;
                worksheet.Cells[i + 2, 14].Value = aF1BL77Dtos[i].NbrDaysWhenLess92;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF32(byte[] fileBytes, List<Af1_32EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].RelationCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Grade;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Dental;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Optical;
				worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NSSF;
				worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].ClassOfCoveragCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Ambulatory;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].PrescriptionMedecine;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DoctorVisit;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MobileNumber;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Email;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF33(byte[] fileBytes, List<Af1_33EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
          
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Grade;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Currency;
                // worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].AnnualWages;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LimitOfCoverage;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MobileNumber;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Email;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF30(byte[] fileBytes, List<Af1_30EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].ClientName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].RelationCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NSSF;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].ClassOfCoveragCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Ambulatory;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].PrescriptionMedecine;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DoctorVisit;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelCQ10(byte[] fileBytes, List<IDictionary<string, string>> dynamicSummary, List<IDictionary<string, string>> dynamicSection, List<IDictionary<string, string>> dynamicMember, List<IDictionary<string, string>> dynamicPivotBenifit, List<IDictionary<string, string>> dynamicPivotPriceList, List<CQHeader321110> cQHeader)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category

            MemoryStream memoryStream = new MemoryStream();
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            
            ExcelWorksheet worksheetSum = excelPackage.Workbook.Worksheets["SQLSummary"];
            IDictionary<string, string> firstDictionary = dynamicSummary.FirstOrDefault();
            if (firstDictionary != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionary.Keys)
                {
                    worksheetSum.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndex23 = 2;
            foreach (IDictionary<string, string> dictionary in dynamicSummary)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetSum.Cells[rowIndex23, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex23++;
            }
            //i want to delete other category if count <4
            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader321110 header = new CQHeader321110(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader321110).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader321110 header1 in cQHeader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader321110).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }



            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = dynamicPivotBenifit.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in dynamicPivotBenifit)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }

            //draw section pivot
            var groupedItemsPayment = dynamicSection.GroupBy(d => d["Category"]).ToList();
            int paymentExcel = 1;
            foreach (var groupBills in groupedItemsPayment)
            {

                ExcelWorksheet worksheetSec = excelPackage.Workbook.Worksheets["SQLPivot" + paymentExcel];

                IDictionary<string, string> firstDictionarySec = groupBills.FirstOrDefault();
                if (firstDictionarySec != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionarySec.Keys)
                    {
                        worksheetSec.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                }

                int rowIndex22 = 2;
                foreach (IDictionary<string, string> dictionary in groupBills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheetSec.Cells[rowIndex22, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex22++;
                }

               
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
              
                paymentExcel++;
            }
            //draw section pivot
            var groupedItemsMember = dynamicMember.GroupBy(d => d["Category"]).ToList();
            int memberExcel = 1;
            int totalPivotMemberColumnNumer = 0;
            foreach (var groupBills in groupedItemsMember)
            {

                ExcelWorksheet worksheetSec = excelPackage.Workbook.Worksheets["SQLPivotMember" + memberExcel];

                IDictionary<string, string> firstDictionarySec = groupBills.FirstOrDefault();
                if (firstDictionarySec != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionarySec.Keys)
                    {
                        worksheetSec.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                    totalPivotMemberColumnNumer = columnIndex11;
                }

                int rowIndex22 = 2;
                foreach (IDictionary<string, string> dictionary in groupBills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheetSec.Cells[rowIndex22, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex22++;
                }


                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;

                
                var worksheetQuot = excelPackage.Workbook.Worksheets["Cat"+ memberExcel];
                int totalColumns = worksheetQuot.Dimension.End.Column;

                for (int i = totalPivotMemberColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
                {
                    worksheetQuot.Column(i).Hidden = true;
                }
                var worksheetQuot1 = excelPackage.Workbook.Worksheets["Cat" + memberExcel+" Details"];
                int totalColumns1 = worksheetQuot1.Dimension.End.Column;

                for (int i = totalPivotMemberColumnNumer; i <= totalColumns1; i++) // Start from 12 because you want to hide columns after 11
                {
                    worksheetQuot1.Column(i).Hidden = true;
                }
                memberExcel++;
            }
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            ExcelWorksheet worksheetPriceList = excelPackage.Workbook.Worksheets["SQLPriceList"];
            IDictionary<string, string> firstDictionaryPriceList = dynamicPivotPriceList.FirstOrDefault();
            if (firstDictionaryPriceList != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryPriceList.Keys)
                {
                    worksheetPriceList.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndex232 = 2;
            foreach (IDictionary<string, string> dictionary in dynamicPivotPriceList)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetPriceList.Cells[rowIndex232, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex232++;
            }
            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

           


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ30(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader> cQHeaders, List<CQCategory> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["CatId"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            int pivotExcel = 1;
            foreach (var groupPivot in groupedItems)
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot" + pivotExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
                //  hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }

                // ExcelPackage
                // Set a password for the workbook
                //excelPackage.Workbook.Protection.SetPassword("password");
                //excelPackage.Workbook.Protection.LockStructure = true;
                //excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                //excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook
                //foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                //{

                //    worksheet1.Protection.IsProtected = true;
                //    worksheet1.Protection.AllowSelectLockedCells = true;
                //    worksheet1.Protection.AllowFormatCells = true;

                //}
                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                pivotExcel++;
            }
            //i want to delete other category if count <4


            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader header = new CQHeader(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            CQCategory category = new CQCategory(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQCategory).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex111 = 2;
            foreach (CQCategory category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQCategory).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex111++;
            }

            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];
            ;
            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }

            //draw payments
            var groupedItemsPayment = bills.GroupBy(d => d["CatId"]).ToList();
            int paymentExcel = 1;
            foreach (var groupBills in groupedItemsPayment)
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPayment" + paymentExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = worksheet;
                //hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = groupBills.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                }

                int rowIndex22 = 2;
                foreach (IDictionary<string, string> dictionary in groupBills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex22, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex22++;
                }

                // ExcelPackage
                // Set a password for the workbook
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                // excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook

                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                paymentExcel++;
            }
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            int totalSheetCount = 4; // Specify the total count of sheets

            int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            if (sheetCountToDelete > 0)
            {
                for (int i = 0; i < sheetCountToDelete; i++)
                {
                    string sheetName = "Category" + (desiredSheetCount + i + 1);
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
                    if (worksheet != null)
                    {
                        worksheet.Hidden = eWorkSheetHidden.Hidden;
                    }
                }
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ30New(byte[] fileBytes, List<List<IDictionary<string, string>>> pivotList, List<List<IDictionary<string, string>>> pivotMemberList, List<List<IDictionary<string, string>>> benifitsCompList, List<List<IDictionary<string, string>>> benifitsList, List<CQHeader301401Dto> cQHeaders, List<CQCategory> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader301401Dto header = new CQHeader301401Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader301401Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader301401Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader301401Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            CQCategory category = new CQCategory(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQCategory).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex111 = 2;
            foreach (CQCategory category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQCategory).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex111++;
            }
            //i want to draw for each category pivot
            //group pivot by category
            // var groupedItems = pivotList.GroupBy(d => d["CatId"]).ToList();
            //List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            int pivotExcel = 1;
            foreach (var groupPivot in pivotList)
            {

                ExcelWorksheet worksheet;
                string excelSheetName = "SQLPivot";
                if (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == excelSheetName + pivotExcel))
                {
                    worksheet = excelPackage.Workbook.Worksheets[excelSheetName + pivotExcel];
                }
                else
                {
                    worksheet = excelPackage.Workbook.Worksheets.Add(excelSheetName + pivotExcel);
                }
                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }


                pivotExcel++;
            }

            //pivot Member
            //var pivotMembers = pivotMemberList.GroupBy(d => d["CatId"]).ToList();
            int pivotMemberExcel = 1;
            foreach (var groupPivot in pivotMemberList)
            {

                ExcelWorksheet worksheet1;
                string excelSheetName = "SQLPivotMember";
                if (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == excelSheetName + pivotMemberExcel))
                {
                    worksheet1 = excelPackage.Workbook.Worksheets[excelSheetName + pivotMemberExcel];
                }
                else
                {
                    worksheet1 = excelPackage.Workbook.Worksheets.Add(excelSheetName + pivotMemberExcel);
                }
                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet1.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet1.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }


                pivotMemberExcel++;
            }




            //sheet SQLBenefitsComp
            //var benefitsComps = benifitsCompList.GroupBy(d => d["CatId"]).ToList();
            int benefitsCompExcel = 1;
            foreach (var groupPivot in benifitsCompList)
            {

                ExcelWorksheet worksheet2;
                string excelSheetName = "SQLBenefitsComp";
                if (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == excelSheetName + benefitsCompExcel))
                {
                    worksheet2 = excelPackage.Workbook.Worksheets[excelSheetName + benefitsCompExcel];
                }
                else
                {
                    worksheet2 = excelPackage.Workbook.Worksheets.Add(excelSheetName + benefitsCompExcel);
                }
                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet2.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet2.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }


                benefitsCompExcel++;
            }
            //sheet SQLBenefits
            //var benefits = benifitsList.GroupBy(d => d["CatId"]).ToList();
            int benefitsExcel = 1;
            foreach (var groupPivot in benifitsList)
            {

                ExcelWorksheet worksheet3;
                string excelSheetName = "SQLBenefits";
                if (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == excelSheetName + benefitsExcel))
                {
                    worksheet3 = excelPackage.Workbook.Worksheets[excelSheetName + benefitsExcel];
                }
                else
                {
                    worksheet3 = excelPackage.Workbook.Worksheets.Add(excelSheetName + benefitsExcel);
                }
                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet3.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet3.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }

                benefitsExcel++;
            }
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            //int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            //int totalSheetCount = 4; // Specify the total count of sheets

            //int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            //if (sheetCountToDelete > 0)
            //{
            //    for (int i = 0; i < sheetCountToDelete; i++)
            //    {
            //        string sheetName = "Category" + (desiredSheetCount + i + 1);
            //        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
            //        if (worksheet != null)
            //        {
            //            worksheet.Hidden = eWorkSheetHidden.Hidden;
            //        }
            //    }
            //}
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ2(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader021502Dto> cQHeaders, List<CQCategory021502Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
           
            MemoryStream memoryStream = new MemoryStream();
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            //int pivotExcel = 1;
            // foreach (var groupPivot in groupedItems)
            // {
            int totalPivotColumnNumer = 0;
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot1"];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
                //  hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = list.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                totalPivotColumnNumer = columnIndex11;
            }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in list)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }

                // ExcelPackage
                // Set a password for the workbook
                //excelPackage.Workbook.Protection.SetPassword("password");
                //excelPackage.Workbook.Protection.LockStructure = true;
                //excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                //excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook
                //foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                //{

                //    worksheet1.Protection.IsProtected = true;
                //    worksheet1.Protection.AllowSelectLockedCells = true;
                //    worksheet1.Protection.AllowFormatCells = true;

                //}
                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
             //   pivotExcel++;
          //  }
            //i want to delete other category if count <4


            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader021502Dto header = new CQHeader021502Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader021502Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader021502Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            //ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            //CQCategory021502Dto category = new CQCategory021502Dto(); // Create an instance of CQHeader
            //int columnIndex111 = 1;
            //foreach (var propertyInfo in typeof(CQCategory021502Dto).GetProperties())
            //{
            //    string propertyName = propertyInfo.Name;
            //    worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
            //    columnIndex111++;
            //}
            //int rowIndex111 = 2;
            //foreach (CQCategory021502Dto category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            //{
            //    int columnIndex1 = 1;
            //    foreach (var propertyInfo in typeof(CQCategory021502Dto).GetProperties())
            //    {
            //        string propertyName = propertyInfo.Name;
            //        object propertyValue = propertyInfo.GetValue(category1);
            //        worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
            //        columnIndex1++;
            //    }
            //    rowIndex111++;
            //}

            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];
            
            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }

            //draw payments
            //var groupedItemsPayment = bills.GroupBy(d => d["CatId"]).ToList();
            //int paymentExcel = 1;
            //foreach (var groupBills in groupedItemsPayment)
            //{

                ExcelWorksheet worksheetpayment = excelPackage.Workbook.Worksheets["SQLPayment"];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = worksheet;
                //hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionaryyyy = bills.FirstOrDefault();
                if (firstDictionaryyyy != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionaryyyy.Keys)
                    {
                    worksheetpayment.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                }

                int rowIndex22 = 2;
                foreach (IDictionary<string, string> dictionary in bills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                    worksheetpayment.Cells[rowIndex22, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex22++;
                }

                // ExcelPackage
                // Set a password for the workbook
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                // excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook

                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
              //  paymentExcel++;
           // }
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet12 in excelPackage.Workbook.Worksheets)
            {
                if (worksheet12.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet12.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            //int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            //int totalSheetCount = 4; // Specify the total count of sheets

            //int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            //if (sheetCountToDelete > 0)
            //{
            //    for (int i = 0; i < sheetCountToDelete; i++)
            //    {
            //        string sheetName = "Category" + (desiredSheetCount + i + 1);
            //        ExcelWorksheet worksheet1122 = excelPackage.Workbook.Worksheets[sheetName];
            //        if (worksheet != null)
            //        {
            //            worksheet.Hidden = eWorkSheetHidden.Hidden;
            //        }
            //    }
            //}
            var worksheetQuot = excelPackage.Workbook.Worksheets["Quotation"];
            int totalColumns = worksheetQuot.Dimension.End.Column;

            for (int i = totalPivotColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
            {
                worksheetQuot.Column(i).Hidden = true;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ2AF01(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader010602Dto> cQHeaders, List<CQCategory010602Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
           
            MemoryStream memoryStream = new MemoryStream();
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
         
            int totalPivotColumnNumer = 0;
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot1"];

       


            IDictionary<string, string> firstDictionary = list.FirstOrDefault();
            if (firstDictionary != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionary.Keys)
                {
                    worksheet.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
                totalPivotColumnNumer = columnIndex11;
            }

            int rowIndex23 = 2;
            foreach (IDictionary<string, string> dictionary in list)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex23++;
            }

          
            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader010602Dto header = new CQHeader010602Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader010602Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader010602Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader010602Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            //ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            //CQCategory021502Dto category = new CQCategory021502Dto(); // Create an instance of CQHeader
            //int columnIndex111 = 1;
            //foreach (var propertyInfo in typeof(CQCategory021502Dto).GetProperties())
            //{
            //    string propertyName = propertyInfo.Name;
            //    worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
            //    columnIndex111++;
            //}
            //int rowIndex111 = 2;
            //foreach (CQCategory021502Dto category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            //{
            //    int columnIndex1 = 1;
            //    foreach (var propertyInfo in typeof(CQCategory021502Dto).GetProperties())
            //    {
            //        string propertyName = propertyInfo.Name;
            //        object propertyValue = propertyInfo.GetValue(category1);
            //        worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
            //        columnIndex1++;
            //    }
            //    rowIndex111++;
            //}

            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }

            //draw payments
        

            ExcelWorksheet worksheetpayment = excelPackage.Workbook.Worksheets["SQLPayment"];

            IDictionary<string, string> firstDictionaryyyy = bills.FirstOrDefault();
            if (firstDictionaryyyy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryyyy.Keys)
                {
                    worksheetpayment.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in bills)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetpayment.Cells[rowIndex22, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22++;
            }

            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
         
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet12 in excelPackage.Workbook.Worksheets)
            {
                if (worksheet12.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet12.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            //int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            //int totalSheetCount = 4; // Specify the total count of sheets

            //int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            //if (sheetCountToDelete > 0)
            //{
            //    for (int i = 0; i < sheetCountToDelete; i++)
            //    {
            //        string sheetName = "Category" + (desiredSheetCount + i + 1);
            //        ExcelWorksheet worksheet1122 = excelPackage.Workbook.Worksheets[sheetName];
            //        if (worksheet != null)
            //        {
            //            worksheet.Hidden = eWorkSheetHidden.Hidden;
            //        }
            //    }
            //}
            var worksheetQuot = excelPackage.Workbook.Worksheets["Quotation"];
            int totalColumns = worksheetQuot.Dimension.End.Column;

            for (int i = totalPivotColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
            {
                worksheetQuot.Column(i).Hidden = true;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ1_8(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader080501> cQHeaders, List<CQCategory080501> cQCategories, List<IDictionary<string, string>> compare)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["CatId"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            int pivotExcel = 1;
            int totalPivotColumnNumer = 0;
            foreach (var groupPivot in groupedItems)
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot" + pivotExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
                //  hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                    totalPivotColumnNumer = columnIndex11;

                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }

                // ExcelPackage
                // Set a password for the workbook
                //excelPackage.Workbook.Protection.SetPassword("password");
                //excelPackage.Workbook.Protection.LockStructure = true;
                //excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                //excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook
                //foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                //{

                //    worksheet1.Protection.IsProtected = true;
                //    worksheet1.Protection.AllowSelectLockedCells = true;
                //    worksheet1.Protection.AllowFormatCells = true;

                //}
                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                pivotExcel++;
            }
            //i want to delete other category if count <4


            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader080501 header = new CQHeader080501(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader080501).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader080501 header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader080501).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            CQCategory080501 category = new CQCategory080501(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQCategory080501).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex111 = 2;
            foreach (CQCategory080501 category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQCategory080501).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex111++;
            }

            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }
            //draw compare
            ExcelWorksheet worksheettt = excelPackage.Workbook.Worksheets["SQLCompare"];

            IDictionary<string, string> firstDictionaryyy = compare.FirstOrDefault();
            if (firstDictionaryyy != null)
            {
                int columnIndex1111 = 1;
                foreach (string key in firstDictionaryyy.Keys)
                {
                    worksheettt.Cells[1, columnIndex1111].Value = key;
                    columnIndex1111++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in compare)
            {
                int columnIndex22 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheettt.Cells[rowIndex22, columnIndex22].Value = value;
                    columnIndex22++;
                }
                rowIndex22++;
            }
            //draw payments
            var groupedItemsPayment = bills.GroupBy(d => d["CatId"]).ToList();
            int paymentExcel = 1;
            foreach (var groupBills in groupedItemsPayment)
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPayment" + paymentExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = worksheet;
                //hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = groupBills.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                }

                int rowIndex222 = 2;
                foreach (IDictionary<string, string> dictionary in groupBills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex222, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex222++;
                }

                // ExcelPackage
                // Set a password for the workbook
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                // excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook

                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                paymentExcel++;
            }
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            int totalSheetCount = 4; // Specify the total count of sheets

            int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            if (sheetCountToDelete > 0)
            {
                for (int i = 0; i < sheetCountToDelete; i++)
                {
                    string sheetName = "Category" + (desiredSheetCount + i + 1);
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
                    if (worksheet != null)
                    {
                        worksheet.Hidden = eWorkSheetHidden.Hidden;
                    }
                }
            }
            //delete columns from category1
            //ExcelWorksheet worksheetCategory1 = excelPackage.Workbook.Worksheets["Quotation"];
            //for (int i = 1; i <= 26; i++) // columns K to Z correspond to indices 11 to 26
            //{
            //    worksheetCategory1.Cells[1, i, ExcelPackage.MaxRows, i].Clear(); // clear all cells in the column
            //}

            //delete empty rows
            //for (int i = worksheetCategory1.Dimension.End.Row; i >= 1; i--)
            //{
            //    var row = worksheetCategory1.Cells[i, 1, i, worksheetCategory1.Dimension.End.Column];
            //    if (row.Any(c => !string.IsNullOrEmpty(c.Text)))
            //    {
            //        continue;
            //    }

            //    // Delete the row if it's empty
            //    worksheetCategory1.DeleteRow(i);
            //}
            var worksheetQuot = excelPackage.Workbook.Worksheets["Quotation"];
            int totalColumns = worksheetQuot.Dimension.End.Column;

            for (int i = totalPivotColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
            {
                worksheetQuot.Column(i).Hidden = true;
            }
            //for (int i = 1; i <= totalColumns; i++)
            //{
            //    bool isEmptyColumn = true;
            //    for (int j = 1; j <= worksheetQuot.Dimension.End.Row; j++)
            //    {
            //        if (worksheetQuot.Cells[j, i].Value != null)
            //        {
            //            isEmptyColumn = false;
            //            break;
            //        }
            //    }

            //    if (isEmptyColumn)
            //    {
            //        worksheetQuot.Column(i).Hidden = true;
            //    }
            //}

            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ6(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader070806Dto> cQHeaders, List<CQCategory070806Dto> cQCategories, List<IDictionary<string, string>> compare)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["CatId"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            //int pivotExcel = 1;
            int totalPivotColumnNumer = 0;
            //foreach (var groupPivot in groupedItems)
            //{

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot"];

                IDictionary<string, string> firstDictionary = list.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                    totalPivotColumnNumer = columnIndex11;

                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in list)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }


              //  pivotExcel++;
            //}
            //i want to delete other category if count <4


            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader070806Dto header = new CQHeader070806Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader070806Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader070806Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader070806Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            //ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            //CQCategory070806Dto category = new CQCategory070806Dto(); // Create an instance of CQHeader
            //int columnIndex111 = 1;
            //foreach (var propertyInfo in typeof(CQCategory070806Dto).GetProperties())
            //{
            //    string propertyName = propertyInfo.Name;
            //    worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
            //    columnIndex111++;
            //}
            //int rowIndex111 = 2;
            //foreach (CQCategory070806Dto category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            //{
            //    int columnIndex1 = 1;
            //    foreach (var propertyInfo in typeof(CQCategory070806Dto).GetProperties())
            //    {
            //        string propertyName = propertyInfo.Name;
            //        object propertyValue = propertyInfo.GetValue(category1);
            //        worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
            //        columnIndex1++;
            //    }
            //    rowIndex111++;
            //}

            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }
            //draw compare
            ExcelWorksheet worksheettt = excelPackage.Workbook.Worksheets["SQLCompare"];

            IDictionary<string, string> firstDictionaryyy = compare.FirstOrDefault();
            if (firstDictionaryyy != null)
            {
                int columnIndex1111 = 1;
                foreach (string key in firstDictionaryyy.Keys)
                {
                    worksheettt.Cells[1, columnIndex1111].Value = key;
                    columnIndex1111++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in compare)
            {
                int columnIndex22 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheettt.Cells[rowIndex22, columnIndex22].Value = value;
                    columnIndex22++;
                }
                rowIndex22++;
            }
            //draw payments
          //  var groupedItemsPayment = bills.GroupBy(d => d["CatId"]).ToList();
            //int paymentExcel = 1;
            //foreach (var groupBills in groupedItemsPayment)
            //{

                //ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPayment" + paymentExcel];
                ExcelWorksheet worksheet1 = excelPackage.Workbook.Worksheets["SQLPayment"];
                IDictionary<string, string> firstDictionar = bills.FirstOrDefault();
                if (firstDictionar != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionar.Keys)
                    {
                        worksheet1.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                }

                int rowIndex222 = 2;
                foreach (IDictionary<string, string> dictionary in bills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet1.Cells[rowIndex222, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex222++;
                }

                // ExcelPackage
                // Set a password for the workbook
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;

               // paymentExcel++;
           // }
            foreach (ExcelWorksheet worksheet12 in excelPackage.Workbook.Worksheets)
            {

                worksheet12.Protection.IsProtected = true;
                worksheet12.Protection.AllowSelectLockedCells = true;
                worksheet12.Protection.AllowFormatCells = true;

            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet12 in excelPackage.Workbook.Worksheets)
            {
                if (worksheet12.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet12.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            int totalSheetCount = 4; // Specify the total count of sheets

            int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            if (sheetCountToDelete > 0)
            {
                for (int i = 0; i < sheetCountToDelete; i++)
                {
                    string sheetName = "Category" + (desiredSheetCount + i + 1);
                    ExcelWorksheet worksheet121 = excelPackage.Workbook.Worksheets[sheetName];
                    if (worksheet121 != null)
                    {
                        worksheet121.Hidden = eWorkSheetHidden.Hidden;
                    }
                }
            }
            var worksheetQuot = excelPackage.Workbook.Worksheets["Quotation"];
            int totalColumns = worksheetQuot.Dimension.End.Column;

            for (int i = totalPivotColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
            {
                worksheetQuot.Column(i).Hidden = true;
            }

            await excelPackage.SaveAsAsync(memoryStream);


            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ7(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader051807Dto> cQHeaders, List<CQCategory051807Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["CatId"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            CQExcelDrawSqlPivotSheet(excelPackage, groupedItems);



            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader051807Dto header = new CQHeader051807Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader051807Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            CQCategory051807Dto category = new CQCategory051807Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQCategory051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex111 = 2;
            foreach (CQCategory051807Dto category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQCategory051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex111++;
            }

            CQExcelDrawSqlBenefitsAndPaymentSheets(benefits,null, bills, excelPackage);

            ExcelDeleteSheets(excelPackage, groupedItems);
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ9(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<IDictionary<string, string>> benefitsCompare, List<CQHeader281609Dto> cQHeaders, List<CQCategory281609Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["CatId"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            //CQExcelDrawSqlPivotSheet(excelPackage, groupedItems);

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot"];
            var totalPivotColumnNumer = 1;
            IDictionary<string, string> firstDictionary = list.FirstOrDefault();
            if (firstDictionary != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionary.Keys)
                {
                    worksheet.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
                totalPivotColumnNumer = columnIndex11;

            }

            int rowIndex23 = 2;
            foreach (IDictionary<string, string> dictionary in list)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex23++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader281609Dto header = new CQHeader281609Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader281609Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader281609Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            //ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            //CQCategory281609Dto category = new CQCategory281609Dto(); // Create an instance of CQHeader
            //int columnIndex111 = 1;
            //foreach (var propertyInfo in typeof(CQCategory281609Dto).GetProperties())
            //{
            //    string propertyName = propertyInfo.Name;
            //    worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
            //    columnIndex111++;
            //}
            //int rowIndex111 = 2;
            //foreach (CQCategory281609Dto category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            //{
            //    int columnIndex1 = 1;
            //    foreach (var propertyInfo in typeof(CQCategory281609Dto).GetProperties())
            //    {
            //        string propertyName = propertyInfo.Name;
            //        object propertyValue = propertyInfo.GetValue(category1);
            //        worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
            //        columnIndex1++;
            //    }
            //    rowIndex111++;
            //}

            CQExcelDrawSqlBenefitsAndPaymentSheets(benefits, benefitsCompare, bills, excelPackage);

            ExcelDeleteSheets(excelPackage, groupedItems);
            var worksheetQuot = excelPackage.Workbook.Worksheets["Insurred"];
            int totalColumns = worksheetQuot.Dimension.End.Column;

            for (int i = totalPivotColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
            {
                worksheetQuot.Column(i).Hidden = true;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ8(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<CQHeader291908Dto> cQHeaders, List<CQCategory291908Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["CatId"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            CQExcelDrawSqlPivotSheet(excelPackage, groupedItems);



            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader291908Dto header = new CQHeader291908Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader291908Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQLCategories"];
            CQCategory291908Dto category = new CQCategory291908Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQCategory291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex111].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex111 = 2;
            foreach (CQCategory291908Dto category1 in cQCategories) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQCategory291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    worksheetCategory.Cells[rowIndex111, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex111++;
            }

            CQExcelDrawSqlBenefitsAndPaymentSheets(benefits,null, bills, excelPackage);

            ExcelDeleteSheets(excelPackage, groupedItems);
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");

            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ11(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits,  List<IDictionary<string, string>> pricelist, List<IDictionary<string, string>> member, List<IDictionary<string, string>> summury, List<CQHeader331211Dto> cQHeaders, List<CQCategory331211Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["Category"]).ToList();
            var memberitems = member.GroupBy(d => d["Category"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            //draw pivot
            CQExcelDrawSqlPivotSheet(excelPackage, groupedItems);
            CQExcelDrawSqlPivotMemberSheet(excelPackage, memberitems);

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader331211Dto header = new CQHeader331211Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader331211Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader331211Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader331211Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw pricelist
            ExcelWorksheet worksheettt = excelPackage.Workbook.Worksheets["SQLPriceList"];

            IDictionary<string, string> firstDictionaryyy = pricelist.FirstOrDefault();
            if (firstDictionaryyy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryyy.Keys)
                {
                    worksheettt.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in pricelist)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheettt.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }
            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex22, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22++;
            }
            //draw benefits
            ExcelWorksheet worksheetts = excelPackage.Workbook.Worksheets["SQLSummary"];

            IDictionary<string, string> firstDictionaryys = summury.FirstOrDefault();
            if (firstDictionaryys != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryys.Keys)
                {
                    worksheetts.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22s = 2;
            foreach (IDictionary<string, string> dictionary in summury)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetts.Cells[rowIndex22s, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22s++;
            }
            ExcelDeleteSheets(excelPackage, groupedItems);
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ12(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> pricelist, List<IDictionary<string, string>> member, List<IDictionary<string, string>> summury, List<CQHeader041312Dto> cQHeaders, List<CQCategory041312Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //i want to draw for each category pivot
            //group pivot by category
            var groupedItems = list.GroupBy(d => d["Category"]).ToList();
            var memberitems = member.GroupBy(d => d["Category"]).ToList();
            MemoryStream memoryStream = new MemoryStream();
            //draw pivot
            CQExcelDrawSqlPivotSheet(excelPackage, groupedItems);
            CQExcelDrawSqlPivotMemberSheet(excelPackage, memberitems);

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader041312Dto header = new CQHeader041312Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader041312Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader041312Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader041312Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw pricelist
            ExcelWorksheet worksheettt = excelPackage.Workbook.Worksheets["SQLPriceList"];

            IDictionary<string, string> firstDictionaryyy = pricelist.FirstOrDefault();
            if (firstDictionaryyy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryyy.Keys)
                {
                    worksheettt.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in pricelist)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheettt.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }
            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex22, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22++;
            }
            //draw benefits
            ExcelWorksheet worksheetts = excelPackage.Workbook.Worksheets["SQLSummary"];

            IDictionary<string, string> firstDictionaryys = summury.FirstOrDefault();
            if (firstDictionaryys != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryys.Keys)
                {
                    worksheetts.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22s = 2;
            foreach (IDictionary<string, string> dictionary in summury)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetts.Cells[rowIndex22s, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22s++;
            }
            ExcelDeleteSheets(excelPackage, groupedItems);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelCQ3(byte[] fileBytes, List<IDictionary<string, string>> list, List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> bills, List<IDictionary<string, string>> compares, List<CQHeader090703Dto> cQHeaders, List<CQCategory311703Dto> cQCategories)
        {



            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
           
          
            MemoryStream memoryStream = new MemoryStream();

            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];

            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }
            //draw benefits
            ExcelWorksheet worksheetComapre = excelPackage.Workbook.Worksheets["SQLCompare"];

            IDictionary<string, string> firstDictionaryCompare = compares.FirstOrDefault();
            if (firstDictionaryCompare != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryCompare.Keys)
                {
                    worksheetComapre.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in compares)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetComapre.Cells[rowIndex22, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22++;
            }
            //draw payments


            ExcelWorksheet worksheetpayment = excelPackage.Workbook.Worksheets["SQLPayment"];

            IDictionary<string, string> firstDictionaryyyy = bills.FirstOrDefault();
            if (firstDictionaryyyy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryyyy.Keys)
                {
                    worksheetpayment.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex223 = 2;
            foreach (IDictionary<string, string> dictionary in bills)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetpayment.Cells[rowIndex223, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex223++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLHeader"];
            CQHeader090703Dto header = new CQHeader090703Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader090703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader090703Dto header1 in cQHeaders) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader090703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header1);
                    worksheetHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw benefits
            ExcelWorksheet worksheettPivot = excelPackage.Workbook.Worksheets["SQLPivot"];
            var totalPivotMemberColumnNumer = 0;
            IDictionary<string, string> firstDictionaryyPivot = benefits.FirstOrDefault();
            if (firstDictionaryyPivot != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryyPivot.Keys)
                {
                    worksheettPivot.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
                totalPivotMemberColumnNumer = columnIndex11;
            }

            int rowIndex2Pivot = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheettPivot.Cells[rowIndex2Pivot, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2Pivot++;
            }

            var worksheetQuot = excelPackage.Workbook.Worksheets["Quotation"];
            int totalColumns = worksheetQuot.Dimension.End.Column;

            for (int i = totalPivotMemberColumnNumer; i <= totalColumns; i++) // Start from 12 because you want to hide columns after 11
            {
                worksheetQuot.Column(i).Hidden = true;
            }

            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet12 in excelPackage.Workbook.Worksheets)
            {
                if (worksheet12.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet12.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        private static void CQExcelDrawSqlPivotSheet(ExcelPackage excelPackage, List<IGrouping<string, IDictionary<string, string>>> groupedItems)
        {
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            int pivotExcel = 1;
            foreach (var groupPivot in groupedItems)
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivot" + pivotExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
                //  hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }

                // ExcelPackage
                // Set a password for the workbook
                //excelPackage.Workbook.Protection.SetPassword("password");
                //excelPackage.Workbook.Protection.LockStructure = true;
                //excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                //excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook
                //foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                //{

                //    worksheet1.Protection.IsProtected = true;
                //    worksheet1.Protection.AllowSelectLockedCells = true;
                //    worksheet1.Protection.AllowFormatCells = true;

                //}
                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                pivotExcel++;
            }
        }
        private static void CQExcelDrawSqlPivotMemberSheet(ExcelPackage excelPackage, List<IGrouping<string, IDictionary<string, string>>> groupedItems)
        {
            List<int> pivotTotalSheet = new List<int>() { 1, 2, 3, 4 };
            int pivotExcel = 1;
            foreach (var groupPivot in groupedItems)
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPivotMember" + pivotExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
                //  hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = groupPivot.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;

                        columnIndex11++;
                    }
                }

                int rowIndex23 = 2;
                foreach (IDictionary<string, string> dictionary in groupPivot)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex23, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex23++;
                }

                // ExcelPackage
                // Set a password for the workbook
                //excelPackage.Workbook.Protection.SetPassword("password");
                //excelPackage.Workbook.Protection.LockStructure = true;
                //excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                //excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook
                //foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                //{

                //    worksheet1.Protection.IsProtected = true;
                //    worksheet1.Protection.AllowSelectLockedCells = true;
                //    worksheet1.Protection.AllowFormatCells = true;

                //}
                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                pivotExcel++;
            }
        }
        private static void CQExcelDrawSqlBenefitsAndPaymentSheets(List<IDictionary<string, string>> benefits, List<IDictionary<string, string>> benefitsCompare, List<IDictionary<string, string>> bills, ExcelPackage excelPackage)
        {
            //draw benefits
            ExcelWorksheet worksheett = excelPackage.Workbook.Worksheets["SQLBenefits"];
            
            IDictionary<string, string> firstDictionaryy = benefits.FirstOrDefault();
            if (firstDictionaryy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryy.Keys)
                {
                    worksheett.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex2 = 2;
            foreach (IDictionary<string, string> dictionary in benefits)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheett.Cells[rowIndex2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex2++;
            }
            //draw benefitspayment
            ExcelWorksheet worksheettt = excelPackage.Workbook.Worksheets["SQLBenefitsCompare"];

            IDictionary<string, string> firstDictionaryyy = benefitsCompare.FirstOrDefault();
            if (firstDictionaryyy != null)
            {
                int columnIndex11 = 1;
                foreach (string key in firstDictionaryyy.Keys)
                {
                    worksheettt.Cells[1, columnIndex11].Value = key;
                    columnIndex11++;
                }
            }

            int rowIndex22 = 2;
            foreach (IDictionary<string, string> dictionary in benefitsCompare)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheettt.Cells[rowIndex22, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex22++;
            }
            //draw payments
            //  var groupedItemsPayment = bills.GroupBy(d => d["CatId"]).ToList();
            //    int paymentExcel = 1;
            //  foreach (var groupBills in groupedItemsPayment)
            //  {

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPayment"];
               // ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["SQLPayment" + paymentExcel];

                // Hide a specific worksheet
                //ExcelWorksheet hiddenWorksheet = worksheet;
                //hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");


                IDictionary<string, string> firstDictionary = bills.FirstOrDefault();
                if (firstDictionary != null)
                {
                    int columnIndex11 = 1;
                    foreach (string key in firstDictionary.Keys)
                    {
                        worksheet.Cells[1, columnIndex11].Value = key;
                        columnIndex11++;
                    }
                }

                int rowIndex222 = 2;
                foreach (IDictionary<string, string> dictionary in bills)
                {
                    int columnIndex2 = 1;
                    foreach (string value in dictionary.Values)
                    {
                        worksheet.Cells[rowIndex222, columnIndex2].Value = value;
                        columnIndex2++;
                    }
                    rowIndex222++;
                }

                // ExcelPackage
                // Set a password for the workbook
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                // excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook

                //Console.WriteLine($"Category: {group.Key}");
                //foreach (var item in group)
                //{
                //    Console.WriteLine($"Name: {item["name"]}");
                //}
                //Console.WriteLine();
                //paymentExcel++;
          //  }
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
        }

        private static void ExcelDeleteSheets(ExcelPackage excelPackage, List<IGrouping<string, IDictionary<string, string>>> groupedItems)
        {
            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }

            //category hide
            int desiredSheetCount = groupedItems.Count; // Specify the desired count of sheets
            int totalSheetCount = 4; // Specify the total count of sheets

            int sheetCountToDelete = totalSheetCount - desiredSheetCount;
            if (sheetCountToDelete > 0)
            {
                for (int i = 0; i < sheetCountToDelete; i++)
                {
                    string sheetName = "Category" + (desiredSheetCount + i + 1);
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[sheetName];
                    if (worksheet != null)
                    {
                        worksheet.Hidden = eWorkSheetHidden.Hidden;
                    }
                }
            }
        }

        public async Task<byte[]> ConvetFormToExcelAF4(byte[] fileBytes, List<Af1_4EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
           
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Grade;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Currency;
               // worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].AnnualWages;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LimitOfCoverage;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MobileNumber;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Email;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF28(byte[] fileBytes, List<Af1_28EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].SponsorName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF5(byte[] fileBytes, List<Af1_5EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Currency;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].AnnualWages;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LimitOfCoverage;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF29(byte[] fileBytes, List<Af1_29EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Currency;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].AnnualWages;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LimitOfCoverage;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelAF2(byte[] fileBytes, List<Af1_2EM> aF1BL77Dtos)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            // Hide a specific worksheet
            ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[1];
            hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            // worksheetHide.(true);
            // Protect the worksheet with a password
            //worksheet.Protection.IsProtected = true;
            //worksheet.Protection.AllowSelectLockedCells = false;
            //worksheet.Protection.SetPassword("@@@");
            int y = 1;
            for (int i = 0; i < aF1BL77Dtos.Count; i++)
            {
                // Write the data to the worksheet
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Serial;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].Company;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StaffNbr;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].FirstName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MiddleName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].LastName;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].GenderCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].DOB;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NationalityCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].MaritalStatusCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].CountryOfDepartureCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].CountryOfDestinationCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].StayTripOptionCode;
                worksheet.Cells[i + 2, y++].Value = aF1BL77Dtos[i].NbrDaysWhenLess92;
                y = 1;
            }
            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
            {

                worksheet1.Protection.IsProtected = true;
                worksheet1.Protection.AllowSelectLockedCells = true;
                worksheet1.Protection.AllowFormatCells = true;

            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> ConvetFormToExcelProductList(byte[] fileBytes, List<ProductDto> products)
        {


            MemoryStream stream = new MemoryStream();
            // ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage())
            {


                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");


                // worksheetHide.(true);
                // Protect the worksheet with a password
                //worksheet.Protection.IsProtected = true;
                //worksheet.Protection.AllowSelectLockedCells = false;
                //worksheet.Protection.SetPassword("@@@");
                worksheet.Cells["A1"].Value = "Branch Category";
                worksheet.Cells["B1"].Value = "Branch Class";
                worksheet.Cells["C1"].Value = "Insurer";
                worksheet.Cells["D1"].Value = "Product name";
                worksheet.Cells["E1"].Value = "Third Party Admin";
                worksheet.Cells["F1"].Value = "Currency";
                worksheet.Cells["G1"].Value = "Creation Date";
                worksheet.Cells["H1"].Value = "Activation Date";
                int y = 1;
                for (int i = 0; i < products.Count; i++)
                {
                    // Write the data to the worksheet
                    worksheet.Cells[i + 2, y++].Value = products[i].ProductCategory;
                    worksheet.Cells[i + 2, y++].Value = products[i].ProductClass;
                    worksheet.Cells[i + 2, y++].Value = products[i].Insurer;
                    worksheet.Cells[i + 2, y++].Value = products[i].ProductName;
                    worksheet.Cells[i + 2, y++].Value = products[i].ThirdPartyAdmin;
                    worksheet.Cells[i + 2, y++].Value = products[i].Currency;
                    worksheet.Cells[i + 2, y++].Value = products[i].CreationDate.ToString("yyyy-MM-dd:ss");
                    worksheet.Cells[i + 2, y++].Value = products[i].ActivationDate.ToString("yyyy-MM-dd:ss");
                    y = 1;
                }
                MemoryStream memoryStream = new MemoryStream();
                // ExcelPackage
                // Set a password for the workbook
                excelPackage.Workbook.Protection.SetPassword("password");
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
                // Protect the workbook structure to prevent unhide
                //excelPackage.Workbook.Protection("password", true, true);
                //////// Protect all worksheets in the workbook
                foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                {

                    worksheet1.Protection.IsProtected = true;
                    worksheet1.Protection.AllowSelectLockedCells = true;
                    worksheet1.Protection.AllowFormatCells = true;

                }
                await excelPackage.SaveAsAsync(memoryStream);


                // Return the stream as a FileStreamResult with the appropriate content type and file name
                //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
                return excelPackage.GetAsByteArray();
            }
        }
        public async Task<byte[]> ConvetFormToExcelAF32SlipStep4(byte[] fileBytes, List<Slip4BL321110Dto> products)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            // ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                int y = 1;
                for (int i = 0; i < products.Count; i++)
                {
                    // Write the data to the worksheet
                    worksheet.Cells[i + 2, y++].Value = products[i].RecId;
                    worksheet.Cells[i + 2, y++].Value = products[i].BranchId;
                    worksheet.Cells[i + 2, y++].Value = products[i].BusinessLineCode;
                    worksheet.Cells[i + 2, y++].Value = products[i].Category;
                    worksheet.Cells[i + 2, y++].Value = products[i].BenefitNumber;
                    worksheet.Cells[i + 2, y++].Value = products[i].BenefitName;
                    worksheet.Cells[i + 2, y++].Value = products[i].BenefitAnswer;
                    worksheet.Cells[i + 2, y++].Value = products[i].LifeTime;
                    worksheet.Cells[i + 2, y++].Value = products[i].Excess;
                    y = 1;
                }
                MemoryStream memoryStream = new MemoryStream();


                await excelPackage.SaveAsAsync(memoryStream);

                return excelPackage.GetAsByteArray();
            }
        }
        public async Task<byte[]> ConvetFormToExcelAF33SlipStep4(byte[] fileBytes, List<Slip4BL331211Dto> products)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            // ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                int y = 1;
                for (int i = 0; i < products.Count; i++)
                {
                    // Write the data to the worksheet
                    worksheet.Cells[i + 2, y++].Value = products[i].RecId;
                    worksheet.Cells[i + 2, y++].Value = products[i].BranchId;
                    worksheet.Cells[i + 2, y++].Value = products[i].BusinessLineCode;
                    worksheet.Cells[i + 2, y++].Value = products[i].Category;
                    worksheet.Cells[i + 2, y++].Value = products[i].BenefitNumber;
                    worksheet.Cells[i + 2, y++].Value = products[i].BenefitName;
                    worksheet.Cells[i + 2, y++].Value = products[i].BenefitAnswer;
                    worksheet.Cells[i + 2, y++].Value = products[i].LifeTime;
                    worksheet.Cells[i + 2, y++].Value = products[i].Excess;
                    y = 1;
                }
                MemoryStream memoryStream = new MemoryStream();


                await excelPackage.SaveAsAsync(memoryStream);

                return excelPackage.GetAsByteArray();
            }
        }
        public async Task<byte[]> ConvetFormToExcelAF32DetailsStep5(byte[] fileBytes, List<SalesTransactionDetailsPricesNewDto> products)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            // ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                int y = 1;
                for (int i = 0; i < products.Count; i++)
                {
                    // Write the data to the worksheet
                    worksheet.Cells[i + 2, y++].Value = products[i].SalesTrxDetailsId;
                    worksheet.Cells[i + 2, y++].Value = products[i].SectionName;
                    worksheet.Cells[i + 2, y++].Value = products[i].Category;
                    worksheet.Cells[i + 2, y++].Value = products[i].Dependency;
                    worksheet.Cells[i + 2, y++].Value = products[i].Gender;
                    worksheet.Cells[i + 2, y++].Value = products[i].MaritalStatus;
                    worksheet.Cells[i + 2, y++].Value = products[i].CostSharing;
                    worksheet.Cells[i + 2, y++].Value = products[i].AgeMinRange;
                    worksheet.Cells[i + 2, y++].Value = products[i].AgeMaxRange;
                    worksheet.Cells[i + 2, y++].Value = products[i].Premium;
                    //worksheet.Cells[i + 2, y++].Value = products[i].Rate;
                    y = 1;
                }
                MemoryStream memoryStream = new MemoryStream();


                await excelPackage.SaveAsAsync(memoryStream);

                return excelPackage.GetAsByteArray();
            }
        }
        public async Task<byte[]> ConvetFormToExcelAF33DetailsStep5(byte[] fileBytes, List<SalesTransactionBL331211DetailsPricesNewDto> products)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            // ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                int y = 1;
                for (int i = 0; i < products.Count; i++)
                {
                    // Write the data to the worksheet
                    worksheet.Cells[i + 2, y++].Value = products[i].SalesTrxDetailsId;
                    worksheet.Cells[i + 2, y++].Value = products[i].SectionName;
                    worksheet.Cells[i + 2, y++].Value = products[i].Category;
                    worksheet.Cells[i + 2, y++].Value = products[i].Dependency;
                    worksheet.Cells[i + 2, y++].Value = products[i].Gender;
                    worksheet.Cells[i + 2, y++].Value = products[i].MaritalStatus;
                    worksheet.Cells[i + 2, y++].Value = products[i].Limit;
                    worksheet.Cells[i + 2, y++].Value = products[i].AgeMinRange;
                    worksheet.Cells[i + 2, y++].Value = products[i].AgeMaxRange;
                    worksheet.Cells[i + 2, y++].Value = products[i].Premium;
                    worksheet.Cells[i + 2, y++].Value = products[i].Rate;
                    y = 1;
                }
                MemoryStream memoryStream = new MemoryStream();


                await excelPackage.SaveAsAsync(memoryStream);

                return excelPackage.GetAsByteArray();
            }
        }
        public async Task<byte[]> ConvetFormToExcelProductPrice(byte[] fileBytes, string businessLine,
            List<ProductPriceEM> products, List<CombinationEM> combinations, List<TechnicalSheetEM> technicalSheets)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            // ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

                // Define the column names and their respective indices
                var columnsBusinessLine1 = new Dictionary<string, int>
    {
        { "RecId", 1 },
        { "ProductId", 2 },
        { "TechnicalSheet", 3 },
        { "FamilyCountMinRange", 4 },
        { "FamilyCountMaxRange", 5 },
        { "Period", 6 },
        { "DaysCountMinRange", 7 },
        { "DaysCountMaxRange", 8 },
        { "AgeMinRange", 9 },
        { "AgeMaxRange", 10 },
        { "Premium", 11 },
        { "NbrChildFree", 12 }
    };

                var columnsBusinessLine2 = new Dictionary<string, int>
    {
        { "RecId", 1 },
        { "ProductId", 2 },
        { "TechnicalSheet", 3 },
        { "FamilyCountMinRange", 4 },
        { "FamilyCountMaxRange", 5 },
        { "Gender", 6 },
        { "MaritalStatus", 7 },
        { "AgeMinRange", 8 },
        { "AgeMaxRange", 9 },
        { "Rate", 10 },
        { "Premium", 11 }
    };
                var columnsBusinessLine3 = new Dictionary<string, int>
    {
        { "RecId", 1 },
        { "ProductId", 2 },
        { "TechnicalSheet", 3 },
        { "Gender", 4 },
        { "AgeMinRange", 5 },
        { "AgeMaxRange", 6 },
        { "Premium", 7 }
    };

                var columnsBusinessLine4 = new Dictionary<string, int>
    {
        { "RecId", 1 },
        { "ProductId", 2 },
        { "TechnicalSheet", 3 },
        { "FamilyCountMinRange", 4 },
        { "FamilyCountMaxRange", 5 },
        { "Dependency", 6 },
        { "Gender", 7 },
        { "MaritalStatus", 8 },
        { "CostSharing", 9 },
        { "AgeMinRange", 10 },
        { "AgeMaxRange", 11 },
        { "Premium", 12 },
        { "Pa_Premium", 13 }
    };
                Dictionary<string, int> columns;
                switch (businessLine)
                {
                    case "281609":
                    case "070806":
                        columns = columnsBusinessLine3;
                        break;
                    case "021502":
                    case "010602":
                        columns = columnsBusinessLine1;
                        break;
                    case "311703":
                    case "090703":
                    case "080501":
                    case "301401":
                    case "321110":
                        columns = columnsBusinessLine4;
                        break;
                    case "061005":
                    case "291908":
                    case "030904":
                    case "051807":
                    case "331211":
                    case "041312":
                        columns = columnsBusinessLine2;
                        break;
                    // Add cases for other business lines as needed...
                    default:
                        throw new Exception("Unknown business line");
                }

                // Assign values to the columns
                foreach (var column in columns)
                {
                    worksheet.Cells[1, column.Value].Value = column.Key;
                }

                // Write the data to the worksheet
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i] == null)
                    {
                        continue; // Skip this iteration if the product is null
                    }

                    foreach (var column in columns)
                    {
                        PropertyInfo property = null;
                        if (column.Key.Equals("Pa_Premium"))
                        {
                            property = products[i].GetType().GetProperty("PaPremiium");
                        }
                        else
                        {
                            property = products[i].GetType().GetProperty(column.Key);
                        }
                        if (property != null)
                        {
                            worksheet.Cells[i + 2, column.Value].Value = property.GetValue(products[i], null);
                        }
                    }
                }
                ExcelWorksheet worksheet1;
                if (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == "Combination"))
                {
                    worksheet1 = excelPackage.Workbook.Worksheets["Combination"];
                }
                else
                {
                    worksheet1 = excelPackage.Workbook.Worksheets.Add("Combination");
                }
                // Write the data to the worksheet
                int columnIndex = 1;
                foreach (var propertyInfo in typeof(CombinationEM).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    worksheet1.Cells[1, columnIndex].Value = propertyName;
                    columnIndex++;
                }
                int rowIndex = 2;
                foreach (CombinationEM header11 in combinations) // Replace yourCQHeaderList with the actual list of CQHeader objects
                {
                    int columnIndex11 = 1;
                    foreach (var propertyInfo in typeof(CombinationEM).GetProperties())
                    {
                        string propertyName = propertyInfo.Name;
                        object propertyValue = propertyInfo.GetValue(header11);
                        worksheet1.Cells[rowIndex, columnIndex11].Value = propertyValue;
                        columnIndex11++;
                    }
                    rowIndex++;
                }
                ExcelWorksheet worksheet2;
                if (excelPackage.Workbook.Worksheets.Any(ws => ws.Name == "Technical"))
                {
                    worksheet2 = excelPackage.Workbook.Worksheets["Technical"];
                }
                else
                {
                    worksheet2 = excelPackage.Workbook.Worksheets.Add("Technical");
                }
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(TechnicalSheetEM).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    worksheet2.Cells[1, columnIndex1].Value = propertyName;
                    columnIndex1++;
                }
                int rowIndex1 = 2;
                foreach (TechnicalSheetEM header11 in technicalSheets) // Replace yourCQHeaderList with the actual list of CQHeader objects
                {
                    int columnIndex11 = 1;
                    foreach (var propertyInfo in typeof(TechnicalSheetEM).GetProperties())
                    {
                        string propertyName = propertyInfo.Name;
                        object propertyValue = propertyInfo.GetValue(header11);
                        worksheet2.Cells[rowIndex1, columnIndex11].Value = propertyValue;
                        columnIndex11++;
                    }
                    rowIndex1++;
                }
                MemoryStream memoryStream = new MemoryStream();

                await excelPackage.SaveAsAsync(memoryStream);


                return excelPackage.GetAsByteArray();
            }
        }
        public async Task<byte[]> Split080501(byte[] fileBytes, SalesTransactionBL080501SlipResp salesTransactionBL080501SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader080501 header = new CQHeader080501(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader080501).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader080501 header11 in salesTransactionBL080501SlipResp.CQHeaderBL080501) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader080501).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }
            //i want to delete other category if count <4


            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL080501Dtco).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL080501Dtco> listheader = new List<AF1BL080501Dtco>();
            listheader.Add(salesTransactionBL080501SlipResp.SalesTransactionBL080501.AF1BL080501);
            foreach (AF1BL080501Dtco header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL080501Dtco).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL080501Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL080501Dto category1 in salesTransactionBL080501SlipResp.SalesTransactionBL080501.AF1BL080501.AF1BL080501List) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL080501Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    if (propertyName.Equals("GenderCode"))
                    {
                        if (propertyValue.Equals("M"))
                        {
                            propertyValue = "Male";

                        }
                        else if (propertyValue.Equals("F"))
                        {
                            propertyValue = "Female";
                        }
                    }
                    if (propertyName.Equals("MaritalStatusCode"))
                    {
                        if (propertyValue.Equals("M"))
                        {
                            propertyValue = "Married";
                        }
                        else if (propertyValue.Equals("S"))
                        {
                            propertyValue = "Single";
                        }
                        else if (propertyValue.Equals("W"))
                        {
                            propertyValue = "Widowed";
                        }
                        else if (propertyValue.Equals("P"))
                        {
                            propertyValue = "Seperated";
                        }
                        else if (propertyValue.Equals("D"))
                        {
                            propertyValue = "Divorced";
                        }
                    }
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }


            SecureExcelAndHideSQLSheet(true, excelPackage);

            await excelPackage.SaveAsAsync(memoryStream);


            return excelPackage.GetAsByteArray();

        }

        private static void DrawHeaderSlip(ExcelWorksheet worksheetHeader, int rowIndex1, object header12, int columnIndex111, PropertyInfo propertyInfo)
        {
            object propertyValue = propertyInfo.GetValue(header12);
            string propertyName = propertyInfo.Name;
            switch (propertyName)
            {
                case "ResidenceCode":
                    if (propertyValue.Equals("LB"))
                    {
                        propertyValue = "Lebanon";
                    }
                    break;
                case "Ambulatory":
                case "PrescriptionMedecine":
                case "DoctorVisit":
                case "NSSF":
                    if (propertyValue.ToString().ToLower().Equals("true"))
                    {
                        propertyValue = "Yes";
                    }
                    else if (propertyValue.ToString().ToLower().Equals("false"))
                    {
                        propertyValue = "No";
                    }
                    break;
                default:
                    propertyValue = propertyValue;
                    break;
            }



            worksheetHeader.Cells[rowIndex1, columnIndex111].Value = propertyValue;
        }

        public async Task<byte[]> Split010602(byte[] fileBytes, SalesTransactionBL010602SlipResp salesTransactionBL010602SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader010602Dto header = new CQHeader010602Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader010602Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader010602Dto header11 in salesTransactionBL010602SlipResp.CQHeaderBL010602) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader010602Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL010602Dtco).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL010602Dtco> listheader = new List<AF1BL010602Dtco>();
            listheader.Add(salesTransactionBL010602SlipResp.SalesTransactionBL010602.AF1BL010602);
            foreach (AF1BL010602Dtco header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL010602Dtco).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL010602Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL010602Dto category1 in salesTransactionBL010602SlipResp.SalesTransactionBL010602.AF1BL010602.AF1BL010602List) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL010602Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split070806(byte[] fileBytes, SalesTransactionBL070806SlipResp salesTransactionBL070806SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader070806Dto header = new CQHeader070806Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader070806Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader070806Dto header11 in salesTransactionBL070806SlipResp.CQHeaderBL070806) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader070806Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL070806Dtco).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL070806Dtco> listheader = new List<AF1BL070806Dtco>();
            listheader.Add(salesTransactionBL070806SlipResp.SalesTransactionBL070806.AF1BL070806);
            foreach (AF1BL070806Dtco header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL070806Dtco).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL070806Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL070806Dto category1 in salesTransactionBL070806SlipResp.SalesTransactionBL070806.AF1BL070806.AF1BL070806List) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL070806Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split090703(byte[] fileBytes, SalesTransactionBL090703SlipResp salesTransactionBL090703SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader090703Dto header = new CQHeader090703Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader090703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader090703Dto header11 in salesTransactionBL090703SlipResp.CQHeaderBL090703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader090703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL090703Dtco).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL090703Dtco> listheader = new List<AF1BL090703Dtco>();
            listheader.Add(salesTransactionBL090703SlipResp.SalesTransactionBL090703.AF1BL090703);
            foreach (AF1BL090703Dtco header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL090703Dtco).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL090703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL090703Dto category1 in salesTransactionBL090703SlipResp.SalesTransactionBL090703.AF1BL090703.AF1BL090703List) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL090703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split030904(byte[] fileBytes, SalesTransactionBL030904SlipResp salesTransactionBL030904SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader030904Dto header = new CQHeader030904Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader030904Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader030904Dto header11 in salesTransactionBL030904SlipResp.CQHeaderBL030904) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader030904Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL030904Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL030904Dto> listheader = new List<AF1BL030904Dto>();
            listheader.AddRange(salesTransactionBL030904SlipResp.SalesTransactionBL030904.AF1BL030904);
            foreach (AF1BL030904Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL030904Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL030904Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL030904Dto category1 in salesTransactionBL030904SlipResp.SalesTransactionBL030904.AF1BL030904) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL030904Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split041312(byte[] fileBytes, SalesTransactionBL041312SlipResp salesTransactionBL041312SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader041312Dto header = new CQHeader041312Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader041312Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader041312Dto header11 in salesTransactionBL041312SlipResp.CQHeaderBL041312) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader041312Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }
            //draw step1
            ExcelWorksheet worksheetHeaders1 = excelPackage.Workbook.Worksheets["SQLStep1"];
            List<IDictionary<string, string>> step1 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL041312SlipResp.AF1BL041312);
            if (step1 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step1.FirstOrDefault().Keys)
                {
                    worksheetHeaders1.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndex23 = 2;
            foreach (IDictionary<string, string> dictionary in step1)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaders1.Cells[rowIndex23, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex23++;
            }

            //draw step2
            ExcelWorksheet worksheetHeaderstep2 = excelPackage.Workbook.Worksheets["SQLStep2"];
            List<IDictionary<string, string>> step2 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL041312SlipResp.Step2BL041312);
            if (step2 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step1.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep2.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep2 = 2;
            foreach (IDictionary<string, string> dictionary in step2)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep2.Cells[rowIndexstep2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep2++;
            }
            //draw step3
            ExcelWorksheet worksheetHeaderstep3 = excelPackage.Workbook.Worksheets["SQLStep3"];
            List<IDictionary<string, string>> step3 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL041312SlipResp.Step3BL041312);
            if (step3 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step3.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep3.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep3 = 2;
            foreach (IDictionary<string, string> dictionary in step3)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep3.Cells[rowIndexstep3, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep3++;
            }
            //draw step3
            ExcelWorksheet worksheetHeaderstep4 = excelPackage.Workbook.Worksheets["SQLStep4"];
            List<IDictionary<string, string>> step4 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL041312SlipResp.Step4BL041312);
            if (step4 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step4.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep4.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep4 = 2;
            foreach (IDictionary<string, string> dictionary in step4)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep4.Cells[rowIndexstep4, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep4++;
            }

            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split021502(byte[] fileBytes, SalesTransactionBL021502SlipResp salesTransactionBL021502SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader021502Dto header = new CQHeader021502Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader021502Dto header11 in salesTransactionBL021502SlipResp.CQHeaderBL021502) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader021502Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL021502Dto> listheader = new List<AF1BL021502Dto>();
            listheader.AddRange(salesTransactionBL021502SlipResp.SalesTransactionBL021502.AF1BL021502);
            foreach (AF1BL021502Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL021502Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL021502Dto category1 in salesTransactionBL021502SlipResp.SalesTransactionBL021502.AF1BL021502) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL021502Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split051807(byte[] fileBytes, SalesTransactionBL051807SlipResp salesTransactionBL051807SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader051807Dto header = new CQHeader051807Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader051807Dto header11 in salesTransactionBL051807SlipResp.CQHeaderBL051807) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL051807Dto> listheader = new List<AF1BL051807Dto>();
            listheader.AddRange(salesTransactionBL051807SlipResp.SalesTransactionBL051807.AF1BL051807);
            foreach (AF1BL051807Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL051807Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL051807Dto category1 in salesTransactionBL051807SlipResp.SalesTransactionBL051807.AF1BL051807) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split061005(byte[] fileBytes, SalesTransactionBL061005SlipResp salesTransactionBL061005SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader061005Dto header = new CQHeader061005Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader061005Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader061005Dto header11 in salesTransactionBL061005SlipResp.CQHeaderBL061005) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader061005Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL061005Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL061005Dto> listheader = new List<AF1BL061005Dto>();
            listheader.AddRange(salesTransactionBL061005SlipResp.SalesTransactionBL061005.AF1BL061005);
            foreach (AF1BL061005Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL061005Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL061005Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL061005Dto category1 in salesTransactionBL061005SlipResp.SalesTransactionBL061005.AF1BL061005) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL061005Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split291908(byte[] fileBytes, SalesTransactionBL291908SlipResp salesTransactionBL291908SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader291908Dto header = new CQHeader291908Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader291908Dto header11 in salesTransactionBL291908SlipResp.CQHeaderBL291908) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL291908Dto> listheader = new List<AF1BL291908Dto>();
            listheader.AddRange(salesTransactionBL291908SlipResp.SalesTransactionBL291908.AF1BL291908);
            foreach (AF1BL291908Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL291908Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL291908Dto category1 in salesTransactionBL291908SlipResp.SalesTransactionBL291908.AF1BL291908) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split301401(byte[] fileBytes, SalesTransactionBL301401SlipResp salesTransactionBL301401SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader301401Dto header = new CQHeader301401Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader301401Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader301401Dto header11 in salesTransactionBL301401SlipResp.CQHeaderBL301401) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader301401Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL301401Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL301401Dto> listheader = new List<AF1BL301401Dto>();
            listheader.AddRange(salesTransactionBL301401SlipResp.SalesTransactionBL301401.AF1BL301401);
            foreach (AF1BL301401Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL301401Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL301401Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL301401Dto category1 in salesTransactionBL301401SlipResp.SalesTransactionBL301401.AF1BL301401) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL301401Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split331211(byte[] fileBytes, SalesTransactionBL331211SlipResp salesTransactionBL331211SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader331211Dto header = new CQHeader331211Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader331211Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader331211Dto header11 in salesTransactionBL331211SlipResp.CQHeaderBL331211) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader331211Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw step1
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLStep1"];
            List<IDictionary<string, string>> step1 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL331211SlipResp.AF1BL331211);
            if (step1 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step1.FirstOrDefault().Keys)
                {
                    worksheetHeader.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndex23 = 2;
            foreach (IDictionary<string, string> dictionary in step1)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeader.Cells[rowIndex23, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex23++;
            }

            //draw step2
            ExcelWorksheet worksheetHeaderstep2 = excelPackage.Workbook.Worksheets["SQLStep2"];
            List<IDictionary<string, string>> step2 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL331211SlipResp.Step2BL331211);
            if (step2 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step1.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep2.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep2 = 2;
            foreach (IDictionary<string, string> dictionary in step2)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep2.Cells[rowIndexstep2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep2++;
            }
            //draw step3
            ExcelWorksheet worksheetHeaderstep3 = excelPackage.Workbook.Worksheets["SQLStep3"];
            List<IDictionary<string, string>> step3 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL331211SlipResp.Step3BL331211);
            if (step3 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step3.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep3.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep3 = 2;
            foreach (IDictionary<string, string> dictionary in step3)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep3.Cells[rowIndexstep3, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep3++;
            }
            //draw step3
            ExcelWorksheet worksheetHeaderstep4 = excelPackage.Workbook.Worksheets["SQLStep4"];
            List<IDictionary<string, string>> step4 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL331211SlipResp.Step4BL331211);
            if (step4 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step4.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep4.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep4 = 2;
            foreach (IDictionary<string, string> dictionary in step4)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep4.Cells[rowIndexstep4, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep4++;
            }

            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split321110(byte[] fileBytes, SalesTransactionBL321110SlipResp salesTransactionBL321110SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader321110 header = new CQHeader321110(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader321110).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader321110 header11 in salesTransactionBL321110SlipResp.CQHeaderBL321110) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader321110).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw step1
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQLStep1"];
            List<IDictionary<string, string>> step1 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL321110SlipResp.AF1BL321110);
            if (step1 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step1.FirstOrDefault().Keys)
                {
                    worksheetHeader.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndex23 = 2;
            foreach (IDictionary<string, string> dictionary in step1)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeader.Cells[rowIndex23, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndex23++;
            }

            //draw step2
            ExcelWorksheet worksheetHeaderstep2 = excelPackage.Workbook.Worksheets["SQLStep2"];
            List<IDictionary<string, string>> step2 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL321110SlipResp.Step2BL321110);
            if (step2 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step1.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep2.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep2 = 2;
            foreach (IDictionary<string, string> dictionary in step2)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep2.Cells[rowIndexstep2, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep2++;
            }
            //draw step3
            ExcelWorksheet worksheetHeaderstep3 = excelPackage.Workbook.Worksheets["SQLStep3"];
            List<IDictionary<string, string>> step3 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL321110SlipResp.Step3BL321110);
            if (step3 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step3.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep3.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep3 = 2;
            foreach (IDictionary<string, string> dictionary in step3)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep3.Cells[rowIndexstep3, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep3++;
            }
            //draw step3
            ExcelWorksheet worksheetHeaderstep4 = excelPackage.Workbook.Worksheets["SQLStep4"];
            List<IDictionary<string, string>> step4 = _global.GetDictoinaryListFromDynamicList(salesTransactionBL321110SlipResp.Step4BL321110);
            if (step4 != null)
            {
                int columnIndex11 = 1;
                foreach (string key in step4.FirstOrDefault().Keys)
                {
                    worksheetHeaderstep4.Cells[1, columnIndex11].Value = key;

                    columnIndex11++;
                }
            }

            int rowIndexstep4 = 2;
            foreach (IDictionary<string, string> dictionary in step4)
            {
                int columnIndex2 = 1;
                foreach (string value in dictionary.Values)
                {
                    worksheetHeaderstep4.Cells[rowIndexstep4, columnIndex2].Value = value;
                    columnIndex2++;
                }
                rowIndexstep4++;
            }

            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split281609(byte[] fileBytes, SalesTransactionBL281609SlipResp salesTransactionBL281609SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader281609Dto header = new CQHeader281609Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader281609Dto header11 in salesTransactionBL281609SlipResp.CQHeaderBL281609) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader281609Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL281609Dto> listheader = new List<AF1BL281609Dto>();
            listheader.AddRange(salesTransactionBL281609SlipResp.SalesTransactionBL281609.AF1BL281609);
            foreach (AF1BL281609Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL281609Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL281609Dto category1 in salesTransactionBL281609SlipResp.SalesTransactionBL281609.AF1BL281609) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL281609Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        public async Task<byte[]> Split311703(byte[] fileBytes, SalesTransactionBL311703SlipResp salesTransactionBL311703SlipResp)
        {
            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            MemoryStream memoryStream = new MemoryStream();
            //draw cqheader
            ExcelWorksheet worksheetticketHeader = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader311703Dto header = new CQHeader311703Dto(); // Create an instance of CQHeader
            int columnIndex = 1;
            foreach (var propertyInfo in typeof(CQHeader311703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetticketHeader.Cells[1, columnIndex].Value = propertyName;
                columnIndex++;
            }
            int rowIndex = 2;
            foreach (CQHeader311703Dto header11 in salesTransactionBL311703SlipResp.CQHeaderBL311703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(CQHeader311703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header11);
                    worksheetticketHeader.Cells[rowIndex, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex++;
            }

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Header"];
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(AF1BL311703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;
            List<AF1BL311703Dto> listheader = new List<AF1BL311703Dto>();
            listheader.AddRange(salesTransactionBL311703SlipResp.SalesTransactionBL311703.AF1BL311703);
            foreach (AF1BL311703Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex111 = 1;
                foreach (var propertyInfo in typeof(AF1BL311703Dto).GetProperties())
                {
                    DrawHeaderSlip(worksheetHeader, rowIndex1, header12, columnIndex111, propertyInfo);
                    columnIndex111++;
                }
                rowIndex1++;
            }

            //draw cqcategory
            ExcelWorksheet worksheetCategory = excelPackage.Workbook.Worksheets["SQL_Body"];
            int columnIndex1112 = 1;
            foreach (var propertyInfo in typeof(AF1BL311703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetCategory.Cells[1, columnIndex1112].Value = propertyName;
                columnIndex1112++;
            }
            int rowIndex1112 = 2;
            foreach (AF1BL311703Dto category1 in salesTransactionBL311703SlipResp.SalesTransactionBL311703.AF1BL311703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1 = 1;
                foreach (var propertyInfo in typeof(AF1BL311703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(category1);
                    propertyValue = DrawBodySlip(propertyName, propertyValue);
                    worksheetCategory.Cells[rowIndex1112, columnIndex1].Value = propertyValue;
                    columnIndex1++;
                }
                rowIndex1112++;
            }
            SecureExcelAndHideSQLSheet(true, excelPackage);
            await excelPackage.SaveAsAsync(memoryStream);
            return excelPackage.GetAsByteArray();
        }
        private static object DrawBodySlip(string propertyName, object propertyValue)
        {
            if (propertyName.Equals("GenderCode"))
            {
                if (propertyValue.Equals("M"))
                {
                    propertyValue = "Male";

                }
                else if (propertyValue.Equals("F"))
                {
                    propertyValue = "Female";
                }
            }
            if (propertyName.Equals("MaritalStatusCode"))
            {
                if (propertyValue.Equals("M"))
                {
                    propertyValue = "Married";
                }
                else if (propertyValue.Equals("S"))
                {
                    propertyValue = "Single";
                }
                else if (propertyValue.Equals("W"))
                {
                    propertyValue = "Widowed";
                }
                else if (propertyValue.Equals("P"))
                {
                    propertyValue = "Seperated";
                }
                else if (propertyValue.Equals("D"))
                {
                    propertyValue = "Divorced";
                }
            }

            return propertyValue;
        }

        private static void SecureExcelAndHideSQLSheet(bool isSecure, ExcelPackage excelPackage)
        {
            if (isSecure)
            {
                foreach (ExcelWorksheet worksheet1 in excelPackage.Workbook.Worksheets)
                {

                    worksheet1.Protection.IsProtected = true;
                    worksheet1.Protection.AllowSelectLockedCells = true;
                    worksheet1.Protection.AllowFormatCells = true;

                }
            }


            //hide Sql sheets
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
        }





        public async Task<byte[]> ConvetFormToExcelShortLongListtBL080501(byte[] fileBytes, List<CQShortListBL080501Dto> cQShortListBL080501, List<CQFullListBL080501Dto> cQFullListBL080501, List<CQHeader080501> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL080501Dto header1 = new CQShortListBL080501Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL080501Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL080501Dto header12 in cQShortListBL080501) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL080501Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL080501Dto header11 = new CQFullListBL080501Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL080501Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL080501Dto header12 in cQFullListBL080501) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL080501Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader080501 header6 = new CQHeader080501(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader080501).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader080501> listheader = new List<CQHeader080501>();
            listheader.AddRange(headerlist);
            foreach (CQHeader080501 header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader080501).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL010602(byte[] fileBytes, List<CQShortListBL010602Dto> cQShortListBL010602, List<CQFullListBL010602Dto> cQFullListBL010602, List<CQHeader010602Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL010602Dto header1 = new CQShortListBL010602Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL010602Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL010602Dto header12 in cQShortListBL010602) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL010602Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL010602Dto header11 = new CQFullListBL010602Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL010602Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL010602Dto header12 in cQFullListBL010602) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL010602Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader010602Dto header6 = new CQHeader010602Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader010602Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader010602Dto> listheader = new List<CQHeader010602Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader010602Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader010602Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL311703(byte[] fileBytes, List<CQShortListBL311703Dto> cQShortListBL311703, List<CQFullListBL311703Dto> cQFullListBL311703, List<CQHeader311703Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL311703Dto header1 = new CQShortListBL311703Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL311703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL311703Dto header12 in cQShortListBL311703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL311703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL311703Dto header11 = new CQFullListBL311703Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL311703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL311703Dto header12 in cQFullListBL311703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL311703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader311703Dto header6 = new CQHeader311703Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader311703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader311703Dto> listheader = new List<CQHeader311703Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader311703Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader311703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL090703(byte[] fileBytes, List<CQShortListBL090703Dto> cQShortListBL090703, List<CQFullListBL090703Dto> cQFullListBL090703, List<CQHeader090703Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL090703Dto header1 = new CQShortListBL090703Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL090703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL090703Dto header12 in cQShortListBL090703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL090703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL090703Dto header11 = new CQFullListBL090703Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL090703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL090703Dto header12 in cQFullListBL090703) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL090703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader090703Dto header6 = new CQHeader090703Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader090703Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader090703Dto> listheader = new List<CQHeader090703Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader090703Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader090703Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL061005(byte[] fileBytes, List<CQShortListBL061005Dto> cQShortListBL061005, List<CQFullListBL061005Dto> cQFullListBL061005, List<CQHeader061005Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL061005Dto header1 = new CQShortListBL061005Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL061005Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL061005Dto header12 in cQShortListBL061005) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL061005Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL061005Dto header11 = new CQFullListBL061005Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL061005Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL061005Dto header12 in cQFullListBL061005) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL061005Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader061005Dto header6 = new CQHeader061005Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader061005Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader061005Dto> listheader = new List<CQHeader061005Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader061005Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader061005Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL070806(byte[] fileBytes, List<CQShortListBL070806Dto> cQShortListBL070806, List<CQFullListBL070806Dto> cQFullListBL070806, List<CQHeader070806Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL070806Dto header1 = new CQShortListBL070806Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL070806Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL070806Dto header12 in cQShortListBL070806) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL070806Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL070806Dto header11 = new CQFullListBL070806Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL070806Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL070806Dto header12 in cQFullListBL070806) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL070806Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader070806Dto header6 = new CQHeader070806Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader070806Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader070806Dto> listheader = new List<CQHeader070806Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader070806Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader070806Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL021502(byte[] fileBytes, List<CQShortListBL021502Dto> cQShortListBL021502, List<CQFullListBL021502Dto> cQFullListBL021502, List<CQHeader021502Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL021502Dto header1 = new CQShortListBL021502Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL021502Dto header12 in cQShortListBL021502) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL021502Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL021502Dto header11 = new CQFullListBL021502Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL021502Dto header12 in cQFullListBL021502) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL021502Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader021502Dto header6 = new CQHeader021502Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader021502Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader021502Dto> listheader = new List<CQHeader021502Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader021502Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader021502Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL051807(byte[] fileBytes, List<CQShortListBL051807Dto> cQShortListBL051807, List<CQFullListBL051807Dto> cQFullListBL051807, List<CQHeader051807Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL051807Dto header1 = new CQShortListBL051807Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL051807Dto header12 in cQShortListBL051807) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL051807Dto header11 = new CQFullListBL051807Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL051807Dto header12 in cQFullListBL051807) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader051807Dto header6 = new CQHeader051807Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader051807Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader051807Dto> listheader = new List<CQHeader051807Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader051807Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader051807Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL291908(byte[] fileBytes, List<CQShortListBL291908Dto> cQShortListBL291908, List<CQFullListBL291908Dto> cQFullListBL291908, List<CQHeader291908Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL291908Dto header1 = new CQShortListBL291908Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL291908Dto header12 in cQShortListBL291908) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL291908Dto header11 = new CQFullListBL291908Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL291908Dto header12 in cQFullListBL291908) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader291908Dto header6 = new CQHeader291908Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader291908Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader291908Dto> listheader = new List<CQHeader291908Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader291908Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader291908Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL281609(byte[] fileBytes, List<CQShortListBL281609Dto> cQShortListBL281609, List<CQFullListBL281609Dto> cQFullListBL281609, List<CQHeader281609Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL281609Dto header1 = new CQShortListBL281609Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL281609Dto header12 in cQShortListBL281609) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL281609Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL281609Dto header11 = new CQFullListBL281609Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL281609Dto header12 in cQFullListBL281609) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL281609Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader281609Dto header6 = new CQHeader281609Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader281609Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader281609Dto> listheader = new List<CQHeader281609Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader281609Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader281609Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL301401(byte[] fileBytes, List<CQShortListBL301401Dto> cQShortListBL301401, List<CQFullListBL301401Dto> cQFullListBL301401, List<CQHeader> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL301401Dto header1 = new CQShortListBL301401Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL301401Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL301401Dto header12 in cQShortListBL301401) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL301401Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL301401Dto header11 = new CQFullListBL301401Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL301401Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL301401Dto header12 in cQFullListBL301401) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL301401Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader header6 = new CQHeader(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader> listheader = new List<CQHeader>();
            listheader.AddRange(headerlist);
            foreach (CQHeader header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            //excelPackage.Workbook.Protection.SetPassword("password");
            // excelPackage.Workbook.Protection.LockStructure = true;
            // excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            //foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            //{

            //    worksheet11.Protection.IsProtected = true;
            //    worksheet11.Protection.AllowSelectLockedCells = true;
            //    worksheet11.Protection.AllowFormatCells = true;

            //}
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL321110(byte[] fileBytes, List<CQShortListBL321110Dto> cQShortListBL321110, List<CQFullListBL321110Dto> cQFullListBL321110, List<CQHeader321110> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL321110Dto header1 = new CQShortListBL321110Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL321110Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL321110Dto header12 in cQShortListBL321110) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL321110Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL321110Dto header11 = new CQFullListBL321110Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL321110Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL321110Dto header12 in cQFullListBL321110) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL321110Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader321110 header6 = new CQHeader321110(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader321110).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader321110> listheader = new List<CQHeader321110>();
            listheader.AddRange(headerlist);
            foreach (CQHeader321110 header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader321110).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL331211(byte[] fileBytes, List<CQShortListBL331211Dto> cQShortListBL331211, List<CQFullListBL331211Dto> cQFullListBL331211, List<CQHeader331211Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL331211Dto header1 = new CQShortListBL331211Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL331211Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL331211Dto header12 in cQShortListBL331211) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL331211Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL331211Dto header11 = new CQFullListBL331211Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL331211Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL331211Dto header12 in cQFullListBL331211) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL331211Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader331211Dto header6 = new CQHeader331211Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader331211Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader331211Dto> listheader = new List<CQHeader331211Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader331211Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader331211Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL041312(byte[] fileBytes, List<CQShortListBL041312Dto> cQShortListBL041312, List<CQFullListBL041312Dto> cQFullListBL041312, List<CQHeader041312Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL041312Dto header1 = new CQShortListBL041312Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL041312Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL041312Dto header12 in cQShortListBL041312) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL041312Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL041312Dto header11 = new CQFullListBL041312Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL041312Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL041312Dto header12 in cQFullListBL041312) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL041312Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader041312Dto header6 = new CQHeader041312Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader041312Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader041312Dto> listheader = new List<CQHeader041312Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader041312Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader041312Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }
        public async Task<byte[]> ConvetFormToExcelShortLongListtBL030904(byte[] fileBytes, List<CQShortListBL030904Dto> cQShortListBL030904, List<CQFullListBL030904Dto> cQFullListBL030904, List<CQHeader030904Dto> headerlist)
        {


            MemoryStream stream = new MemoryStream(fileBytes);
            ExcelPackage excelPackage = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //draw cqheader
            ExcelWorksheet worksheetHeader = excelPackage.Workbook.Worksheets["SQL_Short"];
            CQShortListBL030904Dto header1 = new CQShortListBL030904Dto(); // Create an instance of CQHeader
            int columnIndex11 = 1;
            foreach (var propertyInfo in typeof(CQShortListBL030904Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader.Cells[1, columnIndex11].Value = propertyName;
                columnIndex11++;
            }
            int rowIndex1 = 2;

            foreach (CQShortListBL030904Dto header12 in cQShortListBL030904) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1112 = 1;
                foreach (var propertyInfo in typeof(CQShortListBL030904Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader.Cells[rowIndex1, columnIndex1112].Value = propertyValue;
                    columnIndex1112++;
                }
                rowIndex1++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader1 = excelPackage.Workbook.Worksheets["SQL_Long"];
            CQFullListBL030904Dto header11 = new CQFullListBL030904Dto(); // Create an instance of CQHeader
            int columnIndex111 = 1;
            foreach (var propertyInfo in typeof(CQFullListBL030904Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader1.Cells[1, columnIndex11].Value = propertyName;
                columnIndex111++;
            }
            int rowIndex11 = 2;

            foreach (CQFullListBL030904Dto header12 in cQFullListBL030904) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1111 = 1;
                foreach (var propertyInfo in typeof(CQFullListBL030904Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);
                    worksheetHeader1.Cells[rowIndex11, columnIndex1111].Value = propertyValue;
                    columnIndex1111++;
                }
                rowIndex11++;
            }
            //draw cqheader
            ExcelWorksheet worksheetHeader6 = excelPackage.Workbook.Worksheets["SQL_TicketHeader"];
            CQHeader030904Dto header6 = new CQHeader030904Dto(); // Create an instance of CQHeader
            int columnIndex116 = 1;
            foreach (var propertyInfo in typeof(CQHeader030904Dto).GetProperties())
            {
                string propertyName = propertyInfo.Name;
                worksheetHeader6.Cells[1, columnIndex116].Value = propertyName;
                columnIndex116++;
            }
            int rowIndex16 = 2;
            List<CQHeader030904Dto> listheader = new List<CQHeader030904Dto>();
            listheader.AddRange(headerlist);
            foreach (CQHeader030904Dto header12 in listheader) // Replace yourCQHeaderList with the actual list of CQHeader objects
            {
                int columnIndex1116 = 1;
                foreach (var propertyInfo in typeof(CQHeader030904Dto).GetProperties())
                {
                    string propertyName = propertyInfo.Name;
                    object propertyValue = propertyInfo.GetValue(header12);

                    worksheetHeader6.Cells[rowIndex16, columnIndex1116].Value = propertyValue;
                    columnIndex1116++;
                }
                rowIndex16++;
            }


            MemoryStream memoryStream = new MemoryStream();
            // ExcelPackage
            // Set a password for the workbook
            excelPackage.Workbook.Protection.SetPassword("password");
            excelPackage.Workbook.Protection.LockStructure = true;
            excelPackage.Workbook.Protection.LockWindows = true;
            // Protect the workbook structure to prevent unhide
            //excelPackage.Workbook.Protection("password", true, true);
            //////// Protect all worksheets in the workbook
            foreach (ExcelWorksheet worksheet11 in excelPackage.Workbook.Worksheets)
            {

                worksheet11.Protection.IsProtected = true;
                worksheet11.Protection.AllowSelectLockedCells = true;
                worksheet11.Protection.AllowFormatCells = true;

            }
            List<string> sheetNamesToDelete = new List<string>();
            foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
            {
                if (worksheet.Name.StartsWith("SQL"))
                {
                    sheetNamesToDelete.Add(worksheet.Name);
                }
            }

            //// HIDE the sheets
            foreach (string sheetName in sheetNamesToDelete)
            {
                //excelPackage.Workbook.Worksheets.Delete(sheetName);
                ExcelWorksheet hiddenWorksheet = excelPackage.Workbook.Worksheets[sheetName];
                hiddenWorksheet.Hidden = eWorkSheetHidden.Hidden;
            }
            await excelPackage.SaveAsAsync(memoryStream);


            // Return the stream as a FileStreamResult with the appropriate content type and file name
            //  return File(streamDownload, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MyExcelFile.xlsx");
            return excelPackage.GetAsByteArray();

        }

    }

}
