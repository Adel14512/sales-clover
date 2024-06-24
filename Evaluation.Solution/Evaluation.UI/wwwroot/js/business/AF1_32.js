﻿var params = decodeParameters(globalParam, 3);
const contactID = params[0];
const trxID = params[1];
//const rowMinRange = params[1];
//const rowMaxRange = params[2];
const BusinessLineCode = params[2];
//const countrnx = params[4];
$("#btnUploadExcel").click(function () {
    document.getElementById('fileInput').click();
});
const tableBody = document.getElementById('table-body');
//var dataList = [];
$('#fileInput').change(function () {
    var fileName = $(this).val();
    if (fileName != '') {
        var file = this.files[0]; // Get the selected file

        // Create a new FormData object and append the selected file to it
        var formData = new FormData();
        formData.append('file', file);
        formData.append('code', BusinessLineCode);

        $.ajax({
            type: 'POST',
            url: '/ExcelImport/ImportExcelAF1_32',
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function (xhr) {
                showLoading();
                // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
            },
            success: function (result) {
                $('#fileInput').val('');
                //generateForm(result);
                hideLoading();
                if (result.status == "success") {
                    if (result.data != null && result.data.length > 0) {
                       // window.location.href = window.location.href;
                        //formCount = 0;
                        $("#table-body").html("");

                        // Assuming your list is named 'dataList'
                        for (let i = 0; i < result.data.length; i++) {
                            const data = result.data[i];
                            const row = document.createElement('tr');

                            // Populate the row with object properties
                            row.innerHTML = `
    <td data-serial="${data.serial}">${data.serial}</td>
    <td data-company="${data.company}">${data.company}</td>
    <td data-staffnbr="${data.staffNbr}">${data.staffNbr}</td>
    <td data-firstname="${data.firstName}">${data.firstName}</td>
    <td data-middlename="${data.middleName}">${data.middleName}</td>
    <td data-lastname="${data.lastName}">${data.lastName}</td>
        <td data-mobileNumber="${data.mobileNumber}">${data.mobileNumber}</td>
    <td data-email="${data.email}">${data.email}</td>
    <td data-gendercode="${genderList.find(x => x.description.toLowerCase() == data.genderCode.toLowerCase()).code}">${data.genderCode}</td>
    <td data-relationcode="${relationList.find(x => x.description.toLowerCase() == data.relationCode.toLowerCase()).code}">${data.relationCode}</td>
    <td data-dob="${data.dob}">${data.dob}</td>

    <td data-nationalitycode="${regionList.find(x => x.description.toLowerCase() == data.nationalityCode.toLowerCase()).code}">${data.nationalityCode}</td>
    <td data-maritalstatuscode="${maritalStatusList.find(x => x.description.toLowerCase() == data.maritalStatusCode.toLowerCase()).code}">${data.maritalStatusCode}</td>
    <td data-nssf="${(data.nssf.toLowerCase() === "yes")}">${data.nssf}</td>
    <td data-grade="${data.grade}">${data.grade}</td>
    <td data-dental="${(data.dental.toLowerCase() === 'yes')}">${data.dental}</td>
    <td data-optical="${(data.optical.toLowerCase() === 'yes')}">${data.optical}</td>
    <td data-classofcoveragcode="${classOfCoverageList.find(x => x.description.toLowerCase() == data.classOfCoveragCode.toLowerCase()).recId}">${data.classOfCoveragCode}</td>
    <td data-ambulatory="${(data.ambulatory.toLowerCase() === 'yes')}">${data.ambulatory}</td>
    <td data-prescriptionmedecine="${(data.prescriptionMedecine.toLowerCase() === "yes")}">${data.prescriptionMedecine}</td>
    <td data-doctorvisit="${(data.doctorVisit.toLowerCase() === "yes")}">${data.doctorVisit}</td>
      <td data-shop="${data.shop}">${data.shop}</td>

`;
                            // Append the row to the table body
                            tableBody.appendChild(row);
                        }
                    }
                } else if (result.status == "warning") {
                    toastr.warning(result.message, "Fix Excel");
                } else {
                    toastr.error("Please fix excel:" + result.message, "Error");
                }

                console.log(result.data)
                // $('#result').html(result);

            },
            error: function (xhr, status, error) {
                $('#fileInput').val('');
                alert('Error: ' + error);
            }
        });
        // $('#importButton').prop('disabled', false);
    } else {
        //$('#importButton').prop('disabled', true);
    }
});


