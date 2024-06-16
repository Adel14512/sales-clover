$('#tableDashboardShort').DataTable({
    data: shortlist,
    responsive: true,
    autoWidth: true,
    columns: [
        {
            data: null,
            render: function (data, type, row) {
                var html = '<input type="checkbox" name="checkmeSQ" value="' + row.salesTransactionId + '" data-businesslinecode="' + row.businessLineCode + '" data-productid="' + row.productId + '" data-combination="' + row.combination + '" class="checkmeSQ" data-cqurl="' + row.cqurl + '" onclick="selectOnlyOne(this)" />';
                return html;
            }
        },
        // { data: 'familyId' },
        { data: 'insurred' },
        //{ data: 'productId' },
        //{ data: 'classId' },
        { data: 'insurerProduct' },
        {
            data: 'combination'
        },
        { data: 'memberPerFamily' },

        {
            data: 'ip',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'amb',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'pm',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'dv',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'cp',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        { data: 'af' },
        {
            data: 'total',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'features',
            render: function (data, type, row) {
                if (type === 'display') {
                    data = '<a href="#">' + data + '</a>';
                }
                return data;
            }
        }
    ],
});
$('#tableDashboardLong').DataTable({
    data: longlist,
    responsive: true,
    autoWidth: false,
    columns: [
        {
            data: null,
            render: function (data, type, row) {
                var html = '<input type="checkbox" name="checkmeSQ" value="' + row.salesTransactionId + '" data-businesslinecode="' + row.businessLineCode + '" data-productid="' + row.productId + '" data-combination="' + row.combination + '" class="checkmeSQ" data-cqurl="' + row.cqurl + '" onclick="selectOnlyOne(this)" />';
                return html;
            }
        },
        // { data: 'familyId' },
        { data: 'insurred' },
        //{ data: 'productId' },
        { data: 'insurerProduct' },
        {
            data: 'combination'
        },
        { data: 'memberPerFamily' },

        {
            data: 'ip',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'amb',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'pm',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'dv',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'cp',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'af',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'total',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'features',
            render: function (data, type, row) {
                if (type === 'display') {
                    data = '<a href="#">' + data + '</a>';
                }
                return data;
            },
            width: '30%'
        }
    ],
});
//// Add a click event listener to the "features" cell
//$('#tableDashboardShort tbody').on('click', 'td[data-column="features"]', function () {
$('#tableDashboardShort tbody').on('click', 'td:last-child', function () {
    var rowdata = $('#tableDashboardShort').DataTable().row($(this).closest('tr')).data();
    getBenifitsModal(rowdata);

});
$('#tableDashboardLong tbody').on('click', 'td:last-child', function () {
    var rowdata = $('#tableDashboardLong').DataTable().row($(this).closest('tr')).data();
    getBenifitsModal(rowdata);

});

// your custom function to open the modal and handle the data

$("#btnDashboard").click(function () {
    var urlencode = encodeParameters("?contactid=" + $("#ContactId").val());
    window.location.href = "../../transaction/Dashboard/" + urlencode;
});
$("#btnExportToExcel").click(function () {
    var formData = new FormData();

    formData.append('businesscode', $("#BusinessLineCode").val());
    formData.append('contactid', $("#ContactId").val());
    formData.append('type', JSON.stringify("SL"));
    formData.append('shortlist', JSON.stringify(shortlist));
    formData.append('longlist', JSON.stringify(longlist));
    formData.append('headerlist', JSON.stringify(headerlist));
    $.ajax({
        type: 'POST',
        url: '/ExcelImport/ExportExcelTransactionDetailed',
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
$("#btnSlip").click(function () {
    var formData = new FormData();

    formData.append('businesscode', JSON.stringify($("#BusinessLineCode").val()));
    formData.append('salestransactionId', JSON.stringify($("#SalestransactionID").val()));
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
$("#btnQuotation").click(function () {
    var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + $("#SalestransactionID").val() + "&businesslinecode=" + $("#BusinessLineCode").val());
    excelOrPdfExport($("#PageType").val(), $("#ContactId").val(), $("#BusinessLineCode").val(), params, false, 'CQ');
});
$("#btnOfficialQuote").click(function () {
    var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + $("#SalestransactionID").val() + "&businesslinecode=" + $("#BusinessLineCode").val());
    excelOrPdfExport($("#PageType").val(), $("#ContactId").val(), $("#BusinessLineCode").val(), params, true, 'CQOFF');
});
function excelOrPdfExport(pageaction, contactID, businessCode, params, ispdf, type) {

    var formData = new FormData();

    formData.append('params', JSON.stringify(params));
    formData.append('businesscode', businessCode);
    formData.append('contactid', contactID);
    formData.append('ispdf', ispdf);
    formData.append('businessPage', JSON.stringify(pageaction));
    formData.append('type', JSON.stringify(type));
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
}
$("#btnConsolidation").click(function (e) {

    var checkboxes = document.getElementsByName('checkmeSQ');
    var selectedValue = '';
    var urlCQ = '';
    var busid = '';
    var combination = '';
    var productid = '';
    checkboxes.forEach(function (currentCheckbox) {
        if (currentCheckbox.checked) {
            selectedValue = currentCheckbox.value;
            urlCQ = currentCheckbox.dataset.cqurl;
            busid = currentCheckbox.dataset.businesslinecode;
            productid = currentCheckbox.dataset.productid;
            combination = currentCheckbox.dataset.combination;
        }

    });
    if (selectedValue != '') {

        var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + + $("#SalestransactionID").val() + "&businesslinecode=" + $("#BusinessLineCode").val() + "&productid=" + productid + "&combination=" + combination);
        window.location.href = "/Consolidation/Consolidation" + $("#BusinessLineCode").val() + "/" + params;
    } else {
        toastr.warning("Please Select a Ticket", "Select a Ticket");
    }
});

function checkIdTabIsShort() {
    // Get all tab links
    const tabLinks = document.querySelectorAll('.nav-link');
    var result = false;
    // Loop through each tab link
    tabLinks.forEach(tabLink => {
        // Check if the tab link has the 'active' class
        if (tabLink.classList.contains('active')) {
            // Get the href attribute to determine which tab it is
            const tabId = tabLink.getAttribute('href');
            console.log("Current active tab:", tabId);
            if (tabId == "#shortlist") {
                result= true;
            } else {
                result= false;
            }
           
            // Now you have the ID of the active tab
            // You can do whatever you want with it, like showing/hiding content or applying styles
        }
    });
    return result;
}
$("#btnEditAf1").click(function () {
    var urlparams = "?contactId=" + $("#ContactId").val() + "&trx=" + $("#SalestransactionID").val() + "&businesslinecode=" + $("#BusinessLineCode").val();
    var params = encodeParameters(urlparams);
    window.location.href ="/Business/AF1_8/" + params;
})