const email = urlParams.get('email');
const lineNbr = urlParams.get('lineNbr');
const dob = urlParams.get('dob');
const firstName = urlParams.get('firstName');
const lastName = urlParams.get('lastName');
const middleName = urlParams.get('middleName');
$("#FirstName").val(firstName);
$("#LastName").val(lastName);
$("#MiddleName").val(middleName);
$("#Email").val(email);
$("#LandLine").val(lineNbr);
$("#Dob").val(dob);


function Submit() {
    var obj = {};
    var objcontact = {};
    objcontact.firstName = $("#FirstName").val();
    objcontact.lastName = $("#LastName").val();
    objcontact.middleName = $("#MiddleName").val();
    objcontact.genderCode = $("#GenderId").val();
    objcontact.registrationNo = $("#RegistrationNo").val();
   // objcontact.dob = $("#Dob").val();
    objcontact.yob = $("#YOB").val();
    objcontact.regionCode = $("#RegionCode").val();
    objcontact.job = $("#Job").val();
    objcontact.company = $("#Company").val();
    objcontact.contactChannel = getChannels();
    obj.contact = objcontact;
    var formBody = new FormData();
    formBody.append("contact", JSON.stringify(obj));
    $.ajax({
        url: "../Contact/Create",
        type: "POST",
        contentType: false,
        processData: false,
        data: formBody,
        success: function (data) {
            if (data.webResponseCommon.returnCode == '200') {
                toastr.success("", "Saved");
                window.location.href = window.location.href;
            } else {
                toastr.warning( data.webResponseCommon.returnMessage, "UnSaved");
            }
        
        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }
    });
}
