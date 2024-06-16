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
        formData.append('code', "AF1_30");
        $("#btnSubmit").attr('disabled', false);
        $("#btnSubmitWithEmail").attr('disabled', false);
        $.ajax({
            type: 'POST',
            url: '/ExcelImport/ImportExcelAF1_30',
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
                        // Initialize increment value
                        var incrementValue = 0;

                        // Loop through the list
                        for (var i = 0; i < result.data.length; i++) {
                            if (result.data[i].relationCode.toLowerCase() === "principal") {
                                incrementValue++;
                                result.data[i].familyNmbr = incrementValue;

                            } else {
                                result.data[i].familyNmbr = incrementValue;
                            }
                        }
                        // var validfamily = validateFamilies(result.data);
                        // Assuming your list is named 'dataList'
                        for (let i = 0; i < result.data.length; i++) {
                            const data = result.data[i];
                            const row = document.createElement('tr');
                            try {

                                var resultdata = validateModel(data);
                                if (!resultdata.valid) {
                                    row.innerHTML = `
    <td data-serial="${data.serial}">${data.serial}</td>
    <td data-clientname="${data.clientName}">${data.clientName}</td>
    <td data-staffnbr="${data.staffNbr}">${data.staffNbr}</td>
    <td data-firstname="${data.firstName}">${data.firstName}</td>
    <td data-middlename="${data.middleName}">${data.middleName}</td>
    <td data-lastname="${data.lastName}">${data.lastName}</td>
    <td data-gendercode="">${data.genderCode}</td>
    <td data-relationcode="">${data.relationCode}</td>
    <td data-dob="${data.dob}">${data.dob}</td>
    <td data-nationalitycode="">${data.nationalityCode}</td>
    <td data-maritalstatuscode="">${data.maritalStatusCode}</td>
    <td data-nssf="">${data.nssf}</td>
    <td data-classofcoveragcode="">${data.classOfCoveragCode}</td>
      <td data-networklevelcode="">${data.networkLevelCode}</td>
    <td data-ambulatory="">${data.ambulatory}</td>
    <td data-prescriptionmedecine=""</td>
    <td data-doctorvisit="">${data.doctorVisit}</td>
`;
                                    row.style.backgroundColor = 'red';
                                    row.setAttribute('title', resultdata.message)
                                    toastr.warning(`Error in row ${i + 1}, message: ${resultdata.message}`, "Fix Excel");
                                    $("#btnSubmit").attr('disabled', true);
                                    $("#btnSubmitWithEmail").attr('disabled', true);
                                    tableBody.appendChild(row);
                                } else {
                                    // Populate the row with object properties
                                    row.innerHTML = `
    <td data-serial="${data.serial}">${data.serial}</td>
    <td data-clientname="${data.clientName}">${data.clientName}</td>
    <td data-staffnbr="${data.staffNbr}">${data.staffNbr}</td>
    <td data-firstname="${data.firstName}">${data.firstName}</td>
    <td data-middlename="${data.middleName}">${data.middleName}</td>
    <td data-lastname="${data.lastName}">${data.lastName}</td>
    <td data-gendercode="${genderList.find(x => x.description.toLowerCase() == data.genderCode.toLowerCase()).code}">${data.genderCode}</td>
    <td data-relationcode="${relationList.find(x => x.description.toLowerCase() == data.relationCode.toLowerCase()).code}">${data.relationCode}</td>
    <td data-dob="${data.dob}">${data.dob}</td>
    <td data-nationalitycode="${regionList.find(x => x.description.toLowerCase() == data.nationalityCode.toLowerCase()).code}">${data.nationalityCode}</td>
    <td data-maritalstatuscode="${maritalStatusList.find(x => x.description.toLowerCase() == data.maritalStatusCode.toLowerCase()).code}">${data.maritalStatusCode}</td>
    <td data-nssf="${(data.nssf.toLowerCase() === "yes")}">${data.nssf}</td>
    <td data-classofcoveragcode="${classOfCoverageList.find(x => x.description.toLowerCase() == data.classOfCoveragCode.toLowerCase()).recId}">${data.classOfCoveragCode}</td>
      <td data-networklevelcode="${networkList.find(x => x.description.toLowerCase() == data.networkLevelCode.toLowerCase()).recId}">${data.networkLevelCode}</td>
    <td data-ambulatory="${(data.ambulatory.toLowerCase() === "yes")}">${data.ambulatory}</td>
    <td data-prescriptionmedecine="${(data.prescriptionMedecine.toLowerCase() === "yes")}">${data.prescriptionMedecine}</td>
    <td data-doctorvisit="${(data.doctorVisit.toLowerCase() === "yes")}">${data.doctorVisit}</td>
`;
                                    tableBody.appendChild(row);
                                }

                            } catch (error) {
                                // Populate the row with object properties
                                row.innerHTML = `
    <td data-serial="${data.serial}">${data.serial}</td>
    <td data-clientname="${data.clientName}">${data.clientName}</td>
    <td data-staffnbr="${data.staffNbr}">${data.staffNbr}</td>
    <td data-firstname="${data.firstName}">${data.firstName}</td>
    <td data-middlename="${data.middleName}">${data.middleName}</td>
    <td data-lastname="${data.lastName}">${data.lastName}</td>
    <td data-gendercode="">${data.genderCode}</td>
    <td data-relationcode="">${data.relationCode}</td>
    <td data-dob="${data.dob}">${data.dob}</td>
    <td data-nationalitycode="">${data.nationalityCode}</td>
    <td data-maritalstatuscode="">${data.maritalStatusCode}</td>
    <td data-nssf="">${data.nssf}</td>
    <td data-classofcoveragcode="">${data.classOfCoveragCode}</td>
      <td data-networklevelcode="">${data.networkLevelCode}</td>
    <td data-ambulatory="">${data.ambulatory}</td>
    <td data-prescriptionmedecine=""</td>
    <td data-doctorvisit="">${data.doctorVisit}</td>
`;
                                row.style.backgroundColor = 'red';
                                console.log(`Error in row ${i + 1}`);
                                toastr.warning(`Error in row ${i + 1}, message: ${error.message}`, "Fix Excel");
                                tableBody.appendChild(row);
                                $("#btnSubmit").attr('disabled', true);
                                $("#btnSubmitWithEmail").attr('disabled', true);
                            }
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
        data.clientName = row.querySelector('[data-clientname]').textContent;
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
        data.classOfCoveragCode = row.querySelector('[data-classofcoveragcode]').textContent;
        data.networkLevelCode = row.querySelector('[data-networklevelcode]').textContent;
        data.ambulatory = row.querySelector('[data-ambulatory]').textContent;
        data.prescriptionMedecine = row.querySelector('[data-prescriptionmedecine]').textContent;
        data.doctorVisit = row.querySelector('[data-doctorvisit]').textContent;

        dataList.push(data); // Add the object to the list
    });
    var formData = new FormData();
    formData.append('data', JSON.stringify(dataList));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify("AF1_30"));
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
            data.clientName = row.querySelector('[data-clientname]').getAttribute('data-clientname');
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
            data.classOfCoveragCode = row.querySelector('[data-classofcoveragcode]').getAttribute('data-classofcoveragcode');
            data.networkLevelCode = row.querySelector('[data-networklevelcode]').getAttribute('data-networklevelcode');
            data.ambulatory = row.querySelector('[data-ambulatory]').getAttribute('data-ambulatory');
            data.prescriptionMedecine = row.querySelector('[data-prescriptionmedecine]').getAttribute('data-prescriptionmedecine');
            data.doctorVisit = row.querySelector('[data-doctorvisit]').getAttribute('data-doctorvisit');

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
    obj.AF1BL301401 = dataList;
    formBody.append("data", JSON.stringify(obj));
    if (trxID != 0) {

        $.ajax({
            url: "/Business/EditAF1_30",
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
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_30"), JSON.stringify("AF"));
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
            url: "/Business/CreateAF1_30",
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
                        downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_30"), JSON.stringify("AF"));
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
    { data: 'clientName', title: 'Client', width: '200px' },
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
    { data: 'classOfCoveragCode', title: 'Class of Coverage' },
    { data: 'networkLevelCode', title: 'Network' },
    { data: 'ambulatory', title: 'Ambulatory' },
    { data: 'prescriptionMedecine', title: 'Prescription Medicine' },
    { data: 'doctorVisit', title: 'Doctor Visit' }
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
var table = $('#tableAf130').DataTable({
    data: datatablelist.aF1BL301401,
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'serial', title: 'Serial', width: '100px' },
        { data: 'clientName', title: 'Client', width: '200px' },
        { data: 'staffNbr', title: 'Staff Number' },
        { data: 'firstName', title: 'First Name' },
        { data: 'middleName', title: 'Middle Name' },
        { data: 'lastName', title: 'Last Name' },
        {
            data: 'genderCode', title: 'Gender',
            render: function (data, type, row) {
                return genderList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'relationCode', title: 'Relation Code', visible: true,
            render: function (data, type, row) {
                return relationList.find(x => x.code == data).description || '';
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
        {
            data: 'nssf', title: 'NSSF', render: function (data, type, row, meta) {
                if (data != null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            }
        },
        {
            data: 'classOfCoveragCode', title: 'Class of Coverage',
            render: function (data, type, row) {
                return classOfCoverageList.find(x => x.code == data).description || '';
            }
        },
        {
            data: 'networkLevelCode', title: 'Network',
            render: function (data, type, row) {
                return networkList.find(x => x.recId == data).description || '';
            }
        },
        {
            data: 'ambulatory', title: 'Ambulatory', render: function (data, type, row, meta) {
                if (data != null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            }
        },
        { data: 'prescriptionMedecine', title: 'Prescription Medicine' },
        {
            data: 'doctorVisit', title: 'Doctor Visit', render: function (data, type, row, meta) {
                if (data != null && data.toString() == "true") {
                    return "<span class='badge bg-success'>Yes</span>";
                } else {
                    return "<span class='badge bg-danger'>No</span>";
                }
            }
        }
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
    downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_30"), JSON.stringify("AF"));
})
// Function to validate a value against a list
function validateValueFromList(value, list) {
    return list.includes(value);
}

function validateModel(model) {
    var obj = {};
    var msg = "";
    obj.valid = true;

    for (const prop in model) {
        if (model.hasOwnProperty(prop)) {
            var value = model[prop].toString();
            var valueLowerCase = value.toLowerCase();
            switch (prop) {
                case 'dob':
                    if (value == null || value == "") {
                        msg += `Date Of Birth "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    //var dateRegex = /^\d{2}\/\d{2}\/\d{4}$/;
                    //if (!value.match(dateRegex)) {
                    //    msg += `Invalid date format. Please use DD/MM/YYYY format.\n`;
                    //    obj.valid = false;
                    //}
                    var birthDate = new Date(value);
                    if (isNaN(birthDate.getTime())) {
                        msg += "Invalid Date Of Birth.\n"
                        obj.valid = false;
                    }
                    var today = new Date();
                    var age = today.getFullYear() - birthDate.getFullYear();
                    var monthDifference = today.getMonth() - birthDate.getMonth();
                    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
                        age--;
                    }
                    if (model.relationCode.toLowerCase() == "principal") {
                        if (age >= 17 && age <= 99) {

                        } else {
                            msg += `Principal age must be between 17 & 99\n`;
                            obj.valid = false;
                        }
                    }
                    if (model.relationCode.toLowerCase() == "spouse") {
                        if (age >= 17 && age <= 99) {

                        } else {
                            msg += `Spouse age must be between 17 & 99\n`;
                            obj.valid = false;
                        }
                    }
                    if (model.relationCode.toLowerCase() == "child") {
                        if (age >= 0 && age <= 25) {

                        } else {
                            msg += `Children age must be between 0 & 25\n`;
                            obj.valid = false;
                        }
                    }

                    break;
                case 'clientName':
                    if (value == null || value == "") {
                        msg += `Client Name "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'firstName':
                    if (value == null || value == "") {
                        msg += `First Name "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'lastName':
                    if (value == null || value == "") {
                        msg += `Last Name "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'genderCode':

                    if (value == null || value == "") {
                        msg += `Gender "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, genderList.map(x => x.description.toLowerCase()))) {
                        msg += `Gender "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'relationCode':
                    if (value == null || value == "") {
                        msg += `Relation "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, relationList.map(x => x.description.toLowerCase()))) {
                        msg += `Relation "${value}" is not valid.\n`;
                        obj.valid = false;
                    }

                    break;
                case 'nationalityCode':
                    if (value == null || value == "") {
                        msg += `Nationality "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, regionList.map(x => x.description.toLowerCase()))) {
                        msg += `Nationality "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'maritalStatusCode':
                    if (value == null || value == "") {
                        msg += `Marital Status "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, maritalStatusList.map(x => x.description.toLowerCase()))) {
                        msg += `Marital Status "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    if (model.relationCode.toLowerCase() == "child") {
                        if (valueLowerCase != "single") {
                            msg += `Child must be single.\n`;
                            obj.valid = false;
                        }
                    }
                    break;
                case 'classOfCoveragCode':
                    if (value == null || value == "") {
                        msg += `Class Of Coverag "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, classOfCoverageList.map(x => x.description.toLowerCase()))) {
                        msg += `Class Of Coverag "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'networkLevelCode':
                    if (value == null || value == "") {
                        msg += `Network Level "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, networkList.map(x => x.description.toLowerCase()))) {
                        msg += `Network Level "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'nssf':
                    if (value == null || value == "") {
                        msg += `NSSF "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, ["yes", "no"])) {
                        msg += `NSSF "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'ambulatory':
                    if (value == null || value == "") {
                        msg += `Ambulatory "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, ["yes", "no"])) {
                        msg += `Ambulatory "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'prescriptionMedecine':
                    if (value == null || value == "") {
                        msg += `Prescription Medecine "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, ["yes", "no"])) {
                        msg += `Prescription Medecine "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                case 'doctorVisit':
                    if (value == null || value == "") {
                        msg += `Doctor Visit "${value}" is Required.\n`;
                        obj.valid = false;
                    }
                    if (!validateValueFromList(valueLowerCase, ["yes", "no"])) {
                        msg += `Doctor Visit "${value}" is not valid.\n`;
                        obj.valid = false;
                    }
                    break;
                // Add more cases for other properties if needed
                default:
                    break;
            }
        }
    }
    obj.message = msg;

    return obj;
}
function validateFamilies(families) {
    // Sort families by familyId
    families.sort((a, b) => a.familyId - b.familyId);

    for (let family of families) {
        let principal = family.find(person => person.role === 'principal');
        let spouse = family.find(person => person.role === 'spouse');
        let children = family.filter(person => person.role === 'child');

        // Check if principal and spouse are not of the same gender
        if (principal.gender === spouse.gender) {
            console.log(`Family ${family.familyId} Error: Principal and spouse cannot be of the same gender.`);
            return false;
        }

        // Check if the younger between principal and spouse is at least 16 years older than the eldest child
        let minParentAge = Math.min(principal.age, spouse.age);
        let maxChildAge = Math.max(...children.map(child => child.age));

        if (minParentAge - maxChildAge < 16) {
            console.log(`Family ${family.familyId} Error: The younger parent should be at least 16 years older than the eldest child.`);
            return false;
        }
    }
    console.log("All families validated successfully.");
    return true;
}

function checkChildren() {
    var table = document.getElementById("tblAf8");
    var rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");
    var result = true;
    var data = [];
    var numberSpouse = 0, numberPrinciple = 0, childrenCount = 0;
    var childBirthdate, spouseBirthdate, principalBirthdate;
    var spouseGender, principalGender;
    for (var i = 0; i < rows.length; i++) {
        var cells = rows[i].getElementsByTagName("td");
        if (cells[0].querySelector("select").value.toLowerCase() == 'c') {
            childrenCount++;
            childBirthdate = cells[5].querySelector("input").value;
        } else if (cells[0].querySelector("select").value.toLowerCase() == 'p') {
            numberPrinciple++;
            principalBirthdate = cells[5].querySelector("input").value;
            principalGender = cells[4].querySelector("select").value.toLowerCase();
        } else if (cells[0].querySelector("select").value.toLowerCase() == 's') {
            numberSpouse++;
            spouseBirthdate = cells[5].querySelector("input").value;
            spouseGender = cells[4].querySelector("select").value.toLowerCase();
        }
        if (childBirthdate != '' && childBirthdate != null) {
            if (!childrenValidationAge(childBirthdate, principalBirthdate, spouseBirthdate)) {
                result = false;
            }
        }

    }
    if (childrenCount < 6) {

    } else {
        toastr.warning("No more Children");
        result = false;
    }
    if (numberPrinciple > 1) {
        toastr.warning("One principle allowed");
        result = false;
    }
    if (numberSpouse > 1) {
        toastr.warning("One spouse allowed");
        result = false;
    }
    if ((spouseGender != '' && spouseGender != null) && (principalGender != '' && principalGender != null)) {
        if ((spouseGender == 'm' && principalGender == 'm') || (spouseGender == 'f' && principalGender == 'f')) {
            toastr.warning("Pricipal and spouse must have diffrent gender");
            result = false;
        }
    }

    return result;
}
function childrenValidationAge(childrenAge, principalAge, spouseAge) {
    var cildrenageNber, principalAgeNber, spouseAgeNber, youngerAge;
    cildrenageNber = getAge(childrenAge);
    principalAgeNber = getAge(principalAge);
    spouseAgeNber = getAge(spouseAge);

    if (cildrenageNber > 25 && cildrenageNber != -1) {
        toastr.warning("Child Age must be less or equal to 25 years old", "Children Age");
        return false;
    }
    // Find the younger one between principal and spouse
    if (principalAgeNber > 0 && spouseAgeNber > 0) {
        youngerAge = Math.min(principalAgeNber, spouseAgeNber);
    } else {
        toastr.warning("Invalid principal or spouse age", "Principal or spouse Age");
        return false;
    }


    // Check if child age is less than the younger one by 18 years
    if (cildrenageNber < (youngerAge - 18)) {
        return true; // Valid
    } else {
        toastr.warning("Invalid child age. Child age must be less than the younger one between principal or spouse age by 18 years.", "Children Age");
        return false; // Invalid
    }
    //if (cildrenageNber >= youngerAge - 18) {
    //    toastr.warning("Invalid child age. Child age must be less than the younger one between principal or spouse age by 18 years.", "Children Age");
    //    return false;
    //} else {
    //    toastr.warning("Valid child age.", "Children Age");
    //    return false;
    //}
    return true;
}
function getAge(dateOfBirth) {
    var dateRegex = /^\d{2}\/\d{2}\/\d{4}$/;
    if (!dateOfBirth.match(dateRegex)) {
        toastr.warning("Invalid date format. Please use DD/MM/YYYY format.", "Children Age");
        return false;
    }
    if (!dateOfBirth) {
        toastr.warning("Date of birth is null", "Children Age");
        return false;
    }
    var birthDate = new Date(dateOfBirth);
    if (isNaN(birthDate.getTime())) {
        toastr.warning("Invalid date", "Children Age");
        return false;
    }
    var today = new Date();
    var age = today.getFullYear() - birthDate.getFullYear();
    var monthDifference = today.getMonth() - birthDate.getMonth();
    if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}
