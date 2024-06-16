var params = decodeParameters(globalParam, 1);
const productID = params[0];
var BusinessLineCode = $("#txtBusinesslineCode").val();
function Submit() {
    if ($("#step1from").valid()) {


        var obj = {};
        var objProduct = {};
        objProduct.IsActive = $("#EditProduct_IsActive").val();
        objProduct.RecId = $("#EditProduct_RecId").val();
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
        objProduct.CommisionFromGP = $("#EditProduct_CommisionFromGP").val();
        objProduct.BuiltInCostOfPolicy = $("#EditProduct_BuiltInCostOfPolicy").val();
        objProduct.BuiltInPropTaxes = $("#EditProduct_BuiltInPropTaxes").val();
        objProduct.FixedTaxes = $("#EditProduct_FixedTaxes").val();
        objProduct.VATOnCommision = $("#EditProduct_VATOnCommision").val();
        objProduct.InsurerLoading = $("#EditProduct_InsurerLoading").val();
        objProduct.NoClaimBonus = $("#EditProduct_NoClaimBonus").val();//.toLowerCase() == 'yes' ? true : false;
        obj.ProductFull = objProduct;
        var formBody = new FormData();
        formBody.append("product", JSON.stringify(obj));
        $.ajax({
            url: "/Product/Edit",
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


                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                    toastr.success("", "Saved");
                    window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product");

            }
        });
    }
}

$("#btnSave").click(function () { Submit(); });
//Table tMiscellaneous Start
const selectedClassIds = [];

function isClassSelected(classId) {
    return selectedClassIds.includes(classId);
}
function isValueExistInColumn(table, columnIndex, value) {
    var data = table.column(columnIndex).data().toArray();
    var count = 0;

    for (var i = 0; i < data.length; i++) {
        if (data[i] === value) {
            count++;
        }
    }

    return count > 0;
}
function getClassOfCoverageFromStep3() {
    var table = $('#tMiscellaneous').DataTable();
    var data = table.column(1).data().toArray();
    var count = 0;
    var classes = [];
    for (var i = 0; i < data.length; i++) {
        classes.push(parseInt(data[i]));
    }
    var listes = productClassOfCoverage.filter(x => classes.indexOf(x.recId) !== -1);
    return listes;
}
function getTechnicalSheetFromStep5() {
    var table = $('#tTechnicalSheets').DataTable();
    var data = table.column(1).data().toArray();
    var count = 0;
    var classes = [];
    for (var i = 0; i < data.length; i++) {
        classes.push(parseInt(data[i]));
    }
    var listes = classes;//productClassOfCoverage.filter(x => classes.indexOf(x.recId) !== -1);
    return listes;
}

