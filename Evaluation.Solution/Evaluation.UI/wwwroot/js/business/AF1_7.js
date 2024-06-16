var params = decodeParameters(globalParam, 3);
const contactID = params[0];
const trxID = params[1];
//const rowMinRange = params[1];
//const rowMaxRange = params[2];
const BusinessLineCode = params[2];
//const countrnx = params[4];
function Submit() {
    var resultchildren = checkChildren();
    if (resultchildren < 6) {
        if (resultchildren == false) {
            return false;
        } else if (resultchildren == true) {
        } else if (resultchildren != 0) {
            return false;
        }
    } else {
        toastr.warning("You can only add children", "No more Children");
    }
    if ($("#form").valid()) {


        var formBody = new FormData();

        var obj = {};
        obj.ContactId = $("#ContactId").val();
        var af8Obj = {};
        af8Obj.SponsorName = $("#AF1BL070806Dtco_SponsorName").val();
        af8Obj.Ambulatory = $("#AF1BL070806Dtco_Ambulatory").val().toLowerCase() == 'true' ? true : false;
     
        af8Obj.AF1BL070806List = getValues();
        obj.AF1BL070806 = af8Obj;
        obj.RecId = trxID;
        obj.BusinessLineCode = BusinessLineCode;
        obj.MasterId = $("#MasterId").val();
        formBody.append("data", JSON.stringify(obj));
        if (trxID != 0) {
            $.ajax({
                url: "/Business/EditAF1_7",
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
                        var urlencode = encodeParameters("?contactid=" + contactID);
                        window.location.href = "../../transaction/Dashboard/" + urlencode;
                    } else {
                        toastr.warning("Please fix required fields", "UnSaved");
                    }

                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }

            });
        } else {
            $.ajax({
                url: "/Business/CreateAF1_7",
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
                        var urlencode = encodeParameters("?contactid=" + contactID);
                        window.location.href = "../../transaction/Dashboard/" + urlencode;
                    } else {
                        toastr.warning("Please fix required fields", "UnSaved");
                    }

                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }

            });
        }
       
    } else {
        toastr.warning("Fill required fields", "Required fields");
    }
}

var totalrow = 1;
var selectRelationlHtml = "";
for (var i = 0; relationList.length > i; i++) {
    selectRelationlHtml += "<option value='" + relationList[i].code + "' >" + relationList[i].description + "</option>";
}
var selectGenderlHtml = "";
for (var i = 0; genderList.length > i; i++) {
    selectGenderlHtml += "<option value='" + genderList[i].code + "' >" + genderList[i].description + "</option>";
}
var selectRegionlHtml = "";
for (var i = 0; regionList.length > i; i++) {
    if (regionList[i].isDefault) {
        selectRegionlHtml += "<option value='" + regionList[i].code + "' selected >" + regionList[i].description + "</option>";
    } else {
        selectRegionlHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
    }
}
var selectMaritalStatuslHtml = "";
for (var i = 0; maritalStatusList.length > i; i++) {
    selectMaritalStatuslHtml += "<option value='" + maritalStatusList[i].code + "' >" + maritalStatusList[i].description + "</option>";
}
function addRow() {
    if (totalrow < 8) {
        var table = document.getElementById("tblAf8");
        var newRow = table.insertRow(-1);

        var cells = [];
        for (var i = 0; i < 9; i++) {
            cells[i] = newRow.insertCell(i);
        }
        cells[0].innerHTML = '<select class="form-select required" id="Relation" required>' + selectRelationlHtml + '</select>';
        cells[1].innerHTML = '<input type="text" class="form-control required" id="FirstName" required value="firstname' + totalrow + '" />';
        cells[2].innerHTML = '<input type="text" class="form-control required" id="FatherName" required value="fathername' + totalrow + '" />';
        cells[3].innerHTML = '<input type="text" class="form-control required" id="LastName" required value="lastname' + totalrow + '"/>';
        cells[4].innerHTML = '<select class="form-select required" id="Gender" required>' + selectGenderlHtml + '</select>';
        cells[5].innerHTML = '<input type="date" class="form-control required" id="DOB" required />';
        cells[6].innerHTML = '<select class="form-select required" required id="Region">' + selectRegionlHtml + '</select>';
        cells[7].innerHTML = '<select class="form-select required"  required id="MaritalStatus">' + selectMaritalStatuslHtml + '</select>';
        cells[8].innerHTML = '<button class="btn btn-danger" onclick="removeRow(this)">-</button>';
        totalrow++;
    }
}

function removeRow(button) {
    var row = button.parentNode.parentNode;
    var table = row.parentNode.parentNode;
    table.deleteRow(row.rowIndex);
    totalrow--;
}
function getValues() {
    var table = document.getElementById("tblAf8");
    var rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");

    var data = [];
    for (var i = 0; i < rows.length; i++) {
        var cells = rows[i].getElementsByTagName("td");

        var rowValues = {
            relationCode: cells[0].querySelector("select").value,
            firstName: cells[1].querySelector("input").value,
            middleName: cells[2].querySelector("input").value,
            lastName: cells[3].querySelector("input").value,
            genderCode: cells[4].querySelector("select").value,
            dob: cells[5].querySelector("input").value,
            nationalityCode: cells[6].querySelector("select").value,
            maritalStatusCode: cells[7].querySelector("select").value
        };

        data.push(rowValues);
    }
    //console.log(data);
    return data;
   
}
function checkChildren() {
    var table = document.getElementById("tblAf8");
    var rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");
    var result = true;
    var data = [];
    var numberSpouse=0, numberPrinciple=0, childrenCount = 0;
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
$("#btnDashboard").click(function () {
    var urlencode = encodeParameters("?contactid=" + $("#ContactId").val());
    window.location.href = "../../transaction/Dashboard/" + urlencode;
})
function getAge(dateOfBirth) {
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