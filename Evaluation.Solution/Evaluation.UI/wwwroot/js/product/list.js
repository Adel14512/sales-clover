//var params = decodeParameters(globalParam, 1);
var showisactive = new URLSearchParams(window.location.search).get("isactive");
function getFilenameFromContentDispositionHeader(contentDisposition) {
    var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
    var matches = filenameRegex.exec(contentDisposition);
    if (matches != null && matches[1]) {
        return decodeURIComponent(matches[1].replace(/['"]/g, ''));
    } else {
        return 'unknown';
    }
}

$("#btnCreate").click(function () {
    window.location.href = "../../Product/Create/";
});
var columnConfig = [
    { data: 'recId', title: 'Product ID' },
    { data: 'productCategory', title: 'Branch Category' },
    { data: 'productClass', title: 'Branch Class' },
    { data: 'insurer', title: 'Insurer' },
    { data: 'productName', title: 'Product Name' },
    { data: 'thirdPartyAdmin', title: 'Third Party Admin' },
    { data: 'currency', title: 'Currency' },
    { data: 'creationDate', title: 'Creation Date' },
    { data: 'activationDate', title: 'Activation Date' },
    {
        data: 'recId', title: 'Actions'

    }
];

var columnDefs = columnConfig.map(function (column, index) {
    return {
        targets: index,
        data: column.data,
        title: column.title,
        width: column.width,
        createdCell: function (cell, cellData) {
            if (column.data != null) {
                var attributeName = 'data-' + column.data.toLowerCase();
                $(cell).attr(attributeName, cellData);
            }

        }
    };
});
var table = $('#tableProducts').DataTable({
    data: datatablelist,
    responsive: true,
    autoWidth: false,
    columns: [
        { data: 'recId', title: 'ID',width: "5%" },
        { data: 'productCategory', title: 'Branch Category' },
        { data: 'productClass', title: 'Branch Class' },
        { data: 'insurer', title: 'Insurer' ,width:"20%"},
        { data: 'productName', title: 'Name' },
        { data: 'thirdPartyAdmin', title: 'Third Party Admin' },
        { data: 'currency', title: 'Currency' },

        {
            data: 'creationDate', title: 'Creation Date', render: function (data, type, row) {
                return data.split("T")[0];
            }
        },
        {
            data: 'activationDate', title: 'Activation Date', render: function (data, type, row) {
                return data.split("T")[0];
            }
        },
        {
            data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                var params = encodeParameters("?id=" + row.recId);
                var html = '<a href="../Product/Edit/' + params + '"><i class="fas fa-edit"></i></a> ';
                if (row.isActive) {
                    html += ' <a onclick="rowActiveInActive(this)" data-id="' + row.recId + '" title="Active"><i class="fas fa-eye"></i></a>';
                } else {

                    html += ' <a  onclick="rowActiveInActive(this)"  data-id="' + row.recId + '" title="Not Active"> <i class="fas fa-eye-slash"></i></a>';
                }
                //if (row.isComplete) {
                //    html += ' <a onclick="rowComplete(this)" data-id="' + row.recId + '" title="Active"><i class="fas fa-calendar-check"></i></a>';
                //} else {

                //    html += ' <a  onclick="rowComplete(this)"  data-id="' + row.recId + '" title="Not Active"> <i class="fas fa-calendar-times"></i></a>';
                //}
                return html;
            }
        }
    ],
    columnDefs: columnDefs,
    initComplete: function () {
        this.api().columns(2).every(function () {
            var column = this;
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
                select.append('<option value="' + d + '">' + d + '</option>')
            });
        }),
        this.api().columns(3).every(function () {
            var column = this;
            var select = $('<select class="select2 form-select"><option value="">---Select---</option></select>\n')
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
                select.append('<option value="' + d + '">' + d + '</option>')
            });
        }),
        this.api().columns(5).every(function () {
            var column = this;
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
                select.append('<option value="' + d + '">' + d + '</option>')
            });
        });
    }
});

$("#btnSendEmailExcel").click(function () {


    var formData = new FormData();
    formData.append('data', JSON.stringify(datatablelist));
    $.ajax({
        type: 'POST',
        url: '/ExcelImport/ExportExcelProduct',
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
if (showisactive == "1") {
    $("#toggleShowActive").text("Show InActive");
    $("#toggleShowActive").addClass("activebtn");
} else {
    $("#toggleShowActive").text("Show Active");
    $("#toggleShowActive").addClass("inactivebtn");

}
document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("toggleShowActive");

    button.addEventListener("click", function () {
        if (button.classList.contains("activebtn")) {
            button.classList.remove("activebtn");
            button.classList.add("inactivebtn");
            button.textContent = "Show Active";
            window.location.href = "../Product/Index?isactive=0";
        } else {
            button.classList.remove("inactivebtn");
            button.classList.add("activebtn");
            button.textContent = "Show InActive";
            window.location.href = "../Product/Index?isactive=1";
        }
    });
});

function rowActiveInActive(sender) {
    var icon = sender.children[0]
    var obj = {};
    obj.ProductId = sender.dataset.id;
    var msgTitle = "";
    var msgText = "";
    // Set new icon and color based on current class
    if (icon.classList.contains('fa-eye')) {
        obj.IsActive = false;
        msgTitle = "Sure you want to deactivate this product?";
        msgText = "Deactivate";
    } else {
        obj.IsActive = true;
        msgTitle = "Sure you want to activate this product?";
        msgText = "Activate";
    }
    var formData = new FormData();
    Swal.fire(
        {
            title: msgTitle,
            text: msgText,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, Complete it!",
            closeOnConfirm: false,
        }).then((result) => {
            if (result.value) {

                if (result.value) {
                  
                    formData.append('product', JSON.stringify(obj));
                    $.ajax({
                        type: 'POST',
                        url: '/Product/ChangeActiveStatus',
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
                            if (data != null && data.webResponseCommon.returnCode == '202') {
                                toastr.success("", "Saved");
                                window.location.href = window.location.href;
                                if (icon.classList.contains('fa-eye')) {
                                    icon.classList.toggle('fa-eye', false);
                                    icon.classList.toggle('fa-eye-slash', true);
                                } else {
                                    icon.classList.toggle('fa-eye', true);
                                    icon.classList.toggle('fa-eye-slash', false);
                                }
                            } else {
                                toastr.warning("Error Changing Active Status", "UnSaved");
                            }
                        },
                        error: function (xhr, status, error) {
                            toastr.error(error, "Error Changing Active Status");
                            hideLoading();
                        }
                    });
                }
            }
        });
 

   

}
function rowComplete(sender) {
    var icon = sender.children[0]
    var obj = {};
    obj.ProductId = sender.dataset.id;

    // Set new icon and color based on current class
    if (icon.classList.contains('fa-calendar-check')) {
        obj.IsComplete = false;
    } else {
        obj.IsComplete = true;
    }
    var formData = new FormData();

    formData.append('product', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Product/ChangeCompleteStatus',
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
            if (data != null && data.webResponseCommon.returnCode == '202') {
                toastr.success("", "Saved");
                window.location.href = window.location.href;
                if (icon.classList.contains('fa-calendar-check')) {
                    icon.classList.toggle('fa-calendar-check', false);
                    icon.classList.toggle('fa-calendar-times', true);
                } else {
                    icon.classList.toggle('fa-calendar-check', true);
                    icon.classList.toggle('fa-calendar-times', false);
                }
            } else {
                toastr.warning("Error Changing Complete Status", "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error Complete Active Status");
            hideLoading();
        }
    });

}
