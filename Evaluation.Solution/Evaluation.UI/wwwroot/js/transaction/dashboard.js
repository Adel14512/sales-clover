function redirectAction(e) {
    var id = e.dataset.id;
    var trnxid = e.dataset.transactionid;
    var typeid = e.dataset.typeid;
    var urlAf1 = e.dataset.afurl;
    var urlCQ = e.dataset.cqurl;
    var busid = e.dataset.businesslinecode;
    var url = "";
    var urlparams = "?contactId=" + $("#ContactId").val() + "&trx=" + trnxid + "&businesslinecode=" + busid;
   // if (typeid == 1) {
        url = urlAf1;
   // } else {
    //    url = urlCQ;
    //}
    var params = encodeParameters(urlparams);
    window.location.href = url + "/" + params;
}
function redirectToCQ(e) {
    var trnxid = e.dataset.transactionid;
    var busid = e.dataset.businesslinecode;
    var urlCQ = e.dataset.cqurl;
    var urlparams = "?contactId=" + $("#ContactId").val() + "&trx=" + trnxid + "&businesslinecode=" + busid + "&cqurl=" + urlCQ;
    var params = encodeParameters(urlparams);
    window.location.href = "/Transaction/Detailed" + busid + "/" + params;
    //window.location.href = "/ComparitiveQuotation/" + urlCQ + "/" + params;
}
function downloadExcel(e) {
    var trnxid = e.dataset.transactionid;
    var busid = e.dataset.businesslinecode;
    var urlCQ = e.dataset.cqurl;

    var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + trnxid + "&businesslinecode=" + busid);
    excelOrPdfExport(urlCQ, $("#ContactId").val(), busid, params, false);
    //  var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + trnxid + "&businesslinecode=" + busid);
    //  window.location.href = "/ComparitiveQuotation/" + urlCQ + "/" + params;
}
function downloadPdf(e) {
    var trnxid = e.dataset.transactionid;
    var busid = e.dataset.businesslinecode;
    var urlCQ = e.dataset.cqurl;

    var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + trnxid + "&businesslinecode=" + busid);
    excelOrPdfExport(urlCQ, $("#ContactId").val(), busid, params, true);
}
function transactionComplete(e) {
    var trnxid = e.dataset.transactionid;
    var buscode = e.dataset.businesslinecode;
    var parentid = e.dataset.parentsalestransacrionid;
    var ticketid = e.dataset.ticketid;
    var ticketCode = e.dataset.ticketcode;
    var salesTransactionId = e.dataset.salestransactionid;

    Swal.fire(
        {
            title: "Sure you want to the move to next step?",
            text: "You will complete this transaction",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, Complete it!",
            closeOnConfirm: false,
        }).then((result) => {
            if (result.value) {

                if (result.value) {
                    var formData = new FormData();
                    var objBusinessLineDuplication = {};
                    var obj = {};
                    objBusinessLineDuplication.TicketId = ticketid;
                    objBusinessLineDuplication.TicketCode = ticketCode;
                    objBusinessLineDuplication.BusinessLineCode = buscode;
                    objBusinessLineDuplication.SalesTransactionId = salesTransactionId;
                    objBusinessLineDuplication.ParentSalesTransactionId = parentid;

                    obj.TicketDetails = objBusinessLineDuplication;

                    formData.append('data', JSON.stringify(obj));
                    $.ajax({
                        type: 'POST',
                        url: '/Transaction/MoveToNextStep',
                        data: formData,
                        processData: false,
                        contentType: false,
                        beforeSend: function (xhr) {
                            showLoading();
                        },
                        success: function (data, status, xhr) {
                            hideLoading();
                            if (data.webResponseCommon.returnCode == '202') {
                                window.location.href = window.location.href.replace("#", "");
                                toastr.success("Added!", "New Version");
                            } else {
                                toastr.error(data.webResponseCommon.returnMessage, "Error");
                            }

                        },
                        error: function (xhr, status, error) {
                            toastr.error(error, "Error while Move to Next Step");
                            hideLoading();
                        }
                    });

                }
            }
        });
}
function redirectToDetails(e) {

}
function copyTransaction(e) {
    var trnxid = e.dataset.transactionid;
    var buscode = e.dataset.businesslinecode;
    var parentid = e.dataset.parentsalestransacrionid;
    var ticketid = e.dataset.ticketid;
    var ticketCode = e.dataset.ticketcode;
    var salesTransactionId = e.dataset.salestransactionid;
    Swal.fire(
        {
            title: "Duplicate Sales transactions ?",
            text: "Are you Sure ?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, Duplicated it!",
            closeOnConfirm: false,
        }).then((result) => {
            if (result.value) {
                var formData = new FormData();
                var objBusinessLineDuplication = {};
                var obj = {};
                objBusinessLineDuplication.TicketId = ticketid;
                objBusinessLineDuplication.TicketCode = ticketCode;
                objBusinessLineDuplication.BusinessLineCode = buscode;
                objBusinessLineDuplication.SalesTransactionId = salesTransactionId;
                objBusinessLineDuplication.ParentSalesTransactionId = parentid;

                obj.BusinessLineDuplication = objBusinessLineDuplication;

                formData.append('data', JSON.stringify(obj));
                $.ajax({
                    type: 'POST',
                    url: '/Transaction/DuplicateTransaction',
                    data: formData,
                    processData: false,
                    contentType: false,
                    beforeSend: function (xhr) {
                        showLoading();
                    },
                    success: function (data, status, xhr) {
                        hideLoading();
                        if (data.webResponseCommon.returnCode == '201') {
                            window.location.href = window.location.href.replace("#", "");
                        } else {
                            toastr.error(data.webResponseCommon.returnMessage, "Error");
                        }

                    },
                    error: function (xhr, status, error) {
                        toastr.error(error, "Error while duplicating");
                        hideLoading();
                    }
                });

            }
        });
}
$("#btnTransaction").click(function (e) {
    var params = encodeParameters("?contactId=" + $("#ContactId").val());
    window.location.href = "/transaction/create/" + params;
})
$("#btnDashboardDetails").click(function (e) {
    var params = encodeParameters("?contactId=" + $("#ContactId").val());
    window.location.href = "/transaction/DashboardDetails/" + params;
})
$("#btnCqscreen").click(function (e) {

    var checkboxes = document.getElementsByName('checkmeSQ');
    var selectedValue = '';
    var urlCQ = '';
    var busid = '';
    checkboxes.forEach(function (currentCheckbox) {
        if (currentCheckbox.checked) {
            selectedValue = currentCheckbox.value;
            urlCQ = currentCheckbox.dataset.cqurl;
            busid = currentCheckbox.dataset.businesslinecode;
        }

    });
    if (selectedValue != '') {

        var params = encodeParameters("?contactId=" + $("#ContactId").val() + "&trxid=" + selectedValue + "&businesslinecode=" + busid);
        window.location.href = "/ComparitiveQuotation/" + urlCQ + "/" + params;
    } else {
        toastr.warning("Please Select a Ticket", "Select a Ticket");
    }
})
var contextIdCount = 0;
var table = $('#tableDashboard').DataTable({
    data: salesTransaction,
    responsive: true,
    autoWidth: true,
    columns: [
        {
            data: 'ticketCode',
            render: function (data, type, row) {
                if (row.detailStatusId == 1) {
                    return data;
                } else {
                    return '<a  href="#"  title="Display Details Quotation " href="#" onclick="redirectToCQ(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-cqurl="' + row.cqurl + '"  data-afurl="' + row.aF1URL + '" data-transactionid="' + row.salesTransactionId + '" data-typeid="' + row.detailStatusId + '">' + data + '</a>';
                }
               
            }
        },
        {
            data: 'openDate',
            render: function (data, type, row) {
                return data.split("T")[0];
            }
        },
        { data: 'businessLine' },
        { data: 'headerStatus' },
        { data: 'detailStatus' },
        {
            data: 'aF1Resume',
            render: function (data, type, row) {
                    if (row.detailStatusId != 3) {
                        return '<a  href="#"  onclick="redirectAction(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-transactionid="' + row.salesTransactionId + '" data-afurl="' + row.aF1URL + '" data-cqurl="' + row.cqurl + '" data-typeid="' + row.detailStatusId + '" title="Edit Current Sales Transaction">' + data + '</a>';
                    } else {
                        return  data;
                    }
            }
},
     //   { data: 'policyHolder' },
        {
            data: null,
            render: function (data, type, row) {

                //var html = '<div class="btn-group-sm" role="group" aria-label="First group">'
                //    + '     <button type="button" class="btn btn-secondary" onclick="redirectAction(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-transactionid="' + row.salesTransactionId + '" data-afurl="' + row.aF1URL + '" data-cqurl="' + row.cqurl + '" data-typeid="' + row.detailStatusId + '" title="Edit Current Sales Transaction">       '
                //    + '         <i class="fas fa-edit"></i>                        '
                //    + '     </button>                                              '
                //    + '     <button type="button" class="btn btn-secondary" title="Move to next phase" href="#" onclick="transactionComplete(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '">       '
                //    + '         <i class="fas fa-check"></i>                       '
                //    + '     </button>                                              '
                //    + '     <button type="button" class="btn btn-secondary" title="Display Details Quotation " href="#" onclick="redirectToCQ(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '">       '
                //    + '         <i class="fas fa-eye"></i>                         '
                //    + '     </button>                                              '
                //    + '     <button type="button" class="btn btn-secondary"  title="Duplicate Current Sales Transaction" href="#" onclick="copyTransaction(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '">       '
                //    + '         <i class="fas fa-copy"></i>                        '
                //    + '     </button>                                              '
                //    + '     <button type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '">       '
                //    + '         <i class="fab fa-contao"></i>                      '
                //    + '     </button>                                              '

                //    + ' </div>';
                var isEditEnable = '', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '', isNextStepEnable = '';
                if (row.detailStatusId == 1) {
                    isEditEnable = '', isNextStepEnable = '', isDetailsEnable = 'disabled', isDuplicateEnable = 'disabled', isExcelPdfEnable = 'disabled', isExcelEnable = 'disabled', isOfficialEnable = 'disabled';
                } else if (row.detailStatusId == 2) {
                    isEditEnable = '', isNextStepEnable='', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '';
                } else if (row.detailStatusId == 3) {
                    isEditEnable = 'disabled', isNextStepEnable = 'disabled', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '';

                }
                var html = '    <div class="btn-group" role="group">'
                    + '       <button id="btnGroupVerticalDrop' + contextIdCount + '" type="button" class="btn btn-light-secondary text-secondary font-weight-medium dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">'
                    + '          <i class="fas fa-ellipsis-v"></i> '
                    + '       </button>'
                    + '       <div class="dropdown-menu" aria-labelledby="btnGroupVerticalDrop' + contextIdCount + '">'
                    + '           <a class="dropdown-item ' + isEditEnable +'" href="#" class="btn btn-secondary" onclick="redirectAction(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-transactionid="' + row.salesTransactionId + '" data-afurl="' + row.aF1URL + '" data-cqurl="' + row.cqurl + '" data-typeid="' + row.detailStatusId + '" title="Edit Current Sales Transaction"><i class="fas fa-eye"></i> Edit AF1</a>'
                    + '           <a class="dropdown-item ' + isNextStepEnable +'" href="#" type="button" class="btn btn-secondary" title="Move to next phase" href="#" onclick="transactionComplete(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-salestransactionid="' + row.salesTransactionId + '"  data-ticketid="' + row.recId + '"data-ticketcode="' + row.ticketCode + '" data-parentsalestransacrionid="' + row.parentSalesTransactionId + '"><i class="fas fa-check"></i> Next Step</a>'
                    + '           <a class="dropdown-item ' + isDetailsEnable +'" href="#" type="button" class="btn btn-secondary" title="Display Details Quotation " href="#" onclick="redirectToCQ(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-cqurl="' + row.cqurl + '"  data-afurl="' + row.aF1URL + '" data-transactionid="' + row.salesTransactionId + '" data-typeid="' + row.detailStatusId + '"><i class="fas fa-eye"></i> Details</a>'
                    + '           <a class="dropdown-item ' + isDuplicateEnable +'" href="#"  type="button" class="btn btn-secondary"  title="New Version Sales Transaction" href="#" onclick="copyTransaction(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-salestransactionid="' + row.salesTransactionId + '"  data-ticketid="' + row.recId + '"data-ticketcode="' + row.ticketCode + '" data-parentsalestransacrionid="' + row.parentSalesTransactionId + '" ><i class="fas fa-copy"></i> New Version</a>'

                    + '           <a class="dropdown-item ' + isExcelEnable +'"  type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '" onclick="downloadExcel(this)"><i class="fas fa-file-excel"></i> Print CQ Excel</a>'
                    + '           <a class="dropdown-item ' + isExcelPdfEnable +'"  type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '" onclick="downloadPdf(this)"><i class="fas fa-file-pdf"></i> Print CQ Pdf</a>'

                    + '       </div>'
                    + '   </div>';
                return html;
            }
        },

    ],
});
$("#btnDashboard").click(function () {
    var urlencode = encodeParameters("?contactid=" + $("#ContactId").val());
    window.location.href = "../../transaction/Dashboard/" + urlencode;
});

function excelOrPdfExport(pageaction, contactID, businessCode, params, ispdf) {

    var formData = new FormData();

    formData.append('params', JSON.stringify(params));
    formData.append('businesscode', businessCode);
    formData.append('contactid', contactID);
    formData.append('ispdf', ispdf);
    formData.append('businessPage', JSON.stringify(pageaction));
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
}