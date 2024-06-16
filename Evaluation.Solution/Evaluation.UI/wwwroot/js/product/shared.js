var form = $(".validation-wizard").show();
var tTechnicalSheetsCloned;
$(".validation-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Submit",
    },
    onStepChanging: function (event, currentIndex, newIndex) {
        if (newIndex === 1 || newIndex === 2 || newIndex === 0) {
            $("#btnSave").show();
        } else {
            $("#btnSave").hide();
        }
        if (newIndex === 4) {
            document.getElementById("txtClass").innerHTML = "";
            var x = document.getElementById("txtClass");
            var option = document.createElement("option");
            option.text = "--Select--";
            option.value = "";
            x.add(option);
            var addToStep4Classes = getClassOfCoverageFromStep3();
            for (var i = 0; addToStep4Classes.length > i; i++) {
                var y = document.getElementById("txtClass");
                var optiony = document.createElement("option");
                optiony.text = addToStep4Classes[i].description;
                optiony.value = addToStep4Classes[i].recId;
                y.add(optiony);
            }
        }
        if (newIndex === 5) {
           
            if (tTechnicalSheetsCloned) {
                // DataTable is already initialized, so let's destroy it
                tTechnicalSheetsCloned.destroy();
                console.log('Existing DataTable destroyed.');
            } else {
                console.log('DataTable with ID tTechnicalSheets is not yet initialized.');
            }

            tTechnicalSheetsCloned=$('#tTechnicalSheetsCloned').DataTable({
                data: $('#tTechnicalSheets').DataTable().data(),
                responsive: true,
                autoWidth: true,
                columns: [
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
                        data: 'classId', title: 'Class', render: function (data, type, row) {
                            var model = productClassOfCoverage.find(x => x.recId == data);
                            if (model != null) {
                                return model.description
                            } else {
                                return '';
                            }
                        }
                    },
                    { data: 'limitAmount', title: 'Limit Amount' },
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

                ]
            });
            var technicalSheetList = getTechnicalSheetFromStep5();
            technicalSheetList.push(null);
            // Select all dropdown elements with class "mySelect" and populate them
            $(".tsheetddl").empty();
            $(".tsheetddl").each(function () {
                var select = $(this); // Current select element
                $.each(technicalSheetList, function (index, value) {
                    select.append($("<option>").text(value).val(value));
                });
            });
            //$(".tsheetddl").each(function () {
            //    var select = $(this); // Current select element
            //    $.each(technicalSheetList, function (index, value) {
            //        select.append($("<option>").text(value).val(value));
            //    });
            //});
        }
        //if (currentIndex === 1) {
        //    if (form.valid()){
        //        Submit();
        //    }

        //}

        return true;
       // return form.valid();
    },
    onFinishing: function (event, currentIndex) {
        return (form.validate().settings.ignore = ":disabled"), form.valid();
    },
    onFinished: function (event, currentIndex) {
        //  Submit();
    },
}),
    $(".validation-wizard").validate({
        ignore: "input[type=hidden]",
        errorClass: "text-danger",
        successClass: "text-success",
        highlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },
        unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },
        errorPlacement: function (error, element) {
            error.insertAfter(element);
        },
        rules: {
            email: {
                email: !0,
            },
        },
    });