var columnConfigtMiscellaneous = [

    { data: 'productId', title: 'Product' },
    {
        data: 'classId', title: 'Class'
    },
    { data: 'amlAmount', title: 'Amount' },
    { data: 'costPolicy', title: 'Cost Policy' },
    { data: 'adminFees', title: 'Fees' },
    { data: 'firstYearDiscount', title: '1st year Discount' },
    { data: 'commision', title: 'Commision%' },
    { data: 'recId', title: 'ID', },
];
var columnDefstMiscellaneous = columnConfigtMiscellaneous.map(function (column, index) {
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
var data = [
    {
        recId: 1,
        productId: 'Product A',
        classId: 'Class X',
        amlAmount: 100,
        costPolicy: 'Policy A',
        adminFees: 10,
        firstYearDiscount: 5,
        commision: 15,
        isActive: true
    },
    // Add more data objects as needed
];
var tMiscellaneous = $('#tMiscellaneous').DataTable({
    data: productDetails,
    responsive: true,
    autoWidth: true,
    columns: [
        // { data: 'recId', title: 'ID', },
        { data: 'productId', title: 'Product', },
        {
            data: 'classId', title: 'Class', render: function (data, type, row) {
                var model = productClassOfCoverage.find(x => x.recId == data);
                if (model != null) {
                    return model.description
                } else {
                    return '';
                }
            }
        },
        { data: 'amlAmount', title: 'AMT' },
        { data: 'costPolicy', title: 'Cost Policy' },
        { data: 'adminFees', title: 'Fees' },
        { data: 'firstYearDiscount', title: '1Y Discount' },
        { data: 'commision', title: 'Commision' },
        // { data: 'commisionFromGP', title: 'GP Commision %' },
        { data: 'vatPer', title: 'VAT %' },
        { data: 'costPolicyAmount', title: 'Cost of Policy Amt' },
        { data: 'fixedTaxAmount', title: 'Fixed Tax' },
        { data: 'properTaxPer', title: 'Prop. Tax %' },
        // { data: 'builtInCostOfPolicy', title: 'COP' },
        // { data: 'insurerLoading', title: 'Loading%' },
        {
            data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                var html = '<a href="#" onclick="editProductDetailsModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a> <a href="#" onclick="deleteProductDetailsModel(this,' + row.recId + ')"><i class="fas fa-trash text-danger"></i></a> ';
                return html;
            }
        }

    ],
    columnDefs: columnDefstMiscellaneous,
});

//options 
// Show modal when "Add Row" button is clicked
$('#addtMiscellaneousSheets').on('click', function () {
    resetModalInputs();
    isCreate = true;
    $('#modalAddtMiscellaneousSheets').modal('show');

});

// Close modal when the modal's close button is clicked
$('.close').on('click', function () {
    $('#modalAddtMiscellaneousSheets').modal('hide');

});

// Save row data when "Save" button in the modal is clicked
var isCreate = true;
var oldClassId = '';
$('#saveRowBtntMiscellaneousSheets').on('click', function () {

    if (!$("#modelStep3").valid()) {
        toastr.warning("Please Fill Required Fields", "Required");
        return;
    }
    var productId = productID;
    var classId = $('#txtClassid').val();
    var amlAmount = $('#txtAmount').val();
    var costPolicy = $('#txtCostpolicy').val();
    var adminFees = $('#txtAdminfees').val();
    var firstYearDiscount = $('#txtFirstYeardiscount').val();
    var commision = $('#txtCommision').val();

    // Example usage:
    var table = $('#tMiscellaneous').DataTable();
    var columnIndex = 1; // Replace with the index of the column you want to check
    var valueToCheck = classId; // Replace with the value you want to check
    var isRepeated = isValueExistInColumn(table, columnIndex, parseInt(valueToCheck));

    if (isRepeated) {
        console.log(valueToCheck + ' is repeated in column ' + columnIndex);
    } else {
        console.log(valueToCheck + ' is not repeated in column ' + columnIndex);
    }
    // Check if the class is already selected
    if (isRepeated && isCreate) {

        toastr.warning("Class is already Selected", "Duplicate");
        return;
    } else if (isRepeated && !isCreate && classId != oldClassId) {
        toastr.warning("Class is already Selected", "Duplicate");
        return;
    }
    var obj = {};
    var objProduct = {};
    objProduct.ProductId = parseFloat(productId);
    objProduct.ClassId = parseFloat(classId);
    objProduct.AmlAmount = parseFloat(amlAmount);
    objProduct.CostPolicy = parseFloat(costPolicy);
    objProduct.FirstYearDiscount = firstYearDiscount;
    objProduct.Commision = parseFloat(commision);
    objProduct.AdminFees = parseFloat(adminFees);

    objProduct.CostPolicyAmount = parseFloat($('#txtCostPolicyAmount').val());
    objProduct.FixedTaxAmount = parseFloat($('#txtFixedTaxAmount').val());
    objProduct.ProperTaxPer = parseFloat($('#txtPropTaxPer').val());
    objProduct.VATPer = parseFloat($('#txtVATPer').val());
    objProduct.IsActive = true;


    if (isCreate) {
        obj.ProductDetails = objProduct;
        var formBody = new FormData();
        formBody.append("productdetails", JSON.stringify(obj));
        $.ajax({
            url: "/Product/CreateProductDetails",
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

                    // Get the select element
                    var dropdown = document.getElementById("txtClassid");

                    // Get the selected option
                    var selectedOption = dropdown.options[dropdown.selectedIndex];

                    // Get the selected option's text
                    var selectedText = selectedOption.text;
                    tMiscellaneous.row.add({

                        productId: productId,
                        classId: classId,
                        amlAmount: amlAmount,
                        costPolicy: costPolicy,
                        adminFees: adminFees,
                        firstYearDiscount: firstYearDiscount,
                        commision: commision,
                        isActive: true,
                        recId: data.productDetails.recId,
                        costPolicyAmount: objProduct.CostPolicyAmount,
                        fixedTaxAmount: objProduct.FixedTaxAmount,
                        properTaxPer: objProduct.ProperTaxPer,
                        vatPer: objProduct.VATPer,
                    }).draw(false);
                    resetModalInputs();
                    $("#btnCloseModalMiscellaneous").click();
                    //  window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product Details");

            }
        });
    } else {
        objProduct.RecId = $('#txtRecId').val();
        obj.ProductDetails = objProduct;
        var formBody = new FormData();
        formBody.append("productdetails", JSON.stringify(obj));

        $.ajax({
            url: "/Product/EditProductDetails",
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


                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                    toastr.success("", "Saved");
                    var editModel = {

                        productId: productId,
                        classId: classId,
                        amlAmount: amlAmount,
                        costPolicy: costPolicy,
                        adminFees: adminFees,
                        firstYearDiscount: firstYearDiscount,
                        commision: commision,
                        isActive: true,
                        costPolicyAmount: objProduct.CostPolicyAmount,
                        fixedTaxAmount: objProduct.FixedTaxAmount,
                        properTaxPer: objProduct.ProperTaxPer,
                        vatPer: objProduct.VATPer,
                        recId: $('#txtRecId').val(),
                    }

                    // Redraw the row to reflect the updated data
                    currentRowSelected.data(editModel).draw();

                    resetModalInputs();
                    $("#btnCloseModalMiscellaneous").click();
                    //  window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product Details");

            }
        });
    }

    // Add the class ID to the selected list
    selectedClassIds.push(classId);
});
function resetModalInputs() {
    $('#txtClassid').val("");
    $('#txtRecId').val(0);
    $('#txtAmount').val(0);
    $('#txtCostpolicy').val(0);
    $('#txtAdminfees').val(0);
    $('#txtFirstYeardiscount').val(0);
    $('#txtCommision').val(0);
    $('#txtCostPolicyAmount').val(0);
    $('#txtFixedTaxAmount').val(0);
    $('#txtPropTaxPer').val(0);
    $('#txtVATPer').val(0);
}
var currentRowSelected;
var currentRowSelectedCombination;
function editProductDetailsModel(sender, id) {
    var tr = $(sender).closest('tr');
    currentRowSelected = tMiscellaneous.row(tr);


    // var model = productDetails.find(x => x.recId == id);
    var model = currentRowSelected.data();
    if (model != null) {
        oldClassId = model.classId;
        $('#txtRecId').val(model.recId);
        $('#txtClassid').val(model.classId);
        $('#txtAmount').val(model.amlAmount);
        $('#txtCostpolicy').val(model.costPolicy);
        $('#txtAdminfees').val(model.adminFees);
        $('#txtFirstYeardiscount').val(model.firstYearDiscount);
        $('#txtCommision').val(model.commision);
        $('#txtCostPolicyAmount').val(model.costPolicyAmount);
        $('#txtFixedTaxAmount').val(model.fixedTaxAmount);
        $('#txtPropTaxPer').val(model.properTaxPer);
        $('#txtVATPer').val(model.vatPer);
    } else {

    }
    isCreate = false;
    $('#modalAddtMiscellaneousSheets').modal('show');
}
function deleteProductDetailsModel(sender, rowDataJson) {
    var tr = $(sender).closest('tr');
    currentRowSelected = tMiscellaneous.row(tr);
    var model = currentRowSelected.data();
    Swal.fire(
        {
            title: "Are you sure?",
            text: "You will not be able to recover this row!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false,
        }).then((result) => {
            if (result.value) {

                var obj = {};
                var objProduct = {};
                objProduct.ProductId = parseFloat(productID);
                objProduct.ClassId = parseFloat(model.classId);
                objProduct.AmlAmount = parseFloat(model.amlAmount);
                objProduct.CostPolicy = parseFloat(model.costPolicy);
                objProduct.FirstYearDiscount = parseFloat(model.firstYearDiscount);
                objProduct.Commision = parseFloat(model.commision);
                objProduct.AdminFees = parseFloat(model.adminFees);
                objProduct.RecId = model.recId;
                objProduct.Active = false;


                obj.ProductDetails = objProduct;
                var formBody = new FormData();
                formBody.append("productdetails", JSON.stringify(obj));
                $.ajax({
                    url: "/Product/EditProductDetails",
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


                        if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                            currentRowSelected.remove().draw();

                            swal("Deleted!", "Your row has been deleted.", "success");
                        } else {
                            toastr.warning(data.webResponseCommon.returnMessage, "UnDelete");
                        }
                    },
                    error: function (xhr, status, error) {
                        hideLoading();
                        toastr.error(error, "Error Deleting Product Details");

                    }
                });
            }
        });
}
//////////////////////////////////////////////technical sheet/////////////////////////////////////////////////////
//Table tTechnicalSheets Start
var columnConfigtTechnicalSheets = [

    { data: 'productId', title: 'Product', },
    { data: 'technicalSheet', title: 'Technical Sheet' },
    { data: 'sectionId', title: 'Section' },
    { data: 'covered', title: 'Covered' },
    //{ data: 'territorialScope', title: 'Territorial Scope' },
    { data: 'classId', title: 'Class' },
    { data: 'commissionInsurance', title: 'Commission Insurance' },
    { data: 'limitAmount', title: 'Limit Amount' },
    // { data: 'limitAmountMaxRange', title: 'Limit Amount Max Range' },
    { data: 'networkId', title: 'Network' },
    { data: 'recId', title: 'ID', },
];
var columnDefstTechnicalSheets = columnConfigtTechnicalSheets.map(function (column, index) {
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
//var technicalSheetList = $(productDetailsPOIs.map(x => x.technicalSheet)).sort(function (a, b) {
//    return a - b;
//}).get();
//technicalSheetList.push(null);
var tTechnicalSheets = $('#tTechnicalSheets').DataTable({
    data: productDetailsPOIs.sort((a, b) => parseFloat(a.technicalSheet) - parseFloat(b.technicalSheet)),
    responsive: true,
    autoWidth: true,
    columns: [
        { data: 'productId', title: 'Product', },
        { data: 'technicalSheet', title: 'Technical Sheet', },
        {
            data: 'sectionId', title: 'Section',
            render: function (data, type, row) {

                var model = productDetailsPOISections.find(x => x.recId == data);
                if (model != null) {
                    return model.description
                } else {
                    return '';
                }
            }
        },
        {
            data: 'covered', title: 'Covered', render: function (data, type, row) {

                //if (data) {
                //    return '<input type="checkbox"  class="material-inputs filled-in chk-col-teal" checked="">';
                //} else {
                //    return '<input type="checkbox"  class="material-inputs filled-in chk-col-teal"';
                //}
                if (data) {
                    return 'Yes';
                } else {
                    return 'No';
                }
            }
        },
        {
            data: 'territorialScope', title: 'Territorial Scope',
            render: function (data, type, row) {

                var model = productTerritorialScope.find(x => x.recId == data);
                if (model != null) {
                    return model.description
                } else {
                    return '';
                }
            }
        },
        {
            data: 'classId', title: 'Class', render: function (data, type, row) {
                var model = productClassOfCoverage.find(x => x.recId == data);
                if (model != null) {
                    return model.description
                } else {
                    return '';
                }
            }
        },
        { data: 'commissionInsurance', title: 'Co-Insurance' },
        { data: 'limitAmount', title: 'Limit Amount' },
        //  { data: 'limitAmountMaxRange', title: 'Limit Amount Max Range' },
        {
            data: 'networkId', title: 'Network',
            render: function (data, type, row) {
                var model = productDetailsPOINetworks.find(x => x.recId == data);
                if (model != null) {
                    return model.networkExplanation
                } else {
                    return '';
                }
            }
        },
        {
            data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                var html = '<a href="#" onclick="editTechnicalSheetsModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a> <a href="#" onclick="deleteTechnicalSheetsModel(this,' + row.recId + ')"><i class="fas fa-trash text-danger"></i></a> ';
                return html;
            }
        }

    ],
    columnDefs: columnDefstTechnicalSheets,
});

$('#addtTechnicalSheets').on('click', function () {
    resetTechnicalModalInputs();
    isCreate = true;
    var totalRowCount = tTechnicalSheets.rows().count();
    $('#txtTechnicalSheet').val(totalRowCount + 1);
    $('#modalAddtTechnicalSheets').modal('show');
});

// Close modal when the modal's close button is clicked
$('.close').on('click', function () {
    $('#modalAddtTechnicalSheets').modal('hide');
});
function editTechnicalSheetsModel(sender, id) {
    var tr = $(sender).closest('tr');
    currentRowSelected = tTechnicalSheets.row(tr);


    // var model = productDetails.find(x => x.recId == id);
    var model = currentRowSelected.data();
    if (model != null) {
        oldClassId = model.classId;
        $('#txtRecIdStep4').val(model.recId);
        $('#txtTechnicalSheet').val(model.technicalSheet);
        $('#txtSectionId').val(model.sectionId);
        $('#chkCovered').val(model.covered.toString());
        $('#txtTerritorialScope').val(model.territorialScope);
        $('#txtClass').val(model.classId);
        $('#txtCommissionInsurance').val(model.commissionInsurance);
        $('#txtLimitAmount').val(model.limitAmount);
        //    $('#txtLimitAmountMaxRange').val(model.limitAmountMaxRange);
        $('#txtNetworkId').val(model.networkId);
    } else {

    }
    isCreate = false;
    $('#modalAddtTechnicalSheets').modal('show');
}
function deleteTechnicalSheetsModel(sender, rowDataJson) {
    var tr = $(sender).closest('tr');
    currentRowSelected = tTechnicalSheets.row(tr);
    var model = currentRowSelected.data();
    if (searchForValueIfExist($('#tCombinations').DataTable().data().toArray(), model.technicalSheet)) {
        toastr.warning("Already used in Combinations", "Can't Delete");
    } else {
        Swal.fire(
            {
                title: "Are you sure?",
                text: "You will not be able to recover this row!",
                type: "warning",
                showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!",
                closeOnConfirm: false,
            }).then((result) => {
                if (result.value) {

                    var obj = {};
                    var objProduct = {};
                    objProduct.RecId = parseFloat(model.recId);
                    objProduct.ProductId = parseFloat(productID);
                    objProduct.TechnicalSheet = parseFloat(model.technicalSheet);
                    objProduct.SectionId = parseFloat(model.sectionId);
                    objProduct.Covered = Boolean(model.covered);
                    objProduct.TerritorialScope = parseFloat(model.territorialScope);
                    objProduct.ClassId = parseFloat(model.classId);
                    objProduct.CommissionInsurance = parseFloat(model.commissionInsurance);
                    objProduct.LimitAmount = parseFloat(model.limitAmoun);
                    // objProduct.LimitAmountMaxRange = parseFloat(model.limitAmountMaxRange);
                    objProduct.NetworkId = model.networkId;
                    objProduct.Active = false;


                    obj.ProductDetails = objProduct;
                    var formBody = new FormData();
                    formBody.append("productdetails", JSON.stringify(obj));
                    $.ajax({
                        url: "/Product/EditProductDetailsPOI",
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


                            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                                currentRowSelected.remove().draw();

                                swal("Deleted!", "Your row has been deleted.", "success");
                            } else {
                                toastr.warning(data.webResponseCommon.returnMessage, "UnDelete");
                            }
                        },
                        error: function (xhr, status, error) {
                            hideLoading();
                            toastr.error(error, "Error Deleting Product Details");

                        }
                    });
                }
            });
    }
    
}
function resetTechnicalModalInputs() {
    $('#txtRecIdStep4').val("");
    $('#txtTechnicalSheet').val(0);
    $('#txtSectionId').val(0);
    $('#chkCovered').val(false);
    $('#txtTerritorialScope').val(0);
    $('#txtClass').val(0);
    $('#txtCommissionInsurance').val(0);
    $('#txtLimitAmount').val(0);
    //$('#txtLimitAmountMaxRange').val(0);
    $('#txtNetworkId').val(0);
}
// Save row data when "Save" button in the modal is clicked
$('#saveRowBtntTechnicalSheets').on('click', function () {
    if (!$("#modelStep4").valid()) {
        toastr.warning("Please Fill Required Fields", "Required");
        return;
    }
    var recid = $('#txtRecIdStep4').val();
    var ts = $('#txtTechnicalSheet').val();
    var sec = $('#txtSectionId').val();
    var cover = $('#txtCovered').val();
    var territory = $('#txtTerritorialScope').val();
    var classid = $('#txtClass').val();
    var commissionins = $('#txtCommissionInsurance').val();
    var lammount = $('#txtLimitAmount').val();
    //   var lamountmax = $('#txtLimitAmountMaxRange').val();
    var network = $('#txtNetworkId').val();
    //if (!(sec != null && territory != null && network != null)) {
    //    toastr.warning("Please Fill Required Fields", "Required");
    //    return;
    //}

    var obj = {};
    var objProduct = {};
    var productId = productID;
    objProduct.ProductId = parseFloat(productID);
    objProduct.TechnicalSheet = parseFloat(ts);
    objProduct.SectionId = parseFloat(sec);
    objProduct.Covered = Boolean(cover);
    objProduct.TerritorialScope = parseFloat(territory);
    objProduct.ClassId = parseFloat(classid);
    objProduct.CommissionInsurance = parseFloat(commissionins);
    objProduct.LimitAmount = parseFloat(lammount);
    // objProduct.LimitAmountMaxRange = parseFloat(lamountmax);
    objProduct.NetworkId = network;
    objProduct.Active = true;


    if (isCreate) {
        obj.ProductDetails = objProduct;
        var formBody = new FormData();
        formBody.append("productdetails", JSON.stringify(obj));
        $.ajax({
            url: "/Product/CreateProductDetailsPOI",
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

                    // Get the select element
                    var dropdown = document.getElementById("txtClassid");

                    // Get the selected option
                    var selectedOption = dropdown.options[dropdown.selectedIndex];

                    // Get the selected option's text
                    var selectedText = selectedOption.text;
                    tTechnicalSheets.row.add({
                        productId: productId,
                        technicalSheet: ts,
                        sectionId: sec,
                        covered: cover,
                        territorialScope: territory,
                        classId: classid,
                        commissionInsurance: commissionins,
                        limitAmount: lammount,
                        // limitAmountMaxRange: lamountmax,
                        networkId: network,
                        recId: recid
                    }).draw(false);

                    resetTechnicalModalInputs();
                    $("#btnClosAddtTechnicalSheets").click();
                    //  window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product Details");

            }
        });
    } else {
        objProduct.RecId = $('#txtRecIdStep4').val();
        obj.ProductDetails = objProduct;
        var formBody = new FormData();
        formBody.append("productdetails", JSON.stringify(obj));

        $.ajax({
            url: "/Product/EditProductDetailsPOI",
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


                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                    toastr.success("", "Saved");
                    var editModel = {
                        productId: productID,
                        technicalSheet: ts,
                        sectionId: sec,
                        covered: cover,
                        territorialScope: territory,
                        classId: classid,
                        commissionInsurance: commissionins,
                        limitAmount: lammount,
                        //  limitAmountMaxRange: lamountmax,
                        networkId: network,
                        isActive: true,
                        recId: $('#txtRecIdStep4').val()
                    }

                    // Redraw the row to reflect the updated data
                    currentRowSelected.data(editModel).draw();

                    resetTechnicalModalInputs();
                    $("#btnClosAddtTechnicalSheets").click();
                    //  window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product Details");

            }
        });
    }

});

