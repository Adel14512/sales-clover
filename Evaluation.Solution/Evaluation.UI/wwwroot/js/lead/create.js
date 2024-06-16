function Submit() {
    if ($("#form").valid()) {
        var obj = {};
        var objcontact = {};

        objcontact.leadStatusId = parseInt($("#LeadStatusId").val());
        objcontact.countryId = $("#CountryId").val();
        objcontact.owner = $("#Owner").val();
        objcontact.firstName = $("#FirstName").val();
        objcontact.lastName = $("#LastName").val();
        objcontact.mobile = $("#Mobile").val();
        objcontact.eMail = $("#EMail").val();
        objcontact.job = $("#Job").val();
        objcontact.company = $("#Company").val();
        objcontact.topic = $("#Topic").val();
        objcontact.businessLine = $("#BusinessLine").val();
        objcontact.leadSourceId = parseInt($("#LeadSourceId").val());
        objcontact.leadSaleId = parseInt($("#LeadSaleId").val());
        objcontact.summaryFeedback = $("#SummaryFeedback").val();
        objcontact.nextActionDate = $("#NextActionDate").val();
        obj.lead = objcontact;
        var formBody = new FormData();
        formBody.append("lead", JSON.stringify(obj));
        $.ajax({
            url: "../Lead/Create",
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
                if (data.webResponseCommon.returnCode == '201') {
                    toastr.success("", "Saved");
                    window.location.href = "../Lead/index";
                } else {
                    toastr.warning("Please fix required fields", "UnSaved");
                }

            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }

        });
    } else {
        toastr.warning("Please fix required fields", "UnSaved");
    }
}