$("#btnSendEmailExcel").click(function () {

    const dataList = []; // Create an empty list to store the objects
    var tableRows = document.querySelectorAll('#table-body tr');
    tableRows.forEach((row) => {
        const data = {}; // Create an empty object for each row

        data.serial = row.querySelector('[data-serial]').textContent;
        data.company = row.querySelector('[data-company]').textContent;
        data.staffNbr = row.querySelector('[data-staffnbr]').textContent;
        data.firstName = row.querySelector('[data-firstname]').textContent;
        data.middleName = row.querySelector('[data-middlename]').textContent;
        data.lastName = row.querySelector('[data-lastname]').textContent;
        data.genderCode = row.querySelector('[data-gendercode]').textContent;
        data.relationCode = row.querySelector('[data-relationcode]').textContent;
        data.dob = row.querySelector('[data-dob]').textContent;
        data.nationalityCode = row.querySelector('[data-nationalitycode]').textContent;
        data.maritalStatusCode = row.querySelector('[data-maritalstatuscode]').textContent;
        data.nssf = row.querySelector('[data-nssf]').textContent;
        data.grade = row.querySelector('[data-grade]').textContent;
        data.dental = row.querySelector('[data-dental]').textContent;
        data.optical = row.querySelector('[data-optical]').textContent;
        data.classOfCoveragCode = row.querySelector('[data-classofcoveragcode]').textContent;
        data.ambulatory = row.querySelector('[data-ambulatory]').textContent;
        data.prescriptionMedecine = row.querySelector('[data-prescriptionmedecine]').textContent;
        data.doctorVisit = row.querySelector('[data-doctorvisit]').textContent;
        data.mobileNumber = row.querySelector('[data-mobileNumber]').textContent;
        data.email = row.querySelector('[data-email]').textContent;
        data.shop = row.querySelector('[data-shop]').textContent;

        dataList.push(data); // Add the object to the list
    });
    var formData = new FormData();
    formData.append('data', JSON.stringify(dataList));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify('AF1_32'));
    formData.append('type', JSON.stringify("AF"));
    $.ajax({
        type: 'POST',
        url: '/ExcelImport/ExportExcel',
        data: formData,
        processData: false,
        contentType: false,
        xhrFields: {
            responseType: 'blob'
        },
        beforeSend: function (xhr) {
            showLoading();
            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
        },
        success: function (data, status, xhr) {
            hideLoading();
            var filename = getFilenameFromContentDispositionHeader(xhr.getResponseHeader('Content-Disposition'));
            var url = window.URL.createObjectURL(data);
            var link = document.createElement('a');
            link.href = url;
            link.download = filename;
            link.click();
            window.URL.revokeObjectURL(url);
        },
        error: function (xhr, status, error) {
            console.log('Error downloading Excel file:', error);
        }
    });
})
function getFilenameFromContentDispositionHeader(contentDisposition) {
    var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
    var matches = filenameRegex.exec(contentDisposition);
    if (matches != null && matches[1]) {
        return decodeURIComponent(matches[1].replace(/['"]/g, ''));
    } else {
        return 'unknown';
    }
}
$("#btnSubmitWithEmail").click(function () {
    submitAF(true);
})
$("#btnSubmit").click(function () {
    submitAF(false);

})
function submitAF(isSent) {
    const dataList = []; // Create an empty list to store the objects\
    try {

        var tableRows = document.querySelectorAll('#table-body tr');
        tableRows.forEach((row) => {
            const data = {}; // Create an empty object for each row

            data.serial = row.querySelector('[data-serial]').getAttribute('data-serial');
            data.company = row.querySelector('[data-company]').getAttribute('data-company');
            data.staffNbr = row.querySelector('[data-staffnbr]').getAttribute('data-staffnbr');
            data.firstName = row.querySelector('[data-firstname]').getAttribute('data-firstname');
            data.middleName = row.querySelector('[data-middlename]').getAttribute('data-middlename');
            data.lastName = row.querySelector('[data-lastname]').getAttribute('data-lastname');
            data.genderCode = row.querySelector('[data-gendercode]').getAttribute('data-gendercode');
            data.relationCode = row.querySelector('[data-relationcode]').getAttribute('data-relationcode');
            data.dob = row.querySelector('[data-dob]').getAttribute('data-dob');
            data.nationalityCode = row.querySelector('[data-nationalitycode]').getAttribute('data-nationalitycode');
            data.maritalStatusCode = row.querySelector('[data-maritalstatuscode]').getAttribute('data-maritalstatuscode');
            data.nssf = row.querySelector('[data-nssf]').getAttribute('data-nssf');
            data.grade = row.querySelector('[data-grade]').getAttribute('data-grade');
            data.dental = row.querySelector('[data-dental]').getAttribute('data-dental');
            data.optical = row.querySelector('[data-optical]').getAttribute('data-optical');
            data.classOfCoveragCode = row.querySelector('[data-classofcoveragcode]').getAttribute('data-classofcoveragcode');
            data.ambulatory = row.querySelector('[data-ambulatory]').getAttribute('data-ambulatory');
            data.prescriptionMedecine = row.querySelector('[data-prescriptionmedecine]').getAttribute('data-prescriptionmedecine');
            data.doctorVisit = row.querySelector('[data-doctorvisit]').getAttribute('data-doctorvisit');
            data.mobileNumber = row.querySelector('[data-mobileNumber]').getAttribute('data-mobileNumber');
            data.email = row.querySelector('[data-email]').getAttribute('data-email');
            data.shop = row.querySelector('[data-shop]').getAttribute('data-shop');

            dataList.push(data); // Add the object to the list
        });
    } catch {
        if (!isSent) {
            toastr.warning("Please fill the table row", "UnSaved");
            return false;

        }
    }
    var formBody = new FormData();
    var obj = {};
    obj.RecId = trxID;
    obj.BusinessLineCode = BusinessLineCode;
    obj.ContactId = $("#ContactId").val();
    obj.AF1BL321110 = dataList;
    formBody.append("data", JSON.stringify(obj));
    if (trxID != 0) {
        $.ajax({
            url: "/Business/EditAF1_32",
            type: "POST",
            contentType: false,
            processData: false,
            data: formBody,
            beforeSend: function (xhr) {
                showLoading();
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            },
            success: function (data) {
                hideLoading();
                if (data != null && data.webResponseCommon.returnCode == '202') {
                    toastr.success("", "Saved");
                    if (isSent) {
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("AF"));
                    } else {
                        var urlencode = encodeParameters("?contactid=" + contactID);
                        window.location.href = "../../transaction/Dashboard/" + urlencode;
                    }
                } else {
                    toastr.warning("Please fix required fields", "UnSaved");
                }

            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error");
            }
        });
    } else {
        $.ajax({
            url: "/Business/CreateAF1_32",
            type: "POST",
            contentType: false,
            processData: false,
            data: formBody,
            beforeSend: function (xhr) {
                showLoading();
                xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            },
            success: function (data) {
                hideLoading();
                if (data != null && data.webResponseCommon.returnCode == '201') {
                    toastr.success("", "Saved");
                    if (isSent) {
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("AF"));
                    } else {
                        var urlencode = encodeParameters("?contactid=" + contactID);
                        window.location.href = "../../transaction/Dashboard/" + urlencode;
                    }
                } else {
                    toastr.warning("Please fix required fields", "UnSaved");
                }

            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error");
            }
        });
    }
}
$("#btnDashboard").click(function () {
    dashboardRedirect();
});
var columnConfig = [
    { data: 'serial', title: 'Serial' },
    { data: 'company', title: 'Company' },
    { data: 'staffNbr', title: 'Staff Number' },
    { data: 'firstName', title: 'First Name' },
    { data: 'middleName', title: 'Middle Name' },
    { data: 'lastName', title: 'Last Name' },
    { data: 'genderCode', title: 'Gender' },
    { data: 'relationCode', title: 'Relation Code' },
    { data: 'dob', title: 'Date of Birth' },
    { data: 'nationalityCode', title: 'Nationality' },
    { data: 'maritalStatusCode', title: 'Marital Status' },
    { data: 'nssf', title: 'NSSF' },
    { data: 'grade', title: 'Grade' },
    { data: 'dental', title: 'Dental' },
    { data: 'optical', title: 'Optical' },
    { data: 'classOfCoveragCode', title: 'Class of Coverage' },
    { data: 'ambulatory', title: 'Ambulatory' },
    { data: 'prescriptionMedecine', title: 'Prescription Medicine' },
    { data: 'doctorVisit', title: 'Doctor Visit' },
        { data: 'mobileNumber', title: 'Mobile' },
    { data: 'email', title: 'Email' },
    { data: 'shop', title: 'Shop' }
];

var columnDefs = columnConfig.map(function (column, index) {
    return {
        targets: index,
        data: column.data,
        title: column.title,
        width: column.width,
        createdCell: function (cell, cellData) {
            var attributeName = 'data-' + column.data.toLowerCase();
            $(cell).attr(attributeName, cellData);
        }
    };
});
var table = $('#tableAf132').DataTable({
    data: datatablelist,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'serial', title: 'Serial' },
        { data: 'company', title: 'Company', width: '200px' },
        { data: 'staffNbr', title: 'Staff #' },
        { data: 'firstName', title: 'First Name' },
        { data: 'middleName', title: 'Middle Name' },
        { data: 'lastName', title: 'Last Name' },
        { data: 'mobileNumber', title: 'Mobile Number' },
        { data: 'email', title: 'Email' },
        {
            data: 'genderCode', title: 'Gender',
            render: function (data, type, row) {
                return genderList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'relationCode', title: 'Relation',
            render: function (data, type, row) {
                return relationList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'dob', title: 'DOB', width: '40px',
            render: function (data, type, row) {
                return data.split("T")[0];
            }
        },
        {
            data: 'nationalityCode', title: 'Nationality',
            render: function (data, type, row) {
                return regionList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'maritalStatusCode', title: 'Marital Status',
            render: function (data, type, row) {
                return maritalStatusList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'nssf', title: 'NSSF', render: function (data, type, row, meta) {
                if (data!=null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            }
},
        { data: 'grade', title: 'Grade' },
        {
            data: 'dental', title: 'Dental', render: function (data, type, row, meta) {
                if (data!=null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            } },
        {
            data: 'optical', title: 'Optical', render: function (data, type, row, meta) {
                if (data!=null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            } },
        {
            data: 'classOfCoveragCode', title: 'Class',
            render: function (data, type, row) {
                var model = classOfCoverageList.find(x => x.code == data);
                if (model != null) {
                    return model.description;
                } else {
                    return '';
                }

            }
        },
        {
            data: 'ambulatory', title: 'AMB', render: function (data, type, row, meta) {
                if (data!=null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            } },
        {
            data: 'prescriptionMedecine', title: 'PM', render: function (data, type, row, meta) {
                if (data!=null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            } },
        {
            data: 'doctorVisit', title: 'DV', render: function (data, type, row, meta) {
                if (data!=null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            },
             
        },
        { data: 'shop', title: 'Shop' },
    ],
    columnDefs: columnDefs,

});
$("#btnDownloadEmptyExcel").click(function () {
    downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("AF"));
})
$("#btnDownloadEmptyExcelStep4").click(function () {
    downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("BN"));
});
var tStep2Table;
var countDisplay = 0;
$(document).ready(function () {
    tStep2Table = $('#tStep2').DataTable({
        data: step2Data,
        responsive: false,
        autoWidth: true,
        scrollX: true,
        columns: [
            // { data: 'recId', title: 'ID', },

            { data: 'category', title: 'Category', },
            {
                data: 'cateMembers', title: 'Member'
            },
            { data: 'grade', title: 'Grade ' },
            { data: 'class', title: 'Class' },
            {
                data: 'ambulatory', title: 'AMB', render: function (data, type, row, meta) {
                    if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
                data: 'prescriptionMedecine', title: 'PM', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
               
                data: 'doctorVisit', title: 'DV', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
                data: 'dental', title: 'Dental', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
                data: 'optical', title: 'Optical', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            { data: 'amlAMount', title: 'Aml Amount' },
            {
                data: 'e_NoUnderwriting', title: 'NU', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
                data: 'e_Continuity', title: 'Con.', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            { data: 'e_NoWaitingPeriod', title: 'NWP' },
            {
                data: 'e_Renewability', title: 'GR', width:'30px', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
                data: 'n_NoUnderwriting', title: 'NW', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            {
                data: 'n_Continuity', title: 'Con.', render: function (data, type, row, meta) {
                     if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            { data: 'n_NoWaitingPeriod', title: 'NWP' },
            {
                data: 'n_Renewability', title: 'GR', render: function (data, type, row, meta) {
                    if (data!=null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },

            {
                data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                    var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                    var html = '<a href="#" onclick="editStep2Model(this)"><i class="fas fa-edit"></i></a> ';
                    return html;
                }
            }

        ],
        headerCallback: function (thead, data, start, end, display) {
            // Create the first complex header row
            if (countDisplay == 0) {
                $(thead).eq(0).before('<tr> <th colspan="10"></th> <th colspan="4" style="text-align: center;background-color: #fb8282;"> Existing Members</th> <th colspan="4" style="background-color: #bac2c5;text-align: center;">New Members</th><th></th> </tr>');
                countDisplay++;
                fixStep2Header();
            }
            
           
            
        }
    });
    
});
var tStep3Table = $('#tStep3').DataTable({
    data: step3Data,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'category', title: 'Category', },
        {
            data: 'section', title: 'Section'
        },
        { data: 'class', title: 'Class' },
        {
            data: 'territorialScope', title: 'TerritorialScope',
            render: function (data, type, row) {

                var model = territorias.find(x => x.recId == data);
                if (model != null) {
                    return model.description
                } else {
                    return '';
                }
            } },
        { data: 'co_InsurancePer', title: 'Co_InsurancePer' },
    //    { data: 'co_Insurance_Amt', title: 'Co_Insurance_Amt' },
        { data: 'limitAmount', title: 'LimitAmount' },
        {
            data: 'networkLevel', title: 'NetworkLevel',
            render: function (data, type, row) {

                var model = networks.find(x => x.recId == data);
                if (model != null) {
                    return model.description
                } else {
                    return '';
                }
            }
},

        {
            data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                var html = '<a href="#" onclick="editStep3Model(this)"><i class="fas fa-edit"></i></a> ';
                return html;
            }
        }

    ],
    initComplete: function () {
        this.api().columns(0).every(function () {
            filterAddForGrid(this);
        });
    }
});
function filterAddForGrid(sender) {
    var column = sender;
    var select = $('<select  class="select2 form-select"><option value="">---Select---</option></select>\n')
        .appendTo($(column.header()))
        .on('change', function () {
            var val = $.fn.dataTable.util.escapeRegex(
                $(this).val()
            );

            column
                .search(val ? '^' + val + '$' : '', true, false)
                .draw();
        });

    column.data().unique().sort().each(function (d, j) {
        select.append('<option value="' + d + '">' + d + '</option>');
    });
}
var tStep4Table = $('#tStep4').DataTable({
    data: step4Data,
    responsive: true,
    autoWidth: false,
    columns: [
        //   { data: 'recId', title: 'ID', },
        //  { data: 'branchId', title: 'Branch' },
        //{
        //    data: 'businessLineCode', title: 'BusinessLineCode'
        //},
        { data: 'category', title: 'Category' },
        { data: 'benefitNumber', title: 'Benefit #' ,width:"20px" },
        { data: 'benefitName', title: 'Name' },
        { data: 'benefitAnswer', title: 'Answer' },
        { data: 'lifeTime', title: 'Life Time' },
        { data: 'excess', title: 'Excess' },


    ],
});

$("#btnUploadStep4").click(function () {
    document.getElementById('fileInputStep4').click();
});
$('#fileInputStep4').change(function () {
    var fileName = $(this).val();
    if (fileName != '') {
        var file = this.files[0]; // Get the selected file

        // Create a new FormData object and append the selected file to it
        var formData = new FormData();
        formData.append('file', file);
        formData.append('code', BusinessLineCode);

        $.ajax({
            type: 'POST',
            url: '/ExcelImport/ImportExcelAF1_32_SlipStep4',
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function (xhr) {
                showLoading();
                // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
            },
            success: function (result) {
                $('#fileInputStep4').val('');
                //generateForm(result);
                hideLoading();
                if (result.status == "success") {
                    if (result.data != null && result.data.length > 0) {
                        tStep4Table.clear();

                        // Add new data
                        tStep4Table.rows.add(result.data); // replace newData with your new list

                        // Redraw the table
                        tStep4Table.draw();

                    }
                } else if (result.status == "warning") {
                    toastr.warning(result.message, "Fix Excel");
                } else {
                    toastr.error("Please fix excel:" + result.message, "Error");
                }

                console.log(result.data)
                // $('#result').html(result);

            },
            error: function (xhr, status, error) {
                $('#fileInputStep4').val('');
                alert('Error: ' + error);
            }
        });
        // $('#importButton').prop('disabled', false);
    } else {
        //$('#importButton').prop('disabled', true);
    }
});

$("#btnSubmitStep2").click(function () {
    var formData = new FormData();
    var obj = {};
    obj.RecId = trxID;
    obj.Slip2BL321110 = tStep2Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110UpdSlip2',
        data: formData,
        processData: false,
        contentType: false,

        beforeSend: function (xhr) {
            showLoading();
            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
        },
        success: function (data, status, xhr) {
            hideLoading();
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                toastr.success("", "Saved");
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error");
            hideLoading();
        }
    });
});
$("#btnSubmitStep3").click(function () {
    var formData = new FormData();
    var obj = {};
    obj.RecId = trxID;
    obj.Slip3BL321110 = tStep3Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110UpdSlip3',
        data: formData,
        processData: false,
        contentType: false,

        beforeSend: function (xhr) {
            showLoading();
            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
        },
        success: function (data, status, xhr) {
            hideLoading();
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                toastr.success("", "Saved");
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error");
            hideLoading();
        }
    });
});
$("#btnSubmitStep4").click(function () {
    var formData = new FormData();
    var obj = {};
    obj.RecId = trxID;
    obj.Slip4BL321110 = tStep4Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110UpdSlip4',
        data: formData,
        processData: false,
        contentType: false,

        beforeSend: function (xhr) {
            showLoading();
            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
        },
        success: function (data, status, xhr) {
            hideLoading();
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                toastr.success("", "Saved");
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error");
            hideLoading();
        }
    });
});
var modelValues;
function editStep2Model(sender) {
    var tr = $(sender).closest('tr');
    modelValues = tStep2Table.row(tr);

    var model = modelValues.data();
    if (model != null) {
        $("#txtCategory").val(model.category);
        $('#txtMembers').val(model.cateMembers);
        $('#txtGrade').val(model.grade);
        $('#txtClass').val(model.class);
        $('#txtAMB').val(model.ambulatory);
        $('#txtPM').val(model.prescriptionMedecine);
        $('#txtDV').val(model.doctorVisit);
        $('#txtDental').val(model.dental);
        $('#txtOptical').val(model.optical);
        $('#txtAmount').val(model.amlAMount);
        $('#ddlE_NoUnderwriting').val(model.e_NoUnderwriting.toString() == "true" ? "true" : "false");
        $('#ddlE_Continuity').val(model.e_Continuity.toString() == "true" ? "true" : "false");
        $('#txtE_NoWaitingPeriod').val(model.e_NoWaitingPeriod);
        $('#ddlE_Renewability').val(model.e_Renewability.toString() == "true" ? "true" : "false");
        $('#ddlN_NoUnderwriting').val(model.n_NoUnderwriting == "true" ? "true" : "false");
        $('#ddlN_Continuity').val(model.n_Continuity.toString() == "true" ? "true" : "false");
        $('#txtN_NoWaitingPeriod').val(model.n_NoWaitingPeriod);
        $('#ddlN_Renewability').val(model.n_Renewability.toString() == "true" ? "true" : "false");
    } else {

    }
    $('#modalStep2').modal('show');
    fixStep2Header();
}
function editStep3Model(sender) {
    var tr = $(sender).closest('tr');
    modelValues = tStep3Table.row(tr);

    var model = modelValues.data();
    if (model != null) {
        $("#txtCategoryStep2").val(model.category);
        $('#txtSection').val(model.section);
        $('#txtTerritorialScope').val(model.territorialScope);
        $('#txtClassStep2').val(model.class);
        $('#txtCoInsurancePer').val(model.co_InsurancePer);
       // $('#txtCoInsuranceAmt').val(model.co_Insurance_Amt);
        $('#txtLimitAmount').val(model.limitAmount);
        $('#txtNetworkLevel').val(model.networkLevel);
    } else {

    }
    $('#modalStep3').modal('show');
}
$("#btnSaveModalStep2").click(function () {
    var editModel = {
        category: $("#txtCategory").val(),
        cateMembers: $('#txtMembers').val(),
        grade: $('#txtGrade').val(),
        class: $('#txtClass').val(),
        ambulatory: $('#txtAMB').val(),
        prescriptionMedecine: $('#txtPM').val(),
        doctorVisit: $('#txtDV').val(),
        dental: $('#txtDental').val(),
        optical: $('#txtOptical').val(),
        amlAMount: $('#txtAmount').val(),
        e_NoUnderwriting: $('#ddlE_NoUnderwriting').val(),
        e_Continuity: $('#ddlE_Continuity').val(),
        e_NoWaitingPeriod: $('#txtE_NoWaitingPeriod').val(),
        e_Renewability: $('#ddlE_Renewability').val(),
        n_NoUnderwriting: $('#ddlN_NoUnderwriting').val(),
        n_Continuity: $('#ddlN_Continuity').val(),
        n_NoWaitingPeriod: $('#txtN_NoWaitingPeriod').val(),
        n_Renewability: $('#ddlN_Renewability').val()
    };

    // Redraw the row to reflect the updated data
    modelValues.data(editModel).draw();
    fixStep2Header();
    resetModalInputsStep2();
    $("#btnCloseModalStep2").click();
});
$("#btnSaveModalStep3").click(function () {
    var editModel = {
        category: $("#txtCategoryStep2").val(),
        section: $('#txtSection').val(),
        territorialScope: $('#txtTerritorialScope').val(),
        class: $('#txtClassStep2').val(),
        co_InsurancePer: $('#txtCoInsurancePer').val(),
     //   co_Insurance_Amt: $('#txtCoInsuranceAmt').val(),
        limitAmount: $('#txtLimitAmount').val(),
        networkLevel: $('#txtNetworkLevel').val()
    };
    // Redraw the row to reflect the updated data
    modelValues.data(editModel).draw();

    resetModalInputsStep3();
    $("#btnCloseModalStep3").click();
});
function resetModalInputsStep3() {
    $("#txtCategoryStep2").val("");
    $('#txtSection').val("");
    $('#txtTerritorialScope').val("");
    $('#txtClassStep2').val("");
    $('#txtCoInsurancePer').val("");
    //$('#txtCoInsuranceAmt').val("");
    $('#txtLimitAmount').val("");
    $('#txtNetworkLevel').val("");
}
function resetModalInputsStep2() {
    $("#txtCategory").val("");
    $('#txtMembers').val("");
    $('#txtGrade').val("");
    $('#txtClass').val("");
    $('#txtAMB').val("");
    $('#txtPM').val("");
    $('#txtDV').val("");
    $('#txtDental').val("");
    $('#txtOptical').val("");
    $('#txtAmount').val("");
    $('#ddlE_NoUnderwriting').val("");
    $('#ddlE_Continuity').val("");
    $('#txtE_NoWaitingPeriod').val("");
    $('#ddlE_Renewability').val("");
    $('#ddlN_NoUnderwriting').val("");
    $('#ddlN_Continuity').val("");
    $('#txtN_NoWaitingPeriod').val("");
    $('#ddlN_Renewability').val("");
}
$("#btnStep4ExportData").click(function () {
    var formData = new FormData();
    formData.append('data', JSON.stringify(tStep4Table.rows().data().toArray()));

    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify("AF1_32"));
    formData.append('type', JSON.stringify("BN"));
    $.ajax({
        type: 'POST',
        url: '/Slip/ExportExcelStep4AF32',
        data: formData,
        processData: false,
        contentType: false,
        xhrFields: {
            responseType: 'blob'
        },
        beforeSend: function (xhr) {
            showLoading();
            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
        },
        success: function (data, status, xhr) {
            hideLoading();
            var filename = getFilenameFromContentDispositionHeader(xhr.getResponseHeader('Content-Disposition'));
            var url = window.URL.createObjectURL(data);
            var link = document.createElement('a');
            link.href = url;
            link.download = filename;
            link.click();
            window.URL.revokeObjectURL(url);
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error downloading Excel file");
            hideLoading();
        }
    });
});
var tStep5InsurrerTable = $('#tStep5Insurrer').DataTable({
    data: step5InsurrerData,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'recId', title: 'ID' },
        { data: 'description', title: 'Description' }
    ],
});
var tStep5ThirdPartyTable = $('#tStep5ThirdParty').DataTable({
    data: step5ThirdPartyData,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'recId', title: 'ID', },
        { data: 'description', title: 'Description' }
    ],
});
$('#tStep5Insurrer tbody').on('click', 'tr', function () {
    // Remove selection from all rows
    $('#tStep5Insurrer tbody tr').removeClass('selected');

    // Add selection to the clicked row
    $(this).addClass('selected');
});
// Add click event listener to table rows
$('#tStep5ThirdParty tbody').on('click', 'tr', function () {
    // Remove selection from all rows
    $('#tStep5ThirdParty tbody tr').removeClass('selected');

    // Add selection to the clicked row
    $(this).addClass('selected');
});
// Add click event listener to the button
var listLinkedList = [];
$('#getSelectedRowBtn').on('click', function () {
    // Get the selected row
    var selectedRowDataInsurrer = tStep5InsurrerTable.row('.selected').data();
    var selectedRowDataThirdParty = tStep5ThirdPartyTable.row('.selected').data();
    if (selectedRowDataInsurrer && selectedRowDataThirdParty) {
        // Display the selected row data (you can do whatever you want with it)
        //console.log(selectedRowDataInsurrer);
        // console.log(selectedRowDataThirdParty);
        //  alert("Selected Row: " + selectedRowData.join(", "));
        var html = "<li data-insurrerId=" + selectedRowDataInsurrer.recId + " data-partyId=" + selectedRowDataThirdParty.recId + ">" + selectedRowDataInsurrer.description + "-" + selectedRowDataThirdParty.description + "  <a href='#' onclick='deleteLink(this)'><i class='fas fa-trash text-danger'></i></a></li>"
        var obj = {};
        obj.insurerCode = selectedRowDataInsurrer.recId;
        obj.tpaCode = selectedRowDataThirdParty.recId;

        if (listLinkedList.find(x => x.insurerCode == obj.insurerCode && x.tpaCode == obj.tpaCode) == null) {

            listLinkedList.push(obj);
            $("#linkedItems").append(html);
            $('#tStep5Insurrer tbody tr').removeClass('selected');
            $('#tStep5ThirdParty tbody tr').removeClass('selected');
        } else {
            toastr.warning("Choosen!", "Already linked");
        }


    } else {
        toastr.warning("Select a row From the 2 Tables", "Choose");
    }
});
function deleteLink(sender) {
    var obj = {};
    obj.insurerCode = sender.parentElement.dataset.insurrerid;
    obj.tpaCode = sender.parentElement.dataset.partyid;
    listLinkedList = listLinkedList.filter(x => x.insurerCode != obj.insurerCode || x.tpaCode != obj.tpaCode);
    sender.parentElement.outerHTML = "";

}