//////////////////////////Combination//////////////////////////////////////////////
var tCombinations = $('#tCombinations').DataTable({
    data: productCombinations,
    responsive: true,
    autoWidth: true,
    columns: [
        // { data: 'recId', title: 'ID', },
        { data: 'productId', title: 'Product', },
        { data: 'technicalSheet1', title: 'Sheet 1' },
        { data: 'technicalSheet2', title: 'Sheet 2' },
        { data: 'technicalSheet3', title: 'Sheet 3' },
        { data: 'technicalSheet4', title: 'Sheet 4' },
        { data: 'technicalSheet5', title: 'Sheet 5' },
        { data: 'technicalSheet6', title: 'Sheet 6' },
        { data: 'technicalSheet7', title: 'Sheet 7' },
        { data: 'technicalSheet8', title: 'Sheet 8' },
        {
            data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                var html = '<a href="#" onclick="editCombinationModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a> <a href="#" onclick="deleteCombinations(this,' + row.recId + ')"><i class="fas fa-trash text-danger"></i></a> ';
                return html;
            }
        }

    ]
});

function resetCombinationFields() {
    $('#ddlTsheet1').prop('disabled', false);
    $('#ddlTsheet2').prop('disabled', true);
    $('#ddlTsheet3').prop('disabled', true);
    $('#ddlTsheet4').prop('disabled', true);
    $('#ddlTsheet5').prop('disabled', true);
    $('#ddlTsheet6').prop('disabled', true);
    $('#ddlTsheet7').prop('disabled', true);
    $('#ddlTsheet8').prop('disabled', true);
    $('#ddlTsheet1').val("");
    $('#ddlTsheet2').val("");
    $('#ddlTsheet3').val("");
    $('#ddlTsheet4').val("");
    $('#ddlTsheet5').val("");
    $('#ddlTsheet6').val("");
    $('#ddlTsheet7').val("");
    $('#ddlTsheet8').val("");

}
function editCombinationModel(sender, id) {
    var tr = $(sender).closest('tr');
    currentRowSelectedCombination = tCombinations.row(tr);


    // var model = productDetails.find(x => x.recId == id);
    var model = currentRowSelectedCombination.data();
    if (model != null) {
        oldClassId = model.classId;
        $("#txtRecIdStep6").val(model.recId);

        $('#ddlTsheet1').val(model.technicalSheet1);
        $('#ddlTsheet2').val(model.technicalSheet2);
        $('#ddlTsheet3').val(model.technicalSheet3);
        $('#ddlTsheet4').val(model.technicalSheet4);
        $('#ddlTsheet5').val(model.technicalSheet5);
        $('#ddlTsheet6').val(model.technicalSheet6);
        $('#ddlTsheet7').val(model.technicalSheet7);
        $('#ddlTsheet8').val(model.technicalSheet8);
        if (model.technicalSheet1 > 0) {
            $('#ddlTsheet1').prop('disabled', false);
        }
        if (model.technicalSheet2 > 0) {
            $('#ddlTsheet2').prop('disabled', false);
        }
        if (model.technicalSheet3 > 0) {
            $('#ddlTsheet3').prop('disabled', false);
        }
        if (model.technicalSheet4 > 0) {
            $('#ddlTsheet4').prop('disabled', false);
        }
        if (model.technicalSheet5 > 0) {
            $('#ddlTsheet5').prop('disabled', false);
        }
        if (model.technicalSheet6 > 0) {
            $('#ddlTsheet6').prop('disabled', false);
        }
        if (model.technicalSheet7 > 0) {
            $('#ddlTsheet7').prop('disabled', false);
        }
        if (model.technicalSheet8 > 0) {
            $('#ddlTsheet8').prop('disabled', false);
        }
    } else {

    }
    isCreate = false;
    $('#modalCombinations').modal('show');
}
$('#addtCombinations').on('click', function () {
    resetCombinationFields();
    isCreate = true;
    $('#modalCombinations').modal('show');
});

