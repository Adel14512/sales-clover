var params = decodeParameters(globalParam, 3);
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
            url: '/ExcelImport/ImportExcelAF1_04',
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
    <td data-gendercode="${genderList.find(x => x.description.toLowerCase()).code}">${data.genderCode}</td>
    <td data-dob="${data.dob}">${data.dob}</td>
    <td data-nationalitycode="${regionList.find(x => x.description.toLowerCase() == data.nationalityCode.toLowerCase()).code}">${data.nationalityCode}</td>
    <td data-maritalstatuscode="${maritalStatusList.find(x => x.description.toLowerCase() == data.maritalStatusCode.toLowerCase()).code}">${data.maritalStatusCode}</td>
    <td data-grade="${data.grade}">${data.grade}</td>
    <td data-currency="${data.currency}">${data.currency}</td>
    <td data-limitOfCoverage="${data.limitOfCoverage}">${data.limitOfCoverage}</td>
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
        data.mobileNumber = row.querySelector('[data-mobileNumber]').textContent;
        data.email = row.querySelector('[data-email]').textContent;
        data.genderCode = row.querySelector('[data-gendercode]').textContent;
        data.dob = row.querySelector('[data-dob]').textContent;
        data.nationalityCode = row.querySelector('[data-nationalitycode]').textContent;
        data.maritalStatusCode = row.querySelector('[data-maritalstatuscode]').textContent;
        data.grade = row.querySelector('[data-grade]').textContent;
        data.currency = row.querySelector('[data-currency]').textContent;
        data.limitOfCoverage = row.querySelector('[data-limitOfCoverage]').textContent;
        data.shop = row.querySelector('[data-shop]').textContent;

        dataList.push(data); // Add the object to the list

    });
    var formData = new FormData();
    formData.append('data', JSON.stringify(dataList));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify('AF1_4'));
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
            data.mobileNumber = row.querySelector('[data-mobileNumber]').getAttribute('data-doctorvisit');
            data.email = row.querySelector('[data-email]').getAttribute('data-doctorvisit');
            data.genderCode = row.querySelector('[data-gendercode]').getAttribute('data-gendercode');
            data.dob = row.querySelector('[data-dob]').getAttribute('data-dob');
            data.nationalityCode = row.querySelector('[data-nationalitycode]').getAttribute('data-nationalitycode');
            data.maritalStatusCode = row.querySelector('[data-maritalstatuscode]').getAttribute('data-maritalstatuscode');
            data.grade = row.querySelector('[data-grade]').getAttribute('data-grade');
            data.currency = row.querySelector('[data-currency]').getAttribute('data-currency');
            data.limitOfCoverage = row.querySelector('[data-limitOfCoverage]').getAttribute('data-limitOfCoverage');
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
    obj.AF1BL041312 = dataList;
    formBody.append("data", JSON.stringify(obj));
    if (trxID != 0) {
        $.ajax({
            url: "/Business/EditAF1_4",
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
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_4"), JSON.stringify("AF"));
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
            url: "/Business/CreateAF1_4",
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
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_4"), JSON.stringify("AF"));
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
    var urlencode = encodeParameters("?contactid=" + $("#ContactId").val());
    window.location.href = "../../transaction/Dashboard/" + urlencode;
});
var columnConfig = [
    { data: 'serial', title: 'Serial' },
    { data: 'company', title: 'Company' },
    { data: 'staffNbr', title: 'Staff Number' },
    { data: 'firstName', title: 'First Name' },
    { data: 'middleName', title: 'Middle Name' },
    { data: 'lastName', title: 'Last Name' },
    { data: 'mobileNumber', title: 'Mobile' },
    { data: 'email', title: 'Email' },
    { data: 'genderCode', title: 'Gender' },
    { data: 'dob', title: 'Date of Birth' },
    { data: 'nationalityCode', title: 'Nationality' },
    { data: 'maritalStatusCode', title: 'Marital Status' },
    { data: 'grade', title: 'Grade' },
    { data: 'currency', title: 'Currency' },
    { data: 'limitOfCoverage', title: 'Limit Of Coverage' },
    { data: 'shop', title: 'Shop' },
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
var table = $('#tableAf104').DataTable({
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

        { data: 'grade', title: 'Grade' },
        { data: 'currency', title: 'Currency' },
        { data: 'limitOfCoverage', title: 'Limit Of Coverage' },
        { data: 'shop', title: 'Shop' },
    ],
    columnDefs: columnDefs,

});
$("#btnDownloadEmptyExcel").click(function () {
    downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_4"), JSON.stringify("AF"));
})
$("#btnDownloadEmptyExcelStep4").click(function () {
    downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_4"), JSON.stringify("BN"));
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
            { data: 'maxLimit', title: 'Max Limit' },
            { data: 'minLimit', title: 'Min Limit' },]
    });

});
var tStep3Table = $('#tStep3').DataTable({
    data: step3Data,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'category', title: 'Category' },
        { data: 'section', title: 'Section' },
        { data: 'limitAmount', title: 'Limit Amt' },
        { data: 'co_InsurancePer', title: 'Co-Insurance' },
        {
            data: 'covered', title: 'Covered', render: function (data, type, row, meta) {
                if (data != null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
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
        { data: 'benefitNumber', title: 'Benefit #', width: "20px" },
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
            url: '/ExcelImport/ImportExcelAF1_04_SlipStep4',
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
    obj.Slip2BL041312 = tStep2Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL041312UpdSlip2',
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
    obj.Slip3BL041312 = tStep3Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL041312UpdSlip3',
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
    obj.Slip4BL041312 = tStep4Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL041312UpdSlip4',
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

function editStep3Model(sender) {
    var tr = $(sender).closest('tr');
    modelValues = tStep3Table.row(tr);

    var model = modelValues.data();
    if (model != null) {
        $("#txtCategoryStep3").val(model.category);
        $('#txtSection').val(model.section);
        $('#txtCoInsurancePer').val(model.co_InsurancePer);
        $('#txtLimitAmount').val(model.limitAmount);
        $('#txtCovered').val(model.covered.toString() == "true" ? "true" : "false");
    } else {

    }
    $('#modalStep3').modal('show');
}

$("#btnSaveModalStep3").click(function () {
    var editModel = {
        category: $("#txtCategoryStep3").val(),
        section: $('#txtSection').val(),
        co_InsurancePer: $('#txtCoInsurancePer').val(),
        limitAmount: $('#txtLimitAmount').val(),
        covered: $('#txtCovered').val(),
    };
    // Redraw the row to reflect the updated data
    modelValues.data(editModel).draw();

    resetModalInputsStep3();
    $("#btnCloseModalStep3").click();
});
function resetModalInputsStep3() {
    $("#txtCategoryStep3").val("");
    $('#txtSection').val("");
    $('#txtCoInsurancePer').val("");
    $('#txtLimitAmount').val("");
    $('#txtCovered').val("false");
}

$("#btnStep4ExportData").click(function () {
    var formData = new FormData();
    formData.append('data', JSON.stringify(tStep4Table.rows().data().toArray()));

    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify("AF1_4"));
    formData.append('type', JSON.stringify("BN"));
    $.ajax({
        type: 'POST',
        url: '/Slip/ExportExcelStep4AF04',
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

$('#tStep5Insurrer tbody').on('click', 'tr', function () {
    // Remove selection from all rows
    $('#tStep5Insurrer tbody tr').removeClass('selected');

    // Add selection to the clicked row
    $(this).addClass('selected');
});
// Add click event listener to table rows

// Add click event listener to the button
var listLinkedList = [];
$('#getSelectedRowBtn').on('click', function () {
    // Get the selected row
    var selectedRowDataInsurrer = tStep5InsurrerTable.row('.selected').data();
    //var selectedRowDataThirdParty = tStep5ThirdPartyTable.row('.selected').data();
    if (selectedRowDataInsurrer) {
        // Display the selected row data (you can do whatever you want with it)
        //console.log(selectedRowDataInsurrer);
        // console.log(selectedRowDataThirdParty);
        //  alert("Selected Row: " + selectedRowData.join(", "));
        var html = "<li data-insurrerId=" + selectedRowDataInsurrer.recId + " >" + selectedRowDataInsurrer.description + "  <a href='#' onclick='deleteLink(this)'><i class='fas fa-trash text-danger'></i></a></li>"
        var obj = {};
        obj.insurerCode = selectedRowDataInsurrer.recId;
        // obj.tpaCode = selectedRowDataThirdParty.recId;

        if (listLinkedList.find(x => x.insurerCode == obj.insurerCode) == null) {

            listLinkedList.push(obj);
            $("#linkedItems").append(html);
            $('#tStep5Insurrer tbody tr').removeClass('selected');
            //  $('#tStep5ThirdParty tbody tr').removeClass('selected');
        } else {
            toastr.warning("Choosen!", "Already linked");
        }


    } else {
        toastr.warning("Select a row from Insurrer", "Choose");
    }
});
function deleteLink(sender) {
    var obj = {};
    obj.insurerCode = sender.parentElement.dataset.insurrerid;
    // obj.tpaCode = sender.parentElement.dataset.partyid;
    listLinkedList = listLinkedList.filter(x => x.insurerCode != obj.insurerCode);
    sender.parentElement.outerHTML = "";

}


$("#btnSubmitStep5").click(function () {
    var formData = new FormData();
    var obj = {};
    obj.RecId = trxID;
    obj.Slip5BL041312 = listLinkedList;
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL041312UpdSlip5',
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
if (step5Data != null && step5Data.length > 0) {
    listLinkedList = step5Data;
    $("#btnSlip").show();
    for (var i = 0; i < step5Data.length; i++) {
        var getInssurerDescription = step5InsurrerData.filter(x => x.recId == step5Data[i].insurerCode)[0].description;

        var html = "<li data-insurrerId=" + step5Data[i].insurerCode + ">" + getInssurerDescription + "  <a href='#' onclick='deleteLink(this)'><i class='fas fa-trash text-danger'></i></a></li>";
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