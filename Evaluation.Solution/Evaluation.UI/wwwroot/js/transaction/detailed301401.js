$('#tableDashboardShort').DataTable({
    data: shortlist,
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
        { data: 'combination' },
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
            } },
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
            data: 'total',
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
            data: 'totalNet',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
},
        {
            data: 'features', render: function (data, type, row) {
                if (type === 'display') {
                    data = '<a href="#">' + data + '</a>';
                }
                return data;
            }, width: '30%' }
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
        { data: 'combination' },
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
            data: 'total',
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
            data: 'totalNet',
            render: function (data, type, row) {
                if (type === 'display') {

                    return parseFloat(data).toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
                }
                return data;
            }
        },
        {
            data: 'features', render: function (data, type, row) {
                if (type === 'display') {
                    data = '<a href="#">' + data + '</a>';
                }
                return data;
            }, width: '30%'}
    ],
});
$('#tableDashboardShort tbody').on('click', 'td:last-child', function () {
    var rowdata = $('#tableDashboardShort').DataTable().row($(this).closest('tr')).data();
    getBenifitsModal(rowdata);

});
$('#tableDashboardLong tbody').on('click', 'td:last-child', function () {
    var rowdata = $('#tableDashboardLong').DataTable().row($(this).closest('tr')).data();
    getBenifitsModal(rowdata);

});
$("#btnDashboard").click(function () {
    dashboardRedirect();
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
    formData.append('trxID', $("#SalestransactionID").val());
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
