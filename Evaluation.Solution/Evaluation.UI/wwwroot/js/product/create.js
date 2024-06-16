

function Submit() {
    if ($("#step1from").valid()) {
        var obj = {};
        var objProduct = {};
        objProduct.BranchId = $("#EditProduct_BranchId").val();
        objProduct.InsurerId = $("#EditProduct_InsurerId").val();
        objProduct.InsurerProductName = $("#EditProduct_InsurerProductName").val();
        objProduct.ThirdPartyAdminId = $("#EditProduct_ThirdPartyAdminId").val();
        objProduct.CreationDate = $("#EditProduct_CreationDate").val();
        objProduct.ActivationDate = $("#EditProduct_ActivationDate").val();
        objProduct.CurrencyId = $("#EditProduct_CurrencyId").val();
        objProduct.ToCountry = $("#EditProduct_ToCountry").val();
        objProduct.CountryOfResidence = $("#EditProduct_CountryOfResidence").val();
        objProduct.FromCountry = $("#EditProduct_FromCountry").val();
        objProduct.SubjectToProrata = $("#EditProduct_SubjectToProrata").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.PolicyCreationId = $("#EditProduct_PolicyCreationId").val();
        objProduct.Standalone = $("#EditProduct_Standalone").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.NoUnderwriting = $("#EditProduct_NoUnderwriting").val();//.toLowerCase();// == 'yes' ? true : false;
        objProduct.Continuity = $("#EditProduct_Continuity").val();
        objProduct.NoWaitingPeriod = $("#EditProduct_NoWaitingPeriod").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.GuaranteeRenewability = $("#EditProduct_GuaranteeRenewability").val();
        objProduct.NewBusinessAgeMinRange = $("#EditProduct_NewBusinessAgeMinRange").val();
        objProduct.NewBusinessAgeMaxRange = $("#EditProduct_NewBusinessAgeMaxRange").val();
        objProduct.RenewalAgeMinRange = $("#EditProduct_RenewalAgeMinRange").val();
        objProduct.RenewalAgeMaxRange = $("#EditProduct_RenewalAgeMaxRange").val();
        objProduct.ChildStandalone = $("#EditProduct_ChildStandalone").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.AgeCalculationYear = $("#EditProduct_AgeCalculationYear").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.AgeCalculationFullDate = $("#EditProduct_AgeCalculationFullDate").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.FamilyRatesCalculation = $("#EditProduct_FamilyRatesCalculation").val();//.toLowerCase() == 'yes' ? true : false;
        objProduct.NoClaimBonus = $("#EditProduct_NoClaimBonus").val();//.toLowerCase() == 'yes' ? true : false;


        obj.ProductFull = objProduct;
        var formBody = new FormData();
        formBody.append("product", JSON.stringify(obj));
        $.ajax({
            url: "/Product/Create",
            type: "POST",
            contentType: false,
            processData: false,
            data: formBody,
            beforeSend: function (xhr) {
                showLoading();
                // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                hideLoading();


                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '201') {
                    toastr.success("", "Saved");
                    var params = encodeParameters("?id=" + data.productFull.recId);
                    window.location.href = "/Product/edit/" + params;
                } else {
                    toastr.warning("Please fix required fields", "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product");

            }
        });
    }
}
$("#btnSave").click(function () {
    Submit()
})
