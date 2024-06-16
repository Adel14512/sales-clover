var table = $('#tTicketHistory').DataTable({
    data: [],
    processing: true,
    responsive: true,
    autoWidth: false,
    destroy: true,
    language: {
        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
    },
    columns: [
        { data: 'contact', title: 'Contact', width: '60px' },
        { data: 'ticketDetailsId', title: 'Ticket ID', width: '10px' },
        { data: 'openDate', title: 'OpenDate', width: '30px' },
        { data: 'businessLine', title: 'Business Line' },
        { data: 'detailStatus', title: 'Detail Status' },
        { data: 'tat', title: 'TAT' },
        { data: 'aF1Resume', title: 'Resume' },
        { data: 'createdBy', title: 'Created By' },
        {
            data: null,
            render: function (data, type, row) {
                var isEditEnable = '', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '', isNextStepEnable = '';
                if (row.detailStatusId == 1) {
                    isEditEnable = '', isNextStepEnable = '', isDetailsEnable = 'disabled', isDuplicateEnable = 'disabled', isExcelPdfEnable = 'disabled', isExcelEnable = 'disabled', isOfficialEnable = 'disabled';
                } else if (row.detailStatusId == 2) {
                    isEditEnable = '', isNextStepEnable = '', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '';
                } else if (row.detailStatusId == 3) {
                    isEditEnable = 'disabled', isNextStepEnable = 'disabled', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '';

                }
                var html = '    <div class="btn-group" role="group">'
                    + '       <button id="btnGroupVerticalDrop' + contextIdCount + '" type="button" class="btn btn-light-secondary text-secondary font-weight-medium dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">'
                    + '          <i class="fas fa-ellipsis-v"></i> '
                    + '       </button>'
                    + '       <div class="dropdown-menu" aria-labelledby="btnGroupVerticalDrop' + contextIdCount + '">'
                    + '           <a class="dropdown-item ' + isEditEnable + '" href="#" class="btn btn-secondary" onclick="redirectAction(this)" data-id="' + row.recId + '" data-contactid="' + row.contactId + '" data-businesslinecode="' + row.businessLineCode + '" data-transactionid="' + row.salesTransactionId + '" data-afurl="' + row.aF1URL + '" data-cqurl="' + row.cqurl + '" data-typeid="' + row.detailStatusId + '" title="Edit Current Sales Transaction"><i class="fas fa-eye"></i> Edit AF1</a>'
                    + '           <a class="dropdown-item ' + isNextStepEnable + '" href="#" type="button" class="btn btn-secondary" title="Move to next phase" href="#" onclick="transactionComplete(this)" data-contactid="' + row.contactId + '" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-salestransactionid="' + row.salesTransactionId + '"  data-ticketid="' + row.recId + '"data-ticketcode="' + row.ticketCode + '" data-parentsalestransacrionid="' + row.parentSalesTransactionId + '"><i class="fas fa-check"></i> Next Step</a>'
                    + '           <a class="dropdown-item ' + isDetailsEnable + '" href="#" type="button" class="btn btn-secondary" title="Display Details Quotation " href="#" onclick="redirectToCQ(this)" data-contactid="' + row.contactId + '" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-cqurl="' + row.cqurl + '"  data-afurl="' + row.aF1URL + '" data-transactionid="' + row.salesTransactionId + '" data-typeid="' + row.detailStatusId + '"><i class="fas fa-eye"></i> Details</a>'
                    + '           <a class="dropdown-item ' + isDuplicateEnable + '" href="#"  type="button" class="btn btn-secondary"  title="New Version Sales Transaction" href="#" onclick="copyTransaction(this)" data-contactid="' + row.contactId + '" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-salestransactionid="' + row.salesTransactionId + '"  data-ticketid="' + row.recId + '"data-ticketcode="' + row.ticketCode + '" data-parentsalestransacrionid="' + row.parentSalesTransactionId + '" ><i class="fas fa-copy"></i> New Version</a>'

                    + '           <a class="dropdown-item ' + isExcelEnable + '"  type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-contactid="' + row.contactId + '" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '" onclick="downloadExcel(this)"><i class="fas fa-file-excel"></i> Print CQ Excel</a>'
                    + '           <a class="dropdown-item ' + isExcelPdfEnable + '"  type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-contactid="' + row.contactId + '" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '" onclick="downloadPdf(this)"><i class="fas fa-file-pdf"></i> Print CQ Pdf</a>'

                    + '       </div>'
                    + '   </div>';
                return html;
            }
        }
    ],
    columnDefs: columnDefs,
});
$(document).ready(function () {
    $("#formSearch").on("blur", "input", function (event) {
        search();
    });

    //var table = $('#tTicketHistory').DataTable({
    //    searching: false,
    //    destroy: true,
    //});


});
var contextIdCount = 0;
function search() {

    var formBody = new FormData();
    var obj = {};
    obj.NbrDays = $("#txtNbrofDays").val();
    formBody.append("nbr", JSON.stringify(obj));
    $.ajax({
        url: "../DashBoard/SearchTicketHistory",
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
            if (data != null) {
                //Destroy
                $('#tTicketHistory').DataTable().destroy();
                //$('#tTicketHistory').DataTable();
                // initialize DataTables with the data
               var table = $('#tTicketHistory').DataTable({
                    data: data,
                    processing: true,
                    responsive: true,
                    autoWidth: false,
                    destroy: true,
                    language: {
                        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
                    },
                    columns: [
                        { data: 'contact', title: 'Contact', width: '60px' },
                        { data: 'ticketDetailsId', title: 'Ticket ID', width: '10px' },
                        { data: 'openDate', title: 'OpenDate', width: '30px' },
                        {
                            data: 'businessLine', title: 'Business Line'  ,  render: function (data, type, row) {
                                if (row.detailStatusId == 1) {
                                    return data;
                                } else {
                                    return '<a  href="#"  title="Display Details Quotation " href="#" onclick="redirectToCQ(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-contactid="' + row.contactId + '" data-cqurl="' + row.cqurl + '"  data-afurl="' + row.aF1URL + '" data-transactionid="' + row.salesTransactionId + '" data-typeid="' + row.detailStatusId + '">' + data + '</a>';
                                }

                            }
},
                        { data: 'detailStatus', title: 'Detail Status' },
                        { data: 'tat', title: 'TAT' },
                        {
                            data: 'aF1Resume', title: 'Resume'   ,render: function (data, type, row) {
                                if (row.detailStatusId != 3) {
                                    return '<a  href="#"  onclick="redirectAction(this)" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-contactid="' + row.contactId + '" data-transactionid="' + row.salesTransactionId + '" data-afurl="' + row.aF1URL + '" data-cqurl="' + row.cqurl + '" data-typeid="' + row.detailStatusId + '" title="Edit Current Sales Transaction">' + data + '</a>';
                                } else {
                                    return data;
                                }
                            }
},
                        { data: 'createdBy', title: 'Created By' },
                        {
                            data: null,
                            render: function (data, type, row) {
                                var isEditEnable = '', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '', isNextStepEnable = '';
                                if (row.detailStatusId == 1) {
                                    isEditEnable = '', isNextStepEnable = '', isDetailsEnable = 'disabled', isDuplicateEnable = 'disabled', isExcelPdfEnable = 'disabled', isExcelEnable = 'disabled', isOfficialEnable = 'disabled';
                                } else if (row.detailStatusId == 2) {
                                    isEditEnable = '', isNextStepEnable = '', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '';
                                } else if (row.detailStatusId == 3) {
                                    isEditEnable = 'disabled', isNextStepEnable = 'disabled', isDetailsEnable = '', isDuplicateEnable = '', isExcelPdfEnable = '', isExcelEnable = '', isOfficialEnable = '';

                                }
                                var html = '    <div class="btn-group" role="group">'
                                    + '       <button id="btnGroupVerticalDrop' + contextIdCount + '" type="button" class="btn btn-light-secondary text-secondary font-weight-medium dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">'
                                    + '          <i class="fas fa-ellipsis-v"></i> '
                                    + '       </button>'
                                    + '       <div class="dropdown-menu" aria-labelledby="btnGroupVerticalDrop' + contextIdCount + '">'
                                    + '           <a class="dropdown-item ' + isEditEnable + '" href="#" class="btn btn-secondary" onclick="redirectAction(this)" data-id="' + row.recId + '" data-contactid="' + row.contactId + '" data-businesslinecode="' + row.businessLineCode + '" data-transactionid="' + row.salesTransactionId + '" data-afurl="' + row.aF1URL + '" data-cqurl="' + row.cqurl + '" data-typeid="' + row.detailStatusId + '" title="Edit Current Sales Transaction"><i class="fas fa-eye"></i> Edit AF1</a>'
                                    + '           <a class="dropdown-item ' + isNextStepEnable + '" href="#" type="button" class="btn btn-secondary" title="Move to next phase" href="#" onclick="transactionComplete(this)" data-contactid="' + row.contactId + '" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-salestransactionid="' + row.salesTransactionId + '"  data-ticketid="' + row.recId + '"data-ticketcode="' + row.ticketCode + '" data-parentsalestransacrionid="' + row.parentSalesTransactionId + '"><i class="fas fa-check"></i> Next Step</a>'
                                    + '           <a class="dropdown-item ' + isDetailsEnable + '" href="#" type="button" class="btn btn-secondary" title="Display Details Quotation " href="#" onclick="redirectToCQ(this)" data-contactid="' + row.contactId + '" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '" data-cqurl="' + row.cqurl + '"  data-afurl="' + row.aF1URL + '" data-transactionid="' + row.salesTransactionId + '" data-typeid="' + row.detailStatusId + '"><i class="fas fa-eye"></i> Details</a>'
                                    + '           <a class="dropdown-item ' + isDuplicateEnable + '" href="#"  type="button" class="btn btn-secondary"  title="New Version Sales Transaction" href="#" onclick="copyTransaction(this)" data-contactid="' + row.contactId + '" data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-salestransactionid="' + row.salesTransactionId + '"  data-ticketid="' + row.recId + '"data-ticketcode="' + row.ticketCode + '" data-parentsalestransacrionid="' + row.parentSalesTransactionId + '" ><i class="fas fa-copy"></i> New Version</a>'

                                    + '           <a class="dropdown-item ' + isExcelEnable + '"  type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-contactid="' + row.contactId + '" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '" onclick="downloadExcel(this)"><i class="fas fa-file-excel"></i> Print CQ Excel</a>'
                                    + '           <a class="dropdown-item ' + isExcelPdfEnable + '"  type="button" class="btn btn-secondary" title="Print Comparative quotation" href="#" data-contactid="' + row.contactId + '" data-cqurl="' + row.cqurl + '" data-afurl="' + row.aF1URL + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLineCode + '"  data-transactionid="' + row.salesTransactionId + '" onclick="downloadPdf(this)"><i class="fas fa-file-pdf"></i> Print CQ Pdf</a>'

                                    + '       </div>'
                                    + '   </div>';
                                contextIdCount++;
                                return html;
                            }
                        }
                    ],
                    columnDefs: columnDefs,
                });
            }
        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }
    });
}
var columnConfig = [
    { data: 'contact', title: 'Contact', width: '60px' },
    { data: 'ticketDetailsId', title: 'Ticket ID', width: '10px' },
    { data: 'openDate', title: 'OpenDate',width: '30px' },
    { data: 'businessLine', title: 'Business Line' },
    { data: 'detailStatus', title: 'Detail Status' },
    { data: 'tat', title: 'TAT' },
    { data: 'af1Resume', title: 'Resume' },
    { data: 'createdBy', title: 'Created By' },
  
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


function redirectAction(e) {
    var id = e.dataset.id;
    var trnxid = e.dataset.transactionid;
    var urlAf1 = e.dataset.afurl;
    var busid = e.dataset.businesslinecode;
    var contactid = e.dataset.contactid;
    var url = "";
    var urlparams = "?contactId=" + contactid + "&trx=" + trnxid + "&businesslinecode=" + busid;
    url = urlAf1;
    var params = encodeParameters(urlparams);
    window.location.href = url + "/" + params;
}
function redirectToCQ(e) {
    var trnxid = e.dataset.transactionid;
    var busid = e.dataset.businesslinecode;
    var urlCQ = e.dataset.cqurl;
    var contactid = e.dataset.contactid;
    var urlparams = "?contactId=" + contactid + "&trx=" + trnxid + "&businesslinecode=" + busid + "&cqurl=" + urlCQ;
    var params = encodeParameters(urlparams);
    window.location.href = "/Transaction/Detailed" + busid + "/" + params;
}
function transactionComplete(e) {
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
function copyTransaction(e) {
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