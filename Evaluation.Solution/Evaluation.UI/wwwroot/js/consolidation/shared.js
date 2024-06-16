
$(document).ready(function () {
    var form = $(".validation-wizard-consolidation").show();

    $(".validation-wizard-consolidation").steps({
        headerTag: "h6",
        bodyTag: "section",
        transitionEffect: "fade",
        titleTemplate: '<span class="step">#index#</span> #title#',
        labels: {
            finish: "Submit",
        },
        onStepChanging: function (event, currentIndex, newIndex) {
            //if (currentIndex === 1) {
            //    if (form.valid()){
            //        Submit();
            //    }

            //}

            return form.valid();
        },
        onFinishing: function (event, currentIndex) {
            if ((form.validate().settings.ignore = ":disabled"), form.valid()) {

            } else {
                toastr.warning("Fill Required Fields","Required Fields");
            }
            return (form.validate().settings.ignore = ":disabled"), form.valid();
        },
        onFinished: function (event, currentIndex) {
              Submit();
        },
    }),
        $(".validation-wizard-consolidation").validate({
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

});

function clientMasterDropdownChanges() {
    var clientSelect = document.getElementById("ClientId");
    var masterSelect = document.getElementById("MasterId");

    // Add event listener to Client dropdown
    clientSelect.addEventListener("change", function () {
        var selectedClientId = parseInt(this.value);
        populateMasterDropdown(selectedClientId);
    });

    // Function to populate Master dropdown based on selected Client
    function populateMasterDropdown(selectedClientId) {
        // Clear existing options
        masterSelect.innerHTML = '';
        var masterId = clientList.find(x => x.code == selectedClientId).masterId;
        // Populate Master dropdown
        masterFilter = masterList.filter(x => x.code == masterId);
        masterFilter.forEach(function (master) {
            if (parseInt(master.code) === masterId) {
                var option = document.createElement("option");
                option.value = master.code;
                option.textContent = master.description;
                masterSelect.appendChild(option);
            }
        });
    }
}