// Close modal when the modal's close button is clicked
$('.close').on('click', function () {
    $('#modalCombinations').modal('hide');
});
$('#saveRowCombinations').on('click', function () {
    var obj = {};
    var objProduct = {};
    objProduct.ProductId = parseInt(productID);
    objProduct.RecId = parseInt($("#txtRecIdStep6").val());
    objProduct.TechnicalSheet1 = $('#ddlTsheet1').val();
    objProduct.TechnicalSheet2 = $('#ddlTsheet2').val();
    objProduct.TechnicalSheet3 = $('#ddlTsheet3').val();
    objProduct.TechnicalSheet4 = $('#ddlTsheet4').val();
    objProduct.TechnicalSheet5 = $('#ddlTsheet5').val();
    objProduct.TechnicalSheet6 = $('#ddlTsheet6').val();
    objProduct.TechnicalSheet7 = $('#ddlTsheet7').val();
    objProduct.TechnicalSheet8 = $('#ddlTsheet8').val();

    function isSequenceUnique(newRow) {
        // Get all the data from the DataTable
        var data = tCombinations.data().toArray();

        // Extract the sequences from the existing rows
        var existingSequences = data.map(row => [
            row.technicalSheet1,
            row.technicalSheet2,
            row.technicalSheet3,
            row.technicalSheet4,
            row.technicalSheet5,
            row.technicalSheet6,
            row.technicalSheet7,
            row.technicalSheet8
        ]);

        // Extract the sequence from the new row
        var newSequence = [
            newRow.TechnicalSheet1,
            newRow.TechnicalSheet2,
            newRow.TechnicalSheet3,
            newRow.TechnicalSheet4,
            newRow.TechnicalSheet5,
            newRow.TechnicalSheet6,
            newRow.TechnicalSheet7,
            newRow.TechnicalSheet8
        ];

        // Check if the new sequence is unique
        for (var i = 0; i < existingSequences.length; i++) {
            if (arraysEqual(existingSequences[i], newSequence)) {
                return false;
            }
        }

        return true;
    }

    // Helper function to check if two arrays are equal
    function arraysEqual(a, b) {
        if (a === b) return true;
        if (a == null || b == null) return false;
        if (a.length != b.length) return false;

        // If you don't care about the order of the elements inside
        // the array, you should sort both arrays here.

        for (var i = 0; i < a.length; ++i) {
            if (a[i] !== b[i]) return false;
        }

        return true;
    }


    if (isSequenceUnique(objProduct)) {
        console.log("unik")
    } else {
        console.log("mech unik")
    }


    obj.ProductCombination = objProduct;
    var formBody = new FormData();
    formBody.append("product", JSON.stringify(obj));
    if (isCreate) {



        $.ajax({
            url: "/Product/CreateProductCombination",
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


                    tCombinations.row.add({
                        productId: productID,
                        technicalSheet1: objProduct.TechnicalSheet1,
                        technicalSheet2: objProduct.TechnicalSheet2,
                        technicalSheet3: objProduct.TechnicalSheet3,
                        technicalSheet4: objProduct.TechnicalSheet4,
                        technicalSheet5: objProduct.TechnicalSheet5,
                        technicalSheet6: objProduct.TechnicalSheet6,
                        technicalSheet7: objProduct.TechnicalSheet7,
                        technicalSheet8: objProduct.TechnicalSheet8,
                    }).draw(false);

                    resetCombinationFields();
                    $("#btnClosCombinations").click();
                    //  window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Creating Product Combination");

            }
        });
    } else {

        $.ajax({
            url: "/Product/EditProductCombination",
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


                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                    toastr.success("", "Saved");
                    var editModel = {
                        recId: objProduct.RecId,
                        productId: productID,
                        technicalSheet1: objProduct.TechnicalSheet1,
                        technicalSheet2: objProduct.TechnicalSheet2,
                        technicalSheet3: objProduct.TechnicalSheet3,
                        technicalSheet4: objProduct.TechnicalSheet4,
                        technicalSheet5: objProduct.TechnicalSheet5,
                        technicalSheet6: objProduct.TechnicalSheet6,
                        technicalSheet7: objProduct.TechnicalSheet7,
                        technicalSheet8: objProduct.TechnicalSheet8,
                    }

                    // Redraw the row to reflect the updated data
                    currentRowSelectedCombination.data(editModel).draw();

                    resetCombinationFields();
                    $("#btnClosCombinations").click();
                    //  window.location.href = "/Product/Index?isactive=1";
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Editing Product Combination");

            }
        });
    }

});
function deleteCombinations(sender, rowDataJson) {
    var tr = $(sender).closest('tr');
    currentRowSelectedCombination = tCombinations.row(tr);
    var model = currentRowSelectedCombination.data();
    Swal.fire(
        {
            title: "Are you sure?",
            text: "You will not be able to recover this row!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false,
        }).then((result) => {
            if (result.value) {

                var obj = {};
                var objProduct = {};
                objProduct.ProductId = parseFloat(productID);
                objProduct.ClassId = parseFloat(model.classId);
                objProduct.AmlAmount = parseFloat(model.amlAmount);
                objProduct.CostPolicy = parseFloat(model.costPolicy);
                objProduct.FirstYearDiscount = parseFloat(model.firstYearDiscount);
                objProduct.Commision = parseFloat(model.commision);
                objProduct.AdminFees = parseFloat(model.adminFees);
                objProduct.RecId = model.recId;
                objProduct.Active = false;


                obj.ProductDetails = objProduct;
                var formBody = new FormData();
                formBody.append("productdetails", JSON.stringify(obj));
                $.ajax({
                    url: "/Product/EditProductDetails",
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


                        if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                            currentRowSelectedCombination.remove().draw();

                            swal("Deleted!", "Your row has been deleted.", "success");
                        } else {
                            toastr.warning(data.webResponseCommon.returnMessage, "UnDelete");
                        }
                    },
                    error: function (xhr, status, error) {
                        hideLoading();
                        toastr.error(error, "Error Deleting Product Details");

                    }
                });
            }
        });
}


