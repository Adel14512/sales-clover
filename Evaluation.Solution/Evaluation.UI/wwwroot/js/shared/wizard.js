var form = $(".validation-wizard").show();

$(".validation-wizard").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    titleTemplate: '<span class="step">#index#</span> #title#',
    labels: {
        finish: "Submit",
    },
    onStepChanging: function (event, currentIndex, newIndex) {


        return form.valid();
    },
    onFinishing: function (event, currentIndex) {
        return (form.validate().settings.ignore = ":disabled"), form.valid();
    },
    onFinished: function (event, currentIndex) {
        Submit();
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
function fixStep2Header() {

    $('#tStep2').dataTable().fnAdjustColumnSizing();
    $("#tStep2 thead").css('border', 'transparent');
}
$(".validation-slip").steps({
    headerTag: "h6",
    bodyTag: "section",
    transitionEffect: "fade",
    enableFinishButton: false,
    titleTemplate: '<span class="step">#index#</span> #title#',
    //labels: {
    //    finish: "Submit",
    //},
    onStepChanged: function (e, currentIndex, priorIndex) {
        fixStep2Header();
      
    },
    onStepChanging: function (event, currentIndex, newIndex) {
       
        

        return true;
    },
    onFinishing: function (event, currentIndex) {
        return true;
    },
    onFinished: function (event, currentIndex) {
       
    },
}),
    $(".validation-slip").validate({
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
