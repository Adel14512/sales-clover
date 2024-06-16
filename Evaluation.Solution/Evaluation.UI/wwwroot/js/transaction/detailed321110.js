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

    //const dataList = []; // Create an empty list to store the objects
    //var tableRows = document.querySelectorAll('#table-body tr');
    //tableRows.forEach((row) => {
    //    const data = {}; // Create an empty object for each row

    //    data.serial = row.querySelector('[data-serial]').textContent;
    //    data.company = row.querySelector('[data-company]').textContent;
    //    data.staffNbr = row.querySelector('[data-staffnbr]').textContent;
    //    data.firstName = row.querySelector('[data-firstname]').textContent;
    //    data.middleName = row.querySelector('[data-middlename]').textContent;
    //    data.lastName = row.querySelector('[data-lastname]').textContent;
    //    data.genderCode = row.querySelector('[data-gendercode]').textContent;
    //    data.relationCode = row.querySelector('[data-relationcode]').textContent;
    //    data.dob = row.querySelector('[data-dob]').textContent;
    //    data.nationalityCode = row.querySelector('[data-nationalitycode]').textContent;
    //    data.maritalStatusCode = row.querySelector('[data-maritalstatuscode]').textContent;
    //    data.nssf = row.querySelector('[data-nssf]').textContent;
    //    data.grade = row.querySelector('[data-grade]').textContent;
    //    data.dental = row.querySelector('[data-dental]').textContent;
    //    data.optical = row.querySelector('[data-optical]').textContent;
    //    data.classOfCoveragCode = row.querySelector('[data-classofcoveragcode]').textContent;
    //    data.ambulatory = row.querySelector('[data-ambulatory]').textContent;
    //    data.prescriptionMedecine = row.querySelector('[data-prescriptionmedecine]').textContent;
    //    data.doctorVisit = row.querySelector('[data-doctorvisit]').textContent;
    //    data.mobileNumber = row.querySelector('[data-mobileNumber]').textContent;
    //    data.email = row.querySelector('[data-email]').textContent;
    //   // data.shop = row.querySelector('[data-shop]').textContent;


    //    dataList.push(data); // Add the object to the list
    //});
    var formData = new FormData();
    formData.append('data', JSON.stringify(table.rows().data().toArray()));
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
            data.mobileNumber = row.querySelector('[data-mobileNumber]').getAttribute('data-doctorvisit');
            data.email = row.querySelector('[data-email]').getAttribute('data-doctorvisit');
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
    var urlencode = encodeParameters("?contactid=" + $("#ContactId").val());
    window.location.href = "../../transaction/Dashboard/" + urlencode;
});