$(document).ready(function () {
    var $dropdowns = $('.tsheetddl'); // Get a reference to all the dropdowns
    var numOptions = 8; // Adjust this to match the number of options in each dropdown

    // Initialize each dropdown
    $dropdowns.each(function (i, dropdown) {
        var $dropdown = $(dropdown);

        //// Populate the dropdown with options
        //for (var j = 1; j <= numOptions; j++) {
        //    $dropdown.append(new Option(j, j));
        //}

        // When an option is selected, check if it's not null and then enable the next dropdown and disable the selected option in all other dropdowns
        $dropdown.on('change', function () {
            var selectedValue = this.value;

            // Check if the selected value is not null
            if (selectedValue) {
                // Enable the next dropdown
                if (i < $dropdowns.length - 1) {
                    $dropdowns.eq(i + 1).prop('disabled', false);
                }

                // Disable the selected option in all other dropdowns
                $dropdowns.not(this).each(function () {
                    var $otherDropdown = $(this);
                    $otherDropdown.children('option[value=' + selectedValue + ']').prop('disabled', true);

                    // Sort the options to maintain their original order
                    $otherDropdown.html($otherDropdown.children('option').sort(function (a, b) {
                        return a.index - b.index;
                    }));
                });
            }
        });
    });
});

// Select all dropdown elements with class "mySelect" and populate them
//$(".tsheetddl").each(function () {
//    var select = $(this); // Current select element
//    $.each(technicalSheetList, function (index, value) {
//        select.append($("<option>").text(value).val(value));
//    });
//});
function filterAddForGrid(sender) {
    var column = sender;
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
        select.append('<option value="' + d + '">' + d + '</option>');
    });
}
var tPrice = $('#tPrice').DataTable({
    data: productPrice,
    responsive: true,
    autoWidth: true,
    columns: [

        { data: 'recId', title: 'RecId' },
        { data: 'productId', title: 'Product' },
        { data: 'technicalSheet', title: 'Technical Sheet' },
        { data: 'familyCountMinRange', title: 'Family Min Range' },
        { data: 'familyCountMaxRange', title: 'Family Max Range' },
        { data: 'period', title: 'Period' },
        { data: 'daysCountMinRange', title: 'Days Min Range' },
        { data: 'daysCountMaxRange', title: 'Days Max Range' },
        { data: 'dependency', title: 'Dependency' },
        { data: 'gender', title: 'Gender' },
        { data: 'maritalStatus', title: 'Marital Status' },
        { data: 'costSharing', title: 'Cost Sharing' },
        { data: 'ageMinRange', titlageMaxRangee: 'Age Min' },
        { data: 'ageMaxRange', title: 'Age Max' },
        { data: 'rate', title: 'Rate' },
        { data: 'premium', title: 'Premium ' },
        { data: 'paPremiium', title: 'Pa Premium' },
        { data: 'nbrChildFree', title: 'Child Free #' },
        //{ data: 'IsActive', title: 'IsActive' },

    ],
    initComplete: function () {
        this.api().columns(2).every(function () {
            filterAddForGrid(this);
        }),
        this.api().columns(3).every(function () {
            filterAddForGrid(this);
        }),
        this.api().columns(8).every(function () {
            filterAddForGrid(this);
        });
        this.api().columns(9).every(function () {
            filterAddForGrid(this);
        });
        this.api().columns(10).every(function () {
            filterAddForGrid(this);
        });
    }
});