$("#btnSubmitStep5").click(function () {
    var formData = new FormData();
    var obj = {};
    obj.RecId = trxID;
    obj.Slip5BL321110 = listLinkedList;
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110UpdSlip5',
        data: formData,
        processData: false,
        contentType: false,

        beforeSend: function (xhr) {
            showLoading();
            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
        },
        success: function (data, status, xhr) {
            hideLoading();
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                toastr.success("", "Saved");
                $("#btnSlip").show();
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error");
            hideLoading();
        }
    });
});
if (step5Data != null) {
    listLinkedList = step5Data;
    $("#btnSlip").show();
    for (var i = 0; i < step5Data.length; i++) {
        var getInssurerDescription = step5InsurrerData.filter(x => x.recId == step5Data[i].insurerCode)[0].description;
        var getThirdDescription = step5ThirdPartyData.filter(x => x.recId == step5Data[i].tpaCode)[0].description;
        var html = "<li data-insurrerId=" + step5Data[i].insurerCode + " data-partyId=" + step5Data[i].tpaCode + ">" + getInssurerDescription + "-" + getThirdDescription + "  <a href='#' onclick='deleteLink(this)'><i class='fas fa-trash text-danger'></i></a></li>";
        $("#linkedItems").append(html);
    }
} else {

}
$("#btnSlip").click(function () {
    var formData = new FormData();

    formData.append('businesscode', JSON.stringify(BusinessLineCode));
    formData.append('salestransactionId', JSON.stringify(trxID));
    $.ajax({
        type: 'POST',
        url: '/Transaction/Slip',
        data: formData,
        processData: false,
        contentType: false,
        xhrFields: {
            responseType: 'blob'
        },
        beforeSend: function (xhr) {
            showLoading();
        },
        success: function (data, status, xhr) {
            hideLoading();
            var filename = getFilenameFromContentDispositionHeader(xhr.getResponseHeader('Content-Disposition'));
            var url = window.URL.createObjectURL(data);
            var link = document.createElement('a');
            link.href = url;
            link.download = filename;
            link.click();
            window.URL.revokeObjectURL(url);

        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error while Move to Next Step");
            hideLoading();
        }
    });
});