var tInssurredPartySelectedData;
var table, tStep2Table, tStep3Table, tStep4Table, tStep5Table;
$(document).ready(function () {
    var tInssurredParty = $('#tInssurredParty').DataTable({
        data: details,//.map(({ recId, insurer_Code, thirdPartyAdmin_Code }) => ({ recId, insurer_Code, thirdPartyAdmin_Code }))
        responsive: true,
        autoWidth: true,
        columns: [
            //  { data: 'recId', title: 'RecId', },

            {
                data: 'insurer_Code', title: 'Insurer',
                render: function (data, type, row) {

                    var model = step5InsurrerData.find(x => x.recId == data);
                    if (model != null) {
                        return model.description
                    } else {
                        return '';
                    }
                }
            },
            {
                data: 'thirdPartyAdmin_Code', title: 'Third Party',
                render: function (data, type, row) {

                    var model = step5ThirdPartyData.find(x => x.recId == data);
                    if (model != null) {
                        return model.description
                    } else {
                        return '';
                    }
                }
            },
        ],
    });

    var countDisplay = 0;

    $('#tInssurredParty tbody').on('click', 'tr', function () {
        $('#tInssurredParty tbody tr').removeClass('selected');
        $(this).addClass('selected');

        tInssurredPartySelectedData = tInssurredParty.row(this).data();
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
        table = step1DataTable(tInssurredPartySelectedData, columnDefs);
        $('#tableAf132').DataTable().destroy();
        table = step1DataTable(tInssurredPartySelectedData, columnDefs);
        $("#btnDownloadEmptyExcel").click(function () {
            downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("AF"));
        })
        $("#btnDownloadEmptyExcelStep4").click(function () {
            downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("BN"));
        });
        $("#btnDownloadEmptyExcelStep5").click(function () {
            downloadEmptyExcel(BusinessLineCode, JSON.stringify("AF1_32"), JSON.stringify("PL"));
        });

        tStep2Table = step2DataTable();
        $('#tStep2').DataTable().destroy();
        tStep2Table = step2DataTable();


        tStep3Table = step3DataTable();
        $('#tStep3').DataTable().destroy();
        tStep3Table = step3DataTable();

        tStep4Table = step4DataTable();
        $('#tStep4').DataTable().destroy();
        tStep4Table = step4DataTable();

        tStep5Table = step5DataTable();
        $('#tStep5').DataTable().destroy();
        tStep5Table = step5DataTable();

        $("#CommisinOnGPPer").val(tInssurredPartySelectedData.commisinOnGPPer);
        $("#AdminFeesAmount").val(tInssurredPartySelectedData.adminFeesAmount);
        $("#CostOfPolicyPer").val(tInssurredPartySelectedData.costOfPolicyPer);
        $("#CostOfPolicyAmount").val(tInssurredPartySelectedData.costOfPolicyAmount);
        $("#FixedTaxesAmount").val(tInssurredPartySelectedData.fixedTaxesAmount);
        $("#FixedTaxesPer").val(tInssurredPartySelectedData.fixedTaxesPer);
        $("#VATPer").val(tInssurredPartySelectedData.vatPer);
        $("#AgeCalculationYear").val(tInssurredPartySelectedData.ageCalculationYear);
        $("#AgeCalculationFullDate").val(tInssurredPartySelectedData.ageCalculationFullDate);
        var dateValue = tInssurredPartySelectedData.ageCalculationStartDate;
        if (dateValue) {
            dateValue = dateValue.split('T')[0];
        }
        $("#AgeCalculationStartDate").val(dateValue);
        if ($("#AgeCalculationFullDate").val() == "true") {
            $('#AgeCalculationFullDate').prop('checked', true);
            $('#AgeCalculationYear').prop('checked', false);
            $("#AgeCalculationYear").val("false");
            $(".fulldate").show();
        } else {
            $('#AgeCalculationFullDate').prop('checked', false);
            $('#AgeCalculationYear').prop('checked', true);
            $("#AgeCalculationFullDate").val("false");
            $(".fulldate").hide();
        }
    });
    function step3DataTable() {
        return $('#tStep3').DataTable({
            data: tInssurredPartySelectedData.slip3BL321110,
            responsive: true,
            autoWidth: true,
            destroy: true,
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
                            return model.description;
                        } else {
                            return '';
                        }
                    }
                },
                { data: 'co_InsurancePer', title: 'Co_InsurancePer' },
                //{ data: 'co_Insurance_Amt', title: 'Co_Insurance_Amt' },
                { data: 'limitAmount', title: 'LimitAmount' },
                {
                    data: 'networkLevel', title: 'NetworkLevel',
                    render: function (data, type, row) {

                        var model = networks.find(x => x.recId == data);
                        if (model != null) {
                            return model.description;
                        } else {
                            return '';
                        }
                    }
                },
                {
                    data: 'network', title: 'Network',
                    render: function (data, type, row) {

                        var model = networkpoi.find(x => x.recId == data);
                        if (model != null) {
                            return model.networkName + " - " + model.networkExplanation;
                        } else {
                            return '';
                        }
                    }
                },

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
    }

    function step2DataTable() {
        return $('#tStep2').DataTable({
            destroy: true,
            data: tInssurredPartySelectedData.slip2BL321110,
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
                    data: 'e_Renewability', title: 'GR', width: '30px', render: function (data, type, row, meta) {
                        if (data != null && data.toString() == "true") {
                            return "<span class='badge bg-success'>Yes</span>";
                        } else {
                            return "<span class='badge bg-danger'>No</span>";
                        }
                    }
                },
                {
                    data: 'n_NoUnderwriting', title: 'NU', render: function (data, type, row, meta) {
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
                }
                $("#tStep2 thead").css('border', 'transparent');

            }
        });
    }
});
function step4DataTable() {
    return $('#tStep4').DataTable({
        destroy: true,
        data: tInssurredPartySelectedData.slip4BL321110,
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
}

function step5DataTable() {
    var list = detailsPrices.filter(x => x.salesTrxDetailsId == tInssurredPartySelectedData.recId);
    if (list != null && list.length != 0) {
        $("#btnPrintCq").show();
    }
    return $('#tStep5').DataTable({
        destroy: true,
        data: list,
        responsive: true,
        autoWidth: false,
        columns: [
            //{ data: 'salesTrxDetailsId', title: 'SalesTrxDetailsId' },
            { data: 'sectionName', title: 'Name', width: "20px" },
            { data: 'category', title: 'Category' },
            { data: 'dependency', title: 'Dependency' },
            {
                data: 'gender', title: 'Gender',
                render: function (data, type, row) {
                    if (data != null || data != "") {
                        var model = genderList.find(x => x.code == data).description || '';
                        if (model != null || model != "") {
                            return genderList.find(x => x.code == data).description || '';
                        } else {
                            toastr.warning(data, "Gender Wrong Value");
                            return '';
                        }

                    } else {
                        return '';
                    }

                }
            },
            {
                data: 'maritalStatus', title: 'Marital Status',
                render: function (data, type, row) {
                    if (data != null || data != "") {
                        var model = maritalStatusList.find(x => x.code == data).description || '';
                        if (model != null || model != "") {
                            return maritalStatusList.find(x => x.code == data).description || '';
                        } else {
                            toastr.warning(data, "Gender Wrong Value");
                            return '';
                        }
                    } else {
                        return '';
                    }

                }
            },
            { data: 'costSharing', title: 'Cost Sharing' },
            { data: 'ageMinRange', title: 'Age Min Range' },
            { data: 'ageMaxRange', title: 'Age Max Range' },
            { data: 'premium', title: 'Premium' },
        ],
    });
}

function step1DataTable(tInssurredPartySelectedData, columnDefs) {
    return $('#tableAf132').DataTable({
        destroy: true,
        data: tInssurredPartySelectedData.aF1BL321110,
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
                    if (data != null && data.toString() == "true") {
                        return "<span class='badge bg-success'>Yes</span>";
                    } else {
                        return "<span class='badge bg-danger'>No</span>";
                    }
                }
            },
            { data: 'grade', title: 'Grade' },
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
            { data: 'shop', title: 'Shop' },
        ],
        columnDefs: columnDefs,
    });
}

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
                        Swal.fire(
                            "Uploading Benefits!",
                            "Uploaded Data will not be saved until you click on (Submit)"
                        );
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
    fixStep2Header();
    var formData = new FormData();
    var obj = {};
    obj.RecId = tInssurredPartySelectedData.recId;
    obj.Slip2BL321110 = tStep2Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110DetailsUpdSlip2',
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
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].slip2BL321110 = tStep2Table.rows().data().toArray();
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
    obj.RecId = tInssurredPartySelectedData.recId;
    obj.Slip3BL321110 = tStep3Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110DetailsUpdSlip3',
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
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].slip3BL321110 = tStep3Table.rows().data().toArray();
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
    obj.RecId = tInssurredPartySelectedData.recId;
    obj.Slip4BL321110 = tStep4Table.rows().data().toArray();
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110DetailsUpdSlip4',
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
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].slip4BL321110 = tStep4Table.rows().data().toArray();
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
    fixStep2Header();
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
        $('#txtNetwork').html("");
        $('#txtNetwork').append($('<option>', {
            value: "",
            text: "---Select---"
        }));
        $.each(networkpoi.filter(x => x.thirdPartyAdminId == tInssurredPartySelectedData.thirdPartyAdmin_Code), function (index, option) {
            $('#txtNetwork').append($('<option>', {
                value: option.recId,
                text: option.networkName + " - " + option.networkExplanation
            }));
        });
        $('#txtNetwork').val(model.network);
        if (model.covered == null) {
            $('#ddlCovered').val("false");
        } else {
            $('#ddlCovered').val(model.covered.toString() == "true" ? "true" : "false");
        }

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
        //co_Insurance_Amt: $('#txtCoInsuranceAmt').val(),
        limitAmount: $('#txtLimitAmount').val(),
        networkLevel: $('#txtNetworkLevel').val(),
        network: $('#txtNetwork').val(),
        covered: $('#ddlCovered').val()
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
    $('#txtCoInsuranceAmt').val("");
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