// Define the mapping
var columnMapping = {
    '070806': ["RecId", "Product", "Technical Sheet", "Gender", "Age Min", "Age Max", "Premium "],
    '281609': ["RecId", "Product", "Technical Sheet", "Gender", "Age Min", "Age Max", "Premium "],


    '021502': ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Period", "Days Min Range", "Days Max Range", "Age Min", "Age Max", "Premium ", "Child Free #"],
    '010602': ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Period", "Days Min Range", "Days Max Range", "Age Min", "Age Max", "Premium ", "Child Free #"],

    "311703": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Dependency", "Gender", "Marital Status", "Cost Sharing", "Age Min", "Age Max", "Premium", "Pa Premium"],
    "090703": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Dependency", "Gender", "Marital Status", "Cost Sharing", "Age Min", "Age Max", "Premium", "Pa Premium"],
    "080501": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Dependency", "Gender", "Marital Status", "Cost Sharing", "Age Min", "Age Max", "Premium", "Pa Premium"],
    "301401": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Dependency", "Gender", "Marital Status", "Cost Sharing", "Age Min", "Age Max", "Premium", "Pa Premium"],
    "321110": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Dependency", "Gender", "Marital Status", "Cost Sharing", "Age Min", "Age Max", "Premium", "Pa Premium"],

    "061005": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Gender", "Marital Status", "Age Min", "Age Max", "Rate", "Premium "],
    "291908": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Gender", "Marital Status", "Age Min", "Age Max", "Rate", "Premium "],
    "030904": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Gender", "Marital Status", "Age Min", "Age Max", "Rate", "Premium "],
    "051807": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Gender", "Marital Status", "Age Min", "Age Max", "Rate", "Premium "],
    "331211": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Gender", "Marital Status", "Age Min", "Age Max", "Rate", "Premium "],
    "041312": ["RecId", "Product", "Technical Sheet", "Family Min Range", "Family Max Range", "Gender", "Marital Status", "Age Min", "Age Max", "Rate", "Premium "],

};


