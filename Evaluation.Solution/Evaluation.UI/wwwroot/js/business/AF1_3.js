var params = decodeParameters(globalParam, 3);
const contactID = params[0];
const trxID = params[1];
//const rowMinRange = params[1];
//const rowMaxRange = params[2];
const BusinessLineCode = params[2];
//const countrnx = params[4];
function Submit() {

    
    if ($("#form").valid()) {


        var formBody = new FormData();

        var obj = {};
        var listSave = [];
        obj.ContactId = $("#ContactId").val();
        var af8Obj = {};
        af8Obj.FirstName = $("#AF1BL030904Dto_FirstName").val();
        af8Obj.MiddleName = $("#AF1BL030904Dto_MiddleName").val()
        af8Obj.LastName = $("#AF1BL030904Dto_LastName").val()
        af8Obj.GenderCode = $("#AF1BL030904Dto_GenderCode").val()
        af8Obj.DOB = $("#Dob").val()
        af8Obj.NationalityCode = $("#AF1BL030904Dto_NationalityCode").val()
        af8Obj.MaritalStatusCode = $("#AF1BL030904Dto_MaritalStatusCode").val()
        af8Obj.CountryOfResidenceCode = $("#AF1BL030904Dto_CountryOfResidenceCode").val()
        af8Obj.RequestedLimitCurrency = $("#AF1BL030904Dto_RequestedLimitCurrency").val()
        af8Obj.Occupation = $("#AF1BL030904Dto_Occupation").val()
        af8Obj.ReasonOfInsurance = $("#AF1BL030904Dto_ReasonOfInsurance").val()
        af8Obj.Beneficiary = $("#AF1BL030904Dto_Beneficiary").val()
       // af8Obj.AF1BL030904List = getValues();
        listSave.push(af8Obj)
        obj.AF1BL030904 = listSave;
        obj.RecId = trxID;
        obj.BusinessLineCode = BusinessLineCode;
        formBody.append("data", JSON.stringify(obj));
        if (trxID != 0) {
            $.ajax({
                url: "/Business/EditAF1_3",
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
                url: "/Business/CreateAF1_3",
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

//var totalrow = 1;
//var selectRelationlHtml = "";
//for (var i = 0; relationList.length > i; i++) {
//    selectRelationlHtml += "<option value='" + relationList[i].code + "' >" + relationList[i].description + "</option>";
//}
//var selectGenderlHtml = "";
//for (var i = 0; genderList.length > i; i++) {
//    selectGenderlHtml += "<option value='" + genderList[i].code + "' >" + genderList[i].description + "</option>";
//}
//var selectRegionlHtml = "";
//for (var i = 0; regionList.length > i; i++) {
//    selectRegionlHtml += "<option value='" + regionList[i].code + "' >" + regionList[i].description + "</option>";
//}
//var selectMaritalStatuslHtml = "";
//for (var i = 0; maritalStatusList.length > i; i++) {
//    selectMaritalStatuslHtml += "<option value='" + maritalStatusList[i].code + "' >" + maritalStatusList[i].description + "</option>";
//}
//function addRow() {
//    if (totalrow < 8) {
//        var table = document.getElementById("tblAf8");
//        var newRow = table.insertRow(-1);

//        var cells = [];
//        for (var i = 0; i < 9; i++) {
//            cells[i] = newRow.insertCell(i);
//        }

//        cells[0].innerHTML = '<select class="form-select required" id="Relation" required>' + selectRelationlHtml + '</select>';
//        cells[1].innerHTML = '<input type="text" class="form-control required" id="FirstName" required />';
//        cells[2].innerHTML = '<input type="text" class="form-control required" id="FatherName" required />';
//        cells[3].innerHTML = '<input type="text" class="form-control required" id="LastName" required />';
//        cells[4].innerHTML = '<select class="form-select required" id="Gender" required>' + selectGenderlHtml + '</select>';
//        cells[5].innerHTML = '<input type="date" class="form-control required" id="DOB" required />';
//        cells[6].innerHTML = '<select class="form-select required" required id="Region">' + selectRegionlHtml + '</select>';
//        cells[7].innerHTML = '<select class="form-select required"  required id="MaritalStatus">' + selectMaritalStatuslHtml + '</select>';
//        cells[8].innerHTML = '<button class="btn btn-danger" onclick="removeRow(this)">-</button>';
//        totalrow++;
//    }
//}

//function removeRow(button) {
//    var row = button.parentNode.parentNode;
//    var table = row.parentNode.parentNode;
//    table.deleteRow(row.rowIndex);
//    totalrow--;
//}
//function getValues() {
//    var table = document.getElementById("tblAf8");
//    var rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");

//    var data = [];
//    for (var i = 0; i < rows.length; i++) {
//        var cells = rows[i].getElementsByTagName("td");

//        var rowValues = {
//            relationCode: cells[0].querySelector("select").value,
//            firstName: cells[1].querySelector("input").value,
//            middleName: cells[2].querySelector("input").value,
//            lastName: cells[3].querySelector("input").value,
//            genderCode: cells[4].querySelector("select").value,
//            dob: cells[5].querySelector("input").value,
//            nationalityCode: cells[6].querySelector("select").value,
//            maritalStatusCode: cells[7].querySelector("select").value
//        };

//        data.push(rowValues);
//    }
//    //console.log(data);
//    return data;
   
//}
//function checkChildren() {
//    var table = document.getElementById("tblAf8");
//    var rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");

//    var data = [];
//    var childrenCount = 0;
//    for (var i = 0; i < rows.length; i++) {
//        var cells = rows[i].getElementsByTagName("td");
//        if (cells[0].querySelector("select").value == 'C') {
//            childrenCount++;
//        }
//    }

//    return childrenCount;
//}
$("#btnDashboard").click(function () {
    dashboardRedirect();
})