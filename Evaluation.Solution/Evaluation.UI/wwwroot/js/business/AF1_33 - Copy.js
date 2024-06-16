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
            url: '/ExcelImport/ImportExcelAF1_33',
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
    <td data-gendercode="${genderList.find(x => x.description.toLowerCase().trim() == data.genderCode.toLowerCase().trim()).code}">${data.genderCode}</td>
    <td data-dob="${data.dob}">${data.dob}</td>
    <td data-nationalitycode="${regionList.find(x => x.description.toLowerCase().trim() == data.nationalityCode.toLowerCase().trim()).code}">${data.nationalityCode}</td>
    <td data-maritalstatuscode="${maritalStatusList.find(x => x.description.toLowerCase().trim() == data.maritalStatusCode.toLowerCase().trim()).code}">${data.maritalStatusCode}</td>
    <td data-grade="${data.grade}">${data.grade}</td>
    <td data-currency="${data.currency}">${data.currency}</td>
   
    <td data-limitOfCoverage="${data.limitOfCoverage}">${data.limitOfCoverage}</td>
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
     //   data.annualWages = row.querySelector('[data-annualWages]').textContent;
        data.limitOfCoverage = row.querySelector('[data-limitOfCoverage]').textContent;

        dataList.push(data); // Add the object to the list
    });
    var formData = new FormData();
    formData.append('data', JSON.stringify(dataList));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify("AF1_33"));
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
            toastr.error(error, "Error downloading Excel file");
            hideLoading();
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
    const dataList = []; // Create an empty list to store the objects
    try {
        var tableRows = document.querySelectorAll('#table-body tr');
        tableRows.forEach((row) => {
            const data = {}; // Create an empty object for each row

            data.serial = row.querySelector('[data-serial]').getAttribute('data-serial');
            data.company = row.querySelector('[data-company]').getAttribute('data-company');
            data.staffNbr = row.querySelector('[data-staffnbr]').getAttribute('data-staffnbr');
            data.firstName = row.querySelector('[data-firstname]').getAttribute('data-firstname');
            data.middleName = row.querySelector('[data-middlename]').getAttribute('data-middlename');
            data.mobileNumber = row.querySelector('[data-mobileNumber]').getAttribute('data-mobileNumber');
            data.email = row.querySelector('[data-email]').getAttribute('data-email');
            data.lastName = row.querySelector('[data-lastname]').getAttribute('data-lastname');
            data.genderCode = row.querySelector('[data-gendercode]').getAttribute('data-gendercode');
            data.dob = row.querySelector('[data-dob]').getAttribute('data-dob');
            data.nationalityCode = row.querySelector('[data-nationalitycode]').getAttribute('data-nationalitycode');
            data.maritalStatusCode = row.querySelector('[data-maritalstatuscode]').getAttribute('data-maritalstatuscode');
            data.grade = row.querySelector('[data-grade]').getAttribute('data-grade');
            data.currency = row.querySelector('[data-currency]').getAttribute('data-currency');
           // data.annualWages = row.querySelector('[data-annualWages]').getAttribute('data-annualWages');
            data.limitOfCoverage = row.querySelector('[data-limitOfCoverage]').getAttribute('data-limitOfCoverage');

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

    obj.BusinessLineCode = BusinessLineCode;
    obj.ContactId = $("#ContactId").val();
    obj.RecId = trxID;
    obj.AF1BL331211 = dataList;
    formBody.append("data", JSON.stringify(obj));
    if (trxID != 0) {

        $.ajax({
            url: "/Business/EditAF1_33",
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
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_33"), JSON.stringify("AF"));
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
            url: "/Business/CreateAF1_33",
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
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_33"), JSON.stringify("AF"));
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
    { data: 'serial', title: 'Serial', width: '100px' },
    { data: 'company', title: 'Company', width: '100px' },
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
   // { data: 'annualWages', title: 'Annual Wages' },
    { data: 'limitOfCoverage', title: 'Limit Of Coverage' }
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
var table = $('#tableAf133').DataTable({
    data: datatablelist,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'serial', title: 'Serial' },
        { data: 'company', title: 'Company' },
        { data: 'staffNbr', title: 'Staff Number' },
        { data: 'firstName', title: 'First Name' },
        { data: 'middleName', title: 'Middle Name' },
        { data: 'lastName', title: 'Last Name' },
        { data: 'mobileNumber', title: 'Mobile' },
        { data: 'email', title: 'Email' },
        {
            data: 'genderCode', title: 'Gender',
            render: function (data, type, row) {
                return genderList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'dob', title: 'Date of Birth',
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
    //    { data: 'annualWages', title: 'Annual Wages' },
        { data: 'limitOfCoverage', title: 'Limit Of Coverage' }
    ],
    columnDefs: columnDefs,
});
$(".buttons-excel").addClass("btn btn-primary mr-1");
var hiddenColumns = []; // Array to store hidden columns
// Create the dropdown with checkboxes for column visibility
var columnVisibilityDropdown = $('<div>').addClass('dropdown-menu');
table.columns().every(function () {
    var column = this;
    var columnIndex = column.index();
    var columnTitle = $(column.header()).text();
    var isVisible = column.visible();

    $('<div>').addClass('dropdown-item').append(
        $('<label>').addClass('dropdown-item-label').append(
            $('<input>').attr({
                type: 'checkbox',
                checked: isVisible
            }).on('change', function () {
                var isChecked = $(this).is(':checked');

                if (isChecked) {
                    // Show the column in the table
                    table.column(columnIndex).visible(true);

                    // Remove the column from the hiddenColumns array
                    var hiddenIndex = hiddenColumns.indexOf(columnIndex);
                    if (hiddenIndex > -1) {
                        hiddenColumns.splice(hiddenIndex, 1);
                    }

                    // Remove the column from the details section
                    $('.details-section').find('.column-details[data-column="' + columnIndex + '"]').remove();
                } else {
                    // Hide the column from the table
                    table.column(columnIndex).visible(false);

                    // Add the column to the hiddenColumns array if it's not already added
                    if (hiddenColumns.indexOf(columnIndex) === -1) {
                        hiddenColumns.push(columnIndex);
                    }

                    // Add the column to the details section if it's not already added
                    if (!$('.details-section').find('.column-details[data-column="' + columnIndex + '"]').length) {
                        var columnData = table.column(columnIndex).data().toArray();
                        var columnDetails = $('<div>').addClass('column-details').attr('data-column', columnIndex);
                        $('<h3>').text(columnTitle).appendTo(columnDetails);
                        $('<ul>').appendTo(columnDetails);

                        columnData.forEach(function (value) {
                            var listItem = $('<li>').text(value).appendTo(columnDetails.find('ul'));
                        });

                        $('.details-section').append(columnDetails);
                    }
                }
            }),
            $('<span>').text(columnTitle)
        )
    ).appendTo(columnVisibilityDropdown);
});
// Append the dropdown to the button container
$('.dt-buttons').append(columnVisibilityDropdown);
// Hide initially hidden columns
hiddenColumns.forEach(function (columnIndex) {
    table.column(columnIndex).visible(false);
});
$("#btnDownloadEmptyExcel").click(function () {
    downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_33"), JSON.stringify("AF"));
})