$(".preloader").fadeOut();
// ==============================================================
// Login and Recover Password
// ==============================================================
$("#to-recover").on("click", function () {
    $("#loginform").slideUp();
    $("#recoverform").fadeIn();
});
// Attach a keydown event handler to the document
$(document).on('keypress', function (event) {
    if (event.key === 'Enter') {
        $('#btnLogin').click();
    }
});
$('#loginform').submit(function (e) {
    console.log("submit login");
    e.preventDefault(); // prevent the form from submitting normally
    $('#btnLogin').attr("disabled", true);
    var username = $('#UserName').val();
    var password = $('#Password').val();

    // make a POST request to the server to authenticate the user and obtain a JWT
    $.ajax({
        type: 'POST',
        url: '/Login/Authenticate',
        data: {
            username: username,
            password: password
        }, beforeSend: function (xhr) {
           
        },
        success: function (data) {
            $('#btnLogin').attr("disabled", false);
            localStorage.setItem('jwt', data.token);
            console.log("success login");
            window.location.href = '../Home/Index';
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
            hideLoading();
            $('#btnLogin').attr("disabled", false);
        }
    });
});