$("#btnUploadStep5").click(function () {
    document.getElementById('fileInputStep5').click();
});
$('#fileInputStep5').change(function () {
    var fileName = $(this).val();
    if (fileName != '') {
        var file = this.files[0]; // Get the selected file

        // Create a new FormData object and append the selected file to it
        var formData = new FormData();
        formData.append('file', file);
        formData.append('code', BusinessLineCode);

        $.ajax({
            type: 'POST',
            url: '/ExcelImport/ImportExcelAF1_32_DetailsStep5',
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function (xhr) {
                showLoading();
                // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
            },
            success: function (result) {
                $('#fileInputStep5').val('');
                //generateForm(result);
                hideLoading();
                if (result.status == "success") {
                    if (result.data != null && result.data.length > 0) {
                        tStep5Table.clear();
                        $("#btnPrintCq").show();
                        // Add new data
                        tStep5Table.rows.add(result.data); // replace newData with your new list

                        // Redraw the table
                        tStep5Table.draw();
                        Swal.fire(
                            "Uploading Prices!",
                            "Uploaded Data will not be saved until you click on (Submit)"
                        );
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
$("#btnSubmitStep5").click(function () {
    var formData = new FormData();
    if ($("#AgeCalculationYear").val() == "true") {
        step5Submit(formData);
    } else
        if ($("#AgeCalculationFullDate").val() == "true" && $("#AgeCalculationStartDate").valid()) {
            step5Submit(formData);
        } else {
            toastr.warning("Fill Full Date", "Full Date");
        }
});
$("#btnStep5ExportData").click(function () {
    var formData = new FormData();
    formData.append('data', JSON.stringify(tStep5Table.rows().data().toArray()));

    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify("AF1_32"));
    formData.append('type', JSON.stringify("PL"));
    $.ajax({
        type: 'POST',
        url: '/Slip/ExportExcelDetailsStep5AF32',
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
$("#btnPrintCq").click(function () {
    var formData = new FormData();
    formData.append('businessPage', JSON.stringify("CQ_10"));
    formData.append('businesscode', BusinessLineCode);
    formData.append('trxID', JSON.stringify(tInssurredPartySelectedData.salesTrxId));
    formData.append('type', JSON.stringify("CQ"));
    formData.append('contactid', 0);
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
$("#btnConsolidation").click(function (e) {
    if (tInssurredPartySelectedData != null) {
        var thirdPartyDesc = step5ThirdPartyData.filter(x => x.recId == tInssurredPartySelectedData.thirdPartyAdmin_Code)[0].description;
        var insurrerDescription = step5InsurrerData.filter(x => x.recId == tInssurredPartySelectedData.insurer_Code)[0].description;


        Swal.fire(
            {
                title: "Consolidation",
                text: insurrerDescription + " - " + thirdPartyDesc,
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, Complete it!",
                closeOnConfirm: false,
            }).then((result) => {
                if (result.value) {

                    if (result.value) {

                        var params = encodeParameters("?contactId=" + contactID + "&trxid=" + tInssurredPartySelectedData.salesTrxId + "&businesslinecode=" + BusinessLineCode + "&productid=" + tInssurredPartySelectedData.insurer_Code + "&combination=" + tInssurredPartySelectedData.thirdPartyAdmin_Code);
                        window.location.href = "/Consolidation/Consolidation" + BusinessLineCode + "/" + params;
                    }
                }
            });

    } else {

        toastr.warning("Please Select an Insurer", "Select an Insurer");
    }
});


$('input[type=radio]').on('click', function () {
    // Get the ID of the selected radio button
    var selectedId = $(this).attr('id');

    // Check which radio button is selected and log the result
    if (selectedId === 'AgeCalculationYear') {
        $(".fulldate").hide();
        $("#AgeCalculationYear").val("true");
        $("#AgeCalculationFullDate").val("false");
        $("#AgeCalculationStartDate").attr("required", false);
    } else if (selectedId === 'AgeCalculationFullDate') {
        $(".fulldate").show();
        $("#AgeCalculationYear").val("false");
        $("#AgeCalculationFullDate").val("true");
        $("#AgeCalculationStartDate").attr("required", true);
    }
});

function step5Submit(formData) {
    var obj = {};
    obj.RecId = tInssurredPartySelectedData.recId;
    obj.CommisinOnGPPer = $("#CommisinOnGPPer").val();
    obj.AdminFeesAmount = $("#AdminFeesAmount").val();
    obj.CostOfPolicyPer = $("#CostOfPolicyPer").val();
    obj.CostOfPolicyAmount = $("#CostOfPolicyAmount").val();
    obj.FixedTaxesAmount = $("#FixedTaxesAmount").val();
    obj.FixedTaxesPer = $("#FixedTaxesPer").val();
    obj.VATPer = $("#VATPer").val();
    obj.AgeCalculationFullDate = $("#AgeCalculationFullDate").val();
    obj.AgeCalculationStartDate = $("#AgeCalculationStartDate").val();
    obj.AgeCalculationYear = $("#AgeCalculationYear").val();
    obj.salesTransactionDetailsPrices = tStep5Table.rows().data().toArray().map(obj => ({ ...obj, SalesTrxDetailsId: tInssurredPartySelectedData.recId }));
    formData.append('slip', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Slip/SalesTransactionBL321110DetailsPricesNewRec',
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
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '200') {
                toastr.success("", "Saved");
                // Filter out the objects with the specified ID
                var filtereddetailsPrices = detailsPrices.filter(function (x) {
                    return x.salesTrxDetailsId !== tInssurredPartySelectedData.recId;
                });
                detailsPrices = filtereddetailsPrices;
                detailsPrices = detailsPrices.concat(tStep5Table.rows().data().toArray());
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].slip4BL321110 = tStep4Table.rows().data().toArray();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].recId = tInssurredPartySelectedData.recId;
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].commisinOnGPPer = $("#CommisinOnGPPer").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].adminFeesAmount = $("#AdminFeesAmount").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].costOfPolicyPer = $("#CostOfPolicyPer").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].costOfPolicyAmount = $("#CostOfPolicyAmount").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].fixedTaxesAmount = $("#FixedTaxesAmount").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].fixedTaxesPer = $("#FixedTaxesPer").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].vatPer = $("#VATPer").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].ageCalculationFullDate = $("#AgeCalculationFullDate").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].ageCalculationStartDate = $("#AgeCalculationStartDate").val();
                details.filter(x => x.recId == tInssurredPartySelectedData.recId)[0].ageCalculationYear = $("#AgeCalculationYear").val();
                //detailsPrices.forEach((price, index) => {
                //    const matchingIndex = tStep5Table.rows().data().toArray().findIndex(item => item.salesTrxDetailsId === price.salesTrxDetailsId);
                //    if (matchingIndex !== -1) {
                //        // Replace the item in detailsPrices with the corresponding item from anotherList
                //        detailsPrices[index] = tStep5Table.rows().data().toArray()[matchingIndex];
                //    }
                //});
                //var filteredAnotherList = tStep5Table.rows().data().toArray();
                //var removedItems = detailsPrices.filter(x => x.salesTrxDetailsId == tInssurredPartySelectedData.recId);
                //detailsPrices.filter(x => x.salesTrxDetailsId == tInssurredPartySelectedData.recId).map((price, index) => {
                //        return filteredAnotherList[index];
                //});
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error");
            hideLoading();
        }
    });
}