// Hide the columns
// Iterate over each column
//tPrice.columns().visible(false)
tPrice.columns().every(function () {
    var column = this;
    //var title = column.header().innerHTML;
    var title = column.header().textContent;
    //column.visible(false);
    // Check if the column title should be hidden for the current BusinessLineCode
    column.visible(columnMapping[BusinessLineCode].some(function (columnName) {
        return title.split("---")[0].includes(columnName);
    }));
    //columnMapping[BusinessLineCode].forEach(function (columnName) {
    //    if (title.split("---")[0].includes(columnName)) { 
    //  //  if (column.header().textContent.includes(columnName.toLowerCase())) {
    //        column.visible(false);
    //    } else {
    //        column.visible(true);
    //    }
    //    //var columnIndex = tPrice.column(columnName.toLowerCase() + ':name').index();
    //   // tPrice.column(columnIndex).visible(false);
    //});
    // Check if the column title should be hidden
    //if (columnMapping[BusinessLineCode].indexOf(title) !== -1) {
    //    column.visible(true);
    //} else {
    //    column.visible(false);
    //}
});
$("#btnUploadPrice").click(function () {
    document.getElementById('fileInput').click();
});
const tableBodyPrice = document.getElementById('tPrice');
//var dataList = [];
$('#fileInput').change(function () {
    var fileName = $(this).val();
    if (fileName != '') {
        var file = this.files[0]; // Get the selected file

        // Create a new FormData object and append the selected file to it
        var formData = new FormData();
        formData.append('file', file);
        formData.append('code', productID);

        $.ajax({
            type: 'POST',
            url: '/ExcelImport/ImportExcelProductPrice',
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
                        // Clear the existing data
                        tPrice.clear();

                        // Add new data
                        tPrice.rows.add(result.data); // replace newData with your new list

                        // Redraw the table
                        tPrice.draw();
                        //formCount = 0;
                        //                        $("#tPrice").html("");

                        //                        // Assuming your list is named 'dataList'
                        //                        for (let i = 0; i < result.data.length; i++) {
                        //                            const data = result.data[i];
                        //                            const row = document.createElement('tr');

                        //                            // Populate the row with object properties
                        //                            row.innerHTML = `
                        //    <td data-recId="${data.recId}">${data.recId}</td>
                        //    <td data-productId="${data.productId}">${data.productId}</td>
                        //    <td data-technicalSheet="${data.technicalSheet}">${data.technicalSheet}</td>
                        //    <td data-familyCountMinRange="${data.familyCountMinRange}">${data.familyCountMinRange}</td>
                        //    <td data-familyCountMaxRange="${data.familyCountMaxRange}">${data.familyCountMaxRange}</td>
                        //    <td data-period="${data.period}">${data.period}</td>
                        //    <td data-daysCountMinRange="${data.daysCountMinRange}">${data.daysCountMinRange}</td>
                        //    <td data-daysCountMaxRange="${data.daysCountMaxRange}">${data.daysCountMaxRange}</td>
                        //    <td data-dependency="${data.dependency}">${data.dependency}</td>
                        //    <td data-gender="${data.gender}">${data.gender}</td>
                        //    <td data-maritalStatus="${data.maritalStatus}">${data.maritalStatus}</td>
                        //    <td data-costSharing="${data.costSharing}">${data.costSharing}</td>
                        //    <td data-ageMinRange="${data.ageMinRange}">${data.ageMinRange}</td>
                        //    <td data-ageMaxRange="${data.ageMaxRange}">${data.ageMaxRange}</td>
                        //    <td data-rate="${data.rate}">${data.rate}</td>
                        //    <td data-premium="${data.premium}">${data.premium}</td>
                        //    <td data-paPremiium="${data.paPremiium}">${data.paPremiium}</td>
                        //`;
                        //                            // Append the row to the table body
                        //                            tableBodyPrice.appendChild(row);
                        //                        }
                    }
                } else if (result.status == "warning") {
                    toastr.warning(result.message, "Fix Excel");
                } else {
                    toastr.error("Please fix excel:" + result.message, "Error");
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

$("#btnExportPrice").click(function () {
    var data = tPrice.rows().data();
    var list = [];
    for (var i = 0; i < data.length; i++) {
        var row = data[i];
        var obj = {
            recId: row.recId,
            productId: row.productId,
            technicalSheet: row.technicalSheet,
            familyCountMinRange: row.familyCountMinRange,
            familyCountMaxRange: row.familyCountMaxRange,
            period: row.period,
            daysCountMinRange: row.daysCountMinRange,
            daysCountMaxRange: row.daysCountMaxRange,
            dependency: row.dependency,
            gender: row.gender,
            maritalStatus: row.maritalStatus,
            costSharing: row.costSharing,
            ageMinRange: row.ageMinRange,
            ageMaxRange: row.ageMaxRange,
            rate: row.rate,
            premium: row.premium,
            paPremiium: row.paPremiium,
            isActive: row.isActive
        };
        list.push(obj);
    }
    //const dataList = []; // Create an empty list to store the objects
    //var tableRows = document.querySelectorAll('#tPrice tr');
    //tableRows.forEach((row) => {
    //    const data = {}; // Create an empty object for each row



    //    data.recId = row.querySelector('[data-recId]').textContent;
    //    data.productId = row.querySelector('[data-productId]').textContent;
    //    data.technicalSheet = row.querySelector('[data-technicalSheet]').textContent;
    //    data.familyCountMinRange = row.querySelector('[data-familyCountMinRange]').textContent;
    //    data.familyCountMaxRange = row.querySelector('[data-familyCountMaxRange]').textContent;
    //    data.period = row.querySelector('[data-period]').textContent;
    //    data.daysCountMinRange = row.querySelector('[data-daysCountMinRange]').textContent;
    //    data.daysCountMaxRange = row.querySelector('[data-daysCountMaxRange]').textContent;
    //    data.dependency = row.querySelector('[data-dependency]').textContent;
    //    data.gender = row.querySelector('[data-gender]').textContent;
    //    data.maritalStatus = row.querySelector('[data-maritalStatus]').textContent;
    //    data.costSharing = row.querySelector('[data-costSharing]').textContent;
    //    data.ageMinRange = row.querySelector('[data-ageMinRange]').textContent;
    //    data.ageMaxRange = row.querySelector('[data-ageMaxRange]').textContent;
    //    data.rate = row.querySelector('[data-rate]').textContent;
    //    data.premium = row.querySelector('[data-premium]').textContent;
    //    data.paPremiium = row.querySelector('[data-paPremiium]').textContent;

    //    dataList.push(data); // Add the object to the list
    //});
    var formData = new FormData();
    formData.append('data', JSON.stringify(list));
    formData.append('combination', JSON.stringify(tCombinations.rows().data().toArray()));
    formData.append('technical', JSON.stringify(tTechnicalSheets.rows().data().toArray()));
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('businessPage', JSON.stringify("AF1_2"));
    formData.append('type', JSON.stringify("PL"));
    $.ajax({
        type: 'POST',
        url: '/product/ExportExcelProductPrice',
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
$("#btnSubmit").click(function () {
    var dataList = []; // Create an empty list to store the objects

    tPrice.rows().every(function () {
        var row = this.data(); // Get data of the current row
        var rowData = {
            recId: row.recId,
            productId: row.productId,
            technicalSheet: row.technicalSheet,
            familyCountMinRange: row.familyCountMinRange,
            familyCountMaxRange: row.familyCountMaxRange,
            period: row.period,
            daysCountMinRange: row.daysCountMinRange,
            daysCountMaxRange: row.daysCountMaxRange,
            dependency: row.dependency,
            gender: row.gender,
            maritalStatus: row.maritalStatus,
            costSharing: row.costSharing,
            ageMinRange: row.ageMinRange,
            ageMaxRange: row.ageMaxRange,
            rate: row.rate,
            premium: row.premium,
            paPremiium: row.paPremiium,
            nbrChildFree: row.nbrChildFree,
            isActive: row.isActive
        };
        dataList.push(rowData); // Add the object to the list
    });
    var formData = new FormData();
    var obj = {};
    obj.ProductPriceList = dataList;
    formData.append('product', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Product/CreateProductPrice',
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
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '201') {
                toastr.success("", "Saved");
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error");
            hideLoading();
        }
    });
})
$("#btnDownloadPriceList").click(function () {

    var formData = new FormData();
    formData.append('businesscode', BusinessLineCode);
    formData.append('contactid', $("#ContactId").val());
    formData.append('type', JSON.stringify("PL"));
    $.ajax({
        type: 'POST',
        url: '/Product/DownloadProductListExcelTemplate',
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
});
///////////////////////////       BENIFIT         /////////////////////////
$("#btnSaveAllBenifits").click(function () {
    var dataList = []; // Create an empty list to store the objects
    var table = $('#tBenifits').DataTable(); // Get the DataTable instance

    table.rows().every(function () {
        var data = this.data(); // Get data of the current row
        var rowData = {
            recId: data.recId,
            productId: data.productId,
            classCode: data.classCode,
            benefitAnswer: data.benefitAnswer,
            benefitNumber: data.benefitNumber,
            benefitName: data.benefitName,
            lifeTime: data.lifeTime,
            excess: data.excess
        };
        dataList.push(rowData); // Add the object to the list
    });
    var formData = new FormData();
    var obj = {};
    obj.ProductBenefitsList = dataList;
    formData.append('product', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Product/ProductBenefitCreate',
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
            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '201') {
                toastr.success("", "Saved");
            } else {
                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
            }
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error downloading Excel file");
            hideLoading();
        }
    });
})
var columnConfigBenifit = [
    { data: 'recId' },
    { data: 'productId' },
    { data: 'classCode', title: 'Class' },
    { data: 'benefitNumber', title: 'Number' },
    { data: 'benefitName', title: 'Name' },
    { data: 'benefitAnswer', title: 'Answer' },
    { data: 'lifeTime', title: 'Life Time' },
    { data: 'excess', title: 'Excess' },
];

var columnDefsBenifit = columnConfigBenifit.map(function (column, index) {
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
var tBenifits;
if (productBenifits != null) {

    tBenifits = $('#tBenifits').DataTable({
        data: productBenifits,
        responsive: true,
        autoWidth: true,
        retrieve: true,
        columns: [
            { data: 'recId' },
            { data: 'productId' },
            { data: 'classCode', title: 'Class' },
            { data: 'benefitNumber', title: 'Number' },
            { data: 'benefitName', title: 'Name' },
            { data: 'benefitAnswer', title: 'Answer' },
            { data: 'lifeTime', title: 'Life Time' },
            { data: 'excess', title: 'Excess' },
            {
                data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                    var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                    // var html = '<a href="#" onclick="editBenifitModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a> <a href="#" onclick="deleteBenifits(this,' + row.recId + ')"><i class="fas fa-trash text-danger"></i></a> ';
                    var html = '<a href="#" onclick="editBenifitModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a>';
                    return html;
                }
            }

        ],
        columnDefs: columnDefsBenifit
    });
    tBenifits.column(0).visible(false);
    tBenifits.column(1).visible(false);
}
$("#btnGetBenifits").click(function () {
    var formData = new FormData();
    var obj = {};
    obj.ProductId = productID;
    formData.append('product', JSON.stringify(obj));
    $.ajax({
        type: 'POST',
        url: '/Product/GetProductBenifits',
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
            tBenifits = $('#tBenifits').DataTable({
                data: data.productBenefitsList,
                responsive: true,
                autoWidth: true,
                retrieve: true,
                columns: [
                    { data: 'recId' },
                    { data: 'productId' },
                    { data: 'classCode', title: 'Class' },
                    { data: 'benefitNumber', title: 'Number' },
                    { data: 'benefitName', title: 'Name' },
                    { data: 'benefitAnswer', title: 'Answer' },
                    { data: 'lifeTime', title: 'Life Time' },
                    { data: 'excess', title: 'Excess' },
                    {
                        data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                            var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                            var html = '<a href="#" onclick="editBenifitModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a> <a href="#" onclick="deleteBenifits(this,' + row.recId + ')"><i class="fas fa-trash text-danger"></i></a> ';
                            return html;
                        }
                    }

                ],
                columnDefs: columnDefsBenifit
            });
            tBenifits.column(0).visible(false);
            tBenifits.column(1).visible(false);
        },
        error: function (xhr, status, error) {
            toastr.error(error, "Error Getting benifits");
            hideLoading();
        }
    });


});
function resetBenifitsFields() {
    // $('#txtClassBenifit').val(0);
    // $('#txtBenifitNumber').val("");
    // $('#txtBenifitName').val("");
    $('#txtBenifitAnswer').val("");
    $('#txtBenifitLifeTime').val("");
    $('#txtBenifitExcess').val("");

}
function editBenifitModel(sender, id) {
    var tr = $(sender).closest('tr');
    currentRowSelectedCombination = tBenifits.row(tr);


    // var model = productDetails.find(x => x.recId == id);
    var model = currentRowSelectedCombination.data();
    if (model != null) {
        oldClassId = model.classId;
        $("#txtRecIdBenifit").val(model.recId);
        $('#txtClassBenifit').val(model.classCode);
        $('#txtBenifitNumber').val(model.benefitNumber);
        $('#txtBenifitName').val(model.benefitName);
        $('#txtBenifitAnswer').val(model.benefitAnswer);
        $('#txtBenifitLifeTime').val(model.lifeTime);
        $('#txtBenifitExcess').val(model.excess);
    } else {

    }
    isCreate = false;
    $('#modalBenifit').modal('show');
}
$('#addBenifitModel').on('click', function () {
    resetBenifitsFields();
    isCreate = true;
    $('#modalBenifit').modal('show');
});

// Close modal when the modal's close button is clicked
$('.close').on('click', function () {
    $('#modalBenifit').modal('hide');
});

$("#saveRowBenifit").click(function () {
    var obj = {};
    var objProduct = {};
    objProduct.ProductId = parseInt(productID);
    objProduct.RecId = parseInt($("#txtRecIdBenifit").val());
    objProduct.ClassCode = $('#txtClassBenifit').val();
    objProduct.BenefitNumber = $('#txtBenifitNumber').val();
    objProduct.BenefitName = $('#txtBenifitName').val();
    objProduct.BenefitAnswer = $('#txtBenifitAnswer').val();
    objProduct.LifeTime = $('#txtBenifitLifeTime').val();
    objProduct.Excess = $('#txtBenifitExcess').val();
    obj.ProductCombination = objProduct;
    var formBody = new FormData();
    //if (isCreate) {


    //    formBody.append("product", JSON.stringify(obj));
    //    $.ajax({
    //        url: "/Product/ProductBenefitCreate",
    //        type: "POST",
    //        contentType: false,
    //        processData: false,
    //        data: formBody,
    //        beforeSend: function (xhr) {
    //            showLoading();
    //            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
    //            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
    //        },
    //        success: function (data) {
    //            hideLoading();


    //            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '201') {
    //                toastr.success("", "Saved");


    //                tBenifits.row.add({
    //                    productId: productId,
    //                    //recId: objProduct.RecId,
    //                    classCode: objProduct.ClassCode,
    //                    benefitNumber: objProduct.BenefitNumber,
    //                    benefitName: objProduct.BenefitName,
    //                    benefitAnswer: objProduct.BenefitAnswer,
    //                    lifeTime: objProduct.LifeTime,
    //                    excess: objProduct.Excess,
    //                }).draw(false);

    //                resetCombinationFields();
    //                $("#btnClosCombinations").click();
    //                //  window.location.href = "/ProdproductBenifitsuct/Index?isactive=1";
    //            } else {
    //                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
    //            }
    //        },
    //        error: function (xhr, status, error) {
    //            hideLoading();
    //            toastr.error(error, "Error Creating Product Combination");

    //        }
    //    });
    //} else {
    //    formBody.append("product", JSON.stringify(obj));

    //    $.ajax({
    //        url: "/Product/EditProductCombination",
    //        type: "POST",
    //        contentType: false,
    //        processData: false,
    //        data: formBody,
    //        beforeSend: function (xhr) {
    //            showLoading();
    //            // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
    //            //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
    //        },
    //        success: function (data) {
    //            hideLoading();


    //            if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
    //                toastr.success("", "Saved");
    var editModel = {
        productId: objProduct.ProductId,
        recId: objProduct.RecId,
        classCode: objProduct.ClassCode,
        benefitNumber: objProduct.BenefitNumber,
        benefitName: objProduct.BenefitName,
        benefitAnswer: objProduct.BenefitAnswer,
        lifeTime: objProduct.LifeTime,
        excess: objProduct.Excess,
    }

    // Redraw the row to reflect the updated data
    currentRowSelectedCombination.data(editModel).draw();

    resetCombinationFields();
    $("#btnSaveAllBenifits").click();
    $("#btnCloseBenifit").click();
    //  window.location.href = "/Product/Index?isactive=1";
    //            } else {
    //                toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
    //            }
    //        },
    //        error: function (xhr, status, error) {
    //            hideLoading();
    //            toastr.error(error, "Error Editing Product Benefit");

    //        }
    //    });
    //}
})
function deleteBenifits() {
    var tr = $(sender).closest('tr');
    currentRowSelected = tBenifits.row(tr);
    var model = currentRowSelected.data();
    Swal.fire(
        {
            title: "Are you sure?",
            text: "You will not be able to recover this row!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false,
        }).then((result) => {
            if (result.value) {


                var obj = {};
                var formBody = new FormData();
                obj.RecId = model.recId;
                formBody.append("product", JSON.stringify(obj));
                $.ajax({
                    url: "/Product/DeleteProductCombination",
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


                        if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                            currentRowSelected.remove().draw();

                            swal("Deleted!", "Your row has been deleted.", "success");
                        } else {
                            toastr.warning(data.webResponseCommon.returnMessage, "UnDelete");
                        }
                    },
                    error: function (xhr, status, error) {
                        hideLoading();
                        toastr.error(error, "Error Deleting Product Details");

                    }
                });
            }
        });
}


function addNumberToValue(id, number) {
    $("#" + id).val(number);
}
function searchForValueIfExist(list, value) {
    const results = [];
    for (const obj of list) {
        for (const key in obj) {
            if (obj[key] === value) {
                return true;
                break; // No need to check other fields in this object
            }
        }
    }
    return false;
}

