var params = decodeParameters(globalParam, 3);
const contactID = params[0];
const trxID = params[1];
//const rowMinRange = params[1];
//const rowMaxRange = params[2];
const BusinessLineCode = params[2];
$("#btnDashboard").click(function () {
    dashboardRedirect();
})
$('#tableCQDetails').DataTable({
    data: dataTableDataDetails,
    processing: true,
    searching: true,
    responsive: true,
    dom: "Bfrtip",
    buttons: ["excel"],
    language: {
        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
    },
    columns: [
        {
            data: null,
            render: function (data, type, row) {
                var html = '<input type="checkbox" name="checkmeSQ" value="' + row.salesTrxId + '" data-familyid="' + row.familyId + '" class="checkmeSQ" data-productid="' + row.productId + '" data-sheet="' + row.sheet + '" data-price="' + row.price + '" data-businessLinecode="' + row.businessLineCode + '" onclick="selectOnlyOne(this)" />';
                return html;
            }
        },
        {
            data: 'salesTrxId',
            visible: false
        },
        {
            data: 'familyId',
            width: "200px"
        },
        {
            data: 'insurred'
        },
        {
            data: 'aF1Age'
        },
        {
            data: 'relationCode'
        },
        {
            data: 'productId'
        },
        {
            data: 'insurerProduct'
        },
        {
            data: 'sheet'
        },
        {
            data: 'sectionName'
        },
        {
            data: 'combination'
        },
        {
            data: 'memberPerFamily'
        },
        {
            data: 'membersCount'
        },
        {
            data: 'price'
        },
        {
            data: 'costPolicy'
        },
        {
            data: 'adminFees'
        },
        {
            data: 'features'
        }
    ],
    columnDefs: [
        {
            targets: 0,
            responsivePriority: 1,
            className: 'dt-body-center',
            orderable: false,
            width: '40px'
        }
    ]
});

$('#tableCQSummary').DataTable({
    data: dataTableDataSummary,
    processing: true,
    searching: true,
    language: {
        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
    },
    dom: "Bfrtip",
    buttons: ["excel"],
    responsive: true,
    columns: [

        {
            data: 'familyId'
        },
        {
            data: 'insurred'
        },
        {
            data: 'productId'
        },
        {
            data: 'insurerProduct'
        },

        {
            data: 'sheet'
        },
        {
            data: 'sectionName'
        },
        {
            data: 'combination'
        },
        {
            data: 'memberPerFamily'
        },

        {
            data: 'price'
        },
        {
            data: 'costPolicy'
        },
        {
            data: 'adminFees'
        },
        {
            data: 'features'
        }

    ],
});
var keys = Object.keys(datapivot[0]);

var columns = keys.map(function (key) {
    return { title: key, data: key };
});
$('#tableCQPivot').DataTable({
    data: datapivot,
    processing: true,
    dom: "Bfrtip",
    buttons: ["excel"],
    responsive: true,
    searching: true,
    language: {
        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
    },
    columns: columns,
});
$(".buttons-excel").addClass("btn btn-primary mr-1");

//$("#tableCQDetails").resize()
//$("#tableCQSummary").resize()
//$("#tableCQPivot").resize()
var tables = [];
tables.push('#tableCQDetails');
tables.push('#tableCQSummary');
tables.push('#tableCQPivot');
// Show/hide tables when tabs are clicked
$('.nav-tabs').on('click', '.nav-link', function () {
    //  var target = $(this).find('a').attr('href');

    // Show the selected tab content
    //$('.tab-pane').hide();
    //$(target).show();

    // Trigger responsive reflow for the visible table
    var visibleTable = tables.find(function (table) {
        return $(table).is(':visible');
    });

    if (visibleTable) {
        $(visibleTable).DataTable().responsive.recalc();
    }
});

$("#btnSendEmailExcel").click(function () {
    var pageaction=window.location.pathname.split("/")[2]

    var formData = new FormData();
    formData.append('data', JSON.stringify(datapivot));
    formData.append('benefitList', JSON.stringify(dataBenefit));
    formData.append('billsList', JSON.stringify(dataBills));
    formData.append('cqheader', JSON.stringify(dataHeader));
    formData.append('cqcategory', JSON.stringify(dataCategory));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', contactID);
    formData.append('businessPage', JSON.stringify(pageaction));
    formData.append('ispdf', false);
    formData.append('type', JSON.stringify("CQ"));
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

var selectedValue = '';
var familyid = '';
var productid = '';
var price = '';
var busline = '';
var sheet = '';
$("#btnSpecial").click(function () {
    var checkboxes = document.getElementsByName('checkmeSQ');

    checkboxes.forEach(function (currentCheckbox) {
        if (currentCheckbox.checked) {
            selectedValue = currentCheckbox.value;
            familyid = currentCheckbox.dataset.familyid;
            productid = currentCheckbox.dataset.productid;
            price = currentCheckbox.dataset.price;
            busline = currentCheckbox.dataset.businessLinecode;
            sheet = currentCheckbox.dataset.sheet;
        }

    });
    if (selectedValue != '') {
        var obj = {};
        obj.SalesTrxId = selectedValue;
        obj.BusinessLineCode = BusinessLineCode;
        obj.ProductId = productid;
        obj.Sheet = sheet;
        //obj.DiscountPer = $('#txtPercentage').val();
        //obj.DiscountAmount = $('#txtPrice').val();
        var formData = new FormData();
        formData.append('data', JSON.stringify(obj));
        $.ajax({
            type: 'POST',
            url: '/ComparitiveQuotation/GetSpecialCondition',
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
                if (data.webResponseCommon.returnCode != "No content") {
                    $('#txtPercentage').val(data.specialCondition.discountPer);
                    if (data.specialCondition.discountAmount != 0) {
                        $('#txtPrice').val(data.specialCondition.discountAmount);
                    } else {
                        $('#txtPrice').val(price);
                    }
              
                }
                $('#myModal').modal('show');
            },
            error: function (xhr, status, error) {
                toastr.error(error, "Error ");
                hideLoading();
            }
        });
 
    } else {
        toastr.warning("Please Select a Transaction", "Select a Transaction");
    }
   
});
$("#btnCloseModel").click(function () {
    $('#myModal').modal('hide');
});

$("#btnSavePrice").click(function (e) {
    if ($('#txtPercentage').val() != null && $('#txtPrice').val() <= price) {
        var obj = {};
        obj.SalesTrxId = selectedValue;
        obj.BusinessLineCode = BusinessLineCode;
        obj.ProductId = productid;
        obj.Sheet = sheet;
        obj.DiscountPer = $('#txtPercentage').val();
        obj.DiscountAmount = $('#txtPrice').val();
        var formData = new FormData();
        formData.append('data', JSON.stringify(obj));
        $.ajax({
            type: 'POST',
            url: '/ComparitiveQuotation/InsertSpecialCondition',
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
                toastr.success("Saved!");
                window.location.href = window.location.href;
            },
            error: function (xhr, status, error) {
                toastr.error(error, "Error ");
                hideLoading();
            }
        });
    } else {
        toastr.warning("fix the prices", "Please Fix the input");
    }
    

})
// Get the input elements
const percentageInput = document.getElementById('txtPercentage');
const priceInput = document.getElementById('txtPrice');

// Listen for changes in the percentage input
percentageInput.addEventListener('input', function () {
    // Reset the price input value
    priceInput.value = price;
});

// Listen for changes in the price input
priceInput.addEventListener('input', function (e) {
    // Reset the percentage input value
    if (parseInt(e.currentTarget.value) > parseInt(price)) {
        e.currentTarget.value = price;
    }
    percentageInput.value = 0;
});