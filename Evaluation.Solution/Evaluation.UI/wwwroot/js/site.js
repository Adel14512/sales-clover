var apiUrl = "https://localhost:5001/";
const currentUrl = window.location.href;
var urlParams;
try {
     urlParams = new URLSearchParams(window.location.search);
} catch  {

}

const globalParam = currentUrl.substring(currentUrl.lastIndexOf("/") + 1);

function encodeParameters(parameter) {
    const encoded = new TextEncoder().encode(parameter);
    return btoa(String.fromCharCode.apply(null, encoded));
}

function decodeParameters(ticket, numberOfParameters) {
    const parameters = [];
    const decoded = atob(ticket.replace("#",""));
    const decodedParams = decoded.split('&');

    for (let i = 0; i < numberOfParameters; i++) {
        const param = decodedParams[i].split('=')[1];
        parameters.push(param);
    }

    return parameters;
}


function getFilenameFromContentDispositionHeader(contentDisposition) {
    var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
    var matches = filenameRegex.exec(contentDisposition);
    if (matches != null && matches[1]) {
        return decodeURIComponent(matches[1].replace(/['"]/g, ''));
    } else {
        return 'unknown';
    }
}
function selectOnlyOne(checkbox) {
    var checkboxes = document.getElementsByName('checkmeSQ');
    checkboxes.forEach(function (currentCheckbox) {
        if (currentCheckbox !== checkbox)
            currentCheckbox.checked = false;
    });
}
const mimeTypes = {
    // Images
    'jpg': 'image/jpeg',
    'jpeg': 'image/jpeg',
    'png': 'image/png',
    'gif': 'image/gif',
    'bmp': 'image/bmp',
    'webp': 'image/webp',

    // Documents
    'pdf': 'application/pdf',
    'doc': 'application/msword',
    'docx': 'application/vnd.openxmlformats-officedocument.wordprocessingml.document',
    'xls': 'application/vnd.ms-excel',
    'xlsx': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
    'ppt': 'application/vnd.ms-powerpoint',
    'pptx': 'application/vnd.openxmlformats-officedocument.presentationml.presentation',

    // Audio
    'mp3': 'audio/mpeg',
    'wav': 'audio/wav',
    'ogg': 'audio/ogg',

    // Video
    'mp4': 'video/mp4',
    'webm': 'video/webm',
    'avi': 'video/x-msvideo',

    // Text
    'txt': 'text/plain',
    'html': 'text/html',
    'css': 'text/css',
    'js': 'application/javascript',

    // Archives
    'zip': 'application/zip',
    'rar': 'application/x-rar-compressed',
    'tar': 'application/x-tar',

    // Other
    'json': 'application/json',
    'xml': 'application/xml',
};

// Example usage:
//const extension = 'pdf';
//const mimeType = mimeTypes[extension.toLowerCase()];
//console.log(`MIME type for ${extension}: ${mimeType}`);


function downloadEmptyExcel(businessLineCode, pageType, typeForm) {
    var formData = new FormData();
    formData.append('businesscode', businessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', pageType);
    formData.append('type', typeForm);
    formData.append('isemptydownload', true);
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
function getBenifitsModal(rowdata) {
    var classId = rowdata.classId;
    var formData = new FormData();
    var obj = {};
    obj.ProductId = rowdata.productId;
    formData.append('product', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Product/GetProductBenifits',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function (xhr) {
            showLoading();
        },
        success: function (data, status, xhr) {
            hideLoading();
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '200') {

                var dataList = data.productBenefitsList.filter(x => x.classCode == classId && x.benefitAnswer == 'No' && x.productId == obj.ProductId);
                if (dataList.length > 0) {
                    benifitList = data.productBenefitsList;
                    $('#benefitsModal').modal('show');
                    var tableBody = $('#benefitsTableBody tbody');
                    $('#benefitsTableBody').DataTable().clear().draw();
                    $('#benefitsTableBody').DataTable().destroy();
                    dataList.forEach(function (benefit) {
                        var row = '<tr>' +
                            '<td>' + benefit.benefitNumber + '</td>' +
                            '<td>' + benefit.benefitName + '</td>' +
                            '</tr>';
                        tableBody.append(row);
                    });

                    $('#benefitsTableBody').DataTable({
                        paging: true, // Enable pagination
                        // Other DataTable options...
                    });
                } else {
                    toastr.warning("No Data");
                }

            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "Error");
            }

        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error while Move to Next Step");
            hideLoading();
        }
    });
}
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
                result = true;
            } else {
                result = false;
            }

            // Now you have the ID of the active tab
            // You can do whatever you want with it, like showing/hiding content or applying styles
        }
    });
    return result;
}
function addNumberToValue(id, number) {
    $("#" + id).val(number);
}