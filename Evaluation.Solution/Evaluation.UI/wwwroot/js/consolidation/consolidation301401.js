var policySelectedData = {};
var currentRowSelectedInsured;
var inssudedModelSelectedData;
var policyItems = [];
var countClick = 0;
$(document).ready(function () {
    $('input[type="text"], input[type="file"],select').prop('disabled', true);

    $("#btnDashboard").click(function (e) {
        var params = encodeParameters("?contactId=" + $("#ContactId").val());
        window.location.href = "/transaction/Dashboard/" + params;
    })
    //  "",   
    $('#fileAttachedProposal').change(function () {
        var fileName = $(this).val();
        if (fileName != '') {
            $("#btnfileAttachedProposal").hide();
            var file = this.files[0]; // Get the selected file


            var obj = {};
            obj.documentType = "ProposalForm";
            obj.file = file;
            createUpdateConsolidation(obj);
            // $('#importButton').prop('disabled', false);
        } else {
            //$('#importButton').prop('disabled', true);
        }
    });
    $('#fileUploadPolicyDocument').change(function () {
        var fileName = $(this).val();
        if (fileName != '') {
            $("#btnfileUploadPolicyDocument").hide();
            var file = this.files[0]; // Get the selected file


            var obj = {};
            obj.documentType = "PolicyDocument";
            obj.file = file;
            createUpdateConsolidation(obj);
            // $('#importButton').prop('disabled', false);
        } else {
            //$('#importButton').prop('disabled', true);
        }
    });
    $('#fileUploadCommissionSheet').change(function () {
        var fileName = $(this).val();
        if (fileName != '') {
            $("#btnfileUploadCommissionSheet").hide();
            var file = this.files[0]; // Get the selected file


            var obj = {};
            obj.documentType = "CommissionSheet";
            obj.file = file;
            createUpdateConsolidation(obj);
            // $('#importButton').prop('disabled', false);
        } else {
            //$('#importButton').prop('disabled', true);
        }
    });
    $('#fileAttachedSigned').change(function () {
        var fileName = $(this).val();
        if (fileName != '') {
            $("#btnfileAttachedSigned").hide();
            var file = this.files[0]; // Get the selected file


            var obj = {};
            obj.documentType = "SignedOffer";
            obj.file = file;
            createUpdateConsolidation(obj);
            // $('#importButton').prop('disabled', false);
        } else {
            //$('#importButton').prop('disabled', true);
        }
    });
    $('#fileAttachedPassport').change(function () {
        var fileName = $(this).val();
        if (fileName != '') {
            $("#btnfileAttachedPassport").hide();
            var file = this.files[0]; // Get the selected file


            var obj = {};
            obj.documentType = "PassportId";
            obj.file = file;
            createUpdateConsolidation(obj);
            // $('#importButton').prop('disabled', false);
        } else {
            //$('#importButton').prop('disabled', true);
        }
    });
    $('#fileAttachedInsurance').change(function () {
        var fileName = $(this).val();
        if (fileName != '') {
            $("#btnfileAttachedInsurance").hide();
            var file = this.files[0]; // Get the selected file


            var obj = {};
            obj.documentType = "InsuranceCards";
            obj.file = file;
            createUpdateConsolidation(obj);
            // $('#importButton').prop('disabled', false);
        } else {
            //$('#importButton').prop('disabled', true);
        }
    });
    $("#btnfileAttachedSignedRemove").click(function () {
        var obj = {};
        obj.documentType = "SignedOffer";
        removeFile(obj);
    })

    $("#btnfileAttachedProposalRemove").click(function () {
        var obj = {};
        obj.documentType = "ProposalForm";
        removeFile(obj);
    })

    $("#btnfileAttachedPassportRemove").click(function () {
        var obj = {};
        obj.documentType = "PassportId";
        removeFile(obj);
    })

    $("#btnfileAttachedInsuranceRemove").click(function () {
        var obj = {};
        obj.documentType = "InsuranceCard";
        removeFile(obj);
    })
    $("#btnfileUploadPolicyDocumentRemove").click(function () {
        var obj = {};
        obj.documentType = "PolicyDocument";
        removeFile(obj);
    })
    $("#btnfileUploadCommissionSheetRemove").click(function () {
        var obj = {};
        obj.documentType = "CommissionSheet";
        removeFile(obj);
    })
    //Table tPolicies Start
    var columnConfigtPolicies = [
        { data: 'policyId', title: 'Policy_ID', },
        { data: 'policyHolder', title: 'Policy Holder', },
        { data: 'businessLineName', title: 'LOB' },
        { data: 'currency', title: 'Curr' },
        { data: 'premium', title: 'Premium' },
        { data: 'costOfPolicy', title: 'Cost of Policy' },
        { data: 'propTaxes', title: 'Prop. Taxes' },
        { data: 'fixedTaxes', title: 'Fixed Taxes' },
        { data: 'adminFees', title: 'Admin Fees' },
        { data: 'vat', title: 'VAT' },
        { data: 'policyTotal', title: 'Total' }
    ];
    var columnDefstPolicies = columnConfigtPolicies.map(function (column, index) {
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
    var tPolicies = $('#tPolicies').DataTable({
        data: policyList,
        responsive: true,
        autoWidth: true,
        columns: [
            { data: 'policyId', title: 'Policy #', },
            { data: 'policyHolder', title: 'Policy Holder', },
            { data: 'businessLineName', title: 'LOB' },
            { data: 'currency', title: 'Curr' },
            { data: 'premium', title: 'Premium' },
            { data: 'costOfPolicy', title: 'Cost of Policy' },
            { data: 'propTaxes', title: 'Prop. Taxes' },
            { data: 'fixedTaxes', title: 'Fixed Taxes' },
            { data: 'adminFees', title: 'Admin Fees' },
            { data: 'vat', title: 'VAT' },
            { data: 'policyTotal', title: 'Total' }
        ],
        columnDefs: columnDefstPolicies,
    });
    var fileSignedOffer, fileProposalForm, filePassportId, fileInsuranceCard, filePolicyDocument, fileCommissionSheet;

    $('#tPolicies tbody').on('click', 'tr', function () {
        // Remove the 'selected' class from all rows
        $('#tPolicies tbody tr').removeClass('consolidationselectedrow');
        // Add the 'selected' class to the clicked row
        $(this).addClass('consolidationselectedrow');
     //   $(this).addClass('consolidationselectedrow');
        $('input[type="text"], input[type="file"],select').prop('disabled', false);

        // Get the selected row data
        policySelectedData = tPolicies.row(this).data();
        //draw data
        $("#MasterId").val(salesTransactionBL301401.masterId);
        $("#ClientId").val(salesTransactionBL301401.clientId);
        $("#MasterClientRecID").val(salesTransactionBL301401.recId);
        $("#txtInssuranceCompany").val(policySelectedData.insurerProduct);
        $("#ddlIsBilling").val(policySelectedData.billingToSamePolicyHolder == true ? "Yes" : "No");
        $("#ddlProrata").val(policySelectedData.proRataAccept == true ? "Yes" : "No");
        $("#checkSkipUpload").val();
        $("#txtPolicyNumber").val(policySelectedData.policyNumber);
        $("#txtEffectiveDate").val(policySelectedData.policyEffectiveDate.split('T')[0]);
        $("#txtEmissionDate").val(policySelectedData.policyIssuedDate.split('T')[0]);
        $("#txtExpiryDate").val(policySelectedData.policyExpiryDate.split('T')[0]);
        $("#txtPolicyHolder").val(policySelectedData.policyHolder);
        //uploaded file

        clientMasterDropdownChanges();

        fileSignedOffer = policyRelatedDoc.find(x => x.documentType == "SignedOffer");
        fileProposalForm = policyRelatedDoc.find(x => x.documentType == "ProposalForm");
        filePassportId = policyRelatedDoc.find(x => x.documentType == "PassportId");
        fileInsuranceCard = policyRelatedDoc.find(x => x.documentType == "InsuranceCard");
        filePolicyDocument = policyRelatedDoc.find(x => x.documentType == "PolicyDocument");
        fileCommissionSheet = policyRelatedDoc.find(x => x.documentType == "CommissionSheet");
        // Add an event listener for the download button


        if (fileProposalForm && fileProposalForm.attachDocBinary != null) {
            if (fileProposalForm.isActive == true) {

                var filenametext = fileProposalForm.attachDocName + "." + fileProposalForm.attachDocExt

                $("#btnfileAttachedProposal").show();
                $("#btnfileAttachedProposalRemove").show();
                $("#btnfileAttachedProposal").html(filenametext + '<i class="m-1 fas  fa-download"></i>');
                $("#btnfileAttachedProposal").click(function () {
                    downloadBlobFile(fileProposalForm);
                });

            }

        }
        if (filePassportId && filePassportId.attachDocBinary != null) {
            if (filePassportId.isActive == true) {
                var filenametext = filePassportId.attachDocName + "." + filePassportId.attachDocExt
                //   $("#fileAttachedPassport").val(filename);
                $("#btnfileAttachedPassport").show();
                $("#btnfileAttachedPassportRemove").show();
                $("#btnfileAttachedPassport").html(filenametext + '<i class="m-1 fas  fa-download"></i>');
                $("#btnfileAttachedPassport").click(function () {
                    downloadBlobFile(filePassportId);
                });
            }
        }
        if (fileInsuranceCard&& fileInsuranceCard.attachDocBinary != null) {
            if (fileInsuranceCard.isActive == true) {
                var filenametext = fileInsuranceCard.attachDocName + "." + fileInsuranceCard.attachDocExt
                //   $("#fileAttachedInsurance").val(filename);
                $("#btnfileAttachedInsurance").show();
                $("#btnfileAttachedInsuranceRemove").show();
                $("#btnfileAttachedInsurance").html(filenametext + '<i class="m-1 fas  fa-download"></i>');
                $("#btnfileAttachedInsurance").click(function () {
                    downloadBlobFile(fileInsuranceCard);
                });
            }
        }
        if (fileSignedOffer && fileSignedOffer.attachDocBinary != null) {

            if (fileSignedOffer.isActive == true) {
                var filenametext = fileSignedOffer.attachDocName + "." + fileSignedOffer.attachDocExt
                // $("#fileAttachedSigned").val(filename);
                $("#btnfileAttachedSigned").show();
                $("#btnfileAttachedSignedRemove").show();
                $("#btnfileAttachedSigned").html(filenametext + '<i class="m-1 fas  fa-download"></i>');
                $("#btnfileAttachedSigned").click(function () {
                    downloadBlobFile(fileSignedOffer);
                });
            }
        }
        if (filePolicyDocument && filePolicyDocument.attachDocBinary != null) {
            if (filePolicyDocument.isActive == true) {
                var filenametext = filePolicyDocument.attachDocName + "." + filePolicyDocument.attachDocExt
                //   $("#fileAttachedPassport").val(filename);
                $("#btnfileUploadPolicyDocument").show();
                $("#btnfileUploadPolicyDocumentRemove").show();
                $("#btnfileUploadPolicyDocument").html(filenametext + '<i class="m-1 fas  fa-download"></i>');
                $("#btnfileUploadPolicyDocument").click(function () {
                    downloadBlobFile(filePolicyDocument);
                });
            }
        }
        if (fileCommissionSheet && fileCommissionSheet.attachDocBinary != null) {
            if (fileCommissionSheet.isActive == true) {
                var filenametext = fileCommissionSheet.attachDocName + "." + fileCommissionSheet.attachDocExt
                //   $("#fileAttachedPassport").val(filename);
                $("#btnfileUploadCommissionSheet").show();
                $("#btnfileUploadCommissionSheetRemove").show();
                $("#btnfileUploadCommissionSheet").html(filenametext + '<i class="m-1 fas  fa-download"></i>');
                $("#btnfileUploadCommissionSheet").click(function () {
                    downloadBlobFile(fileCommissionSheet);
                });
            }
        }
        //Table tPrice Start
        var columnConfigtPrice = [
            { data: 'paymentNumberStr', title: 'Payment No.', },
            { data: 'paymentDate', title: 'Payment Date', },
            { data: 'paymentAmount', title: 'Amount' },
            { data: 'paid', title: 'Paid' },
            { data: 'remainingAmount', title: 'Remaining' },
        ];
        var columnDefstPrice = columnConfigtPrice.map(function (column, index) {
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
        var tPrice = $('#tPrice').DataTable({
            destroy: true,
            data: paymentList,//paymentList.filter(x => x.policyId == policySelectedData.policyId)
            responsive: true,
            autoWidth: true,
            columns: [
                { data: 'paymentNumberStr', title: 'Payment No.', },
                {
                    data: 'paymentDate', title: 'Payment Date',
                    render: function (data, type, row) {
                        return data.split("T")[0];
                    }
                },
                {
                    data: 'paymentAmount', title: 'Amount', render: function (data, type, row) {
                        if (type === 'display' || type === 'filter') {
                            return parseFloat(data).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                        }
                        return data;
                    }
                },
                {
                    data: 'paid', title: 'Paid', render: function (data, type, row) {
                        var html = "";
                        if (data) {
                            html = "<input type='checkbox' value='checked' disabled/>";
                        } else {
                            html = "<input type='checkbox' value='unchecked' disabled/>";
                        }
                        return html;
                    }
                },
                {
                    data: 'remainingAmount', title: 'Remaining', render: function (data, type, row) {
                        if (type === 'display' || type === 'filter') {
                            return parseFloat(data).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                        }
                        return data;
                    }
                },
            ],
            columnDefs: columnDefstPrice,
        });
        tPrice.destroy();
        var tPrice = $('#tPrice').DataTable({
            destroy: true,
            data: paymentList,
            responsive: true,
            autoWidth: true,
            columns: [
                { data: 'paymentNumberStr', title: 'Payment No.', },
                {
                    data: 'paymentDate', title: 'Payment Date',
                    render: function (data, type, row) {
                        return data.split("T")[0];
                    }
                },
                {
                    data: 'paymentAmount', title: 'Amount', render: function (data, type, row) {
                        if (type === 'display' || type === 'filter') {
                            return parseFloat(data).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                        }
                        return data;
                    }
                },
                {
                    data: 'paid', title: 'Paid', render: function (data, type, row) {
                        var html = "";
                        if (data) {
                            html = "<input type='checkbox' value='checked' disabled/>";
                        } else {
                            html = "<input type='checkbox' value='unchecked' disabled/>";
                        }
                        return html;
                    }
                },
                {
                    data: 'remainingAmount', title: 'Remaining', render: function (data, type, row) {
                        if (type === 'display' || type === 'filter') {
                            return parseFloat(data).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                        }
                        return data;
                    }
                },
            ],
            columnDefs: columnDefstPrice,
        });
        policyItems = [
            { item: 'Gross Premium (GP)', percent: '', amount: policySelectedData.grossPremiumGP, isEdit: false, isNetCalculated: true, elemenetAmount: 'GrossPremiumGP' },
            { item: 'Commission % from (GP)', percent: policySelectedData.commisionFromGPPer, amount: policySelectedData.commisionFromGPAmount, isEdit: true, isNetCalculated: true, elemenetPer: 'CommisionFromGPPer', elemenetAmount: 'CommisionFromGPAmount' },
            { item: 'VAT on Commission (Paid by Clover)', percent: policySelectedData.vatOnCommisionPer, amount: policySelectedData.vatOnCommisionAmount, isEdit: true, isNetCalculated: true, elemenetPer: 'VATOnCommisionPer', elemenetAmount: 'VATOnCommisionAmount' },
            { item: 'BuiltIn_Fixed Taxes', percent: '', amount: policySelectedData.builtInFixedTaxesAmount, isEdit: false, isNetCalculated: false, elemenetPer: 'BuiltInPropTaxesPer', elemenetAmount: 'BuiltInFixedTaxesAmount' },
            { item: 'BuiltIn_Prop. Taxes', percent: policySelectedData.builtInPropTaxesPer, amount: policySelectedData.builtInPropTaxesAmount, isEdit: true, isNetCalculated: true, elemenetPer: 'BuiltInPropTaxesPer', elemenetAmount: 'BuiltInPropTaxesAmount' },
            { item: 'BuiltIn_Cost of Policy', percent: '', amount: policySelectedData.builtInCostOfPolicyAmount, isEdit: false, isNetCalculated: true, elemenetPer: '', elemenetAmount: 'BuiltInCostOfPolicyAmount' },
            { item: 'Insurer Loading ( % from (GP))', percent: policySelectedData.insurerLoadingPer, amount: policySelectedData.insurerLoadingAmount, isEdit: true, isNetCalculated: true, elemenetPer: 'InsurerLoadingPer', elemenetAmount: 'InsurerLoadingAmount' },
            { item: 'Net Premium', percent: '', amount: policySelectedData.netPremiumAmount, isEdit: false, isNetCalculated: false, elemenetAmount: 'NetPremiumAmount' },
        ];
        // Call the function to generate table rows
       // if (countClick == 0) {
            generateTableRows();
            //countClick++;
        //}
    });

    //Table tInsured Start
    var columnConfigtInsured = [
        { data: 'relationCode', title: 'Relation', },
        { data: 'firstName', title: 'First Name', },
        { data: 'middleName', title: 'Father/Middle Name' },
        { data: 'lastName', title: 'Last Name' },
        { data: 'genderCode', title: 'Gender' },
        { data: 'dob', title: 'DD/MM/YYYY' },
        { data: 'nationalityCode', title: 'Nationality' },
        { data: 'maritalStatusCode', title: 'Marital Status' },
        //{ data: 'mobileNumber', title: 'Mobile No' },
       // { data: 'email', title: 'E-mail' },
    ];
    var columnDefstInsured = columnConfigtInsured.map(function (column, index) {
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
    var tInsured = $('#tInsured').DataTable({
        data: salesTransactionBL301401.aF1BL301401.sort(customSort),
        responsive: true,
        autoWidth: true,
        ordering: false,
        columns: [
            {
                data: 'relationCode', title: 'Relation',
                render: function (data, type, row) {
                    return relationList.find(x => x.code.toLowerCase() == data.toLowerCase()).description;
                }
            },
            { data: 'firstName', title: 'First Name', },
            { data: 'middleName', title: 'Father/Middle Name' },
            { data: 'lastName', title: 'Last Name' },
            {
                data: 'genderCode', title: 'Gender',
                render: function (data, type, row) {
                    return genderList.find(x => x.code.toLowerCase() == data.toLowerCase()).description;
                }
            },
            {
                data: 'dob', title: 'DD/MM/YYYY',
                render: function (data, type, row) {
                    return data.split("T")[0];
                }
            },
            {
                data: 'nationalityCode', title: 'Nationality',
                render: function (data, type, row) {
                    return regionList.find(x => x.code.toLowerCase() == data.toLowerCase()).description;
                }
            },
            {
                data: 'maritalStatusCode', title: 'Marital Status',
                render: function (data, type, row) {
                    return maritalStatusList.find(x => x.code.toLowerCase() == data.toLowerCase()).description;
                }
            },
           // { data: 'mobileNumber', title: 'Mobile No' },
           // { data: 'email', title: 'E-mail' },
            //{
            //    data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
            //        var html = '<a class="edit-btn"><i class="fas fa-edit"></i></a> ';
            //        return html;
            //    }
            //},
        ],
        columnDefs: columnDefstInsured,
    });
   

    // Add click event handler for the edit button
    $('#tInsured tbody').on('click', '.edit-btn', function () {
        // Get the clicked row
        inssudedModelSelectedData = tInsured.row($(this).parents('tr')).data();
        var tr = $(this).parents('tr');
        currentRowSelectedInsured = tInsured.row(tr);
        $('#modalAddOrEditInsured').modal('show');
        // Log the details to the console (you can do anything with the data)
        console.log('Row Data:', inssudedModelSelectedData);
        $("#txtFirstName").val(inssudedModelSelectedData.firstName);
        $("#txtMiddelName").val(inssudedModelSelectedData.middleName);
        $("#txtLastName").val(inssudedModelSelectedData.lastName);
        $("#txtMobile").val(inssudedModelSelectedData.mobileNumber);
        $("#txtEmail").val(inssudedModelSelectedData.email);
        // You can now use rowData to populate a form, display details, etc.
    });
    $("#btnCloseModalAddOrEditInsured").click(function () {
        $('#modalAddOrEditInsured').modal('hide');
        $("#txtFirstName").val("");
        $("#txtMiddelName").val("");
        $("#txtLastName").val("");
        $("#txtMobile").val("");
        $("#txtEmail").val("");
    })
    $("#btnSaveInsured").click(function () {
        SubmitAf8(false);
    })
    function validateForm() {
        var fileInput = document.getElementById('fileAttachedSigned');
        var checkbox = document.getElementById('checkSkipUpload');

        if (!fileInput.files.length && !checkbox.checked) {
            alert("Please either attach a file or check the 'Skip Upload' checkbox.");
        } else {
            // Perform other actions or submit the form
            document.getElementById('myForm').submit();
        }
    }

    function createUpdateConsolidation(model) {
        var modelfile = policyRelatedDoc.find(x => x.policyId == policySelectedData.policyId && x.documentType == model.documentType)
        if (modelfile == null) {
            var formData = new FormData();
            var obj = {};
            obj.SalesTransactionId = $("#SalestransactionID").val();
            obj.TicketId = policySelectedData.ticketId;
            obj.ParentPolicyId = policySelectedData.parentPolicyId;
            obj.PolicyId = policySelectedData.policyId
            obj.BusinessLineCode = $("#BusinessLineCode").val();
            obj.DocumentType = model.documentType;

            formData.append('uploadfile', model.file);
            formData.append('data', JSON.stringify(obj));
            $.ajax({
                type: 'POST',
                url: '/Consolidation/CreateConsolidationDocument301401',
                data: formData,
                processData: false,
                contentType: false,
                beforeSend: function (xhr) {
                    showLoading();
                },
                success: function (data, status, xhr) {
                    hideLoading();
                    afterAjaxCall(data, model);
                },
                error: function (xhr, status, error) {
                    toastr.error(error, "Error");
                    hideLoading();
                }
            });
        } else {
            var formData = new FormData();
            var obj = {};

            obj.RecId = modelfile.recId;
            formData.append('uploadfile', model.file);
            formData.append('data', JSON.stringify(obj));
            $.ajax({
                type: 'POST',
                url: '/Consolidation/UpdateConsolidationDocument301401',
                data: formData,
                processData: false,
                contentType: false,
                beforeSend: function (xhr) {
                    showLoading();
                },
                success: function (data, status, xhr) {
                    hideLoading();
                    afterAjaxCall(data, model);
                },
                error: function (xhr, status, error) {
                    toastr.error(error, "Error");
                    hideLoading();
                }
            });
        }

    }





    //master client w lista and datatable
    $('#MasterId').on('blur', function () {
        SubmitAf8(true);
    })
    $('#ClientId').on('blur', function () {
        SubmitAf8(true);
    })
    function SubmitAf8(isClientMaster) {
        if (isClientMaster) {
            var obj = {};
            var formBody = new FormData();
            obj.RecId = $("#MasterClientRecID").val();
            obj.ClientId = $("#ClientId").val();
            obj.MasterId = $("#MasterId").val();
            obj.PolicyId = policySelectedData.policyId;
            formBody.append("data", JSON.stringify(obj));
            $.ajax({
                url: "/Business/EditAF1_30Consolidation",
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

                    } else {
                        toastr.error(data.webResponseCommon.returnMessage, "Didin't saved");

                    }

                },
                error: function (xhr, status, error) {
                    console.log("Error: " + error);
                }

            });
        } else {

            if ($("#form").valid()) {
                var editModel = inssudedModelSelectedData;
                editModel.firstName = $("#txtFirstName").val();
                editModel.middleName = $("#txtMiddelName").val();
                editModel.lastName = $("#txtLastName").val();
                editModel.mobileNumber = $("#txtMobile").val();
                editModel.email = $("#txtEmail").val();


                // Redraw the row to reflect the updated data
                currentRowSelectedInsured.data(editModel).draw();
                var obj = {};
                var formBody = new FormData();
                var af8Obj = {};
                af8Obj.ResidenceCode = salesTransactionBL301401.aF1BL301401.residenceCode;
                af8Obj.NetworkLevelCode = salesTransactionBL301401.aF1BL301401.networkLevelCode;
                af8Obj.ClassOfCoveragCode = salesTransactionBL301401.aF1BL301401.classOfCoveragCode;
                af8Obj.Ambulatory = salesTransactionBL301401.aF1BL301401.ambulatory;
                af8Obj.PrescriptionMedecine = salesTransactionBL301401.aF1BL301401.prescriptionMedecine;
                af8Obj.DoctorVisit = salesTransactionBL301401.aF1BL301401.doctorVisit;
                af8Obj.NSSF = salesTransactionBL301401.aF1BL301401.nssf;
                af8Obj.AF1BL301401List = getValues();
                obj.AF1BL301401 = af8Obj;
                obj.RecId = $("#SalestransactionID").val();
                obj.BusinessLineCode = $("#BusinessLineCode").val();
                obj.ClientId = $("#ClientId").val();
                obj.MasterId = $("#MasterId").val();
                formBody.append("data", JSON.stringify(obj));
                $.ajax({
                    url: "/Business/EditAF1_8",
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
                            $('#modalAddOrEditInsured').modal('hide');
                            $("#txtFirstName").val("");
                            $("#txtMiddelName").val("");
                            $("#txtLastName").val("");
                            $("#txtMobile").val("");
                            $("#txtEmail").val("");
                        } else {
                            // Redraw the row to reflect the updated data
                            currentRowSelectedInsured.data(inssudedModelSelectedData).draw();
                            toastr.error(data.webResponseCommon.returnMessage, "Didin't saved");
                            $('#modalAddOrEditInsured').modal('hide');
                            $("#txtFirstName").val("");
                            $("#txtMiddelName").val("");
                            $("#txtLastName").val("");
                            $("#txtMobile").val("");
                            $("#txtEmail").val("");
                        }

                    },
                    error: function (xhr, status, error) {
                        console.log("Error: " + error);
                    }

                });


            } else {
                toastr.warning("Fill required fields", "Required fields");
            }
        }

    }


    function downloadBlobFile(model) {

        // Remove the data:image/png;base64, prefix if present
        const base64WithoutPrefix = model.attachDocBinary.replace(/^data:[^;]+;base64,/, '');

        // Convert the base64 string to a Uint8Array
        const byteCharacters = atob(base64WithoutPrefix);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);

        // Create a Blob from the Uint8Array
        const blob = new Blob([byteArray], { type: mimeTypes[model.attachDocExt.toLowerCase()] || 'application/octet-stream' });

        // Create a download link
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = model.attachDocName + "." + model.attachDocExt || 'download';

        // Trigger the download
        document.body.appendChild(a);
        a.click();

        // Clean up
        window.URL.revokeObjectURL(url);
    }
    //// Select the first row after the table has been drawn
    //tPolicies.on('draw.dt', function () {
    //    tPolicies.row(':eq(0)').select(); // Select the first row (index 0)
    //});

    //// Trigger a draw to populate the table initially (you may not need this depending on your setup)
    //tPolicies.draw();
});
function getValues() {
    var table = document.getElementById("tInsured");
    var rows = table.getElementsByTagName("tbody")[0].getElementsByTagName("tr");

    var data = [];
    for (var i = 0; i < rows.length; i++) {
        var cells = rows[i].getElementsByTagName("td");

        var rowValues = {
            relationCode: cells[0].dataset.relationcode,
            firstName: cells[1].textContent,
            middleName: cells[2].textContent,
            lastName: cells[3].textContent,
            genderCode: cells[4].dataset.gendercode,
            dob: cells[5].dataset.dob,
            nationalityCode: cells[6].dataset.nationalitycode,
            maritalStatusCode: cells[7].dataset.maritalstatuscode,
            mobileNumber: cells[8].textContent,
            email: cells[9].textContent
        };

        data.push(rowValues);
    }
    //console.log(data);
    return data;

}
// Custom sorting function
function customSort(a, b) {
    const order = { "p": 1, "s": 2, "c": 3 };
    return order[a.relationCode.toLowerCase()] - order[b.relationCode.toLowerCase()];
}


// Sample JavaScript list
//const policyItems = [
//    { item: 'Gross Premium (GP)', percent: '', amount: '8,484.70', isEdit: false },
//    { item: 'Commission % from (GP)', percent: '30', amount: '2,545.41', isEdit: true },
//    { item: 'VAT on Commission (Paid by Clover)', percent: '5', amount: '127.27', isEdit: true },
//    { item: 'BuiltIn_Fixed Taxes', percent: '', amount: '1.35', isEdit: false },
//    { item: 'BuiltIn_Prop. Taxes', percent: '11', amount: '840.83', isEdit: true },
//    { item: 'BuiltIn_Cost of Policy', percent: '', amount: '15.00', isEdit: false },
//    { item: 'Insurer Loading ( % from (GP))', percent: '10', amount: '848.47', isEdit: true },
//    { item: 'Net Premium', percent: '', amount: '4,233.64', isEdit: false },
//];


// Function to generate table rows
function generateTableRows() {
    const tableBody = document.getElementById('policyTableBody');
    tableBody.innerHTML = "";
    var count = 0;
    policyItems.forEach(item => {
        const row = document.createElement('tr');

        if (count == 0) {
            row.innerHTML = `
        <td >${item.item}</td>
        <td  contenteditable="false" ></td>
        <td id="grossPremium">${item.amount}</td>
        <td></td>
        <td></td>
        <td></td>
      `;
        } else if (count == 7) {
            row.innerHTML = `
        <td >${item.item}</td>
        <td contenteditable="false" > </td>
        <td id="netPremium">${item.amount}</td>
        <td></td>
        <td></td>
        <td></td>
      `;
        } else {
            var html = `<td>${item.item}</td>`;
            if (item.isEdit) {
                html += ` <td id="${item.elemenetPer}"  contenteditable="true" onfocus="showPercentInfo(this)" onblur="hidePercentInfo(this)" data-percent="${item.percent}">${item.percent}</td>`;
            } else {
                html += `<td id="${item.elemenetPer}" contenteditable="false" data-percent="${item.percent}">${item.percent}</td>`;
            }
            if (item.isNetCalculated) {
                html += `<td  id="${item.elemenetAmount}" class="rowAmount">${item.amount}</td>`;
            } else {
                html += `<td id="${item.elemenetAmount}">${item.amount}</td>`;
            }
            html += '<td></td>';
            html += '<td></td>';
            html += ' <td></td>';
            row.innerHTML = html;
        }
        count++;
        tableBody.appendChild(row);
    });
}

// Function to calculate Net Premium based on Gross Premium and Percentage
function updateNetPremium(element) {

    //const grossPremium = parseFloat($('#grossPremium').text().replace(',', '')) || 0;
    //var currentSelectedPercentage = parseFloat(parseInt(element.textContent));
    //var netAmount = (grossPremium * (currentSelectedPercentage / 100));
    //element.nextElementSibling.innerText = netAmount.toFixed(2);
    //var netPremium = 0;
    //for (var i = 0; i < $('.rowAmount').length; i++) {
    //    netPremium = netPremium + parseFloat($('.rowAmount')[i].textContent.replace(',', ''));
    //}
    //console.log(netAmount);
    //console.log(netPremium);
    //document.getElementById('netPremium').innerText = (grossPremium - netPremium).toFixed(2);

    const grossPremium = parseFloat($('#grossPremium').text()) || 0;
    var currentSelectedPercentage = parseFloat(element.textContent);
    var netAmount = (grossPremium * (currentSelectedPercentage / 100));
    element.nextElementSibling.innerText = netAmount.toFixed(2);
    var netPremium = 0;
    for (var i = 0; i < $('.rowAmount').length; i++) {
        netPremium = netPremium + parseFloat($('.rowAmount')[i].textContent);
    }
    console.log(netAmount);
    console.log(netPremium);
    document.getElementById('netPremium').innerText = (grossPremium - netPremium).toFixed(2);
}

// Function to show the percentage info
function showPercentInfo(element) {
    document.getElementById('percentInfo').innerText = `(Editing)`;
}

// Function to hide the percentage info
function hidePercentInfo(element) {
    document.getElementById('percentInfo').innerText = `(Hover to edit)`;
    updateNetPremium(element);
}
function Submit() {

    var formBody = new FormData();
    var obj = {};
    obj.SalesTransactionId = $("#SalestransactionID").val();
    obj.TicketId = policySelectedData.ticketId;
    obj.ParentPolicyId = policySelectedData.parentPolicyId;
    obj.PolicyId = policySelectedData.policyId;
    obj.BusinessLineCode = $("#BusinessLineCode").val();
    obj.GrossPremiumGP = parseFloat($("#grossPremium").text()) || 0;
    obj.CommisionFromGPPer = parseFloat($("#CommisionFromGPPer").text()) || 0;
    obj.CommisionFromGPAmount = parseFloat($("#CommisionFromGPAmount").text()) || 0;
    obj.VATOnCommisionPer = parseFloat($("#VATOnCommisionPer").text()) || 0;
    obj.VATOnCommisionAmount = parseFloat($("#VATOnCommisionAmount").text()) || 0;
    obj.BuiltInFixedTaxesAmount = parseFloat($("#BuiltInFixedTaxesAmount").text()) || 0;
    obj.BuiltInPropTaxesPer = parseFloat($("#BuiltInPropTaxesPer").text()) || 0;
    obj.BuiltInPropTaxesAmount = parseFloat($("#BuiltInPropTaxesAmount").text()) || 0;
    obj.BuiltInCostOfPolicyAmount = parseFloat($("#BuiltInCostOfPolicyAmount").text()) || 0;
    obj.InsurerLoadingPer = parseFloat($("#InsurerLoadingPer").text()) || 0;
    obj.InsurerLoadingAmount = parseFloat($("#InsurerLoadingAmount").text()) || 0;
    obj.NetPremiumAmount = parseFloat($("#netPremium").text()) || 0;
    obj.PolicyNumber = $("#txtPolicyNumber").val();
    obj.PolicyEffectiveDate = $("#txtEffectiveDate").val();
    obj.PolicyExpiryDate = $("#txtExpiryDate").val();
    obj.PolicyIssuedDate = $("#txtEmissionDate").val();
    obj.PolicyHolder = $("#txtPolicyHolder").val();
    formBody.append("data", JSON.stringify(obj));
    $.ajax({
        url: "/Consolidation/UpdateConsolidationForm301401",
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

            } else {
                // Redraw the row to reflect the updated data
             //   currentRowSelectedInsured.data(inssudedModelSelectedData).draw();
                toastr.error(data.webResponseCommon.returnMessage, "Didin't saved");

            }

        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }

    });
}
function afterAjaxCall(data, model) {
    if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
        toastr.success("", "Saved");
        if (model.documentType == "SignedOffer") {
            $("#btnfileAttachedSigned").show();
            $("#btnfileAttachedSignedRemove").show();
            $("#btnfileAttachedSigned").html(model.file.name + '<i class="m-1 fas  fa-download"></i>');
            $("#btnfileAttachedSigned").click(function () {
                // Create a Blob from the uploaded file
                downloadBlobFRomUpload(model);
            });
        } else if (model.documentType == "ProposalForm") {
            $("#btnfileAttachedProposal").show();
            $("#btnfileAttachedProposalRemove").show();
            $("#btnfileAttachedProposal").html(model.file.name + '<i class="m-1 fas  fa-download"></i>');
            $("#btnfileAttachedProposal").click(function () {
                // Create a Blob from the uploaded file
                downloadBlobFRomUpload(model);
            });
        } else if (model.documentType == "PassportId") {
            $("#btnfileAttachedPassport").show();
            $("#btnfileAttachedPassportRemove").show();
            $("#btnfileAttachedPassport").html(model.file.name + '<i class="m-1 fas  fa-download"></i>');
            $("#btnfileAttachedPassport").click(function () {
                // Create a Blob from the uploaded file
                downloadBlobFRomUpload(model);
            });
        } else if (model.documentType == "InsuranceCard") {
            $("#btnfileAttachedInsurance").show();
            $("#btnfileAttachedInsurance").html(model.file.name + '<i class="m-1 fas  fa-download"></i>');
            $("#btnfileAttachedInsurance").click(function () {
                // Create a Blob from the uploaded file
                downloadBlobFRomUpload(model);
            });
        } else if (model.documentType == "PolicyDocument") {
            $("#btnfileUploadPolicyDocument").show();
            $("#btnfileUploadPolicyDocumentRemove").show();
            $("#btnfileUploadPolicyDocument").html(model.file.name + '<i class="m-1 fas  fa-download"></i>');
            $("#btnfileUploadPolicyDocument").click(function () {
                // Create a Blob from the uploaded file
                downloadBlobFRomUpload(model);
            });
        } else if (model.documentType == "CommissionSheet") {
            $("#btnfileUploadCommissionSheet").show();
            $("#btnfileUploadCommissionSheetRemove").show();
            $("#btnfileUploadCommissionSheet").html(model.file.name + '<i class="m-1 fas  fa-download"></i>');
            $("#btnfileUploadCommissionSheet").click(function () {
                // Create a Blob from the uploaded file
                downloadBlobFRomUpload(model);
            });
        }

    } else {

        toastr.error(data.webResponseCommon.returnMessage, "Didin't saved");
        hideDownloadAndREmoveBtn(model);
    }
}
function hideDownloadAndREmoveBtn(model) {
    if (model.documentType == "SignedOffer") {
        $("#btnfileAttachedSigned").hide();
        $("#btnfileAttachedSignedRemove").hide();
    } else if (model.documentType == "ProposalForm") {
        $("#btnfileAttachedProposal").hide();
        $("#btnfileAttachedProposalRemove").hide();
    } else if (model.documentType == "PassportId") {
        $("#btnfileAttachedPassport").hide();
        $("#btnfileAttachedPassportRemove").hide();
    } else if (model.documentType == "InsuranceCard") {
        $("#btnfileAttachedInsurance").hide();
        $("#btnfileAttachedInsuranceRemove").hide();
    } else if (model.documentType == "PolicyDocument") {
        $("#btnfileUploadPolicyDocument").hide();
        $("#btnfileUploadPolicyDocumentRemove").hide();
    } else if (model.documentType == "CommissionSheet") {
        $("#btnfileUploadCommissionSheet").hide();
        $("#btnfileUploadCommissionSheetRemove").hide();
    }
}
function downloadBlobFRomUpload(model) {
    const blob = new Blob([model.file], { type: model.file.type });

    // Create a temporary link element and trigger the download
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = model.file.name;
    link.click();
}
function removeFile(model) {

    var modelfile = policyRelatedDoc.find(x => x.policyId == policySelectedData.policyId && x.documentType == model.documentType)
    if (modelfile != null) {
        var formData = new FormData();
        var obj = {};
        obj.SalesTransactionId = $("#SalestransactionID").val();
        obj.TicketId = policySelectedData.ticketId;
        obj.ParentPolicyId = policySelectedData.parentPolicyId;
        obj.PolicyId = policySelectedData.policyId
        obj.BusinessLineCode = $("#BusinessLineCode").val();
        obj.DocumentType = model.documentType;
        obj.RecId = modelfile.recId;
        formData.append('uploadfile', null);
        formData.append('data', JSON.stringify(obj));
        $.ajax({
            type: 'POST',
            url: '/Consolidation/UpdateConsolidationDocument080501',
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function (xhr) {
                showLoading();
            },
            success: function (data, status, xhr) {
                hideLoading();
                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                    hideDownloadAndREmoveBtn(model);
                }
            },
            error: function (xhr, status, error) {
                toastr.error(error, "Error");
                $("#btnfileAttachedProposal").hide();
                hideLoading();
            }
        });
    }


}