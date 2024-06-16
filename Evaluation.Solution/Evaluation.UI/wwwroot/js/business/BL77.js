var params = decodeParameters(globalParam, 3);
const rowMinRange = params[1];
const rowMaxRange = 10;
const BusinessLineCode = params[2];
const countrnx = params[4];
$("#BusinessLineCode").val(BusinessLineCode);
var formCount = 1;

// function to generate HTML for the form
function generateForm(data,isExcel) {
    var lastcompanyEntered = $('input[id="Company"]').last().val();

    var rowcount = (formCount + 1);
    if (rowcount > rowMaxRange) {
        //alert("Maximum Added Insurer");
        toastr.warning("Maximum Added Insurer", "Can't add");
          return false;
    }
    var selectGenderHtml = "<select id='Gender'  name='Gender[]'  class='select2 form-select' required>";
    // selectGenderHtml += "<option value=''>--Select--</option>";
    for (var i = 0; genderList.length > i; i++) {
        if (isExcel) {
            if (data != null && data.genderCode != null && data.genderCode != "" && data.genderCode.trim().toUpperCase() == genderList[i].description.trim().toUpperCase()) {
                selectGenderHtml += "<option value='" + genderList[i].code + "' selected>" + genderList[i].description + "</option>";
            } else {
                selectGenderHtml += "<option value='" + genderList[i].code + "' >" + genderList[i].description + "</option>";
            }
        } else {
            if (data != null && data.genderCode != null && data.genderCode != "" && data.genderCode.trim().toUpperCase() == genderList[i].code.trim().toUpperCase()) {
                selectGenderHtml += "<option value='" + genderList[i].code + "' selected>" + genderList[i].description + "</option>";
            } else {
                selectGenderHtml += "<option value='" + genderList[i].code + "' >" + genderList[i].description + "</option>";
            }
        }
       

    }
    selectGenderHtml += "</select>";

    var selectRegionHtml = "";
    //        = "<select id='Gender'  name='ddlChannel'  class='select2 form-select' >";
    //selectRegionHtml += "<option value=''>--Select--</option>";
    for (var i = 0; regionList.length > i; i++) {
        if (isExcel) {
            if (data != null && data.nationalityCode != null && data.nationalityCode != "" && data.nationalityCode.trim().toUpperCase() == regionList[i].description.trim().toUpperCase()) {
                selectRegionHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
            } else {
                selectRegionHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
            }
        } else {
            if (data != null && data.nationalityCode != null && data.nationalityCode != "" && data.nationalityCode.trim().toUpperCase() == regionList[i].code.trim().toUpperCase()) {
                selectRegionHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
            } else {
                selectRegionHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
            }
        }
       
       // selectRegionHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
    }
    var selectRegionDestinationHtml = "";
    //        = "<select id='Gender'  name='ddlChannel'  class='select2 form-select' >";
    //selectRegionHtml += "<option value=''>--Select--</option>";
    for (var i = 0; regionList.length > i; i++) {
        if (isExcel) {
            if (data != null && data.countryOfDestinationCode != null && data.countryOfDestinationCode != "" && data.countryOfDestinationCode.trim().toUpperCase() == regionList[i].description.trim().toUpperCase()) {
                selectRegionDestinationHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
            } else {
                selectRegionDestinationHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
            }
        } else {
            if (data != null && data.countryOfDestinationCode != null && data.countryOfDestinationCode != "" && data.countryOfDestinationCode.trim().toUpperCase() == regionList[i].code.trim().toUpperCase()) {
                selectRegionDestinationHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
            } else {
                selectRegionDestinationHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
            }
        }
      
       // selectRegionHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
    }
    var selectRegionDefaultHtml = "";
    //        = "<select id='Gender'  name='ddlChannel'  class='select2 form-select' >";
    //selectRegionHtml += "<option value=''>--Select--</option>";
    for (var i = 0; regionList.length > i; i++) {
        if (regionList[i].isDefault) {
            if (isExcel) {
                if (data != null && data.countryOfDepartureCode != null && data.countryOfDepartureCode != "" && data.countryOfDepartureCode.trim().toUpperCase() == regionList[i].description.trim().toUpperCase()) {
                    selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
                } else {
                    if (data != null) {
                        selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
                    } else {
                        selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
                    }

                }
            } else {
                if (data != null && data.countryOfDepartureCode != null && data.countryOfDepartureCode != "" && data.countryOfDepartureCode.trim().toUpperCase() == regionList[i].code.trim().toUpperCase()) {
                    selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
                } else {
                    if (data != null) {
                        selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
                    } else {
                        selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
                    }

                }
            }
           
          
        } else {
            if (isExcel) {
                if (data != null && data.countryOfDepartureCode != null && data.countryOfDepartureCode != "" && data.countryOfDepartureCode.trim().toUpperCase() == regionList[i].description.trim().toUpperCase()) {
                    selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
                } else {
                    selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
                }
            } else {
                if (data != null && data.countryOfDepartureCode != null && data.countryOfDepartureCode != "" && data.countryOfDepartureCode.trim().toUpperCase() == regionList[i].code.trim().toUpperCase()) {
                    selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' selected>" + regionList[i].description + "</option>";
                } else {
                    selectRegionDefaultHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
                }
            }
           
          
        }
      
        

    }
    //selectRegionHtml += "</select>";

    var selectMaritalStatusHtml = "<select id='MaritalStatus' name='MaritalStatus[]'  class='select2 form-select' required>";
    // selectMaritalStatusHtml += "<option value=''>--Select--</option>";
    for (var i = 0; maritalStatusList.length > i; i++) {
        if (isExcel) {
            if (data != null && data.maritalStatusCode != null && data.maritalStatusCode != "" && data.maritalStatusCode.trim().toUpperCase() == maritalStatusList[i].description.trim().toUpperCase()) {
                selectMaritalStatusHtml += "<option value='" + maritalStatusList[i].code + "' selected>" + maritalStatusList[i].description + "</option>";
            } else {

                selectMaritalStatusHtml += "<option value='" + maritalStatusList[i].code + "' >" + maritalStatusList[i].description + "</option>";
            }
        } else {
            if (data != null && data.maritalStatusCode != null && data.maritalStatusCode != "" && data.maritalStatusCode.trim().toUpperCase() == maritalStatusList[i].code.trim().toUpperCase()) {
                selectMaritalStatusHtml += "<option value='" + maritalStatusList[i].code + "' selected>" + maritalStatusList[i].description + "</option>";
            } else {

                selectMaritalStatusHtml += "<option value='" + maritalStatusList[i].code + "' >" + maritalStatusList[i].description + "</option>";
            }
        }
       
        
    }
    selectMaritalStatusHtml += "</select>";

    var formHTML =
        '<div class="formRow" data-row="' + rowcount + '">' +
        '<h2 id="Title" name="Title[]">Insurer ' + rowcount + '</h2>' +
        '<div class="row">' +
        '<div class="mb-3 col-md-3">' +
        '<label for="Company">Company</label>';
    if (data != null) {
        formHTML += '<input type="text" class="form-control"  id="Company" name="[' + formCount + '][Company[]]" placeholder="Company" required value=' + data.company + '>';
    } else {
        formHTML += '<input type="text" class="form-control"  id="Company" name="[' + formCount + '][Company[]]" placeholder="Company" required value=' + lastcompanyEntered + '>';
    }
         
    formHTML += '<input type="hidden" id="Serial" value="' + rowcount + '" name="[' + formCount + '][Serial[]]" >' +
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="Staff">Staff No</label>';
    if (data != null) {
        formHTML += '<input type="number" id="Staff" name="Staff[]" class="form-control" placeholder="Staff" required value="' + data.staffNbr + '">';
    } else {
        formHTML += '<input type="number" id="Staff" name="Staff[]" class="form-control" placeholder="Staff" required >';
    }

    formHTML += '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="FirstName">First Name</label>';
    if (data != null) {
        formHTML += '<input type="text" class="form-control" id="FirstName" name="FirstName[]" placeholder="First Name" required value="' + data.firstName + '">';
    } else {
        formHTML += '<input type="text" class="form-control" id="FirstName" name="FirstName[]" placeholder="First Name" required >';
    }
    formHTML +=
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="MiddleName">Middle Name</label>';
    if (data != null) {
        formHTML += '<input type="text" class="form-control" id="MiddleName" name="MiddleName[]" placeholder="Middle Name" required value="' + data.middleName + '">';
    } else {
        formHTML += '<input type="text" class="form-control" id="MiddleName" name="MiddleName[]" placeholder="Middle Name" required>';
    }
    formHTML +=
        '</div>' +
        '</div>' +
        '<div class="row">' +
        '<div class="mb-3 col-md-3">' +
        '<label for="LastName">Last Name</label>';
    if (data != null) {
        formHTML += '<input type="text" id="LastName" name="LastName[]" class="form-control" placeholder="Last Name" required value="' + data.lastName + '">';
    } else {
        formHTML += '<input type="text" id="LastName" name="LastName[]" class="form-control" placeholder="Last Name" required >';
    }
    formHTML +=
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="Gender">Gender</label>' +
        selectGenderHtml +
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="Dob">DOB</label>';
    if (data != null) {
       
        if (data.dob.length>10) {
            data.dob = data.dob.substring(0, 10).replace(/\//g, "-");
           // let parts = data.dob.split("/");
           // data.dob = `${parts[2]}-${parts[1]}-${parts[0]}`;
        }
        
        formHTML += '<input type="date" id="Dob" name="Dob[]" class="form-control " required value="' + data.dob + '"/>';
    } else {
        formHTML += '<input type="date" id="Dob" name="Dob[]" class="form-control " required />';
    }

    formHTML += '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="Nationality">Nationality</label>' +
        '<select class="form-select" id="Nationality" name="Nationality[]" required>' +
        selectRegionHtml +
        '</select>' +
        '</div>' +
        '</div>' +
        '<div class="row">' +
        '<div class="mb-3 col-md-3">' +
        '<label for="MaritalStatus">Marital Status</label>' +
        selectMaritalStatusHtml +
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="CountryOfDeparture">Country Of Departure</label>' +

        '<select class="form-select" id="CountryOfDeparture"  name="CountryOfDeparture[] required >" '
        + selectRegionDefaultHtml +
        '</select>' +
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="CountryOfDestination">Country Of Destination</label>' +
        '<select class="form-select" id="CountryOfDestination" name="CountryOfDestination[]" required >' +
        selectRegionDestinationHtml +
        '</select>' +
        '</div>' +
        '<div class="mb-3 col-md-3">' +
        '<label for="StayTripOption">Stay/Trip Option</label>';
    if (data != null) {
        formHTML += '<input type="text" class="form-control" id="StayTripOption" name="StayTripOption[]" placeholder="Stay/Trip Option" value="' + data.stayTripOption + '">';
    } else {
        formHTML += '<input type="text" class="form-control" id="StayTripOption" name="StayTripOption[]" placeholder="Stay/Trip Option" >';
    }


    formHTML += ' </div> ' +
        ' <div class="mb-3 col-md-3" > ' +
        '     <label for= "NoOfDays" > No.of days when less than 92 Days </label>';
    if (data != null) {
        formHTML += '<input type="number" class="form-control" id="NoOfDays" name="NoOfDays[]" min="1" max="91" placeholder="No. Of Days" value="' + data.nbrDaysWhenLess92 + '">';
    } else {
        formHTML += '<input type="number" class="form-control" id="NoOfDays" name="NoOfDays[]" min="1" max="91" placeholder="No. Of Days">';
    }

    formHTML += '</div>' +
        '</div>' +
        '<div class="col-sm-1"> <div class="form-group"> <button class="btn rounded-pill px-4 btn-light-danger text-danger font-weight-medium waves-effect waves-light" type="button" onclick="deleteForm(' + rowcount + ',\'Insurer\')"> <i class="ri-delete-bin-line fs-5"></i> </button> </div>' +

        '</div>' +


        ' </div>';
    return formHTML;
}

// function to add a new form to the DOM
function addForm(data,isExcel) {
    var formHTML = generateForm(data, isExcel);
    $('#form-container').append(formHTML);
    formCount++;
}

// function to get the data from all the forms and add it to the list

function deleteForm(rowcount, name) {
    $('[data-row="' + rowcount + '"]').remove();
    var rowCount = 0;
    $('.formRow').each(function (index) {
        rowCount++;
        $(this).find("#Title").text(name + ' ' + rowCount);
        // $(this).data().row = rowCount;
        $(this).data('row', rowCount);
        formCount = rowCount;
    });

}
// add event listeners for the buttons
$('#add-form-btn').click(addForm);

function submitForms() {
    var formDataFields = [];

    $('.formRow').each(function (index) {
        var formObj = {};
        //formObj['form'] = index + 1;
        formObj['Serial'] = $(this).find('#Serial').val();
        formObj['Company'] = $(this).find('#Company').val();
        formObj['StaffNbr'] = $(this).find('#Staff').val();
        formObj['FirstName'] = $(this).find('#FirstName').val();
        formObj['MiddleName'] = $(this).find('#MiddleName').val();
        formObj['LastName'] = $(this).find('#LastName').val();
        formObj['GenderCode'] = $(this).find('#Gender').val();
        formObj['DOB'] = $(this).find('#Dob').val();
        formObj['NationalityCode'] = $(this).find('#Nationality').val();
        formObj['MaritalStatusCode'] = $(this).find('#MaritalStatus').val();
        formObj['CountryOfDepartureCode'] = $(this).find('#CountryOfDeparture').val();
        formObj['CountryOfDestinationCode'] = $(this).find('#CountryOfDestination').val();
        formObj['StayTripOption'] = $(this).find('#StayTripOption').val();
        formObj['NbrDaysWhenLess92'] = $(this).find('#NoOfDays').val();
        // add code to get data from other fields here
        formDataFields.push(formObj);
    });

    // console.log(formDataFields);
    var arrayDup = findDuplicateNames(formDataFields)
    arrayDup = arrayDup.filter(str => str !== "");
    if (arrayDup.length > 0) {
       // alert("Change Duplicate Staff Number.");
        toastr.warning("Change Duplicate Staff Number", "Duplicate");
        return false;
    }
    var obj = {};
    obj.BusinessLineCode = BusinessLineCode;
    obj.ContactId = $("#ContactId").val();
    obj.RecId = $("#SalesId").val();
    obj.AF1BL77 = formDataFields;

    var formBody = new FormData();
    formBody.append("data", JSON.stringify(obj));
    if ($("#form").valid()) {
      
        if (countrnx == null || countrnx == 0) {
            //create
            $.ajax({
                url: "/Business/CreateBL77",
                type: "POST",
                contentType: false,
                processData: false,
                data: formBody,
                beforeSend: function (xhr) {
                    showLoading();
                    xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                    //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
                },
                success: function (data) {
                    //alert("Saved!");
                    hideLoading();
                    toastr.success("", "Saved");
                    //window.location.href = "../channel/index";
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }
            });
        } else {
            //edit
            $.ajax({
                url: "/Business/EditBL77",
                type: "POST",
                contentType: false,
                processData: false,
                data: formBody,
                beforeSend: function (xhr) {
                    showLoading();
                    xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                    //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
                },
                success: function (data) {
                    //alert("Saved!");
                    hideLoading();
                    toastr.success("", "Saved");
                    //window.location.href = "../channel/index";
                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }
            });
        }
       
    } else {
        //alert("Fix BL77 Fields.");
        return false;
    }
}
function findDuplicateNames(array) {
    var names = new Set();
    var duplicates = new Set();

    $.each(array, function (index, object) {
        if (names.has(object.StaffNbr)) {
            duplicates.add(object.StaffNbr);
        } else {
            names.add(object.StaffNbr);
        }
    });
    var arrayDup = Array.from(duplicates);

    return arrayDup;
}
$("#btnUploadExcel").click(function () {
    document.getElementById('fileInput').click();
});
$('#fileInput').change(function () {
    var fileName = $(this).val();
    if (fileName != '') {
        var file = this.files[0]; // Get the selected file

        // Create a new FormData object and append the selected file to it
        var formData = new FormData();
        formData.append('file', file);

        $.ajax({
            type: 'POST',
            url: '/ExcelImport/ImportExcel',
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

                        formCount = 0;
                        $("#form-container").html("");

                        for (var i = 0; i < result.data.length; i++) {
                            addForm(result.data[i],true);
                        }

                    }
                } else {
                   // alert("Please fix excel:" + data.message);
                    toastr.error("Please fix excel:" + data.message, "Error");

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

    var formDataFields = [];

    $('.formRow').each(function (index) {
        var formObj = {};
        //formObj['form'] = index + 1;
        formObj['Serial'] = $(this).find('#Serial').val();
        formObj['Company'] = $(this).find('#Company').val();
        formObj['StaffNbr'] = $(this).find('#Staff').val();
        formObj['FirstName'] = $(this).find('#FirstName').val();
        formObj['MiddleName'] = $(this).find('#MiddleName').val();
        formObj['LastName'] = $(this).find('#LastName').val();
        formObj['GenderCode'] = $(this).find('#Gender option:selected').text();
        formObj['DOB'] = $(this).find('#Dob').val();
        formObj['NationalityCode'] = $(this).find('#Nationality option:selected').text();
        formObj['MaritalStatusCode'] = $(this).find('#MaritalStatus option:selected').text();
        formObj['CountryOfDepartureCode'] = $(this).find('#CountryOfDeparture option:selected').text();
        formObj['CountryOfDestinationCode'] = $(this).find('#CountryOfDestination option:selected').text();
        formObj['StayTripOption'] = $(this).find('#StayTripOption').val();
        formObj['NbrDaysWhenLess92'] = $(this).find('#NoOfDays').val();
        // add code to get data from other fields here
        formDataFields.push(formObj);
    });
    var formData = new FormData();
    formData.append('data', JSON.stringify(formDataFieldsFixed));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', 'BL77');
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
//draw existing fields
if (countrnx == 1) {
    formCount = 0;
    $("#form-container").html("");

    for (var i = 0; i < salesTransAf1.length; i++) {
        addForm(salesTransAf1[i]);
    }
    var formDataFieldsFixed = [];

    $('.formRow').each(function (index) {
        var formObj = {};
        //formObj['form'] = index + 1;
        formObj['Serial'] = $(this).find('#Serial').val();
        formObj['Company'] = $(this).find('#Company').val();
        formObj['StaffNbr'] = $(this).find('#Staff').val();
        formObj['FirstName'] = $(this).find('#FirstName').val();
        formObj['MiddleName'] = $(this).find('#MiddleName').val();
        formObj['LastName'] = $(this).find('#LastName').val();
        formObj['GenderCode'] = $(this).find('#Gender option:selected').text();
        formObj['DOB'] = $(this).find('#Dob').val();
        formObj['NationalityCode'] = $(this).find('#Nationality option:selected').text();
        formObj['MaritalStatusCode'] = $(this).find('#MaritalStatus option:selected').text();
        formObj['CountryOfDepartureCode'] = $(this).find('#CountryOfDeparture option:selected').text();
        formObj['CountryOfDestinationCode'] = $(this).find('#CountryOfDestination option:selected').text();
        formObj['StayTripOption'] = $(this).find('#StayTripOption').val();
        formObj['NbrDaysWhenLess92'] = $(this).find('#NoOfDays').val();
        // add code to get data from other fields here
        formDataFieldsFixed.push(formObj);
    });
}